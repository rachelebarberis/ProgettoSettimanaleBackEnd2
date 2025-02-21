using Microsoft.AspNetCore.Mvc;
using ProgettoSettimanaleBackEnd2.Models;


namespace ProgettoSettimanaleBackEnd2.Controllers
{
    public class ScarpaController : Controller
    {
        private static List<Scarpa> Scarpe { get; set; } = new List<Scarpa>
        {
            new Scarpa
            {
                Id = 1,
                Nome = "Dunk Rosa",
                Prezzo = 120.65m,
                Descrizione = "Scarpa comoda e versatile",
                Img = "/img/image_c79e344a-ec9e-4f68-bac0-1304b5616d9e.jpeg",
                AddImg = new List<string>
                {
                    "/img/image_c79e344a-ec9e-4f68-bac0-1304b5616d9e.jpeg",
                    "/img/image_c79e344a-ec9e-4f68-bac0-1304b5616d9e.jpeg"
                }
            },
            new Scarpa
            {
                Id = 2,
                Nome = "Dunk Nere e Bianche",
                Prezzo = 110.50m,
                Descrizione = "Scarpa elegante per ogni occasione",
                Img = "/img/image_c79e344a-ec9e-4f68-bac0-1304b5616d9e.jpeg",
                AddImg = new List<string>
                {
                    "/img/image_c79e344a-ec9e-4f68-bac0-1304b5616d9e.jpeg",
                    "/img/image_c79e344a-ec9e-4f68-bac0-1304b5616d9e.jpeg"
                }
            }
        };

        public IActionResult Index()
        {
            var scarpeList = new ScarpeView
            {
                Scarpe = Scarpe
            };

            return View(scarpeList);
        }

        public IActionResult Dettagli(int id)
        {
          
            var scarpa = Scarpe.FirstOrDefault(s => s.Id == id);

            if (scarpa == null)
            {
                return NotFound(); 
            }

            return View(scarpa);
        }
    }
}
