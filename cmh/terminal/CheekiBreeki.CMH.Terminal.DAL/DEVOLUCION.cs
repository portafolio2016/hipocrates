
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace CheekiBreeki.CMH.Terminal.DAL
{

using System;
    using System.Collections.Generic;
    
public partial class DEVOLUCION
{

    public DEVOLUCION()
    {

        this.PAGO = new HashSet<PAGO>();

    }


    public int ID_DEVOLUCION { get; set; }

    public string NOM_TIPO_DEV { get; set; }



    public virtual ICollection<PAGO> PAGO { get; set; }

}

}
