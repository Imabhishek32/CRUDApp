﻿using System.ComponentModel.DataAnnotations;

namespace CRUDApp.Models
{
    public class Product
    {
        [Key]
        public int id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        public float Price { get; set; }
        public string Description { get; set; }
        [Range(0, int.MaxValue, ErrorMessage ="Stock must be positive")]
        public int Stock { get; set; }
    }
}
