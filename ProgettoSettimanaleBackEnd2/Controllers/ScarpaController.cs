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
                AddImg1 = "/img/image_c79e344a-ec9e-4f68-bac0-1304b5616d9e.jpeg",
                AddImg2 ="/img/image_c79e344a-ec9e-4f68-bac0-1304b5616d9e.jpeg",
            },
            new Scarpa
            {
                Id = 2,
                Nome = "Dunk Nere e Bianche",
                Prezzo = 110.50m,
                Descrizione = "Scarpa elegante per ogni occasione",
                Img = "/img/image_c79e344a-ec9e-4f68-bac0-1304b5616d9e.jpeg",
                AddImg1 = "/img/image_c79e344a-ec9e-4f68-bac0-1304b5616d9e.jpeg",
                AddImg2 ="/img/image_c79e344a-ec9e-4f68-bac0-1304b5616d9e.jpeg",
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

        public IActionResult Aggiungi()


        {
            return View("Aggiungi");
        }

        [HttpPost]
        public IActionResult Crea(AggiungiScarpaModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Try again!";
                return RedirectToAction("Aggiungi", model);
            }
            var newScarpa = new Scarpa()
            {
                Id = Scarpe.Max(s => s.Id) + 1,
                Nome = model.Nome,
                Prezzo = model.Prezzo,
                Descrizione = model.Descrizione,
                Img = model.Img,
                AddImg1 = model.AddImg1,
                AddImg2 = model.AddImg2


            };

            Scarpe.Add(newScarpa);
            return RedirectToAction("Index");
        }

      

    }
}



           
        

        