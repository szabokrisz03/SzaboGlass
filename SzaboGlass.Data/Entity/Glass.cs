using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SzaboGlass.Data.Entity
{
    public class Glass
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(150)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public int GlassTypeId { get; set; }

        public int? PurchasePriceCE { get; set; }

        public int? PurchasePriceMalyi { get; set; }

        [Required]
        public float Multiplier { get; set; }

        [ForeignKey(nameof(GlassTypeId))]
        public GlassType? GlassType { get; set; }
    }
}
