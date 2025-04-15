
using Microsoft.EntityFrameworkCore;
using Open.Consola.Validators;
using Open.Data;
using Open.Entidades;
using System.ComponentModel.DataAnnotations;

namespace Open.Consola
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //CreateDb();
            do
            {
                Console.WriteLine("Main Menu");
                Console.WriteLine("1 - SportHouse");
                Console.WriteLine("2 - Zapatillas");
                Console.WriteLine("x - Exit ");
                Console.Write("Enter an option: ");
                var option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        SportHouseMenu();
                        break;
                    case "2":
                        ShoesMenu();
                        break;
                    case "x":
                        return;
                    default:
                        break;
                }
            } while (true);
            Console.WriteLine("End of Program");
        }

        private static void ShoesMenu()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("SHOES");
                Console.WriteLine("1 -List Shoes");
                Console.WriteLine("2 - Add New Shoe");
                Console.WriteLine("3 - Delete Shoe");
                Console.WriteLine("4 - Edit Shoe");
                Console.WriteLine("r - Return ");
                Console.Write("Enter an option: ");
                var option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        ShoesList();
                        break;
                    case "2":
                        AddShoes();
                        break;
                    case "3":
                        DeleteShoes();
                        break;
                    case "4":
                        //EditShoes();
                        break;
                    case "r":
                        return;
                    default:
                        break;
                }
            } while (true);
        }

        private static void DeleteShoes()
        {
            Console.Clear();
            Console.WriteLine("Deleting Shoes");
            Console.WriteLine("List of Shoes to Delete");
            using (var context = new LibraryContextOpen())
            {
                var shoes = context.Shoes
                    .OrderBy(s => s.Id)
                    .Select(s => new
                    {
                        s.Id,
                        s.Model
                    }).ToList();
                foreach (var shoe in shoes)
                {
                    Console.WriteLine($"{shoe.Id} - {shoe.Model}");
                }
                Console.Write("Select ShoeID to Delete (0 to Escape):");
                if (!int.TryParse(Console.ReadLine(), out int shoeId) || shoeId < 0)
                {
                    Console.WriteLine("Invalid ShoeId...");
                    Console.ReadLine();
                    return;
                }
                if (shoeId == 0)
                {
                    Console.WriteLine("Cancelled by user");
                    Console.ReadLine();
                    return;
                }
                var deleteShoe = context.Shoes.Find(shoeId);
                if (deleteShoe is null)
                {
                    Console.WriteLine("Book does not exist!!!");
                }
                else
                {
                    context.Shoes.Remove(deleteShoe);
                    context.SaveChanges();
                    Console.WriteLine("Shoe Successfully Deleted");
                }
                Console.ReadLine();
                return;
            }
        }

        private static void AddShoes()
        {
            
            Console.Clear();
            Console.WriteLine("Addin New Shoe");
            Console.Write("Enter Shoes Model:");
            var model = Console.ReadLine();
            Console.Write("Enter Launch Date (dd/mm/yyyy):");
            if (!DateOnly.TryParse(Console.ReadLine(), out var release))
            {
                Console.WriteLine("Wrong Date....");
                Console.ReadLine();
                return;
            }
            Console.Write("Enter Size:");
            if (!int.TryParse(Console.ReadLine(), out var size))
            {
                Console.WriteLine("Wrong Size Count...");
                Console.ReadLine();
                return;
            }
            Console.WriteLine("List of SportHouse to Select");
            using (var context = new LibraryContextOpen())
            {
                var sportHouseList = context.SportHouses
                    .OrderBy(a => a.Id)
                    .ToList();
                foreach (var sportHouse in sportHouseList)
                {
                    Console.WriteLine($"{sportHouse.Id} - {sportHouse}");
                }
                Console.Write("Enter SportHouseId (0 New SportHouse):");
                if (!int.TryParse(Console.ReadLine(), out var sportHouseId) || sportHouseId < 0)
                {
                    Console.WriteLine("Invalid SportHouseId....");
                    Console.ReadLine();
                    return;
                }
                var selectedSportHouse = context.SportHouses.Find(sportHouseId);
                if (selectedSportHouse is null)
                {
                    Console.WriteLine("SportHouse not found!!!");
                    Console.ReadLine();
                    return;
                }
                var newShoe = new Shoe
                {
                    Model = model ?? string.Empty,
                    Release = release,
                    Size = size,
                    SportHouseId = sportHouseId
                };

                var shoesValidator = new ShoesValidator();
                var validationResult = shoesValidator.Validate(newShoe);

                if (validationResult.IsValid)
                {                    
                    var existingShoe = context.Shoes.FirstOrDefault(s => s.Model.ToLower() == model!.ToLower() &&
                        s.SportHouseId == sportHouseId);

                    if (existingShoe is null)
                    {
                        context.Shoes.Add(newShoe);
                        context.SaveChanges();
                        Console.WriteLine("Shoe Successfully Added!!!");

                    }
                    else
                    {
                        Console.WriteLine("Shoe duplicated!!!");
                    }

                }
                else
                {
                    foreach (var error in validationResult.Errors)
                    {
                        Console.WriteLine(error);
                    }
                }
                Console.ReadLine();
                return;
            }

        }

        private static void ShoesList()
        {
            Console.Clear();
            Console.WriteLine("List of Soes");
            using (var context = new LibraryContextOpen())
            {
                var shoes = context.Shoes
                    .Include(s => s.SportHouse)
                    .Select(s => new
                    {
                        s.Id,
                        s.Model,
                        s.SportHouse
                    })
                    .ToList();
                foreach (var sh in shoes)
                {
                    Console.WriteLine($"{sh.Model} - SportHouse: {sh.SportHouse}");
                }
            }
            Console.WriteLine("ENTER to continue");
            Console.ReadLine();
        }

        private static void SportHouseMenu()
        {
            do
            {
                Console.WriteLine("SPORT-HOUSES");
                Console.WriteLine("1 - List of SportHouse");
                Console.WriteLine("2 - Add New SportHouse");
                Console.WriteLine("3 - Delete an SportHouse");
                Console.WriteLine("4 - Edit an SportHouse");
                Console.WriteLine("r - Return ");
                Console.Write("Enter an option: ");
                var option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        ListSportHouses();
                        break;
                    case "2":
                        AddSportHouses();
                        break;
                    case "3":
                        DeleteSportHouses();
                        break;
                    case "4":
                        EditSportHouses();
                        break;
                    case "r":
                        return;
                    default:
                        break;
                }
            } while (true);
        }

        private static void EditSportHouses()
        {
            Console.Clear();
            Console.WriteLine("Edit An SportHouse");
            using (var context = new LibraryContextOpen())
            {
                var sportHouses = context.SportHouses
                    .OrderBy(s => s.Id)
                    .ToList();
                foreach (var sportHouse in sportHouses)
                {
                    Console.WriteLine($"{sportHouse.Id} - {sportHouse}");
                }
                Console.WriteLine("Enter an SportHouseId to Edit");
                int sportHouseId;
                if (!int.TryParse(Console.ReadLine(), out sportHouseId) || sportHouseId <= 0)
                {
                    Console.WriteLine("Invalid SportHouseId ");
                    Console.ReadLine();
                    return;
                }
                var sportHouseInDb = context.SportHouses.Find(sportHouseId);
                if (sportHouseInDb == null)
                {
                    Console.WriteLine("SportHouse does not exist");
                    Console.ReadLine();
                    return;
                }
//**********Editar Nombre********************
                Console.WriteLine($"Current SportHouse Name {sportHouseInDb.Name} ");
                Console.Write("Enter new Name (or ENTER to keep the same)");//Ingrese un nuevo nombre (o ingrese para mantener el mismo)
                var newName=Console.ReadLine();
                if (!string.IsNullOrEmpty(newName))
                {
                    sportHouseInDb.Name = newName;
                }
//**********Editar Direccion********************
                Console.WriteLine($"Current SportHouse Addres {sportHouseInDb.Addres} ");
                Console.Write("Enter new Addres (or ENTER to keep the same)");//Ingrese un nuevo nombre (o ingrese para mantener el mismo)
                var newAddres = Console.ReadLine();
                if (!string.IsNullOrEmpty(newAddres))
                {
                    sportHouseInDb.Addres = newAddres;
                }

                var originalSportHouse = context.SportHouses
                    .AsNoTracking()
                    .FirstOrDefault(a => a.Id == sportHouseInDb.Id);
;

                Console.Write($"Are you sure to Edit \"{originalSportHouse!.Name} {originalSportHouse.Addres}\"? (y/n):");
                var confirm = Console.ReadLine();
                if (confirm?.ToLower() == "y")
                {                    
                    context.SaveChanges();
                    Console.WriteLine("SportHouse fue edited !!!");
                }
                else
                {
                    Console.WriteLine("Operacion Cancelada!!");
                }
                Console.ReadLine();
                return;
            }
        }

        private static void DeleteSportHouses()
        {
            Console.Clear();
            Console.WriteLine("Delete An SportHouse");
            using (var context= new LibraryContextOpen())
            {
                var sportHouses = context.SportHouses
                    .OrderBy(s => s.Id)
                    .ToList();
                foreach (var sportHouse in sportHouses)
                {
                    Console.WriteLine($"{sportHouse.Id} - {sportHouse}");
                }
                Console.WriteLine("Enter an SportHouseId to delete");
                int sportHouseId;
                if (!int.TryParse(Console.ReadLine(), out sportHouseId) || sportHouseId <= 0)
                {
                    Console.WriteLine("Invalid SportHouseId ");
                    Console.ReadLine();
                    return;
                }
                var sportHouseInDb = context.SportHouses.Find(sportHouseId);
                if (sportHouseInDb == null)
                {
                    Console.WriteLine("SportHouse does not exist");
                    Console.ReadLine();
                    return;
                }
                Console.Write($"Are you sure to delete \"{sportHouseInDb.Name} {sportHouseInDb.Addres}\"? (y/n):");
                var confirm = Console.ReadLine();
                if (confirm?.ToLower() == "y")
                {
                    context.SportHouses.Remove(sportHouseInDb);
                    context.SaveChanges();
                    Console.WriteLine("SportHouse fue borrado!!!");
                }
                else 
                {
                    Console.WriteLine("Operacion Cancelada!!");
                }
                Console.ReadLine();
                return;
            }
        }

        private static void AddSportHouses()//SEGUIR 1:40:00
        {
            Console.Clear();
            Console.WriteLine("Adding a New SportHouse");
            Console.Write("Enter Name: ");
            var name = Console.ReadLine();
            Console.Write("Enter Addres: ");
            var addres = Console.ReadLine();

            using (var context = new LibraryContextOpen())
            {
                bool exist = context.SportHouses.Any(s => s.Name == name 
                                                       && s.Addres == addres);//Any va a devolver bool si alguna entidad del tipo SportHouse tiene Nombre y Direccion igaul al que le pase
                                                                              //SEGUIR 1:14:00
                if (!exist)
                {
                    var sportHouse = new SportHouse
                    {
                        Name = name??string.Empty,
                        Addres = addres??string.Empty
                    };
                    var validationContext = new ValidationContext(sportHouse);// Creo obj "ValidationContext" y le paso "sportHouse" que es el obj que debe validar
                    var errorMessage = new List<ValidationResult>();//Creo obj "List<ValidationResult>()" 

                    bool isValid = Validator.TryValidateObject(sportHouse, validationContext, errorMessage,true);

                    if (isValid)
                    {
                        //context.Add(sportHouse); o context.SportHouses.Add(sportHouse); las 2 estan bien
                        context.SportHouses.Add(sportHouse);//AGREGAR a travez de DbSet
                        context.SaveChanges();//GUARDAR EN BASE DE DATOS 

                        Console.WriteLine("-----------------------------");
                        Console.WriteLine("Sport-House Succesfully added");
                        Console.WriteLine("-----------------------------");
                    }
                    else
                    {
                        foreach (var message in errorMessage)
                        {
                            Console.WriteLine($" ERROR :{message} !!!!");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("SportHouse alrady exist");//ya existe este SportHouse
                }
            }            
            Console.ReadLine();
        }

        private static void ListSportHouses()
        {
            Console.Clear();
            Console.WriteLine("List Soport-Houses");
            using (var context = new LibraryContextOpen())
            {
                var sportHauses = context.SportHouses
                    .OrderBy(s => s.Name)
                    .AsNoTracking()
                    .ToList();//Este es el SELECT
                foreach (var sportHause in sportHauses)
                {
                    Console.WriteLine(sportHause);
                }
                Console.WriteLine("ENTER to continue");
                Console.ReadLine();
            }
        }

        private static void CreateDb()
        {
            using (var context = new LibraryContextOpen())
            {
                context.Database.EnsureCreated();
            }
            Console.WriteLine("Database Created!!!");
        }
    }
}
