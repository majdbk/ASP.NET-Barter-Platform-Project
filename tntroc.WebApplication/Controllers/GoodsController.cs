using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tntroc.Data.Infrastructure;
using tntroc.Services;
using tntroc.WebApplication.Models;

using tntroc.Domain.Entities;
using tntroc.WebApplication.Helpers;


namespace tntroc.WebApplication.Controllers
{

    public partial class GoodsController : Controller
    {

        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);

        EchangeService ce = null;
        GoodsService ca = null;
        public GoodsController()
        {
            ca = new GoodsService();
            ce = new EchangeService();
        }
        // GET: Goods
        public ActionResult Index()
        {
            var good = ca.GoodsValid();
            List<GoodsModels> fVM = new List<GoodsModels>();
            foreach (var item in good)

                if (item.swapperID != 1)  //current user
                {
                    fVM.Add(
                        new GoodsModels
                        {
                            
                            brand = item.brand,
                            description = item.description,
                            date = item.date,
                            label = item.label,
                            quantity = item.quantity,
                            subCategoryID = item.subCategoryID,
                            swapperID = item.swapperID,
                            subCategory = item.subCategory,
                            image = item.image



                        });
                }


            return View(fVM);
        }

        // GET: Goods/Details/5
        public ActionResult Details(int id)
        {
            var good = ca.GoodsDetails(id);
            GoodsModels item = new GoodsModels();
            item.id_goods = good.id_goods;
            item.label = good.label;
            item.quantity = good.quantity;
            item.description = good.description;
            item.subCategoryID = good.subCategoryID;
            item.swapperID = good.swapperID;
            //item.subCategory.name = good.subCategory.name;
            //item.subCategory.description = good.subCategory.description;
            item.subCategory = good.subCategory;
            item.swapper = good.swapper;
            item.image = good.image;
            item.brand = good.brand;
            return View(item);
        }



        public ActionResult DetailsPartner(int id)
        {
            var good = ca.GoodsDetails(id);
            GoodsModels item = new GoodsModels();
            item.id_goods = good.id_goods;
            item.label = good.label;
            item.quantity = good.quantity;
            item.description = good.description;
            item.subCategoryID = good.subCategoryID;
            item.swapperID = good.swapperID;
            //item.subCategory.name = good.subCategory.name;
            //item.subCategory.description = good.subCategory.description;
            item.subCategory = good.subCategory;
            item.swapper = good.swapper;
            item.image = good.image;
            item.brand = good.brand;
            return View(item);
        }


        // GET: Goods/Create
        public ActionResult Create(int id)
        {


            var echangeVM = new ExchangeModels();
            echangeVM.offres = ca.ConsultGoods2(1).ToSelectListItems();//current user
            echangeVM.idgooddemande = id;
            //echangeVM.id_exchange = 1;
            // echangeVM.status = 0;



            //List<string> genres = new List<string> { "Comedy", "Action", "Horror" };
            // echangeVM.status = genres.ToSelectListItems();
            return View(echangeVM);
        }

        // POST: Goods/Create
        [HttpPost]
        public ActionResult Create(ExchangeModels e)
        {
            //if (!ModelState.IsValid)
            //{
            //     RedirectToAction("Create");
            // }
            Boolean verif = ce.verif(e.idgooddemande, e.idgoodOffre);
            Boolean verif2 = ce.verif(e.idgoodOffre, e.idgooddemande);

            if (!ModelState.IsValid)
            {

                //ModelState.AddModelError("CustomError", "The Same test Type might have been already created,, go back to the Visit page to see the avilalbe Lab Tests");
                e.offres = ca.ConsultGoods2(1).ToSelectListItems();
                return View(e);
            }

            else if (verif2 == true)
            {
                ModelState.AddModelError("CustomError", "The Same exchange request might have been already created with this product");
                e.offres = ca.ConsultGoods2(1).ToSelectListItems();
                return View(e);
            }

            else if (verif == true)
            {
                ModelState.AddModelError("CustomError", "The Same exchange request might have been already created by the owner of the product you desire,, go back to your exchange section and verify it's presence");
                e.offres = ca.ConsultGoods2(1).ToSelectListItems();
                return View(e);
            }

            else
            {
                exchange ech = new exchange
                {

                    date_exchange = e.date_exchange,
                    idgooddemande = e.idgooddemande,
                    status = 0,
                    idgoodOffre = e.idgoodOffre,
                    id_exchange = e.id_exchange,


                };



                ce.Add(ech);
                ce.Commit();



                // return Content("Item not found");
                // ModelState.AddModelError("", "votre compte est verouiller.");
                // RedirectToAction("Create", new { id = e.idgooddemande });
                // RedirectToAction("IndexPersonnel");

            }
            return RedirectToAction("Index");

        }
        // GET: Goods/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Goods/Edit/5
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

        // GET: Goods/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Goods/Delete/5
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

        public ActionResult ConsultSwaper(int id)
        {
            var user = ca.ConsultSwaper(id);
            SwaperModels item = new SwaperModels();
            item.firstname = user.firstname;
            item.lastname = user.lastname;
            item.adress = user.adress;
            item.email = user.email;
            item.Phonenumber = (int)user.Phonenumber;
            item.id_swapper = user.id_swapper;
            item.dateofbirth = user.dateofbirth;
            item.state = user.state;

            return View(item);
        }


        public ActionResult ConsultGoods(int id)
        {
            var good = ca.ConsultGoods(id);
            List<GoodsModels> fVM = new List<GoodsModels>();
            foreach (var item in good)
            {
                fVM.Add(
                    new GoodsModels
                    {

                        id_goods = item.id_goods,
                        brand = item.brand,
                        description = item.description,
                        date = item.date,
                        label = item.label,
                        quantity = item.quantity,
                        subCategoryID = item.subCategoryID,
                        swapperID = item.swapperID,
                        subCategory = item.subCategory,
                        image = item.image

                    });
            }

            return View(fVM);
        }

        public ActionResult IndexPersonnel()
        {
            ModelState.Clear();
            var good = ca.ConsultGoods2(1);//current user
            List<GoodsModels> fVM = new List<GoodsModels>();
            foreach (var item in good)
            {
                fVM.Add(
                    new GoodsModels
                    {
                        id_goods = item.id_goods,
                        brand = item.brand,
                        description = item.description,
                        date = item.date,
                        label = item.label,
                        quantity = item.quantity,
                        subCategoryID = item.subCategoryID,
                        swapperID = item.swapperID,
                        subCategory = item.subCategory,
                        image = item.image




                    });
            }


            return View(fVM);
        }

        public ActionResult RequestEchange(int id)
        {



            ModelState.Clear();
            var good = ce.ConsultRequest(id);
            List<ExchangeModels> fVM = new List<ExchangeModels>();
            foreach (var item in good)
            {
                fVM.Add(
                    new ExchangeModels
                    {
                        id_exchange = item.id_exchange,
                        idgooddemande = item.idgooddemande,
                        goodOffre = item.goodOffre,
                        date_exchange = item.date_exchange,
                        goodDemande = item.goodDemande,
                        idgoodOffre = item.idgoodOffre,
                        status = item.status,





                    });
            }


            return View(fVM);
        }


        public ActionResult AcceptEchange(int id)
        {

            //  int i = ce.ConsultRequestCount(id2);






            //if (!ModelState.IsValid)
            //{
            //     RedirectToAction("Create");
            // }
            exchange ech = ce.GetById(id);
            // exchange ech = ce.EchangeDetails(id);
            ech.status = Domain.Entities.Statusexchange.accepted;

            ce.Update(ech);
            ce.Commit();




            return RedirectToAction("IndexPersonnel");
        }
        public ActionResult CancelEchange(int id)
        {
            //if (!ModelState.IsValid)
            //{
            //     RedirectToAction("Create");
            // }
            exchange ech = ce.GetById(id);
            // exchange ech = ce.EchangeDetails(id);
            ech.status = Domain.Entities.Statusexchange.canceled;

            ce.Update(ech);
            ce.Commit();
            return RedirectToAction("IndexPersonnel");




        }
        public ActionResult SentEchange(int id)
        {

            ModelState.Clear();
            var good = ce.ConsultSent(id);
            List<ExchangeModels> fVM = new List<ExchangeModels>();
            foreach (var item in good)
            {
                fVM.Add(
                    new ExchangeModels
                    {
                        id_exchange = item.id_exchange,
                        idgooddemande = item.idgooddemande,
                        goodOffre = item.goodOffre,
                        date_exchange = item.date_exchange,
                        goodDemande = item.goodDemande,
                        idgoodOffre = item.idgoodOffre,
                        status = item.status,





                    });
            }


            return View(fVM);
        }



        public ActionResult ChartApi()
        {
            ModelState.Clear();
            var good = ce.teststat();
            List<ExchangeModels> fVM = new List<ExchangeModels>();
            foreach (var item in good)


                fVM.Add(
                      new ExchangeModels
                      {
                          id_exchange = item.id_exchange,

                          date_exchange = item.date_exchange,
                          status = item.status,
                          goodDemande = item.goodDemande,
                          goodOffre = item.goodOffre,
                          idgooddemande = item.idgooddemande,
                          idgoodOffre = item.idgoodOffre



                      });


            ViewData["fVM"] = fVM;
            return View();





        }
       
        public ActionResult chart()
        {
            return View();
        }

        public ActionResult chart2()
        {
            return View();
        }
    }
}