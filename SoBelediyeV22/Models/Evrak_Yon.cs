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
    
    public partial class Evrak_Yon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Evrak_Yon()
        {
            this.Birim = new HashSet<Birim>();
        }
    
        public int Yon_ID { get; set; }
        public Nullable<int> Evrak_ID { get; set; }
        public Nullable<int> DurumID { get; set; }
        public string Aciklama { get; set; }
        public Nullable<System.DateTime> Tarih { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Birim> Birim { get; set; }
        public virtual Evrak Evrak { get; set; }
        public virtual Evrak_Durum Evrak_Durum { get; set; }
    }
}