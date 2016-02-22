using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using azure_test_003.Models;
using Microsoft.AspNet.Authorization;

namespace azure_test_003.Controllers
{
    [RequireHttps]
    [Authorize]
    public class CmController : Controller
    {
        private ApplicationDbContext _context;

        public CmController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Cm
        public IActionResult Index()
        {
            return View(_context.Contact.ToList());
        }

        // GET: Cm/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Contact contact = _context.Contact.Single(m => m.ContactId == id);
            if (contact == null)
            {
                return HttpNotFound();
            }

            return View(contact);
        }

        // GET: Cm/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cm/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                _context.Contact.Add(contact);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        // GET: Cm/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Contact contact = _context.Contact.Single(m => m.ContactId == id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: Cm/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                _context.Update(contact);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        // GET: Cm/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Contact contact = _context.Contact.Single(m => m.ContactId == id);
            if (contact == null)
            {
                return HttpNotFound();
            }

            return View(contact);
        }

        // POST: Cm/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Contact contact = _context.Contact.Single(m => m.ContactId == id);
            _context.Contact.Remove(contact);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
