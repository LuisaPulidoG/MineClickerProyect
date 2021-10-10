using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ServiceModel;
using System.Security.Principal;
using System.Windows.Forms;

namespace ChatServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Program obj = new Program();
            if (obj.IsCurrentlyRunningAsAdmin())
                obj.RunServer();
            else
                MessageBox.Show("Did you run it as administrator?", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void RunServer()
        {
            using (ServiceHost host = new ServiceHost(typeof(Chat_WCF.ChatService)))
            {
                host.Open();
                Console.WriteLine("Servidor Activo");
                Console.WriteLine("Presione Cualquier tecla para Salir");
                Console.ReadLine();
                host.Close();
            }
        } 
        private bool IsCurrentlyRunningAsAdmin()
        {
            bool isAdmin = false;
            WindowsIdentity currentIdentity = WindowsIdentity.GetCurrent();
            if (currentIdentity != null)
            {
                WindowsPrincipal principal = new WindowsPrincipal(currentIdentity);
                isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
                principal = null;
            }
            return isAdmin;
        }
    }
}
