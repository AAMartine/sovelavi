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
    
    public partial class tbl_EVENEMENT_COLLECTIVITE_TERRITORIALE
    {
        public int id { get; set; }
        public int evementId { get; set; }
        public int collectiviteId { get; set; }
    
        public virtual tbl_COLLECTIVITE_TERRITORIALE tbl_COLLECTIVITE_TERRITORIALE { get; set; }
        public virtual tbl_EVENEMENT tbl_EVENEMENT { get; set; }
    }
}