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
    
    public partial class Foto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Foto()
        {
            this.Evrak = new HashSet<Evrak>();
            this.Yorumlar = new HashSet<Yorumlar>();
        }
    
        public int Foto_ID { get; set; }
        public Nullable<int> Foto_Location_ID { get; set; }
        public Nullable<int> Kullanici_ID { get; set; }
        public Nullable<int> SosMedyaEkip_ID { get; set; }
        public Nullable<int> IstekSikayet_ID { get; set; }
        public Nullable<int> Foto_Link { get; set; }
        public string OnayDurum { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Evrak> Evrak { get; set; }
        public virtual IstekSikayet IstekSikayet { get; set; }
        public virtual Kullanici Kullanici { get; set; }
        public virtual SosyalMedyaEkibi SosyalMedyaEkibi { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Yorumlar> Yorumlar { get; set; }
    }
}