using System;
using System.Web.Mvc;
using Xm.Trial.Service;

namespace Xm.Trial.Controllers
{
    public class ContactUsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult SendEmail(string messageText)
        {
            string resultMessage = new Email().Send(messageText);
            return Json(new {resultMessage}, JsonRequestBehavior.AllowGet);
        }
    }
}