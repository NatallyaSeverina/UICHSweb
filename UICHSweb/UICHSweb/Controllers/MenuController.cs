using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UICHSweb.Models;

namespace UICHSweb.Controllers
{
    public class MenuController : Controller
    {
        //IRepository<Car> repository;

        List<MenuItem> items;
        public MenuController()
        {
            
            items = new List<MenuItem>
            {
              new MenuItem{ Name="Домой",Controller="Home", Action="Index", Active=string.Empty},
              new MenuItem{ Name="Информация о ЧС",Controller="EmergencySituations", Action="List", Active=string.Empty},
              //new MenuItem{ Name="Администрирование",Controller="Admin", Action="Index", Active=string.Empty},
              new MenuItem{ Name="Карта",Controller="Map", Action="Index", Active=string.Empty},
              new MenuItem{ Name="Статистика",Controller="Statistic", Action="Index", Active=string.Empty}
              //new MenuItem{ Name="Войти",Controller="Account", Action="Login", Active=string.Empty},
              //new MenuItem{ Name="Зарегистрироваться",Controller="Account", Action="Register", Active=string.Empty}
            };

        }
        // GET: Menu
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult Main(string a = "Index", string c = "Home")
        {
            items.First(m => m.Controller == c).Active = "active";
            return PartialView(items);


        }
        public PartialViewResult UserInfo()
        {
            return PartialView();
        }
        //public PartialViewResult Side()
        //{
        //    //var groups = repository.GetAll().Select(c=>c.CarYear.ToString()).Distinct();
        //    var groups = repository.GetAll();
        //    List<string> list = new List<string>();
        //    foreach (var item in groups)
        //    {
        //        if (!list.Contains(item.CarYear.ToString()))
        //            list.Add(item.CarYear.ToString());
        //    }
        //    // return PartialView(groups);
        //    return PartialView(list);

        //}
        public PartialViewResult Map()
        {
            return PartialView(items);
        }
    }
}