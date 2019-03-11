using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using tntroc.Domain.Entities;
using tntroc.Services;
using System.Drawing;
using System.IO;
using tntroc.WebApplication.Models;

namespace tntroc.WebApplication.Controllers
{
    public class SwappersController : Controller
    {

        ISwapperService service = new SwapperService();

        // GET: Swappers
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult toProfile(int idSwapper)
        {
            swapper user = service.Get(u => u.id_swapper == idSwapper);

            ViewBag.user = user;
            if (user.imgPath == null) user.imgPath = "";
            if (user.imgPath.Equals("") && user.sex == Sex.M)
                ViewBag.imgPath = "~/imgs/man.gif";
            else if (user.imgPath.Equals("") && user.sex == Sex.F)
                ViewBag.imgPath = "~/imgs/female.png";
            else
                ViewBag.imgPath = user.imgPath;

            return View();
        }

        public ActionResult toProfile2(int idSwapper, string passError)
        {
            swapper user = service.Get(u => u.id_swapper == idSwapper);

            ViewBag.user = user;
            if (user.imgPath.Equals("") && user.sex == Sex.M)
                ViewBag.imgPath = "~/imgs/man.gif";
            else if (user.imgPath.Equals("") && user.sex == Sex.F)
                ViewBag.imgPath = "~/imgs/female.png";
            else
                ViewBag.imgPath = user.imgPath;


            ViewBag.passError = passError;

            return View("toProfile");
        }

        public ActionResult updateSwapper(int idSwapper)
        {
            swapper user = service.Get(u => u.id_swapper == idSwapper);

            ViewBag.user = user;

            string fName = Request.Form["fName"];
            string lName = Request.Form["lName"];
            string email = Request.Form["email"];
            string adress = Request.Form["adress"];
            string state = Request.Form["state"];
            string phone = Request.Form["phone"];
            string birthday = Request.Form["birthday"];

            int year = int.Parse(birthday.Split('-')[0]);
            int month = int.Parse(birthday.Split('-')[1]);
            int day = int.Parse(birthday.Split('-')[2]);

            user.firstname = fName;
            user.lastname = lName;
            user.email = email;
            user.adress = adress;
            user.state = state;
            user.Phonenumber = long.Parse(phone);

            user.dateofbirth = new DateTime(year, month, day);


            return RedirectToAction("toProfile", new { idSwapper = idSwapper });
        }

        public ActionResult changeSwapperPassword(int idSwapper)
        {
            swapper user = service.Get(u => u.id_swapper == idSwapper);

            ViewBag.user = user;

            string passError ="";

            string currentPass = Request.Form["currentPass"];
            string newPass = Request.Form["newPass"];
            string confirmPass = Request.Form["confirmPass"];


            if(user.password.Equals(currentPass))
            {
                user.password = newPass;

                service.Update(user);
                service.Commit();

            }
            else
            {
                passError = "Wrong password!";
            }
            

            return RedirectToAction("toProfile2", new { idSwapper = idSwapper, passError = passError });
        }

        public ActionResult updateSwapperPhoto(int idSwapper)
        {
            swapper user = service.Get(u => u.id_swapper == idSwapper);

            ViewBag.user = user;


            if (Request.Files[0].ContentLength > 0)
            {
                byte[] file = null;
                using (var binaryReader = new BinaryReader(Request.Files[0].InputStream))
                {
                    file = binaryReader.ReadBytes(Request.Files[0].ContentLength);
                }


                Image img = this.byteArrayToImage(file);
                img = new Bitmap(img, new Size(180, 180));

                string path = "~/swapperImgs/" + user.id_swapper + ".jpg";
                img.Save(Server.MapPath(path), System.Drawing.Imaging.ImageFormat.Jpeg);

                user.imgPath = path;
                service.Update(user);
                service.Commit();
            }

            return RedirectToAction("toProfile", new { idSwapper = idSwapper });
        }


        [HttpGet]
        public ActionResult SearchSwapper()
        {
            return View(new SwapperSearch());
        }



        [HttpPost]
        public ActionResult SearchSwapper(SwapperSearch SwapMod)
        {
            try
            {
                if (SwapMod.txt.Equals(""))
                {
                    SwapMod.res = service.GetAll();
                    SwapMod.txt = "";
                    System.Diagnostics.Debug.WriteLine("  ********* Search Is empty  ");
                    SwapMod.txt = "";
                    return View(SwapMod);
                }

                SwapMod.res = service.GetMany(c => c.firstname.Contains(SwapMod.txt) || c.lastname.Contains(SwapMod.txt));
                // System.Diagnostics.Debug.WriteLine("------------------------------------   :    " + service.GetMany(c => c.firstname.Equals("XX")).Count());
                SwapMod.txt = "";
                return View(SwapMod);
            }
            catch (Exception exp)
            {
                SwapMod.res = service.GetAll();
                SwapMod.txt = "";
                System.Diagnostics.Debug.WriteLine("  ********* Search Is empty  ");
                SwapMod.txt = "";
                return View(SwapMod);
            }
        }

        public ActionResult chatCorner()
        {

            return View();
        }


        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms, true, true);
            return returnImage;
        }



    }
}