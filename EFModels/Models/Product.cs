using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFModels.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string ProductName { get; set; }

        [Required]
        [MaxLength(300)]

        public string ProductDescription { get; set; }

        [Required]
        public double Price {  get; set; }

            
        [Required]
        public int Qty { get; set; }
    }
}
