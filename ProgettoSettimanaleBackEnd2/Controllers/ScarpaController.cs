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
                Img = "https://basecesena.com/cdn/shop/products/image_c79e344a-ec9e-4f68-bac0-1304b5616d9e.jpg?v=1653326146&width=",
                AddImg1 = "https://basecesena.com/cdn/shop/products/image_c79e344a-ec9e-4f68-bac0-1304b5616d9e.jpg?v=1653326146&width=",
                AddImg2 ="https://basecesena.com/cdn/shop/products/image_c79e344a-ec9e-4f68-bac0-1304b5616d9e.jpg?v=1653326146&width=",
            },
            new Scarpa
            {
                Id = 2,
                Nome = "Dunk Nere e Bianche",
                Prezzo = 110.50m,
                Descrizione = "Scarpa versatile e utilizzabile per ogni occasione",
                Img = "https://basecesena.com/cdn/shop/products/Nike_Dunk_Low_Black_White_Panda_gs_CW1590-100__Hype_Clothinga_Limited_Edition.3-thumbnail-1080x1080-70.jpg?v=1670437848&width=1200",
                AddImg1 = "https://basecesena.com/cdn/shop/products/image_c79e344a-ec9e-4f68-bac0-1304b5616d9e.jpg?v=1653326146&width=",
                AddImg2 ="https://basecesena.com/cdn/shop/products/image_c79e344a-ec9e-4f68-bac0-1304b5616d9e.jpg?v=1653326146&width=",
            },
             new Scarpa
            {
                Id = 3,
                Nome = "Dunk Grigie",
                Prezzo = 120.65m,
                Descrizione = "Scarpa comoda e versatile",
                Img = "https://images.prodirectsport.com/ProductImages/Main/261348_Main_Thumb_1701048.jpg?imwidth=1440",
                AddImg1 = "https://images.prodirectsport.com/ProductImages/Main/261348_Main_Thumb_1701048.jpg?imwidth=1440",
                AddImg2 ="https://images.prodirectsport.com/ProductImages/Main/261348_Main_Thumb_1701048.jpg?imwidth=1440",
            },
              new Scarpa
            {
                Id = 4,
                Nome = "Dunk Petrolio",
                Prezzo = 120.65m,
                Descrizione = "Scarpa comoda e versatile",
                Img = "https://images.prodirectsport.com/ProductImages/Main/1014969_Main_1791621.jpg?imwidth=1440",
                AddImg1 = "https://images.prodirectsport.com/ProductImages/Main/1014969_Main_1791621.jpg?imwidth=1440",
                AddImg2 ="https://images.prodirectsport.com/ProductImages/Main/1014969_Main_1791621.jpg?imwidth=1440",
            },
               new Scarpa
            {
                Id = 5,
                Nome = "Dunk Bordeaux",
                Prezzo = 120.65m,
                Descrizione = "Scarpa comoda e versatile",
                Img = "https://oblioclothing.com/cdn/shop/products/nike-dunk-low-bordeaux-2-1000.png?v=1648062169&width=1000",
                AddImg1 = "https://oblioclothing.com/cdn/shop/products/nike-dunk-low-bordeaux-2-1000.png?v=1648062169&width=1000",
                AddImg2 ="https://oblioclothing.com/cdn/shop/products/nike-dunk-low-bordeaux-2-1000.png?v=1648062169&width=1000",
            },
                new Scarpa
            {
                Id = 6,
                Nome = "Dunk Petrolio Tessuto",
                Prezzo = 120.65m,
                Descrizione = "Scarpa comoda e versatile",
                Img = "https://www.overlimit.it/cdn/shop/files/INDUSTRIAL1_550x.jpg?v=1687880423",
                AddImg1 = "https://www.overlimit.it/cdn/shop/files/INDUSTRIAL1_550x.jpg?v=1687880423",
                AddImg2 ="https://www.overlimit.it/cdn/shop/files/INDUSTRIAL1_550x.jpg?v=1687880423",
            },
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

        public IActionResult Modifica(int id)
        {
            var scarpa = Scarpe.FirstOrDefault(s => s.Id == id);
            if (scarpa == null)
            {
                return NotFound();
            }

            var model = new AggiungiScarpaModel
            {
                Id = scarpa.Id,
                Nome = scarpa.Nome,
                Prezzo = scarpa.Prezzo,
                Descrizione = scarpa.Descrizione,
                Img = scarpa.Img,
                AddImg1 = scarpa.AddImg1,
                AddImg2 = scarpa.AddImg2
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Salva(AggiungiScarpaModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Modifica", model);
            }

            var scarpa = Scarpe.FirstOrDefault(s => s.Id == model.Id);
            if (scarpa == null)
            {
                return NotFound();
            }

           
            scarpa.Nome = model.Nome;
            scarpa.Prezzo = model.Prezzo;
            scarpa.Descrizione = model.Descrizione;
            scarpa.Img = model.Img;
            scarpa.AddImg1 = model.AddImg1;
            scarpa.AddImg2 = model.AddImg2;

            return RedirectToAction("Index");
        }

        public IActionResult Elimina(int id)
        {
            var scarpa = Scarpe.FirstOrDefault(s => s.Id == id);
            if (scarpa == null)
            {
                return NotFound();
            }

            Scarpe.Remove(scarpa);

            return RedirectToAction("Index");
        }






    }
}



           
        

        