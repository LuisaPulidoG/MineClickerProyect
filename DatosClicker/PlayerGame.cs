
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
    
public partial class PlayerGame
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public PlayerGame()
    {

        this.PlayerGameBlock = new HashSet<PlayerGameBlock>();

    }


    public int PlayerGameId { get; set; }

    public int PlayerId { get; set; }

    public int GameId { get; set; }

    public double EarnedMoney { get; set; }



    public virtual Game Game { get; set; }

    public virtual Player Player { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<PlayerGameBlock> PlayerGameBlock { get; set; }

}

}
