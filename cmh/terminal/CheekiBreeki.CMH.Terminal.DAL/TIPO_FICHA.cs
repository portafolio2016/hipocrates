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
    
    public partial class TIPO_FICHA
    {
        public TIPO_FICHA()
        {
            this.ENTRADA_FICHA = new HashSet<ENTRADA_FICHA>();
        }
    
        public int ID_TIPO_FICHA { get; set; }
        public string NOM_TIPO_FICHA { get; set; }
    
        public virtual ICollection<ENTRADA_FICHA> ENTRADA_FICHA { get; set; }
    }
}