using System.ComponentModel.DataAnnotations;
using SzaboGlass.Data.Entity;

namespace SzaboGlass.Data.Dtos
{
    public class GlassDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int GlassTypeId { get; set; }

        public int? PurchasePriceCE { get; set; }

        public int? PurchasePriceMalyi { get; set; }

        public int RoundedPrice { get; set; }

        public int? PriceWithVAT { get; set; }

        public int? SerialPrice { get; set; }

        public int? UniquePrice { get; set; }

        public float Multiplier { get; set; }
    }
}
