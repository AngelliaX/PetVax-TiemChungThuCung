using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.DataAccessLayer;
using Models.EntityFramework;
using TiemChungThuCung.Models;

namespace TiemChungThuCung.Areas.CommonUse
{
    public class PetDocumentCommonUse : Controller
    {
        public string getPetDocument(string petId)
        {
            VaccineDAO vaccineDAO = new VaccineDAO();
            var petvaccineList = vaccineDAO.getList_AllPet_VaccineFromPetId(petId);
            string result = "";

            List<string> diseaseList = new List<string>();
            List<string> detailList = new List<string>();
            foreach (var item in petvaccineList)
            {
                string vaccineName = vaccineDAO.getVaccineNamefromVaccineId(item.vaccine_code);
                string diseaseName = vaccineDAO.getDiseaseNamefromVaccineCode(item.vaccine_code);
                string date = item.vaccine_date.Value.ToString("dd/MM/yyyy");
                int index = diseaseList.IndexOf(diseaseName);

                string detail = detail = "&emsp;&emsp;<span style=\"display: inline-block; width: 32%; white-space: nowrap; overflow: hidden; text-overflow: ellipsis;\">Mũi " + item.dose_order + ": " + vaccineName + "</span><span style=\"display: inline-block; width: 40%; white-space: nowrap; overflow: hidden; text-overflow: ellipsis;\">Ngày hẹn tiêm: " + date + "</span><span style=\"display: inline-block; width: 27%; white-space: nowrap; overflow: hidden; text-overflow: ellipsis;\">Trạng thái: ";

                if (item.state == true)
                {
                    detail += "<span style=\"color: green\">Thành công</span></span>";
                }
                else
                {
                    detail += "<span style=\"color: gray\">Chưa tiêm</span></span>";
                }
                //Trace.WriteLine(detail);

                if (index == -1) // disease does not exist in list
                {
                    diseaseList.Add(diseaseName);
                    detailList.Add(detail);
                }
                else // disease already exists in list
                {
                    detailList[index] += "<br>" + detail;
                }
            }

            for (int i = 0; i < diseaseList.Count; i++)
            {
                result += "<span style=\"font: 16\"><b>• " + diseaseList[i] + ":</b></span>" + "<br>" + detailList[i] + "<br><br>";
            }
            if (string.IsNullOrEmpty(result))
            {
                result = "Chưa có hồ sơ";
            }

            return result;
        }
    }
}