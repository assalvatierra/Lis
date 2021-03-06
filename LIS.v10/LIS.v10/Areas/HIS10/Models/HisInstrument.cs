//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LIS.v10.Areas.HIS10.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class HisInstrument
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HisInstrument()
        {
            this.Status = "ACT";
            this.HisOrders = new HashSet<HisOrder>();
        }
    
        public int Id { get; set; }
        public int HisEntityId { get; set; }
        public string Name { get; set; }
        public string InsCode { get; set; }
        public string Description { get; set; }
        public string Specification { get; set; }
        public string Remarks { get; set; }
        public string Status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HisOrder> HisOrders { get; set; }
        public virtual HisEntity HisEntity { get; set; }
    }
}
