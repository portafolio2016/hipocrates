//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cheekibreeki.CMH.Seguro.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class BENEFICIO
    {
        public BENEFICIO()
        {
            this.PRESTACION = new HashSet<PRESTACION>();
        }
    
        public int ID_BENEFICIO { get; set; }
        public decimal PORCENTAJE { get; set; }
        public Nullable<int> LIMITE_DINERO { get; set; }
        public Nullable<int> ID_PLAN { get; set; }
    
        public virtual PLAN PLAN { get; set; }
        public virtual ICollection<PRESTACION> PRESTACION { get; set; }
    }
}
