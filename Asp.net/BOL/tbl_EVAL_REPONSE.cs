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
    public partial class tbl_EVAL_REPONSE
    {
        public int id { get; set; }
        [Required]
        public int reponseId { get; set; }
        [Required]
        public int niveauId { get; set; }
        [Required]
        public string commentaires { get; set; }
    
        public virtual tbl_NIVEAU_RESOLUTION tbl_NIVEAU_RESOLUTION { get; set; }
        public virtual tbl_REPONSE tbl_REPONSE { get; set; }
    }
}
