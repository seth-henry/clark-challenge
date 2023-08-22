using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ClarkCodingChallenge.Models;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ClarkCodingChallenge.Controllers
{
    public class ContactsController : Controller
    {

        public static IList<Contacts> contactList = new List<Contacts>() {};

        public IActionResult Index()
        {
            return View(contactList);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind("LastName, FirstName, Email")]Contacts contacts)
        {
            if (ModelState.IsValid)
            {
                contactList.Add(contacts);
                return RedirectToAction("Success");
            }
            return View(contacts);
        }

        public ActionResult Success()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public async Task<ActionResult> GetContacts()
        {
            try{
                return Ok(contactList);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data.");
            }
        }
    }
}
