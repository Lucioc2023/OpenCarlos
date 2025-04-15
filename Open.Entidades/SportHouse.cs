using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Open.Entidades
{
    [Table("SportHouses")]
    //Creame un indice Con Nombre y direccion que se llame "IX_SportHouses_Name_Addres" y que sea unico
    [Index(nameof(SportHouse.Name), nameof(SportHouse.Addres), Name = "IX_SportHouses_Name_Addres", IsUnique = true)]
    public class SportHouse
    {        
        public int Id { get; set; }
        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(50, ErrorMessage = "The field {0} must be between {2} and {1} characteres", MinimumLength = 3)]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(50, ErrorMessage = "The field {0} must be between {2} and {1} characteres", MinimumLength = 3)]
        public string Addres { get; set; } = null!;
        public ICollection<Shoe>? Shoes { get; set; }
        public override string ToString()
        {
            return $"{Name.ToUpper()}, {Addres}";
        }
    }
}
