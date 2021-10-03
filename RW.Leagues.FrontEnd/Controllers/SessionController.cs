using System;
using System.Web.Http;
using System.Web.Mvc;
using Newtonsoft.Json;
using RW.Leagues.FrontEnd.Models;

namespace RW.Leagues.FrontEnd.Controllers
{
    public class SessionController : Controller
    {
        [System.Web.Mvc.HttpPost]
        public JsonResult Get([FromUri] string name)
        {
            return Json(Session[name]);
        }

        [System.Web.Mvc.HttpPost]
        public JsonResult Set([FromUri] string name, [FromBody] SessionVariable session)
        {
            try
            {
                object newValue = session.NewValue;
                Session[name] = newValue;
            }
            catch (Exception e)
            {
                return Json(new { success = false, error = e.Message });
            }

            return Json(new { success = true });
        }
    }
}