using Microsoft.AspNetCore.Mvc;
using TTRoll.Data;
using TTRoll.Models;

namespace TTRoll.Controllers
{
    public class CharacterController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CharacterController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Character> objCharacterList = _db.Characters;
            return View(objCharacterList);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Character obj)
        {
            if (ModelState.IsValid)
            {
                obj.CurrentHP = obj.MaxHP;
                _db.Characters.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            var characterFromDb = _db.Characters.Find(id);

            if (characterFromDb == null)
            {
                return NotFound();
            }

            return View(characterFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Character obj)
        {
            if (ModelState.IsValid)
            {
                _db.Characters.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var characterFromDb = _db.Characters.Find(id);

            if (characterFromDb == null)
            {
                return NotFound();
            }

            return View(characterFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Characters.Find(id);
            if(obj == null)
            {
                return NotFound();
            }

            _db.Characters.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
