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
    
    public partial class Birim
    {
        public int Birim_ID { get; set; }
        public string Info { get; set; }
        public string Cevap { get; set; }
        public int Yon_ID { get; set; }
        public int SosMedyaYet_ID { get; set; }
    
        public virtual Evrak_Yon Evrak_Yon { get; set; }
        public virtual SosyalMedyaEkibi SosyalMedyaEkibi { get; set; }
    }
}