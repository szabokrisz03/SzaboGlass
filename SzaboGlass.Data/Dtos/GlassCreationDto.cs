using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzaboGlass.Data.Dtos
{
    public class GlassCreationDto
    {
        [Required(ErrorMessage = "A név kitöltés kötelező!"), StringLength(100, ErrorMessage = "A név nem lehet hosszabb 100 karakternél!")]
        public string Name { get; set; } = string.Empty;

        public int? PurchasePriceCE { get; set; }

        public int? PurchasePriceMalyi { get; set; }

        [Required(ErrorMessage = "A szorzó kitöltése kötelező!")]
        public float Multiplier { get; set; }
    }
}
