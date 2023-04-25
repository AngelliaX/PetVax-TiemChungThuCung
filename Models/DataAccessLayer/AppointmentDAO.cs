using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EntityFramework;

namespace Models.DataAccessLayer
{
    public class AppointmentDAO
    {
        private TiemChungThuCungDbContext context = null;
        public AppointmentDAO()
        {
            context = new TiemChungThuCungDbContext();
        }

        public List<appointment> getAllAppointmentsfromPetList(List<pet> pets)
        {
            var petIds = pets.Select(p => p.pet_id).ToList();
            var list = context.appointments.Where(a => petIds.Contains(a.pet_id)).ToList() ?? new List<appointment>();
            return list;
        }

        public void insertNewAppointment(string pet_id, DateTime date, string note)
        {
            var app = new appointment();
            string lastestAppID = getLatestAppIDonTable();
            app.appointment_id = CommonUseDAO.getTextPart(lastestAppID) + (CommonUseDAO.getNumberPart(lastestAppID) + 1).ToString();
            app.pet_id = pet_id;
            app.state = 0;
            app.init_day = DateTime.Now;
            app.date = date;
            app.note = note;

            context.appointments.Add(app);
            context.SaveChanges();
        }

        private string getLatestAppIDonTable()
        {
            var apps = context.appointments.ToList();

            int lastAppId_Number = 1;
            string lastestAppID = "app_1";
            foreach (var item in apps)
            {
                if (CommonUseDAO.getNumberPart(item.appointment_id) > lastAppId_Number)
                {
                    lastestAppID = item.appointment_id;
                    lastAppId_Number = CommonUseDAO.getNumberPart(item.appointment_id);
                }
            }

            return lastestAppID;
        }
    }
}
