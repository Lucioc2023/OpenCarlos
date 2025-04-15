using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Open.Entidades
{
     public class Shoe
     {
        public int Id { get; set; }
        public string Model { get; set; } = null!;//Title Modelo
        public DateOnly Release { get; set; }//PublishDate Lanzamiento
        public int Size { get; set; }//Pages Size tamaño

        public int SportHouseId { get; set; }//
        public  SportHouse? SportHouse { get; set; }//Navigation Property
        public override string ToString()
        {
            return $"Modelo: {Model} - Size: {Size}";
        }
    }
}
