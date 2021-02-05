using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebApp.Models
{
    public class SubCategory
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "SubCategory Name")]
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category {get; set;  }
    }
}
