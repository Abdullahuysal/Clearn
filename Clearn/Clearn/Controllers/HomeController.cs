using Clearn.Models;
using Clearn.Models.Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Clearn.Controllers
{
    public class HomeController : Controller
    {
        
        // GET: Home
        public ActionResult Homepage()
        {
            DatabaseContext db = new DatabaseContext();
            db.Users.ToList();

            return View();
        }
        
        [HttpPost]
        public ActionResult Homepage(UserData user)
        {
            DatabaseContext db = new DatabaseContext();
            if(user.UserEmail==null || user.UserFirstName==null ||user.UserSecondName==null || user.UserPassword==null)
            {
                return View();
            }
            else
            {
                db.Users.Add(user);
                db.SaveChanges();
                ViewBag.Result = "Kullanıcı kaydedilmiştir.Giriş yap butonuna tıklayarak giriş yapabilirsiniz!";
                ViewBag.Status ="success";
                return View();
            }
        }

        public ActionResult Loginpage()
        {
                return View();
        }


        [HttpPost]
        public ActionResult Loginpage(string UserEmail,string UserPassword)
        {
            var ctx = new DatabaseContext();
            UserData user = ctx.Database.SqlQuery<UserData>("Select * from Users where UserEmail=@UserEmail", new SqlParameter("@UserEmail", UserEmail)).FirstOrDefault();
            
            if (user != null)
            {
                if(user.UserEmail==UserEmail && user.UserPassword == UserPassword)
                {
                    Session["UserFirstName"] = user.UserFirstName;
                    Session["UserSecondName"] = user.UserSecondName;
                    Session["UserEmail"] = user.UserEmail;
                    
                    return Redirect("/Home/Userpage");
                }
                else
                {
                    ViewBag.error = "girilen e-mail veya şifre hatalıdır";
                    return View();
                }
                
            }

            else
            {
                return View();
            }
            
        }
        public ActionResult Userpage()
        {
            ViewBag.UserFirstName = Session["UserFirstName"].ToString();
            ViewBag.UserSecondName = Session["UserSecondName"].ToString();
            ViewBag.UserEmail = Session["UserEmail"].ToString();
            

            return View();
        }

        public ActionResult UserBegginerTest(String categori)
        {
           
            var sql="";
            List<BeginnerWords> kelimeler=new List<BeginnerWords>();
            List<IntermediateWords> kelimeler2 = new List<IntermediateWords>();
            List<AdvancedWords> kelimeler3 = new List<AdvancedWords>();
            
            var context = new DatabaseContext();


            if (categori== "Beginner")
            {
                sql = "Select * from Begginner";
                kelimeler = context.Database.SqlQuery<BeginnerWords>(sql).ToList();
                return View(kelimeler);

            
                
            }
            else if(categori== "Intermediate")
            {
                 sql = "Select * from Intermediate";
                 kelimeler2 = context.Database.SqlQuery<IntermediateWords>(sql).ToList();
                 return View(kelimeler2);


            }
            else if (categori == "Advanced")
            {
                 sql = "Select * from Advanced";
                 kelimeler3 = context.Database.SqlQuery<AdvancedWords>(sql).ToList();
                 return View(kelimeler3);
            }
          

            return View();
            
          
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult AddWord()
        {
            return View();
        }


        public  ActionResult LogOut()
        {
            //Session.Abandon();
            Session.Clear();
            
            
            return Redirect("/Home/Loginpage");
        }

        
    }

}