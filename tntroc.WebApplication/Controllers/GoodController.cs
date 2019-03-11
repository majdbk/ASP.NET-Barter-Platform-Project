
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tntroc.Data.Infrastructure;
using tntroc.Domain.Entities;
using tntroc.Services;
using tntroc.WebApplication.Models;


namespace tntroc.WebApplication.Controllers
{
    public class GoodController : Controller
    {

        ISwapperService swapperService = new SwapperService();
        ICategoryService categoryService = new CategoryService();
        ISubCategoryService subCategoryService = new SubCategoryService();



        IGoodService service = new GoodService();
        public GoodController()
        {

        }

        // GET: Category
        public ActionResult Index()
        {
            return View();
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult SearchGood()
        {
            category bestCategory = service.mostRatedCategory();
            ViewBag.bestCat = bestCategory.name;

            return View(new GoodModels());
        }

        [HttpPost]
       public ActionResult SearchGood(GoodModels SwapMod)
        {
            if (SwapMod.txt == null)
                SwapMod.txt = "";

            category bestCategory = service.mostRatedCategory();
            System.Diagnostics.Debug.WriteLine("--  MRC =" + bestCategory.name);
            ViewBag.bestCat = bestCategory.name;

          
            if (SwapMod.txt.Equals(""))
                {
                    SwapMod.listGoods = service.GetAll();                  
                    SwapMod.txtSearch = "";
          
                return View("SearchGood", SwapMod);
                }
                SwapMod.listGoods
                     = service.GetMany(c => c.label.Contains(SwapMod.txt));
         
                SwapMod.txtSearch = "";
                return View("SearchGood", SwapMod);

                
            
        }

        public ActionResult SearchGoodSort(GoodModels SwapMod)
        {
            
                SwapMod.listGoods = service.searchByScore();
                SwapMod.txtSearch = "";
                System.Diagnostics.Debug.WriteLine("------------------------------------   :    Vide !!");
                return View("SearchGood", SwapMod);
            
           

        }
        public ActionResult SearchMyGood(GoodModels SwapMod)
        {

            int idSwapper = 1; //utilisateur connecté

            ViewBag.deleted = false;

            if (SwapMod.txt == null)
                SwapMod.txt = "";

            System.Diagnostics.Debug.WriteLine("------------------------------------   :    STR =" + SwapMod.txt);
            if (SwapMod.txt.Equals(""))
            {
                SwapMod.listGoods = service.GetMany(c => c.swapperID == idSwapper);
                SwapMod.txtSearch = "";
               // System.Diagnostics.Debug.WriteLine("------------------------------------   :    Vide !!");
                return View("SearchMyGood", SwapMod);
            }
            SwapMod.listGoods
                 = service.GetMany(c => c.label.Contains(SwapMod.txt) & c.swapperID == idSwapper);
               //System.Diagnostics.Debug.WriteLine("------------------------------------   :    Done !!");
            SwapMod.txtSearch = "";

            

            return View("SearchMyGood", SwapMod);

        }

        public ActionResult SearchMyGood2(GoodModels SwapMod)
        {

            int idSwapper = 1; //utilisateur connecté

            ViewBag.deleted = true;

            if (SwapMod.txt == null)
                SwapMod.txt = "";

            System.Diagnostics.Debug.WriteLine("------------------------------------   :    STR =" + SwapMod.txt);
            if (SwapMod.txt.Equals(""))
            {
                SwapMod.listGoods = service.GetMany(c => c.swapperID == idSwapper);
                SwapMod.txtSearch = "";
                // System.Diagnostics.Debug.WriteLine("------------------------------------   :    Vide !!");
                return View("SearchMyGood", SwapMod);
            }
            SwapMod.listGoods
                 = service.GetMany(c => c.label.Contains(SwapMod.txt) & c.swapperID == idSwapper);
            //System.Diagnostics.Debug.WriteLine("------------------------------------   :    Done !!");
            SwapMod.txtSearch = "";

            

            return View("SearchMyGood", SwapMod);

        }



        public ActionResult renderAddGoods()
        {
            int connectedSwapper = 1; // identity connected user

            swapper user = swapperService.Get(u => u.id_swapper == connectedSwapper);

            ViewBag.user = user;

            IEnumerable<category> categories = categoryService.GetAll();

            category cat = categories.First();
            IEnumerable<subCategory> subCategories = subCategoryService.GetMany(s => s.categoryID == cat.id_category);

            ViewBag.categories = categories;
            ViewBag.subCategories = subCategories;

            return View();
        }

        public string getTheSubCategories()
        {
            int idCategory = int.Parse(Request.Form["catSelect"]);

            category theCategory = categoryService.Get(c => c.id_category == idCategory);

            IEnumerable<subCategory> theSubCategories = subCategoryService.GetMany(s => s.categoryID == theCategory.id_category);

            string ch = "";

            
            foreach (subCategory s in theSubCategories)
            {
                ch += "<option value=" +s.id_subCategory + ">" + s.name + "</option>";
            }

            return ch;

        }

        [HttpPost]
        public ActionResult addGoods()
        {
            
           

           

            service = new GoodService();

            swapperService = new SwapperService();
            categoryService = new CategoryService();
            subCategoryService = new SubCategoryService();


            int connectedSwapper = 1; // connected swapper -identity

            swapper user = swapperService.Get(u => u.id_swapper == connectedSwapper);

            ViewBag.user = user;


            string brand = Request.Form["brand"];
            string description = Request.Form["desc"];
            DateTime date = DateTime.Now;
            int validity = 0;
            int quantity = int.Parse(Request.Form["quantity"]);
            string label = Request.Form["label"];
            Accpted accepted = Accpted.no;

            int catId = int.Parse(Request.Form["cat"]);
            //category cat = categoryService.Get(c => c.id_category == catId);
            
            int subCatId = int.Parse(Request.Form["subCat"]);
            //subCategory subCat = subCategoryService.Get(sc => sc.id_subCategory == subCatId);

            goods newGood = new goods();
            newGood.label = label;
            newGood.brand = brand;
            newGood.description = description;
            newGood.date = date;
            newGood.validity = validity;
            newGood.quantity = quantity;
            newGood.accepted = accepted;

            //subCat.category = cat;

            newGood.subCategoryID = subCatId;
            newGood.swapperID = user.id_swapper;
            service.Add(newGood);
            service.Commit();



            if (Request.Files[0].ContentLength > 0) // on a ajouté une image pour le produit
            {
                byte[] file = null;
                using (var binaryReader = new BinaryReader(Request.Files[0].InputStream))
                {
                    file = binaryReader.ReadBytes(Request.Files[0].ContentLength);
                }


                Image img = this.byteArrayToImage(file);
                img = new Bitmap(img, new Size(180, 180));

                string path = "~/swapperImgs/" + newGood.id_goods + ".jpg";
                img.Save(Server.MapPath(path), System.Drawing.Imaging.ImageFormat.Jpeg);


                newGood.image = path;
                service.Update(newGood);
                service.Commit();
            }
           


            

            return RedirectToAction("SearchGood");
        }

        [HttpPost]
        public String SaveScore()
        {

            int score = int.Parse(Request.Form["rate"]);
            int id = int.Parse(Request.Form["id"]);
            goods g = service.GetById(id);
            g.score =  (g.score+score)/2;
            service.Update(g);
            service.Commit();
           
            return g.score.ToString();

        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms, true, true);
            return returnImage;
        }

        public ActionResult UpdateMyGood(int id)
        {
            GoodModels GM = new GoodModels();
            GM.goood = service.GetById(id);

            List<category> categories = new List<category>();
            categories.Add(GM.goood.subCategory.category);
            categories.AddRange(categoryService.GetMany(c => c.id_category != GM.goood.subCategory.categoryID));
            
            IEnumerable<subCategory> subCategories = subCategoryService.GetMany(s => s.categoryID == GM.goood.subCategory.category.id_category);

            ViewBag.categories = categories;
            ViewBag.subCategories = subCategories;

            return View(GM);
        }


        public ActionResult DeleteMyGood(int id)
        {
            
            GoodModels GM = new GoodModels();
            GM.goood = service.GetById(id);

            service.Delete(GM.goood);
            service.Commit();

            
            return RedirectToAction("SearchMyGood2");



        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult SaveMyGood(GoodModels GM)
        {


            System.Diagnostics.Debug.WriteLine("------------------------------------   :    " +GM.goood.id_goods);


            service = new GoodService();

            swapperService = new SwapperService();
            categoryService = new CategoryService();
            subCategoryService = new SubCategoryService();


            int connectedSwapper = 1;

            swapper user = swapperService.Get(u => u.id_swapper == connectedSwapper);

            ViewBag.user = user;


            string brand = Request.Form["brand"];
            string description = Request.Form["desc"];
            DateTime date = DateTime.Now;
            int validity = 0;
            int quantity = int.Parse(Request.Form["quantity"]);
            string label = Request.Form["label"];

            int idGood = int.Parse(Request.Form["idGood"]);

            Accpted accepted = Accpted.no;

            int catId = int.Parse(Request.Form["cat"]);
            //category cat = categoryService.Get(c => c.id_category == catId);

            int subCatId = int.Parse(Request.Form["subCat"]);
            //subCategory subCat = subCategoryService.Get(sc => sc.id_subCategory == subCatId);

            GM.goood = service.GetById(idGood);
            GM.goood.label = label;
            GM.goood.brand = brand;
            GM.goood.description = description;
            GM.goood.date = date;
            GM.goood.validity = validity;
            GM.goood.quantity = quantity;
            GM.goood.accepted = accepted;

            //subCat.category = cat;

            GM.goood.subCategoryID = subCatId;
            GM.goood.swapperID = user.id_swapper;
       
            service.Update(GM.goood);
            service.Commit();



            if (Request.Files[0].ContentLength > 0)
            {
                byte[] file = null;
                using (var binaryReader = new BinaryReader(Request.Files[0].InputStream))
                {
                    file = binaryReader.ReadBytes(Request.Files[0].ContentLength);
                }


                Image img = this.byteArrayToImage(file);
                img = new Bitmap(img, new Size(180, 180));

                string path = "~/swapperImgs/" + GM.goood.id_goods + ".jpg";
                img.Save(Server.MapPath(path), System.Drawing.Imaging.ImageFormat.Jpeg);

                GM.goood.image = path;
                service.Update(GM.goood);
                service.Commit();
            }

            return RedirectToAction("SearchMyGood");
        }


    }
}
