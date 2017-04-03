using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.ServiceModel;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using WCFRest.Model;

namespace WCFRest
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UserService.svc or UserService.svc.cs at the Solution Explorer and start debugging.
    public class UserService : IUserService
    {

        EmpTestEntities db;
        public UserService()
        {
            db = new EmpTestEntities();
        }

        public List<UserDataContract> GetAllUser()
        {
            var query = (from a in db.UserTables
                         select a).Distinct();

            List<UserDataContract> UserList = new List<UserDataContract>();

            query.ToList().ForEach(rec =>
            {
                UserList.Add(new UserDataContract
                {
                    Id = rec.Id,
                    Name = rec.Name,
                    Address = rec.Address,
                    City = rec.City,
                });
            });
            return UserList;
        }

        public UserDataContract GetUserDetails(int Id)
        {
            UserDataContract User = new UserDataContract();

            try
            {

                var query = (from a in db.UserTables
                             where a.Id.Equals(Id)
                             select a).Distinct().FirstOrDefault();

                User.Id = query.Id;
                User.Name = query.Name;
                User.Address = query.Address;
                User.City = query.City;
            }
            catch (Exception ex)
            {
                throw new FaultException<string>
                        (ex.Message);
            }
            return User;
        }

        public bool AddNewUser(UserDataContract Users)
        {
            try
            {
                UserTable user = db.UserTables.Create();
                user.Name = Users.Name;
                user.Address = Users.City;
                user.City = Users.City;
                db.UserTables.Add(user);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new FaultException<string>
                        (ex.Message);
            }
            return true;
        }

        public void UpdateUser(UserDataContract Users)
        {
            try
            {
                UserTable user = db.UserTables.Create();
                user.Name = Users.Name;
                user.Address = Users.City;
                user.City = Users.City;
                db.UserTables.Add(user);
                db.SaveChanges();

                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new FaultException<string>
                        (ex.Message);
            }
        }

        public void DeleteUser(int Id)
        {
            try
            {

                UserTable user = db.UserTables.Where(rec => rec.Id == Id).FirstOrDefault();
                db.UserTables.Remove(user);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new FaultException<string>
                        (ex.Message);
            }
        }

        public string GetAllUserJson()
        {
            var query = (from a in db.UserTables
                         select a).Distinct();

            List<UserDataContract> UserList = new List<UserDataContract>();

            query.ToList().ForEach(rec =>
            {
                UserList.Add(new UserDataContract
                {
                    Id = rec.Id,
                    Name = rec.Name,
                    Address = rec.Address,
                    City = rec.City,
                });
            });
            // Serialize the results as JSON
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(UserList.GetType());
            MemoryStream memoryStream = new MemoryStream();
            serializer.WriteObject(memoryStream, UserList);

            // Return the results serialized as JSON
            string json = Encoding.Default.GetString(memoryStream.ToArray());
            return json;
            // return UserList;
        }

        public void GetTemp()
        {
            //int year = 2005;
            //XDocument doc = XDocument.Load("D:\\PC Backup\\AngularAndMVC\\WCFRest\\XML\\TempXML.xml");

            //string productName =
            //    (from result in doc.Descendants("bookstore")
            //    .Descendants("book")
            //     where result.Element("year").Value
            //         == year.ToString()
            //     select result.Element("author").Value)
            //    .FirstOrDefault<string>();


            //var  listtest =
            //  (from result in doc.Descendants("bookstore")
            //  .Descendants("book")
            //   select result.Element("author").Value).ToList<string>();

            //var listtest1 =
            // (from result in doc.Descendants("bookstore")
            //  select result.ToString()).ToList<string>();

            XmlDocument xDoc = new XmlDocument();
            // xDoc.Load("Your Xml File Path");
            xDoc.Load("D:\\PC Backup\\AngularAndMVC\\WCFRest\\XML\\TempXML.xml");
            XmlNodeList xEmpList = xDoc.GetElementsByTagName("book");
            foreach (XmlNode xNode in xEmpList)
            {
                var test = xNode["title"].InnerText;
                XmlNodeList xEmpListsub = xDoc.GetElementsByTagName("booksub");
                foreach (XmlNode xNodesub in xEmpListsub)
                {
                    var testsub = xNodesub["titlesub"].InnerText;
                }

                //Employee emp = new Employee();
                //emp.EmpCode = Convert.ToInt32(xNode["Code"].InnerText);
                //emp.EmpName = xNode["Name"].InnerText;
                //emp.EmpAddress = xNode["Address"].InnerText;
                //emp.EmpDOJ = Convert.ToDateTime(xNode["DOJ"].InnerText);
                //emp.EmpSalary = Convert.ToInt32(xNode["Salary"].InnerText);
                //lstEmp.Add(emp);

            }
          //  return productName;
        }
    }
}
