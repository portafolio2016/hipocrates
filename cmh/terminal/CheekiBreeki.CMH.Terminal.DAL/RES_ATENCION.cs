
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
    
public partial class RES_ATENCION
{

    public int ID_RESULTADO_ATENCION { get; set; }

    public Nullable<bool> ATENCION_ABIERTA { get; set; }

    public string COMENTARIO { get; set; }

    public Nullable<int> ID_ATENCION_AGEN { get; set; }

    public Nullable<int> ID_ORDEN_ANALISIS { get; set; }

    public Nullable<int> ID_PERSONAL_MEDICO { get; set; }

    public string ARCHIVO_B64 { get; set; }

    public string EXT_ARCHIVO { get; set; }



    public virtual ATENCION_AGEN ATENCION_AGEN { get; set; }

    public virtual ORDEN_ANALISIS ORDEN_ANALISIS { get; set; }

}

}
