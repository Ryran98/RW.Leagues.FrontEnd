using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using RW.Leagues.FrontEnd.Models;

namespace RW.Leagues.FrontEnd.Controllers
{
    public class CountryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [HttpPost]
        public JsonResult All()
        {
            try
            {
                return Json(db.Countries.ToList());
            }
            catch (Exception e)
            {
                Session["error"] = e.Message;
                return Json("An error has occurred");
            }
        }
    }
}