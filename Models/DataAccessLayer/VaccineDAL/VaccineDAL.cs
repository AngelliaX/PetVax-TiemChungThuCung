using Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DataAccessLayer.VaccineDAL
{
    public class VaccineDAL
    {
        TiemChungThuCungDbContext db = null;
        public VaccineDAL()
        {
            db = new TiemChungThuCungDbContext();
        }

        public VaccineModel GetVaccineByLotNumber(string lotNumber)
        {
            var Records = from LotRec in db.vaccine_lot
                          join VcTypeRec in db.vaccine_type
                          on LotRec.vaccine_code equals VcTypeRec.vaccine_code
                          where LotRec.lot_number == lotNumber
                          select new
                          {
                              LotRec.lot_number,
                              VcTypeRec.vaccine_name,
                              LotRec.vaccine_code,
                              LotRec.total_amount,
                              LotRec.remain_amount,
                              LotRec.dose_unit,
                              LotRec.production_date,
                              LotRec.expiration_date,
                              LotRec.rival_date,
                              LotRec.publisher,
                              LotRec.import_price,
                              LotRec.sale_price,
                              LotRec.tax,
                              VcTypeRec.country_of_origin,
                              LotRec.note,
                          };
            VaccineModel vaccine = new VaccineModel();
            vaccine.lot_number = Records.FirstOrDefault().lot_number;
            vaccine.vaccine_name = Records.FirstOrDefault().vaccine_name;
            vaccine.vaccine_code = Records.FirstOrDefault().vaccine_code;
            vaccine.total_amount = Records.FirstOrDefault().total_amount;
            vaccine.remain_amount = Records.FirstOrDefault().remain_amount;
            vaccine.dose_unit = Records.FirstOrDefault().dose_unit;
            vaccine.production_date = Records.FirstOrDefault().production_date;
            vaccine.expiration_date = Records.FirstOrDefault().expiration_date;
            vaccine.rival_date = Records.FirstOrDefault().rival_date;
            vaccine.publisher = Records.FirstOrDefault().publisher;
            vaccine.import_price = Records.FirstOrDefault().import_price;
            vaccine.sale_price = Records.FirstOrDefault().sale_price;
            vaccine.tax = Records.FirstOrDefault().tax;
            vaccine.country_of_origin = Records.FirstOrDefault().country_of_origin;
            vaccine.lot_note = Records.FirstOrDefault().note;

            return vaccine;
        }
        public List<VaccineModel> GetListVaccine()
        {
            var Records = from LotRec in db.vaccine_lot
                              join VcTypeRec in db.vaccine_type
                              on LotRec.vaccine_code equals VcTypeRec.vaccine_code
                              select new
                              {
                                  LotRec.lot_number,
                                  VcTypeRec.vaccine_name,
                                  LotRec.vaccine_code,
                                  LotRec.total_amount,
                                  LotRec.remain_amount,
                                  LotRec.dose_unit,
                                  LotRec.production_date,
                                  LotRec.expiration_date,
                                  LotRec.rival_date,
                                  LotRec.publisher,
                                  LotRec.import_price,
                                  LotRec.sale_price,
                                  LotRec.tax,
                                  VcTypeRec.country_of_origin,
                                  LotRec.note,
                              };
            List<VaccineModel> listVaccine = new List<VaccineModel>();
            foreach(var i in Records.ToList())
            {
                listVaccine.Add(new VaccineModel
                {
                    lot_number = i.lot_number,
                    vaccine_name = i.vaccine_name,
                    vaccine_code = i.vaccine_code,
                    total_amount = i.total_amount,
                    remain_amount = i.remain_amount,
                    dose_unit = i.dose_unit,
                    production_date = i.production_date,
                    expiration_date = i.expiration_date,
                    rival_date = i.rival_date,
                    publisher = i.publisher,
                    import_price = i.import_price,
                    sale_price = i.sale_price,
                    tax = i.tax,
                    country_of_origin = i.country_of_origin,
                    lot_note = i.note
                }) ;
            }
            return listVaccine;
            
        }

        public void Update(VaccineModel vaccine)
        {

        }
    }
}
