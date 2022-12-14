using LOG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LOG.Models;
using System.Web.Security;

namespace LOG.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Log(Login MODEL,string returnUrl)
        {
            LoginPage1Entities db= new LoginPage1Entities();
            var dataItem=db. Logins.Where(X=>X.UserName == MODEL.UserName && X.Password==MODEL.Password).First();
            if (dataItem != null)
            {
                FormsAuthentication.SetAuthCookie(dataItem.UserName, false);
                if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("\\"))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid user/pass");
                return View();
            }
                

                }
            }
        }


    
