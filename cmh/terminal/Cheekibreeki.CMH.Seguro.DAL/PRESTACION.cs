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
    
    public partial class PRESTACION
    {
        public int ID_PRESTACION { get; set; }
        public string NOMBRE { get; set; }
        public string CODIGO { get; set; }
        public Nullable<int> ID_BENEFICIO { get; set; }
    
        public virtual BENEFICIO BENEFICIO { get; set; }
    }
}