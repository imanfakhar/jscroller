using System.Collections.Generic;

namespace JScroller.Mvc.Models
{
    public class Brand
    {
        public string Name { get; set; }

        public Brand(string name)
        {
            Name = name;
        }
    }

    public class Repo
    {
        public static List<Brand> GetAll()
        {
            return new List<Brand>
                       {
                           new Brand("Acura"),
                           new Brand("Alfa Romeo"),
                           new Brand("Aston Martin"),
                           new Brand("Audi"),
                           new Brand("BMW"),
                           new Brand("Bentley"),
                           new Brand("Buick"),
                           new Brand("Bugatti"),
                           new Brand("Cadillac"),
                           new Brand("Caterham"),
                           new Brand("Carver"),
                           new Brand("Chery"),
                           new Brand("Chevrolet"),
                           new Brand("Chrysler"),
                           new Brand("Citroen"),
                           new Brand("Daewoo"),
                           new Brand("Daihatsu"),
                           new Brand("Daimler"),
                           new Brand("Dodge"),
                           new Brand("Eagle"),
                           new Brand("Fiat"),
                           new Brand("Ferrari"),
                           new Brand("Ford"),
                           new Brand("GM"),
                           new Brand("GMC"),
                           new Brand("Ginetta"),
                           new Brand("Holden"),
                           new Brand("Honda"),
                           new Brand("Hummer"),
                           new Brand("Hyundai"),
                           new Brand("Infiniti"),
                           new Brand("Isuzu"),
                           new Brand("Jaguar"),
                           new Brand("Jeep"),
                           new Brand("Kia"),
                           new Brand("Koenigsegg"),
                           new Brand("Lamborghini"),
                           new Brand("Lancia"),
                           new Brand("Land Rover"),
                           new Brand("LDV"),
                           new Brand("Lexus"),
                           new Brand("Lincoln"),
                           new Brand("Lotus"),
                           new Brand("Marcos"),
                           new Brand("Mangusta"),
                           new Brand("MG"),
                           new Brand("Maserati"),
                           new Brand("Mazda"),
                           new Brand("McLaren"),
                           new Brand("Mercedes-Benz"),
                           new Brand("Micro"),
                           new Brand("Mini"),
                           new Brand("Mercury"),
                           new Brand("Mitsubishi"),
                           new Brand("Morgan"),
                           new Brand("Navistar"),
                           new Brand("Nissan"),
                           new Brand("Oldsmobile"),
                           new Brand("Opel"),
                           new Brand("Packard"),
                           new Brand("Panoz Auto"),
                           new Brand("Perodua"),
                           new Brand("Peugeot"),
                           new Brand("Pontiac"),
                           new Brand("Porsche"),
                           new Brand("Proton"),
                           new Brand("Renault"),
                           new Brand("Rolls Royce"),
                           new Brand("Saab"),
                           new Brand("Saturn"),
                           new Brand("Scion"),
                           new Brand("Seat"),
                           new Brand("Shelby"),
                           new Brand("Skoda"),
                           new Brand("Smart"),
                           new Brand("Subaru"),
                           new Brand("Suzuki"),
                           new Brand("Tata Motors"),
                           new Brand("Tesla Motors"),
                           new Brand("Toyota"),
                           new Brand("TVR"),
                           new Brand("Vauxhall"),
                           new Brand("Volkswagen"),
                           new Brand("Volvo")
                       };
        }
    }
}