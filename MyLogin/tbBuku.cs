namespace MyLogin
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbBuku")]
    public partial class tbBuku
    {
        [Key]
        [StringLength(10)]
        public string kodeBuku { get; set; }

        [Required]
        [StringLength(150)]
        public string judulBuku { get; set; }

        [Required]
        [StringLength(150)]
        public string pengarang { get; set; }

        [Required]
        [StringLength(100)]
        public string penerbit { get; set; }

        [Column(TypeName = "money")]
        public decimal harga { get; set; }

        public int stock { get; set; }
    }
}
