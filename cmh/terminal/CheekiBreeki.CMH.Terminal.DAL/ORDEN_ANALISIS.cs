
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
    
public partial class ORDEN_ANALISIS
{

    public ORDEN_ANALISIS()
    {

        this.RES_ATENCION = new HashSet<RES_ATENCION>();

    }


    public int ID_ORDEN_ANALISIS { get; set; }

    public Nullable<System.DateTime> FECHOR_EMISION { get; set; }

    public Nullable<System.DateTime> FECHOR_RECEP { get; set; }



    public virtual ICollection<RES_ATENCION> RES_ATENCION { get; set; }

}

}
