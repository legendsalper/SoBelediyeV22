//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SoBelediyeV22.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ilce
    {
        public int Ilce_ID { get; set; }
        public Nullable<int> IlID { get; set; }
        public string Ilce1 { get; set; }
    
        public virtual Il Il { get; set; }
    }
}
