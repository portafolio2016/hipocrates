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
    
    public partial class CUEN_BANCARIA
    {
        public int ID_CUEN_BANCARIA { get; set; }
        public Nullable<int> ID_PERS_MEDICO { get; set; }
        public Nullable<int> ID_TIPO_C_BANCARIA { get; set; }
        public string NUM_C_BANCARIA { get; set; }
        public Nullable<int> ID_BANCO { get; set; }
    
        public virtual BANCO BANCO { get; set; }
        public virtual PERS_MEDICO PERS_MEDICO { get; set; }
        public virtual TIPO_C_BANCARIA TIPO_C_BANCARIA { get; set; }
    }
}