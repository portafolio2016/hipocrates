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
    
    public partial class EQUIPO_REQ
    {
        public int ID_EQUIPO_REQ { get; set; }
        public Nullable<int> CANTIDAD { get; set; }
        public Nullable<int> ID_TIPO_EQUIPO { get; set; }
        public Nullable<int> ID_PRESTACION { get; set; }
    
        public virtual PRESTACION PRESTACION { get; set; }
        public virtual TIPO_EQUIPO TIPO_EQUIPO { get; set; }
    }
}