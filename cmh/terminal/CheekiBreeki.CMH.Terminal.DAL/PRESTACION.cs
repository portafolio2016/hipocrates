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
    
    public partial class PRESTACION
    {
        public PRESTACION()
        {
            this.ATENCION_AGEN = new HashSet<ATENCION_AGEN>();
            this.EQUIPO_REQ = new HashSet<EQUIPO_REQ>();
        }
    
        public int ID_PRESTACION { get; set; }
        public string NOM_PRESTACION { get; set; }
        public Nullable<int> PRECIO_PRESTACION { get; set; }
        public string CODIGO_PRESTACION { get; set; }
        public Nullable<int> ID_ESPECIALIDAD { get; set; }
        public Nullable<int> ID_TIPO_PRESTACION { get; set; }
        public bool ACTIVO { get; set; }
    
        public virtual ICollection<ATENCION_AGEN> ATENCION_AGEN { get; set; }
        public virtual ICollection<EQUIPO_REQ> EQUIPO_REQ { get; set; }
        public virtual ESPECIALIDAD ESPECIALIDAD { get; set; }
        public virtual TIPO_PRES TIPO_PRES { get; set; }
    }
}
