//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShivikaWebApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class FormsField
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FormsField()
        {
            this.GridHeaders = new HashSet<GridHeader>();
        }
    
        public int Id { get; set; }
        public Nullable<System.DateTime> TestingDate { get; set; }
        public string Source { get; set; }
        public Nullable<int> TypeOfAggregate { get; set; }
        public string WeightOfSample { get; set; }
        public string InvoiceNo { get; set; }
        public string VechleNo { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<int> FormsHeadersId { get; set; }
        public string FormName { get; set; }
    
        public virtual FormsHeader FormsHeader { get; set; }
        public virtual TypeofAggregator TypeofAggregator { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GridHeader> GridHeaders { get; set; }
    }
}
