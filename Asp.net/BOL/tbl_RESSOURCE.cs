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
    
    public partial class tbl_RESSOURCE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_RESSOURCE()
        {
            this.tbl_RESSOURCES_AFFECTEES = new HashSet<tbl_RESSOURCES_AFFECTEES>();
        }
    
        public int id { get; set; }
        public string nom { get; set; }
        public int typeRessourceId { get; set; }
        public int qteDisponible { get; set; }
        public int qteNecessaire { get; set; }
        public int collectiviteId { get; set; }
    
        public virtual tbl_COLLECTIVITE_TERRITORIALE tbl_COLLECTIVITE_TERRITORIALE { get; set; }
        public virtual tbl_RESSOURCE_TYPE tbl_RESSOURCE_TYPE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_RESSOURCES_AFFECTEES> tbl_RESSOURCES_AFFECTEES { get; set; }
    }
}