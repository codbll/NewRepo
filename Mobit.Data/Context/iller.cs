//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Mobit.Data.Context
{
    using System;
    using System.Collections.Generic;
    
    public partial class iller
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public iller()
        {
            this.ilceler = new HashSet<ilceler>();
        }
    
        public int ilId { get; set; }
        public int UlkeId { get; set; }
        public string ilAdi { get; set; }
        public string PlakaNo { get; set; }
        public string TelKodu { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ilceler> ilceler { get; set; }
    }
}
