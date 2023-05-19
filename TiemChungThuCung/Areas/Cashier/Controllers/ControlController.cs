using Models.DataAccessLayer.BillDAL;
using Models.DataAccessLayer.VaccineDAL;
using Models.DataAccessLayer.ClientDAL;
using Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Management;
using System.Web.Mvc;
using TiemChungThuCung.Areas.Cashier.Model;

namespace TiemChungThuCung.Areas.Cashier.Controllers
{
    public class ControlController : Controller
    {
        // GET: Cashier/Controll
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home", new {area = "Cashier"});
        }
        public ActionResult BillList()
        { 
            return View();
        }
        public ActionResult BillCreateOptions()
        {
            return View();
        }
        public ActionResult CheckAccount()
        {
            bill model = new bill();
            return View(model);
        }

        [HttpPost]
        public ActionResult CheckAccount(bill Bill)
        {
            Bill.bill_id = new BillDAL().GetBillId();
            Bill.init_date = DateTime.Now;
            Bill.total_cost = 0;
            if (!ModelState.IsValid)
            {
                if (Bill.client_username == null)
                {
                    ModelState.AddModelError("client_username", "Vui lòng không để trống");
                    ModelState.AddModelError("", "Vui lòng nhập đầy đủ");
                    return View(Bill);
                }
                else
                {
                    ModelState.AddModelError("", "Vui lòng nhập đầy đủ");
                    return View(Bill);
                }
            }
            else
            {
                if (Bill.client_username == null)
                {
                    ModelState.AddModelError("client_username", "Vui lòng không để trống");
                    ModelState.AddModelError("", "Vui lòng nhập đầy đủ");
                    return View(Bill);
                }
                if (new BillDAL().CheckIfBillIsExist(Bill.bill_id))
                {
                    ModelState.AddModelError("", "Vui lòng kiểm tra lại dữ liệu nhập");
                    return View(Bill);
                }
                if (!new ClientDAL().CheckIfClientIsExist(Bill.client_username))
                {
                    ModelState.AddModelError("client_username", "Username không tồn tại");
                    ModelState.AddModelError("", "Vui lòng kiểm tra lại dữ liệu nhập");
                    return View(Bill);
                }
                else return RedirectToAction("AddBillVaccine", new { BillID = Bill.bill_id, ClientUsername = Bill.client_username });

            }
        }


        public ActionResult Add()
        {
            bill model = new bill();
            return View(model);
        }

       

        [HttpPost]
        public ActionResult Add(bill Bill)
        {
            Bill.bill_id = new BillDAL().GetBillId();
            Bill.init_date = DateTime.Now;
            Bill.total_cost = 0;
            if(!ModelState.IsValid)
            {
                if(Bill.client_username == null)
                {
                    ModelState.AddModelError("client_username", "Vui lòng không để trống");
                    ModelState.AddModelError("","Vui lòng nhập đầy đủ");
                    return View(Bill);
                }
                else
                {
                    ModelState.AddModelError("", "Vui lòng nhập đầy đủ");
                    return View(Bill);
                }
            }
            else
            {
                if (Bill.client_username == null)
                {
                    ModelState.AddModelError("client_username", "Vui lòng không để trống");
                    ModelState.AddModelError("", "Vui lòng nhập đầy đủ");
                    return View(Bill);
                }
                if (new BillDAL().CheckIfBillIsExist(Bill.bill_id))
                {
                    ModelState.AddModelError("", "Vui lòng kiểm tra lại dữ liệu nhập");
                    return View(Bill);
                }
                if(!new ClientDAL().CheckIfClientIsExist(Bill.client_username))
                {
                    ModelState.AddModelError("client_username", "Username không tồn tại");
                    ModelState.AddModelError("", "Vui lòng kiểm tra lại dữ liệu nhập");
                    return View(Bill);
                }
                else return RedirectToAction("AddBillVaccine", new {BillID = Bill.bill_id, ClientUsername = Bill.client_username});
                
            }
        }
        
        public ActionResult AddBillVaccine(string BillID, string ClientUsername)
        {
            //khoi tao list record cua bill_vaccine
            List<BillRecordModel> models = new List<BillRecordModel>();
            models.Add(new BillRecordModel
            {
                bill_id = BillID,
                client_username = ClientUsername
            });
            return View(models);
        }

        [HttpPost]
        public ActionResult AddBillVaccine(List<BillRecordModel> models, string description, string AddRowButton, string ConfirmButton, string CancelButton)
        {
            for (int i = 0; i < models.Count; i++)
            {
                if (!new VaccineTypeDAL().CheckIfVaccineCodeIsExist(models[i].vaccine_code)) ModelState.AddModelError("[" + i + "].vaccine_code", "Mã vaccine không tồn tại");
            }
            if (ModelState.IsValid)
            {
                //Them row vao bill
                if (!string.IsNullOrEmpty(AddRowButton))
                {
                    models.Add(new BillRecordModel
                    {
                        bill_id = models[0].bill_id,
                        client_username = models[0].client_username,
                        //vaccine_code = models.Last().vaccine_code,
                        //dose_unit = models.Last().dose_unit,
                        //amount = models.Last().amount,
                    });
                    return View(models);
                }
                //Them bill vao database
                else if (!string.IsNullOrEmpty(ConfirmButton))
                {
                    //khoi tao list bill va bill vaccine
                    bill BillToAddDB = new bill();
                    List<bill_vaccine> BillVaccineToAddDB = new List<bill_vaccine>();

                    //Kiem tra so luong vaccine
                    bool CheckAmountIfValid = false;
                    int tmp = 0;
                    for (int i = 0; i < models.Count; i++)
                    {
                        if (models[i].amount > new VaccineTypeDAL().GetAmountOfVaccineType(models[i].vaccine_code))
                        {
                            tmp++;
                            ModelState.AddModelError("[" + i + "].vaccine_code", "Số lượng vaccine đã hết");
                        }
                    }
                    if (tmp == 0) CheckAmountIfValid = true;
                    if (CheckAmountIfValid == false)
                    {
                        return View(models);
                       
                    }
                    else
                    {

                        //them gia tri vao bill vaccine
                        foreach (BillRecordModel model in models)
                        {
                            BillVaccineToAddDB.Add(new bill_vaccine()
                            {
                                bill_id = model.bill_id,

                                vaccine_lot_number = new VaccineTypeDAL().GetAppropriateVaccineLotByVaccineCode(model.vaccine_code).lot_number,
                                amount = model.amount,
                                cost = new VaccineTypeDAL().GetAppropriateVaccineLotByVaccineCode(model.vaccine_code).sale_price * model.amount
                            });
                        }

                        //them gia tri vao bill
                        BillToAddDB.bill_id = models[0].bill_id;
                        BillToAddDB.client_username = models[0].client_username;
                        BillToAddDB.init_date = DateTime.Now;
                        BillToAddDB.total_cost = 0;
                        foreach (bill_vaccine i in BillVaccineToAddDB)
                        {
                            BillToAddDB.total_cost += i.cost;
                        }
                        BillToAddDB.description = description;


                        //Add bill vao database
                        new BillDAL().AddBill(BillToAddDB);

                        //Add bill_vaccine vao database
                        BillVaccineDAL DAL = new BillVaccineDAL();
                        foreach (bill_vaccine i in BillVaccineToAddDB)
                        {
                            DAL.AddBillVaccine(i);
                        }
                        TempData["AddBillSuccess"] = "Tạo hóa đơn thành công";
                        return View(models);
                    }
                }
                else
                {
                    return View(models);
                }
            }
                
            
            else
            {
                ModelState.AddModelError("", "Vui lòng kiểm tra lại dữ liệu nhập");
                return View(models);
            }
          
        }

        public ActionResult ListBill()
        {
            List<bill> models = new BillDAL().GetAllBillList();
            return View(models);
        }
        public ActionResult Detail(string BillID)
        {
            List<bill_vaccine> models = new BillVaccineDAL().GetListBillVaccineByBillID(BillID);
            return View(models);
        }

        public ActionResult Edit(string BillID)
        {
            List<BillRecordModel> models = new List<BillRecordModel>();
            List<bill_vaccine> list = new BillVaccineDAL().GetListBillVaccineByBillID(BillID);
            foreach(var i in list)
            {
                models.Add(new BillRecordModel()
                {
                    bill_id = i.bill_id,
                    vaccine_code = i.vaccine_lot.vaccine_code,
                    client_username = i.bill.client_username,
                    dose_unit = i.vaccine_lot.dose_unit,
                    amount = i.amount

                });
            }
            return View(models);
        }

        [HttpPost]
        public ActionResult Edit(List<BillRecordModel> models, string description, string AddRowButton, string ConfirmButton, string CancelButton)
        {
            for (int i = 0; i < models.Count; i++)
            {
                if (!new VaccineTypeDAL().CheckIfVaccineCodeIsExist(models[i].vaccine_code)) ModelState.AddModelError("[" + i + "].vaccine_code", "Mã vaccine không tồn tại");
            }
            if (ModelState.IsValid)
            {
                //Them row vao bill
                if (!string.IsNullOrEmpty(AddRowButton))
                {
                    models.Add(new BillRecordModel
                    {
                        bill_id = models[0].bill_id,
                        client_username = models[0].client_username,
                        //vaccine_code = models.Last().vaccine_code,
                        //dose_unit = models.Last().dose_unit,
                        //amount = models.Last().amount,
                    });
                    return View(models);
                }
                //Them bill vao database
                else if (!string.IsNullOrEmpty(ConfirmButton))
                {
                    //khoi tao list bill va bill vaccine
                    bill BillToAddDB = new bill();
                    List<bill_vaccine> BillVaccineToAddDB = new List<bill_vaccine>();

                    //Kiem tra so luong vaccine
                    bool CheckAmountIfValid = false;
                    int tmp = 0;
                    for (int i = 0; i < models.Count; i++)
                    {
                        if (models[i].amount > new VaccineTypeDAL().GetAmountOfVaccineType(models[i].vaccine_code))
                        {
                            tmp++;
                            ModelState.AddModelError("[" + i + "].vaccine_code", "Số lượng vaccine đã hết");
                        }
                    }
                    if (tmp == 0) CheckAmountIfValid = true;
                    if (CheckAmountIfValid == false)
                    {
                        return View(models);

                    }
                    else
                    {

                        //them gia tri vao bill vaccine
                        foreach (BillRecordModel model in models)
                        {
                            BillVaccineToAddDB.Add(new bill_vaccine()
                            {
                                bill_id = model.bill_id,

                                vaccine_lot_number = new VaccineTypeDAL().GetAppropriateVaccineLotByVaccineCode(model.vaccine_code).lot_number,
                                amount = model.amount,
                                cost = new VaccineTypeDAL().GetAppropriateVaccineLotByVaccineCode(model.vaccine_code).sale_price * model.amount
                            });
                        }

                        //them gia tri vao bill
                        BillToAddDB.bill_id = models[0].bill_id;
                        BillToAddDB.client_username = models[0].client_username;
                        BillToAddDB.init_date = DateTime.Now;
                        BillToAddDB.total_cost = 0;
                        foreach (bill_vaccine i in BillVaccineToAddDB)
                        {
                            BillToAddDB.total_cost += i.cost;
                        }
                        BillToAddDB.description = description;


                        //Add bill vao database
                        new BillDAL().AddBill(BillToAddDB);

                        //Add bill_vaccine vao database
                        BillVaccineDAL DAL = new BillVaccineDAL();
                        foreach (bill_vaccine i in BillVaccineToAddDB)
                        {
                            DAL.AddBillVaccine(i);
                        }
                        TempData["AddBillSuccess"] = "Tạo hóa đơn thành công";
                        return View(models);
                    }
                }
                else
                {
                    return View(models);
                }
            }


            else
            {
                ModelState.AddModelError("", "Vui lòng kiểm tra lại dữ liệu nhập");
                return View(models);
            }
        }

        public ActionResult Delete(string BillID) 
        {
            new BillDAL().DeleteBill(BillID);

            return RedirectToAction("ListBill");
        }

    }
}