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
    
    public partial class Evrak
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Evrak()
        {
            this.SosyalMedyaEkibi = new HashSet<SosyalMedyaEkibi>();
        }
    
        public int EvrakID { get; set; }
        public string Desc { get; set; }
        public string Baslik { get; set; }
        public string Tur { get; set; }
        public System.DateTime Tarih { get; set; }
        public int Kullanici_ID { get; set; }
        public Nullable<int> KurumYetkili_ID { get; set; }
        public Nullable<int> Adres_ID { get; set; }
        public Nullable<int> Istek_ID { get; set; }
        public Nullable<int> Foto_ID { get; set; }
        public Nullable<int> Video_ID { get; set; }
        public Nullable<int> Yon_ID { get; set; }
        public Nullable<int> Durum_ID { get; set; }
    
        public virtual Adres Adres { get; set; }
        public virtual Foto Foto { get; set; }
        public virtual IstekSikayet IstekSikayet { get; set; }
        public virtual Kullanici Kullanici { get; set; }
        public virtual Video Video { get; set; }
        public virtual Evrak_Yon Evrak_Yon { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SosyalMedyaEkibi> SosyalMedyaEkibi { get; set; }
    }
}
