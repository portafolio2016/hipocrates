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
    
    public partial class PLAN
    {
        public PLAN()
        {
            this.AFILIADO = new HashSet<AFILIADO>();
            this.BENEFICIO = new HashSet<BENEFICIO>();
        }
    
        public int ID_PLAN { get; set; }
        public string NOMBRE { get; set; }
        public Nullable<int> ID_EMPRESA { get; set; }
    
        public virtual ICollection<AFILIADO> AFILIADO { get; set; }
        public virtual ICollection<BENEFICIO> BENEFICIO { get; set; }
        public virtual EMPRESA EMPRESA { get; set; }
    }
}
