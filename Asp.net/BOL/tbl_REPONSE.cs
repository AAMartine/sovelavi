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
    using System.ComponentModel.DataAnnotations;
    public partial class tbl_REPONSE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_REPONSE()
        {
            this.tbl_EVAL_REPONSE = new HashSet<tbl_EVAL_REPONSE>();
            this.tbl_RESSOURCES_AFFECTEES = new HashSet<tbl_RESSOURCES_AFFECTEES>();
        }
    
        public int id { get; set; }
        [Required]
        public int typeId { get; set; }
        [Required]
        public System.DateTime heureDecision { get; set; }
        [Required]
        public Nullable<System.DateTime> heureImpactEffectif { get; set; }
        [Required]
        public System.DateTime heureImpactEspere { get; set; }
        [Required]
        public string description { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_EVAL_REPONSE> tbl_EVAL_REPONSE { get; set; }
        public virtual tbl_TYPE_REPONSE tbl_TYPE_REPONSE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_RESSOURCES_AFFECTEES> tbl_RESSOURCES_AFFECTEES { get; set; }
    }
}
