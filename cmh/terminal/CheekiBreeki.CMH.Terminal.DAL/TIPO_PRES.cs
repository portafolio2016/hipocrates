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
    
    public partial class TIPO_PRES
    {
        public TIPO_PRES()
        {
            this.PRESTACION = new HashSet<PRESTACION>();
        }
    
        public int ID_TIPO_PRESTACION { get; set; }
        public string NOM_TIPO_PREST { get; set; }
    
        public virtual ICollection<PRESTACION> PRESTACION { get; set; }
    }
}
