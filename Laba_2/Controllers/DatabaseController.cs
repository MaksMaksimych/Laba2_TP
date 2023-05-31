using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Laba_2.Models;
using System.Web;
using System.Reflection;
using System.Net;


namespace Laba_2.Controllers
{
    public class DatabaseController : Controller
    {
        // Список экземпляров Person
        private static List<Person> _personsList = new List<Person>();

        // Создание аккаунта
        // GET: /Database/Creat_Data
        [HttpGet]
        public ActionResult Creat_Data()
        {
            HttpCookie cookie = Request.Cookies["ID"];
            if (cookie == null)
            {
                cookie = new HttpCookie("ID");
                cookie.Value = "0";
            }
            else
            {
                cookie.Value = (Convert.ToInt32(cookie.Value) + 1).ToString();
            }
            Response.Cookies.Add(cookie);
            return View("Creat_Data");
        }

        // Просмотр созданного аккаунта 
        [HttpPost]
        public ActionResult View_Data(Person person)
        {
            if (Request.Cookies["ID"] != null)
            {
                string id = Request.Cookies["ID"].Value;
                person.PersonId = Convert.ToInt32(id);
                _personsList.Add(person);
            }
            return View("View_Data", person);
        }

        // Просмотр базы данных
        public ActionResult Data_Base()
        {
            // true - внешний метод, false - внутренний;
            ViewData["method"] = false; 
            return View("Data_Base", _personsList);
        }
    }
}
