//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatosClicker
{
    using System;
    using System.Collections.Generic;
    
    public partial class PlayerGameBlock
    {
        public int PlayerGameId { get; set; }
        public int BlockId { get; set; }
        public int Destroyed { get; set; }
    
        public virtual Block Block { get; set; }
        public virtual PlayerGame PlayerGame { get; set; }
    }
}
