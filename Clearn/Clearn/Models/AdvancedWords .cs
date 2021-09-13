using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Clearn.Models
{
    [Table("Advanced")]

    public class AdvancedWords:DbContext
    {
       
            [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int WordId { get; set; }

            [StringLength(20)]
            public string Word { get; set; }

            [StringLength(20)]
            public string Meaning { get; set; }
        
    }
}