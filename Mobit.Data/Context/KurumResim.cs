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
    
    public partial class KurumResim
    {
        public int ResimId { get; set; }
        public int KurumId { get; set; }
        public string Resim { get; set; }
    
        public virtual Kurumlar Kurumlar { get; set; }
    }
}
