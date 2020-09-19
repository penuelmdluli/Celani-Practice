using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Hospital_Management_System.CollectionViewModels;
using Hospital_Management_System.Models;

namespace Hospital_Management_System.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext db;

        private ApplicationUserManager _userManager;

        //Constructor
        public AdminController()
        {
            db = new ApplicationDbContext();
        }

        //Destructor
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }

        public ApplicationUserManager UserManager
        {
            get { return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
            private set { _userManager = value; }
        }

        // GET: Admin
        [Authorize(Roles = "Admin")]
        public ActionResult Index(string message)
        {
            var date = DateTime.Now.Date;
            ViewBag.Messege = message;
            var model = new CollectionOfAll
            {
            
                Departments = db.Centre.ToList(),
                Psychologists = db.Psychologists.ToList(),
                Patients = db.Patients.ToList(),
            
                ActiveAppointments =
                    db.Appointments.Where(c => c.Status).Where(c => c.AppointmentDate >= date).ToList(),
                PendingAppointments = db.Appointments.Where(c => c.Status == false)
                    .Where(c => c.AppointmentDate >= date).ToList(),
            
            };
            return View(model);
        }

        //Centre Section

        //Centre List
        [Authorize(Roles = "Admin")]
        public ActionResult DepartmentList()
        {
            var model = db.Centre.ToList();
            return View(model);
        }

        //Add Centre
        [Authorize(Roles = "Admin")]
        public ActionResult AddDepartment()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddDepartment(Centre model)
        {
            if (db.Centre.Any(c => c.Name == model.Name))
            {
                ModelState.AddModelError("Name", "Name already present!");
                return View(model);
            }

            db.Centre.Add(model);
            db.SaveChanges();
            return RedirectToAction("DepartmentList");
        }

        //Edit Centre
        [Authorize(Roles = "Admin")]
        public ActionResult EditDepartment(int id)
        {
            var model = db.Centre.SingleOrDefault(c => c.Id == id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditDepartment(int id, Centre model)
        {
            var department = db.Centre.Single(c => c.Id == id);
            department.Name = model.Name;
            department.Description = model.Description;
            department.Status = model.Status;
            db.SaveChanges();
            return RedirectToAction("DepartmentList");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult DeleteDepartment(int? id)
        {
            var department = db.Centre.Single(c => c.Id == id);
            return View(department);
        }

        [HttpPost, ActionName("DeleteDepartment")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteDepartment(int id)
        {
            var department = db.Centre.SingleOrDefault(c => c.Id == id);
            db.Centre.Remove(department);
            db.SaveChanges();
            return RedirectToAction("DepartmentList");
        }

        //End Centre Section

        //Start Ambulance Section
        //Ambulance Driver Section

        //Add Ambulance Driver
        [Authorize(Roles = "Admin")]
        public ActionResult AddAmbulanceDriver()
        {
            return View();
        }


       


        

        //End Ambulance Section

        //Start Medicine Section

        //Add Medicine
        [Authorize(Roles = "Admin")]
        public ActionResult AddMedicine()
        {
            return View();
        }

        
        [Authorize(Roles = "Admin")]
        public ActionResult AddDoctor()
        {
            var collection = new DoctorCollection
            {
                ApplicationUser = new RegisterViewModel(),
                Psychologist = new Psychologist(),
                Departments = db.Centre.ToList()
            };
            return View(collection);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddDoctor(DoctorCollection model)
        {
            var user = new ApplicationUser
            {
                UserName = model.ApplicationUser.UserName,
                Email = model.ApplicationUser.Email,
                UserRole = "Psychologist",
                RegisteredDate = DateTime.Now.Date
            };
            var result = await UserManager.CreateAsync(user, model.ApplicationUser.Password);
            if (result.Succeeded)
            {
                await UserManager.AddToRoleAsync(user.Id, "Psychologist");
                var doctor = new Psychologist
                {
                    FirstName = model.Psychologist.FirstName,
                    LastName = model.Psychologist.LastName,
                    FullName = "Dr. " + model.Psychologist.FirstName + " " + model.Psychologist.LastName,
                    EmailAddress = model.ApplicationUser.Email,
                    ContactNo = model.Psychologist.ContactNo,
                    PhoneNo = model.Psychologist.PhoneNo,
                    Designation = model.Psychologist.Designation,
                    Education = model.Psychologist.Education,
                    DepartmentId = model.Psychologist.DepartmentId,
                    Specialization = model.Psychologist.Specialization,
                    Gender = model.Psychologist.Gender,
                    BloodGroup = model.Psychologist.BloodGroup,
                    ApplicationUserId = user.Id,
                    DateOfBirth = model.Psychologist.DateOfBirth,
                    Address = model.Psychologist.Address,
                    Status = model.Psychologist.Status
                };
                db.Psychologists.Add(doctor);
                db.SaveChanges();
                return RedirectToAction("ListOfDoctors");
            }

            return HttpNotFound();

        }

        //List Of Psychologists
        [Authorize(Roles = "Admin")]
        public ActionResult ListOfDoctors()
        {
            var doctor = db.Psychologists.Include(c => c.Centre).ToList();
            return View(doctor);
        }

        //Detail of Psychologist
        [Authorize(Roles = "Admin")]
        public ActionResult PsychologistDetail(int id)
        {
            var doctor = db.Psychologists.Include(c => c.Centre).SingleOrDefault(c => c.Id == id);
            return View(doctor);
        }

        //Edit Psychologists
        [Authorize(Roles = "Admin")]
        public ActionResult EditDoctors(int id)
        {
            var collection = new DoctorCollection
            {
                Departments = db.Centre.ToList(),
                Psychologist = db.Psychologists.Single(c => c.Id == id)
            };
            return View(collection);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditDoctors(int id, DoctorCollection model)
        {
            var doctor = db.Psychologists.Single(c => c.Id == id);
            doctor.FirstName = model.Psychologist.FirstName;
            doctor.LastName = model.Psychologist.LastName;
            doctor.FullName = "Dr. " + model.Psychologist.FirstName + " " + model.Psychologist.LastName;
            doctor.ContactNo = model.Psychologist.ContactNo;
            doctor.PhoneNo = model.Psychologist.PhoneNo;
            doctor.Designation = model.Psychologist.Designation;
            doctor.Education = model.Psychologist.Education;
            doctor.DepartmentId = model.Psychologist.DepartmentId;
            doctor.Specialization = model.Psychologist.Specialization;
            doctor.Gender = model.Psychologist.Gender;
            doctor.BloodGroup = model.Psychologist.BloodGroup;
            doctor.DateOfBirth = model.Psychologist.DateOfBirth;
            doctor.Address = model.Psychologist.Address;
            doctor.Status = model.Psychologist.Status;
            db.SaveChanges();

            return RedirectToAction("ListOfDoctors");
        }

        //Delete Psychologist
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteDoctor(string id)
        {
            var UserId = db.Psychologists.Single(c => c.ApplicationUserId == id);
            return View(UserId);
        }

        [HttpPost, ActionName("DeleteDoctor")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteDoctor(string id, Psychologist model)
        {
            var doctor = db.Psychologists.Single(c => c.ApplicationUserId == id);
            var user = db.Users.Single(c => c.Id == id);
            if (db.Schedules.Where(c => c.DoctorId == doctor.Id).Equals(null))
            {
                var schedule = db.Schedules.Single(c => c.DoctorId == doctor.Id);
                db.Schedules.Remove(schedule);
            }

            db.Users.Remove(user);
            db.Psychologists.Remove(doctor);
            db.SaveChanges();
            return RedirectToAction("ListOfDoctors");
        }

        //End Psychologist Section

        //Start Schedule Section
        //Add Schedule
        [Authorize(Roles = "Admin")]
        public ActionResult AddSchedule()
        {
            var collection = new ScheduleCollection
            {
                Schedule = new Schedule(),
                Psychologists = db.Psychologists.ToList()
            };
            return View(collection);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddSchedule(ScheduleCollection model)
        {
            if (!ModelState.IsValid)
            {
                var collection = new ScheduleCollection
                {
                    Schedule = model.Schedule,
                    Psychologists = db.Psychologists.ToList()
                };
                return View(collection);
            }

            db.Schedules.Add(model.Schedule);
            db.SaveChanges();
            return RedirectToAction("ListOfSchedules");
        }

        //List Of Schedules
        [Authorize(Roles = "Admin")]
        public ActionResult ListOfSchedules()
        {
            var schedule = db.Schedules.Include(c => c.Psychologist).ToList();
            return View(schedule);
        }

        //Edit Schedule
        [Authorize(Roles = "Admin")]
        public ActionResult EditSchedule(int id)
        {
            var collection = new ScheduleCollection
            {
                Schedule = db.Schedules.Single(c => c.Id == id),
                Psychologists = db.Psychologists.ToList()
            };
            return View(collection);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSchedule(int id, ScheduleCollection model)
        {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var schedule = db.Schedules.Single(c => c.Id == id);
            schedule.DoctorId = model.Schedule.DoctorId;
            schedule.AvailableEndDay = model.Schedule.AvailableEndDay;
            schedule.AvailableEndTime = model.Schedule.AvailableEndTime;
            schedule.AvailableStartDay = model.Schedule.AvailableStartDay;
            schedule.AvailableStartTime = model.Schedule.AvailableStartTime;
            schedule.Status = model.Schedule.Status;
            schedule.TimePerPatient = model.Schedule.TimePerPatient;
            db.SaveChanges();
            return RedirectToAction("ListOfSchedules");
        }

        //Delete Schedule
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteSchedule(int? id)
        {
            return View();
        }

        [HttpPost, ActionName("DeleteSchedule")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSchedule(int id)
        {
            var schedule = db.Schedules.Single(c => c.Id == id);
            db.Schedules.Remove(schedule);
            return RedirectToAction("ListOfSchedules");
        }

        //End Schedule Section

        //Start Patient Section

        //List of Patients
        [Authorize(Roles = "Admin")]
        public ActionResult ListOfPatients()
        {
            var patients = db.Patients.ToList();
            return View(patients);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult EditPatient(int id)
        {
            var patient = db.Patients.Single(c => c.Id == id);
            return View(patient);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPatient(int id, Patient model)
        {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var patient = db.Patients.Single(c => c.Id == id);
            patient.FirstName = model.FirstName;
            patient.LastName = model.LastName;
            patient.FullName = model.FirstName + " " + model.LastName;
            patient.Address = model.Address;
            patient.LevelOfEducation = model.LevelOfEducation;
            patient.Age = model.Age;
            patient.MaritalStatus = model.MaritalStatus;
            patient.Language = model.Language;
            patient.Contact = model.Contact;
            patient.DateOfBirth = model.DateOfBirth;
            patient.EmailAddress = model.EmailAddress;
            patient.Gender = model.Gender;
            patient.PhoneNo = model.PhoneNo;
            db.SaveChanges();
            return RedirectToAction("ListOfPatients");
        }

        //Delete Patient
        [Authorize(Roles = "Admin")]
        public ActionResult DeletePatient()
        {
            return View();
        }

        [HttpPost, ActionName("DeletePatient")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePatient(string id)
        {
            var patient = db.Patients.Single(c => c.ApplicationUserId == id);
            var user = db.Users.Single(c => c.Id == id);
            db.Users.Remove(user);
            db.Patients.Remove(patient);
            db.SaveChanges();
            return RedirectToAction("ListOfPatients");
        }

        //End Patient Section

        //Start Appointment Section

        //Add Appointment
        [Authorize(Roles = "Admin")]
        public ActionResult AddAppointment()
        {
            var collection = new AppointmentCollection
            {
                Appointment = new Appointment(),
                Patients = db.Patients.ToList(),
                Psychologists = db.Psychologists.ToList()
            };
            return View(collection);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddAppointment(AppointmentCollection model)
        {
            var collection = new AppointmentCollection
            {
                Appointment = model.Appointment,
                Patients = db.Patients.ToList(),
                Psychologists = db.Psychologists.ToList()
            };
            if (model.Appointment.AppointmentDate >= DateTime.Now.Date)
            {
                var appointment = new Appointment();
                appointment.PatientId = model.Appointment.PatientId;
                appointment.DoctorId = model.Appointment.DoctorId;
                appointment.AppointmentDate = model.Appointment.AppointmentDate;
                appointment.Problem = model.Appointment.Problem;
                appointment.Status = model.Appointment.Status;
                db.Appointments.Add(appointment);
                db.SaveChanges();

                if (model.Appointment.Status == true)
                {
                    return RedirectToAction("ListOfAppointments");
                }
                else
                {
                    return RedirectToAction("PendingAppointments");
                }
            }

            ViewBag.Messege = "Please Enter the Date greater than today or equal!!";
            return View(collection);

        }

        //List of Active Appointment
        [Authorize(Roles = "Admin")]
        public ActionResult ListOfAppointments()
        {
            var date = DateTime.Now.Date;
            var appointment = db.Appointments.Include(c => c.Psychologist).Include(c => c.Patient)
                .Where(c => c.Status == true).Where(c => c.AppointmentDate >= date).ToList();
            return View(appointment);
        }

        //List of pending Appointments
        [Authorize(Roles = "Admin")]
        public ActionResult PendingAppointments()
        {
            var date = DateTime.Now.Date;
            var appointment = db.Appointments.Include(c => c.Psychologist).Include(c => c.Patient)
                .Where(c => c.Status == false).Where(c => c.AppointmentDate >= date).ToList();
            return View(appointment);
        }

        //Edit Appointment
        [Authorize(Roles = "Admin")]
        public ActionResult EditAppointment(int id)
        {
            var collection = new AppointmentCollection
            {
                Appointment = db.Appointments.Single(c => c.Id == id),
                Patients = db.Patients.ToList(),
                Psychologists = db.Psychologists.ToList()
            };
            return View(collection);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAppointment(int id, AppointmentCollection model)
        {
            var collection = new AppointmentCollection
            {
                Appointment = model.Appointment,
                Patients = db.Patients.ToList(),
                Psychologists = db.Psychologists.ToList()
            };
            if (model.Appointment.AppointmentDate >= DateTime.Now.Date)
            {
                var appointment = db.Appointments.Single(c => c.Id == id);
                appointment.PatientId = model.Appointment.PatientId;
                appointment.DoctorId = model.Appointment.DoctorId;
                appointment.AppointmentDate = model.Appointment.AppointmentDate;
                appointment.Problem = model.Appointment.Problem;
                appointment.Status = model.Appointment.Status;
                db.SaveChanges();
                if (model.Appointment.Status == true)
                {
                    return RedirectToAction("ListOfAppointments");
                }
                else
                {
                    return RedirectToAction("PendingAppointments");
                }
            }
            ViewBag.Messege = "Please Enter the Date greater than today or equal!!";

            return View(collection);
        }

        //Detail of Appointment
        [Authorize(Roles = "Admin")]
        public ActionResult DetailOfAppointment(int id)
        {
            var appointment = db.Appointments.Include(c => c.Psychologist).Include(c => c.Patient).Single(c => c.Id == id);
            return View(appointment);
        }

        //Delete Appointment
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteAppointment(int? id)
        {
            var appointment = db.Appointments.Single(c => c.Id == id);
            return View(appointment);
        }

        [HttpPost, ActionName("DeleteAppointment")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAppointment(int id)
        {
            var appointment = db.Appointments.Single(c => c.Id == id);
            db.Appointments.Remove(appointment);
            db.SaveChanges();
            if (appointment.Status)
            {
                return RedirectToAction("ListOfAppointments");
            }
            else
            {
                return RedirectToAction("PendingAppointments");
            }
        }

        //End Appointment Section

        //Start Announcement Section

        //Add Announcement
        [Authorize(Roles = "Admin")]
        public ActionResult AddAnnouncement()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddAnnouncement(Announcement model)
        {
            if (model.End >= DateTime.Now.Date)
            {
                db.Announcements.Add(model);
                db.SaveChanges();
                return RedirectToAction("ListOfAnnouncement");
            }
            else
            {
                ViewBag.Messege = "Please Enter the Date greater than today!!";
            }

            return View(model);
        }

        //List of Announcement
        [Authorize(Roles = "Admin")]
        public ActionResult ListOfAnnouncement()
        {
            var list = db.Announcements.ToList();
            return View(list);
        }

        //Edit Announcement
        [Authorize(Roles = "Admin")]
        public ActionResult EditAnnouncement(int id)
        {
            var announcement = db.Announcements.Single(c => c.Id == id);
            return View(announcement);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAnnouncement(int id, Announcement model)
        {
            var announcement = db.Announcements.Single(c => c.Id == id);
            if (model.End >= DateTime.Now.Date)
            {
                announcement.Announcements = model.Announcements;
                announcement.End = model.End;
                announcement.AnnouncementFor = model.AnnouncementFor;
                db.SaveChanges();
                return RedirectToAction("ListOfAnnouncement");
            }
            else
            {
                ViewBag.Messege = "Please Enter the Date greater than today!!";
            }

            return View(announcement);
        }

        //Delete Announcement
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteAnnouncement(int? id)
        {
            return View();
        }

        [HttpPost, ActionName("DeleteAnnouncement")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAnnouncement(int id)
        {
            var announcement = db.Announcements.Single(c => c.Id == id);
            db.Announcements.Remove(announcement);
            db.SaveChanges();
            return RedirectToAction("ListOfAnnouncement");
        }

        //Start Complaint Section

        //List of Complaints
        [Authorize(Roles = "Admin")]
        public ActionResult ListOfComplains()
        {
            var complain = db.Complaints.ToList();
            return View(complain);
        }

        //Edit Complaint
        [Authorize(Roles = "Admin")]
        public ActionResult EditComplain(int id)
        {
            var complain = db.Complaints.Single(c => c.Id == id);
            return View(complain);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditComplain(int id, Complaint model)
        {
            var complain = db.Complaints.Single(c => c.Id == id);
            complain.Complain = model.Complain;
            complain.Reply = model.Reply;
            db.SaveChanges();
            return RedirectToAction("ListOfComplains");
        }

        //Delete Complaint
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteComplain()
        {
            return View();
        }

        [HttpPost, ActionName("DeleteComplain")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteComplain(int id)
        {
            var complain = db.Complaints.Single(c => c.Id == id);
            db.Complaints.Remove(complain);
            db.SaveChanges();
            return RedirectToAction("ListOfComplains");
        }
    }
}