//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BOL
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_MENACE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_MENACE()
        {
            this.tbl_VULNERABILITE_HISTORIQUE = new HashSet<tbl_VULNERABILITE_HISTORIQUE>();
            this.tbl_VULNERABILITE = new HashSet<tbl_VULNERABILITE>();
        }
    
        public int id { get; set; }
        public string nom { get; set; }
        public int typeMenaceId { get; set; }
    
        public virtual tbl_TYPE_MENACE tbl_TYPE_MENACE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_VULNERABILITE_HISTORIQUE> tbl_VULNERABILITE_HISTORIQUE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_VULNERABILITE> tbl_VULNERABILITE { get; set; }
    }
}
