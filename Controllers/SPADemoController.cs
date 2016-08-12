using SPA_AngularJs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SPA_AngularJs.Controllers
{
    public class SPADemoController : Controller
    {
        //
        // GET: /login/
        bookDBContext dBase = new bookDBContext();
        public ActionResult  login()
        {
            return View();
        }
        [HttpPost]
        public string login(loginDetails loginDetails)
        {
            if (!ModelState.IsValid)
            {
                 ModelState.AddModelError("loginValued", "unexpected parameters");
                 return "unexpected parameters";
            }
           var result = dBase.userDetails.Where(p => p.userName.Equals(loginDetails.username) && p.password.Equals(p.password)).Take(1);
            if (result.Count() == 0)
            {
                return "invalid user login";
            }
            return"success";
    }
        [HttpPost]
        public string register(registerDetails regdetails)
        {
            try
            {
                if (regdetails == null)
                {
                    throw new Exception("Input not complete");
                }


                regdetails.creat_dt = DateTime.Now;
                dBase.userDetails.Add(regdetails);
                dBase.SaveChanges();

                return regdetails.userName;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
           
        }
        [HttpGet]
        public ActionResult home()
        {

            return View();

            //return  Json(dBase.userDetails.ToList(), JsonRequestBehavior.AllowGet);
          
        }
	}
}