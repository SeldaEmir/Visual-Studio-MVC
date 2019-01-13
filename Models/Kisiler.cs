using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace aspnet_mvc_ef_codefirst.Models
{
    [Table("Kisiler")]
    public class Kisiler
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [StringLength(20), Required]
        public string Ad { get; set; }
        [StringLength(20), Required]
        public string Soyad { get; set; }
        [Required]
        public int yas { get; set; }

        public virtual List<Adresler> Adresler { get; set; }
    }
}