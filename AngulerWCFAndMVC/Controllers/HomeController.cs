using AngulerWCFAndMVC.Models;
using AngulerWCFAndMVC.UserServiceReference;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AngulerWCFAndMVC.Controllers
{
    public class HomeController : Controller
    {
        UserServiceReference.UserServiceClient userService = new UserServiceReference.UserServiceClient();
        EmpTestEntities db = new EmpTestEntities();

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            var test = userService.GetAllUserJson();

            return View();
        }
        public ActionResult GetUsers()
        {
            var test = userService.GetAllUser();
            return Json(test, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetAllUserByWCFServiceThrough()
        {
            var test = userService.GetAllUser();
            return Json(test, JsonRequestBehavior.AllowGet);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            List<UserTable> test = new List<UserTable>();
            test = db.UserTables.AsNoTracking().ToList();
            // return Json(test, JsonRequestBehavior.AllowGet);
            var serializedCompanions = SerializeObject(test);
            return View("Contact");
        }
        public JsonResult UserJson()
        {
            List<UserTable> test = new List<UserTable>();
            test = db.UserTables.AsNoTracking().ToList();

            var serializedCompanions = SerializeObject(test);

            return Json(serializedCompanions, JsonRequestBehavior.AllowGet);
        }
        // GET: All books
        public JsonResult GetAllUser()
        {
            using (EmpTestEntities contextObj = new EmpTestEntities())
            {
                var bookList = contextObj.UserTables.ToList();
                return Json(bookList, JsonRequestBehavior.AllowGet);
            }
        }
        //GET: User by Id
        public JsonResult GetUserById(int Id)
        {
            using (EmpTestEntities contextObj = new EmpTestEntities())
            {
                var getUserById = contextObj.UserTables.Find(Id);
                return Json(getUserById, JsonRequestBehavior.AllowGet);
            }
        }
        // Add book
        [HttpPost]
        public string AddUser(UserTable user)
        {
            if (user != null)
            {
                //Save through WCF serverice "AddNewUser" and pass this model
                UserDataContract objUser = new UserDataContract();
                objUser.Name = user.Name;
                objUser.Address = user.Address;
                objUser.City = user.City;
                userService.AddNewUser(objUser);

                //Save with same project model
                //using (EmpTestEntities contextObj = new EmpTestEntities())
                //{
                //    contextObj.UserTables.Add(user);
                //    contextObj.SaveChanges();
                //}
                
                return "User record added successfully";
            }
            else
            {
                return "Invalid User record";
            }
        }
        // Add book
        [HttpPost]
        public string UpdateUser(UserTable user)
        {
            if (user != null)
            {
                using (EmpTestEntities contextObj = new EmpTestEntities())
                {
                    contextObj.UserTables.Add(user);
                    contextObj.Entry(user).State = EntityState.Modified;
                    contextObj.SaveChanges();
                    return "User record updated successfully";
                }
            }
            else
            {
                return "Invalid User record";
            }
        }
        // Add book
        [HttpPost]
        public string DeleteUserById(int Id)
        {

            using (EmpTestEntities contextObj = new EmpTestEntities())
            {
                var userdetail = contextObj.UserTables.Find(Id);
                contextObj.UserTables.Remove(userdetail);
                contextObj.SaveChanges();
                return "User record deleted successfully";
            }

        }
        public static IHtmlString SerializeObject(object value)
        {
            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var serializer = new JsonSerializer
                {
                    // Let's use camelCasing as is common practice in JavaScript
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };

                // We don't want quotes around object names
                jsonWriter.QuoteName = false;
                serializer.Serialize(jsonWriter, value);

                return new HtmlString(stringWriter.ToString());
            }
        }
    }
}
