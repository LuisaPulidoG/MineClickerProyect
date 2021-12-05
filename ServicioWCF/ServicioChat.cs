using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServicioWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código y en el archivo de configuración a la vez.
    [DataContract]
    public class Usuario
    {
        private string nombreUsuario;
        private string contraseniaUsuario;
        
        [DataMember]
        public string Nombre
        {
            get { return nombreUsuario; }
            set { nombreUsuario = value; }
        }
        [DataMember]
        public string Contrasenia
        {
            get { return contraseniaUsuario; }
            set { contraseniaUsuario = value; }
        }
    }
    [DataContract]
    public class Mensaje
    {
        private string usuarioRemitente;
        private string infoMensaje;
        private DateTime tiempo;

        [DataMember]
        public string UsuaruiRemitente
        {
            get { return usuarioRemitente; }
            set { usuarioRemitente = value; }
        }
        [DataMember]
        public string InfoMensaje
        {
            get { return infoMensaje; }
            set { infoMensaje = value; }
        }
        [DataMember]
        public DateTime Tiempo
        {
            get { return tiempo; }
            set { tiempo = value; }
        }
    }
    [ServiceContract(CallbackContract = typeof(IChatCallback),
                         SessionMode = SessionMode.Required)]
    public interface IChat
    {
        [OperationContract(IsInitiating = true)]
        bool Conectado(Usuario usuario);

        [OperationContract(IsOneWay = true)]
        void MandarMensaje(Mensaje mensajeUsuario);

        [OperationContract(IsOneWay = true)]
        void Toque(Mensaje mensajeUsuario, Usuario usuarioReceptor);

        [OperationContract(IsOneWay = true)]
        void EstaEscribiendo(Usuario usuario);

        [OperationContract(IsOneWay = true, IsTerminating = true)]
        void Desconectado(Usuario usuario);
    }

    public interface IChatCallback
    {
        [OperationContract(IsOneWay = true)]
        void RecargarClientes(List<Usuario> usuarios);

        [OperationContract(IsOneWay = true)]
        void RecibirMensaje(Mensaje mensajeUsuario);

        [OperationContract(IsOneWay = true)]
        void RecibirToque(Mensaje mensajeUsuario, Usuario usuarioReceptor);

        [OperationContract(IsOneWay = true)]
        void EstaEscribiendoCallBack(Usuario usuarios);

        [OperationContract(IsOneWay = true)]
        void UsuarioAccedio(Usuario usuarios);

        [OperationContract(IsOneWay = true)]
        void UsuarioSalio(Usuario usuarios);
    }
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single,
    ConcurrencyMode = ConcurrencyMode.Multiple,
    UseSynchronizationContext = false)]
    public class ServicioChat:IChat
    {
        Dictionary<Usuario, IChatCallback> clientes =
                 new Dictionary<Usuario, IChatCallback>();

        List<Usuario> listaClientes = new List<Usuario>();

        public IChatCallback CurrentCallback
        {
            get
            {
                return OperationContext.Current.
                       GetCallbackChannel<IChatCallback>();
            }
        }

        object objetoAuxilizar = new object();

        private bool SearchClientsByName(string nombre)
        {
            foreach (Usuario usuarios in clientes.Keys)
            {
                if (usuarios.Nombre == nombre)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Conectado(Usuario usuario)
        {
            if (!clientes.ContainsValue(CurrentCallback) &&
             !SearchClientsByName(usuario.Nombre))
            {
                lock (objetoAuxilizar)
                {
                    clientes.Add(usuario, CurrentCallback);
                    listaClientes.Add(usuario);

                    foreach (Usuario key in clientes.Keys)
                    {
                        IChatCallback callback = clientes[key];
                        try
                        {
                            callback.RecargarClientes(listaClientes);
                            callback.UsuarioAccedio(usuario);
                        }
                        catch
                        {
                            clientes.Remove(key);
                            return false;
                        }

                    }

                }
                return true;
            }
            return false;
        }

        public void MandarMensaje(Mensaje mensajeUsuario)
        {
            lock (objetoAuxilizar)
            {
                foreach (IChatCallback callback in clientes.Values)
                {
                    callback.RecibirMensaje(mensajeUsuario);
                }
            }
        }

        public void Toque(Mensaje mensajeUsuario, Usuario usuarioReceptor)
        {
            foreach (Usuario usuarioRemintente in clientes.Keys)
            {
                if (usuarioRemintente.Nombre == usuarioReceptor.Nombre)
                {
                    IChatCallback callback = clientes[usuarioRemintente];
                    callback.RecibirToque(mensajeUsuario, usuarioRemintente);

                    foreach (Usuario UsuarioEnvio in clientes.Keys)
                    {
                        if (UsuarioEnvio.Nombre == mensajeUsuario.UsuaruiRemitente)
                        {
                            IChatCallback senderCallback = clientes[UsuarioEnvio];
                            senderCallback.RecibirToque(mensajeUsuario, usuarioRemintente);
                            return;
                        }
                    }
                }
            }
        }

        public void EstaEscribiendo(Usuario usuario)
        {
            lock (objetoAuxilizar)
            {
                foreach (IChatCallback callback in clientes.Values)
                {
                    callback.EstaEscribiendoCallBack(usuario);
                }
            }
        }

        public void Desconectado(Usuario usuario)
        {
            foreach (Usuario UsuarioSys in clientes.Keys)
            {
                if (usuario.Nombre == UsuarioSys.Nombre)
                {
                    lock (objetoAuxilizar)
                    {
                        this.clientes.Remove(UsuarioSys);
                        this.listaClientes.Remove(UsuarioSys);
                        foreach (IChatCallback callback in clientes.Values)
                        {
                            callback.RecargarClientes(this.listaClientes);
                            callback.UsuarioSalio(usuario);
                        }
                    }
                    return;
                }
            }
        }
    }

}
