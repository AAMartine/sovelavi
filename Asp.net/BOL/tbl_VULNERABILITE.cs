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
    
    public partial class tbl_VULNERABILITE
    {
        public int id { get; set; }
        public int collectiviteId { get; set; }
        public int menaceId { get; set; }
        public int niveauVulnerabiliteID { get; set; }
        public System.DateTime startDate { get; set; }
    
        public virtual tbl_COLLECTIVITE_TERRITORIALE tbl_COLLECTIVITE_TERRITORIALE { get; set; }
        public virtual tbl_MENACE tbl_MENACE { get; set; }
        public virtual tbl_VULNERABILITE_NIVEAU tbl_VULNERABILITE_NIVEAU { get; set; }
    }
}
