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

        public appointment getAppointmentById(string appId)
        {
            var app = context.appointments.FirstOrDefault(a => a.appointment_id == appId) ?? new appointment();
            return app;
        }

        //should get the appointment from context then update it, shoulnd passs the appointment directly into the function
        public void setDoctorforApp(string appId, string doctor_username)
        {
            var app = context.appointments.FirstOrDefault(a => a.appointment_id == appId) ?? new appointment();
            app.doctor_username = doctor_username;
            app.state = 1;
            context.SaveChanges();
        }

        public List<appointment> getUpcommingAppointmentsOfDoctorUsername(string username)
        {
            var list = context.appointments.Where(a => a.doctor_username == username && a.state == 0 || a.state == 1).ToList() ?? new List<appointment>();
            return list;
        }

        public List<appointment> getFinishedAppointmentsOfDoctorUsername(string username)
        {
            var list = context.appointments.Where(a => a.doctor_username == username && a.state == 2 || a.state == 3).ToList() ?? new List<appointment>();
            return list;
        }

        public List<appointment> getAllAppointmentsfromPetList(List<pet> pets)
        {
            var petIds = pets.Select(p => p.pet_id).ToList();
            var list = context.appointments.Where(a => petIds.Contains(a.pet_id)).ToList() ?? new List<appointment>();
            return list;
        }

        public List<appointment> getAll_unOwnedAppointments()
        {            
            var list = context.appointments.Where(a => a.state == 0).ToList() ?? new List<appointment>();
            return list;
        }

        public List<appointment> getAll_unOwnedAppointments_FilterSpecialist(List<string> breedIds)
        {
            PetDAO petDAO = new PetDAO();
            var list = getAll_unOwnedAppointments();
            var specialist_List = list.Where(a => breedIds.Contains(petDAO.getBreedIdbyPetId(a.pet_id))).ToList() ?? new List<appointment>();
            return specialist_List;
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
