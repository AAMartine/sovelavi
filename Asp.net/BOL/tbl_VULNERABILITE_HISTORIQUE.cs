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
    
    public partial class tbl_VULNERABILITE_HISTORIQUE
    {
        public int id { get; set; }
        public int communeId { get; set; }
        public int menaceId { get; set; }
        public int niveauVulnerabiliteId { get; set; }
        public System.DateTime startDate { get; set; }
        public System.DateTime endDate { get; set; }
    
        public virtual tbl_COMMUNE tbl_COMMUNE { get; set; }
        public virtual tbl_MENACE tbl_MENACE { get; set; }
        public virtual tbl_VULNERABILITE_NIVEAU tbl_VULNERABILITE_NIVEAU { get; set; }
    }
}
