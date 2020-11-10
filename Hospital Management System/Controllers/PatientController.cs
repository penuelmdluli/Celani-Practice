using System;
using System.Collections.Generic;
using System.Data.Entity;
<<<<<<< HEAD
using System.IO;
=======
>>>>>>> 3c552410d40ec94cbecda862c77b7e85a15807a4
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hospital_Management_System.CollectionViewModels;
using Hospital_Management_System.Models;
using Hospital_Management_System.Models.Dto;
using Microsoft.AspNet.Identity;
using static Hospital_Management_System.Models.ApplicationDbContext;

namespace Hospital_Management_System.Controllers
{
    public class PatientController : Controller
    {
        private ApplicationDbContext db;

        //Constructor
        public PatientController()
        {
            db = new ApplicationDbContext();
        }

        //Destructor
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }
<<<<<<< HEAD
        
        string defaultPic = "Administrator.png";
        [Authorize(Roles = "Patient")]
        public ActionResult Index(string message)
        {
            try
            {
                ViewBag.Messege = message;
                string user = User.Identity.GetUserId();
                var patient = db.Patients.Single(c => c.ApplicationUserId == user);
                if (patient.ProPic != null)
                {
                    ViewBag.Pic = patient.ProPic;
                }
                else
                {
                    ViewBag.Pic = defaultPic;
                }

                var date = DateTime.Now.Date;
                var model = new CollectionOfAll
                {

                    Departments = db.Centre.ToList(),
                    Psychologists = db.Psychologists.ToList(),
                    Patients = db.Patients.ToList(),
                    ActiveAppointments = db.Appointments.Where(c => c.Status).Where(c => c.PatientId == patient.Id).Where(c => c.AppointmentDate >= date).ToList(),
                    PendingAppointments = db.Appointments.Where(c => c.Status == false).Where(c => c.PatientId == patient.Id).Where(c => c.AppointmentDate >= date).ToList(),

                    Announcements = db.Announcements.Where(c => c.AnnouncementFor == "Patient").ToList()
                };
                return View(model);
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
            //if we get here something is wrong
            return View();
=======

        [Authorize(Roles = "Patient")]
        public ActionResult Index(string message)
        {
            ViewBag.Messege = message;
            string user = User.Identity.GetUserId();
            var patient = db.Patients.Single(c => c.ApplicationUserId == user);
            var date = DateTime.Now.Date;
            var model = new CollectionOfAll
            {
                Departments = db.Centre.ToList(),
                Psychologists = db.Psychologists.ToList(),
                Patients = db.Patients.ToList(),
                ActiveAppointments = db.Appointments.Where(c => c.Status).Where(c => c.PatientId == patient.Id).Where(c => c.AppointmentDate >= date).ToList(),
                PendingAppointments = db.Appointments.Where(c => c.Status == false).Where(c => c.PatientId == patient.Id).Where(c => c.AppointmentDate >= date).ToList(),
                Announcements = db.Announcements.Where(c => c.AnnouncementFor == "Patient").ToList()
            };
            return View(model);
>>>>>>> 3c552410d40ec94cbecda862c77b7e85a15807a4
        }

        //Update Patient profile
        [Authorize(Roles = "Patient")]
        public ActionResult UpdateProfile(string id)
        {
<<<<<<< HEAD
            try
            {
                var patient = db.Patients.Single(c => c.ApplicationUserId == id);
                patient.Age = DateTime.Today.Year - ((DateTime)patient.DateOfBirth).Year;

                return View(patient);
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
            //if we get here something is wrong
            return View();
=======
            var patient = db.Patients.Single(c => c.ApplicationUserId == id);
            return View(patient);
>>>>>>> 3c552410d40ec94cbecda862c77b7e85a15807a4
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
<<<<<<< HEAD
        public ActionResult UpdateProfile(string id, Patient model, HttpPostedFileWrapper ProPic)
        {
            try
            {
                if (ProPic == null) ModelState.AddModelError("File", "Please Upload Your file");

                var patient = db.Patients.Single(c => c.ApplicationUserId == id);
                
                patient.FirstName = model.FirstName;
                patient.LastName = model.LastName;
                patient.FullName = model.FirstName + " " + model.LastName;
                patient.Contact = model.Contact;
                patient.Address = model.Address;
                patient.LevelOfEducation = model.LevelOfEducation;
                patient.Age = model.Age;
                patient.MaritalStatus = model.MaritalStatus;
                patient.Language = model.Language;
                patient.DateOfBirth = model.DateOfBirth;
                patient.Gender = model.Gender;
                patient.PhoneNo = model.PhoneNo;

                if (ProPic != null)
                {
                    patient.ProPic = ProPic.FileName;

                    var path = Path.Combine(Server.MapPath("~/Content/img"), ProPic.FileName);
                    ProPic.SaveAs(path);
                }

                db.SaveChanges();

                string audiuserName = User.Identity.GetUserName();
                AuditExtension.AddAudit(audiuserName, "Updated Profile", "Patients");

                return RedirectToAction("Index");
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
            //if we get here something is wrong
            return View();
        }

=======
        public ActionResult UpdateProfile(string id, Patient model)
        {
            var patient = db.Patients.Single(c => c.ApplicationUserId == id);
            patient.FirstName = model.FirstName;
            patient.LastName = model.LastName;
            patient.FullName = model.FirstName + " " + model.LastName;
            patient.Contact = model.Contact;
            patient.Address = model.Address;
            patient.LevelOfEducation = model.LevelOfEducation;
            patient.Age = model.Age;
            patient.MaritalStatus = model.MaritalStatus;
            patient.Language = model.Language;
            patient.Gender = model.Gender;
            patient.PhoneNo = model.PhoneNo;
            db.SaveChanges();
            string audiuserName = User.Identity.GetUserName();
            AuditExtension.AddAudit(audiuserName, "Update", "Patients");
            return RedirectToAction("Index");
        }


>>>>>>> 3c552410d40ec94cbecda862c77b7e85a15807a4
        //Start Appointment Section

        //Add Appointment
        [Authorize(Roles = "Patient")]
        public ActionResult AddAppointment()
        {
<<<<<<< HEAD
            try
            {
                var collection = new AppointmentCollection
                {
                    Appointment = new Appointment(),
                    Psychologists = db.Psychologists.ToList(),
                    Schedules = db.Schedules.Where(c => c.IsBooked == false).ToList()
                };

                return View(collection);
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
            //if we get here something is wrong
            return View();
=======
            var collection = new AppointmentCollection
            {
                Appointment = new Appointment(),
                Psychologists = db.Psychologists.ToList(),
                Schedules = db.Schedules.Where(c => c.IsBooked == false).OrderBy(c => c.ScheduleDate).ToList()
            };
            return View(collection);
>>>>>>> 3c552410d40ec94cbecda862c77b7e85a15807a4
        }

        [Authorize(Roles = "Patient")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddAppointment(AppointmentCollection model)
        {
<<<<<<< HEAD
            try
            {
                var collection = new AppointmentCollection
                {
                    Appointment = model.Appointment,
                    Psychologists = db.Psychologists.ToList()
                };

                if (model.Appointment.AppointmentDate <= DateTime.Now.Date)
                {
                    ViewBag.Messege = "Please Enter the Date greater than today or equal!!";
                    return View(collection);
                }

                string user = User.Identity.GetUserId();
                var patient = db.Patients.Single(c => c.ApplicationUserId == user);
                var appointment = new Appointment();
                appointment.PatientId = patient.Id;
                appointment.Schedule.PsychologistId = model.Appointment.Schedule.PsychologistId;
                appointment.AppointmentDate = model.Appointment.AppointmentDate;
                appointment.Problem = model.Appointment.Problem;
                appointment.Status = false;
                db.Appointments.Add(appointment);
                db.SaveChanges();

                string audiuserName = User.Identity.GetUserName();
                AuditExtension.AddAudit(audiuserName, "Added Appointment", "Appointments");

                return RedirectToAction("ListOfAppointments");

            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
            //if we get here something is wrong
            return View();
        }


=======
            var collection = new AppointmentCollection
            {
                Appointment = model.Appointment,
                Psychologists = db.Psychologists.ToList()
            };

            if (model.Appointment.AppointmentDate <= DateTime.Now.Date)
            {
                ViewBag.Messege = "Please Enter the Date greater than today or equal!!";
                return View(collection);
            }
            string user = User.Identity.GetUserId();
            var patient = db.Patients.Single(c => c.ApplicationUserId == user);
            var appointment = new Appointment();
            appointment.PatientId = patient.Id;
            appointment.Schedule.PsychologistId = model.Appointment.Schedule.PsychologistId;
            appointment.AppointmentDate = model.Appointment.AppointmentDate;
            appointment.Problem = model.Appointment.Problem;
            appointment.Status = false;
            db.Appointments.Add(appointment);
            db.SaveChanges();

            string audiuserName = User.Identity.GetUserName();
            AuditExtension.AddAudit(audiuserName, "Create", "Appointments");
            return RedirectToAction("Index");
        }



>>>>>>> 3c552410d40ec94cbecda862c77b7e85a15807a4
        //Create Appointment
        [Authorize(Roles = "Patient")]
        public ActionResult CreateAppointment(int id)
        {
<<<<<<< HEAD
            try
            {
                var collection = new ScheduleCollection
                {
                    Centres = db.Centre.ToList(),
                    Schedule = db.Schedules.Single(c => c.Id == id),
                    Psychologists = db.Psychologists.ToList(),
                    Patients = db.Patients.ToList()
                };
                return View(collection);
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }

            //if we get here something is wrong
            return View();
=======
            var collection = new ScheduleCollection
            {
                Centres = db.Centre.ToList(),
                Schedule = db.Schedules.Single(c => c.Id == id),
                Psychologists = db.Psychologists.ToList(),
                Patients = db.Patients.ToList()
            };
            return View(collection);
>>>>>>> 3c552410d40ec94cbecda862c77b7e85a15807a4
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAppointment(int id, ScheduleCollection model)
        {
<<<<<<< HEAD
            try
            {
                if (!ModelState.IsValid)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                string user = User.Identity.GetUserId();
                var patient = db.Patients.Single(c => c.ApplicationUserId == user);

=======
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            string user = User.Identity.GetUserId();
            var patient = db.Patients.Single(c => c.ApplicationUserId == user);

            if (patient.CompletedStatus == true  || patient.BookedPsychologistId ==0)
            {
>>>>>>> 3c552410d40ec94cbecda862c77b7e85a15807a4
                var schedule = db.Schedules.Single(c => c.Id == id);
                schedule.PatientId = patient.Id;
                schedule.IsBooked = true;
                db.SaveChanges();

                var appointment = new Appointment();
                appointment.PatientId = patient.Id;
                appointment.ScheduleId = schedule.Id;
                appointment.AppointmentDate = db.Schedules.FirstOrDefault(d => d.Id == schedule.Id).ScheduleDate;
                appointment.StartTime = schedule.StartTime;
                appointment.EndTime = schedule.EndTime;
                appointment.Problem = model.Problem;
                appointment.Status = false;
<<<<<<< HEAD
=======
                appointment.CompletedStatus = false;
>>>>>>> 3c552410d40ec94cbecda862c77b7e85a15807a4

                db.Appointments.Add(appointment);
                db.SaveChanges();

<<<<<<< HEAD
                string audiuserName = User.Identity.GetUserName();
                AuditExtension.AddAudit(audiuserName, "Appointment Created", "Appointments");
                return RedirectToAction("ListOfAppointments");
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }

            //if we get here something is wrong
            return View();
=======
                patient.BookedPsychologistId = db.Schedules.FirstOrDefault(d => d.Id == schedule.Id).PsychologistId;
                db.SaveChanges();
               
            }
            else
            {
               ModelState.AddModelError("error.error", "You  have still have an  ongoing appointment");
            }

            return RedirectToAction("ListOfAppointments");

>>>>>>> 3c552410d40ec94cbecda862c77b7e85a15807a4
        }

        //List of Appointments
        [Authorize(Roles = "Patient")]
        public ActionResult ListOfAppointments()
        {
<<<<<<< HEAD
            try
            {
                string user = User.Identity.GetUserId();
                var patient = db.Patients.Single(c => c.ApplicationUserId == user);

                var appointment = db.Appointments.Where(c => c.PatientId == patient.Id)
                    .Select(e => new AppointmentDto()
                    {
                        AppointmentDate = db.Schedules.FirstOrDefault(d => d.PatientId == patient.Id).ScheduleDate,
                        Id = e.Id,
                        PatientName = e.Patient.FullName,
                        Problem = e.Problem,
                        StartTime = e.StartTime,
                        EndTime = e.EndTime,
                        PsychologistName = db.Psychologists.FirstOrDefault(d => d.Id == e.Schedule.PsychologistId).FullName,
                        Status = e.Status,

                    })
                    .ToList();
                string audiuserName = User.Identity.GetUserName();
                AuditExtension.AddAudit(audiuserName, "Retrieved Appointment(s)", "Appointments");
                return View(appointment);
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }

            //if we get here something is wrong
            return View();
=======
            string user = User.Identity.GetUserId();
            var patient = db.Patients.Single(c => c.ApplicationUserId == user);
           
            var appointment = db.Appointments.Where(c => c.PatientId == patient.Id)
                .Select(e => new AppointmentDto()
                {
                    AppointmentDate = db.Schedules.FirstOrDefault(d => d.PatientId == patient.Id).ScheduleDate,
                    Id = e.Id,
                    PatientName = e.Patient.FullName,
                    Problem = e.Problem,
                    StartTime = e.StartTime,
                    EndTime = e.EndTime,
                    PsychologistName = db.Psychologists.FirstOrDefault(d => d.Id == e.Schedule.PsychologistId).FullName,
                    Status = e.Status,
    
                })
                .ToList();
            string audiuserName = User.Identity.GetUserName();
            AuditExtension.AddAudit(audiuserName, "Read", "Appointments");
            return View(appointment);
>>>>>>> 3c552410d40ec94cbecda862c77b7e85a15807a4
        }

        //Edit Appointment
        [Authorize(Roles = "Patient")]
        public ActionResult EditAppointment(int id)
        {
<<<<<<< HEAD
            try
            {
                var collection = new AppointmentCollection
                {
                    Appointment = db.Appointments.Single(c => c.Id == id),
                    Psychologists = db.Psychologists.ToList()
                };
                return View(collection);
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }

            //if we get here something is wrong
            return View();
=======
            var collection = new AppointmentCollection
            {
                Appointment = db.Appointments.Single(c => c.Id == id),
                Psychologists = db.Psychologists.ToList()
            };
            return View(collection);
>>>>>>> 3c552410d40ec94cbecda862c77b7e85a15807a4
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAppointment(int id, AppointmentCollection model)
        {
<<<<<<< HEAD
            try
            {
                var collection = new AppointmentCollection
                {
                    Appointment = model.Appointment,
                    Psychologists = db.Psychologists.ToList()
                };

                if (model.Appointment.AppointmentDate <= DateTime.Now.Date)
                {
                    ViewBag.Messege = "Please Enter the Date greater than today or equal!!";
                    return View(collection);
                }

                var appointment = db.Appointments.Single(c => c.Id == id);
=======
            var collection = new AppointmentCollection
            {
                Appointment = model.Appointment,
                Psychologists = db.Psychologists.ToList()
            };

            if (model.Appointment.AppointmentDate <= DateTime.Now.Date)
            {
                ViewBag.Messege = "Please Enter the Date greater than today or equal!!";
                return View(collection);
            }

            var appointment = db.Appointments.Single(c => c.Id == id);
>>>>>>> 3c552410d40ec94cbecda862c77b7e85a15807a4
                appointment.Schedule.PsychologistId = model.Appointment.Schedule.PsychologistId;
                appointment.AppointmentDate = model.Appointment.AppointmentDate;
                appointment.Problem = model.Appointment.Problem;
                db.SaveChanges();
<<<<<<< HEAD
                string audiuserName = User.Identity.GetUserName();
                AuditExtension.AddAudit(audiuserName, "Updated Appointemnt Details", "Appointments");
                return RedirectToAction("ListOfAppointments");
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
            //if we get here something is wrong
            return View();
=======
            string audiuserName = User.Identity.GetUserName();
            AuditExtension.AddAudit(audiuserName, "Update", "Appointments");
            return RedirectToAction("ListOfAppointments");
          
>>>>>>> 3c552410d40ec94cbecda862c77b7e85a15807a4
        }

        //Delete Appointment
        [Authorize(Roles = "Patient")]
        public ActionResult DeleteAppointment(int? id)
        {
<<<<<<< HEAD
            try
            {
                var appointment = db.Appointments.Single(c => c.Id == id);
                return View(appointment);
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }

            //if we get here something is wrong
            return View();
=======
            var appointment = db.Appointments.Single(c => c.Id == id);
            return View(appointment);
>>>>>>> 3c552410d40ec94cbecda862c77b7e85a15807a4
        }

        [HttpPost, ActionName("DeleteAppointment")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAppointment(int id)
        {
<<<<<<< HEAD
            try
            {
                var appointment = db.Appointments.Single(c => c.Id == id);
                db.Appointments.Remove(appointment);
                db.SaveChanges();
                string audiuserName = User.Identity.GetUserName();
                AuditExtension.AddAudit(audiuserName, "Deleted Appointment", "Appointments");
                return RedirectToAction("ListOfAppointments");
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
            //if we get here something is wrong
            return View();
=======
            var appointment = db.Appointments.Single(c => c.Id == id);
            db.Appointments.Remove(appointment);
            db.SaveChanges();
            string audiuserName = User.Identity.GetUserName();
            AuditExtension.AddAudit(audiuserName, "Delete", "Appointments");
            return RedirectToAction("ListOfAppointments");
>>>>>>> 3c552410d40ec94cbecda862c77b7e85a15807a4
        }

        //End Appointment Section

        //Start Psychologist Section

        //List of Available Psychologists
        [Authorize(Roles = "Patient")]
        public ActionResult AvailablePsychologists()
        {
<<<<<<< HEAD
            try
            {
                var doctor = db.Psychologists.Include(c => c.Centre).Where(c => c.Status == "Active")
                     .Select(e => new PsychologistDto()
                     {
                         FullName = e.FullName,
                         FirstName = e.FirstName,
                         LastName = e.LastName,
                         Address = e.Address,
                         CentreName = db.Centre.FirstOrDefault(d => d.Id == e.Id).Name,
                         Status = e.Status,
                         ContactNo = e.ContactNo,
                         Education = e.Education,
                         Gender = e.Gender,
                         Id = e.Id

                     }).ToList();
                string audiuserName = User.Identity.GetUserName();
                AuditExtension.AddAudit(audiuserName, "Read List of psychologist", "Psychologists");
                return View(doctor);
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
            //if we get here something is wrong
            return View();
=======
            var doctor = db.Psychologists.Include(c => c.Centre).Where(c => c.Status == "Active")
                 .Select(e => new PsychologistDto()
                 {
                     FullName = e.FullName,
                     FirstName = e.FirstName,
                     LastName = e.LastName,
                     Address = e.Address,
                     CentreName = db.Centre.FirstOrDefault(d => d.Id == e.Id).Name,
                     Status = e.Status,
                     ContactNo = e.ContactNo,
                     Education = e.Education,
                     Gender = e.Gender,
                     Id = e.Id
                     
                 }).ToList();
            string audiuserName = User.Identity.GetUserName();
            AuditExtension.AddAudit(audiuserName, "Read", "Psychologists");
            return View(doctor);
>>>>>>> 3c552410d40ec94cbecda862c77b7e85a15807a4
        }

        //Show Psychologist Schedule
        [Authorize(Roles = "Patient")]
        public ActionResult PsychologistSchedule(int id)
        {
<<<<<<< HEAD
            try
            {
                var schedule = db.Schedules.Where(c => c.PsychologistId == id && c.IsBooked == false)
                    .Select(e => new SchedulesDto()
                    {
                        PsychologistName = db.Psychologists.FirstOrDefault(d => d.Id == e.PsychologistId).FullName,
                        CentreName = db.Centre.FirstOrDefault(d => d.Id == e.Id).Name,
                        EndTime = e.EndTime,
                        StartTime = e.StartTime,
                        ScheduleDate = e.ScheduleDate,
                        Id = e.Id,
                    }).ToList();
                string audiuserName = User.Identity.GetUserName();
                AuditExtension.AddAudit(audiuserName, "Read", "Schedules");
                return View(schedule);
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }

            //if we get here something is wrong
            return View();
=======
          
            var schedule = db.Schedules.Where(c => c.PsychologistId == id && c.IsBooked == false)
                .Select(e => new SchedulesDto()
                {
                    PsychologistName = db.Psychologists.FirstOrDefault(d => d.Id == e.PsychologistId).FullName,
                    CentreName = db.Centre.FirstOrDefault(d => d.Id == e.Id).Name,
                    EndTime = e.EndTime,
                    StartTime = e.StartTime,
                    ScheduleDate = e.ScheduleDate,
                    Id = e.Id,
                }).ToList();
            string audiuserName = User.Identity.GetUserName();
            AuditExtension.AddAudit(audiuserName, "Read", "Schedules");
            return View(schedule);
>>>>>>> 3c552410d40ec94cbecda862c77b7e85a15807a4
        }


        //Psychologist Detail
        [Authorize(Roles = "Patient")]
        public ActionResult PsychologistDetail(int id)
        {
<<<<<<< HEAD
            try
            {
                var doctor = db.Psychologists.Include(c => c.Centre).Single(c => c.Id == id);
                string audiuserName = User.Identity.GetUserName();
                AuditExtension.AddAudit(audiuserName, "Read", "Psychologists");
                return View(doctor);
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            } 
            //if we get here something is wrong
            return View();
=======
            var doctor = db.Psychologists.Include(c => c.Centre).Single(c => c.Id == id);
            string audiuserName = User.Identity.GetUserName();
            AuditExtension.AddAudit(audiuserName, "Read", "Psychologists");
            return View(doctor);
>>>>>>> 3c552410d40ec94cbecda862c77b7e85a15807a4
        }

        //End Psychologist Section



        [Authorize(Roles = "Patient")]
        public ActionResult ListOfSchedules()
        {
<<<<<<< HEAD
            try
            {
                var schedule = db.Schedules.Include(c => c.Psychologist)
                    .Select(e => new SchedulesDto()
                    {
                        PsychologistName = e.PsychologistName,
                    // CentreName = db.Centre.FirstOrDefault(d => d.Id == e.DepartmentId).Name,
                    EndTime = e.EndTime,
                        StartTime = e.StartTime,
                        ScheduleDate = e.ScheduleDate,



                        CentreName = e.CentreName,
                        Id = e.Id,


                    }).ToList();
                string audiuserName = User.Identity.GetUserName();
                AuditExtension.AddAudit(audiuserName, "Read Schedule(s)", "Schedules");
                return View(schedule);
            }catch(Exception error)
            {
                Console.WriteLine(error.Message);
            } 
            //if we get here something is wrong
            return View();
=======
            var schedule = db.Schedules.Include(c => c.Psychologist)
                .Select(e => new SchedulesDto()
                {
                    PsychologistName = e.PsychologistName,
                    // CentreName = db.Centre.FirstOrDefault(d => d.Id == e.DepartmentId).Name,
                    EndTime = e.EndTime,
                    StartTime = e.StartTime,
                    ScheduleDate = e.ScheduleDate,
                    CentreName = e.CentreName,
                    Id = e.Id,
                }).OrderBy(c => c.ScheduleDate).ToList();
            string audiuserName = User.Identity.GetUserName();
            AuditExtension.AddAudit(audiuserName, "Read", "Schedules");
            return View(schedule);
>>>>>>> 3c552410d40ec94cbecda862c77b7e85a15807a4
        }


        //Start Complaint Section

        [Authorize(Roles = "Patient")]
        public ActionResult AddComplain()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddComplain(Complaint model)
        {
<<<<<<< HEAD
            try
            {
                var complain = new Complaint();
                complain.Complain = model.Complain;
                complain.ComplainDate = DateTime.Now.Date;
                db.Complaints.Add(complain);
                db.SaveChanges();
                string audiuserName = User.Identity.GetUserName();
                AuditExtension.AddAudit(audiuserName, "Create", "Complaints");
                return RedirectToAction("ListOfComplains");
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
            //if we get here something is wrong
            return View();
=======
            var complain = new Complaint();
            complain.Complain = model.Complain;
            complain.ComplainDate = DateTime.Now.Date;
            db.Complaints.Add(complain);
            db.SaveChanges();
            string audiuserName = User.Identity.GetUserName();
            AuditExtension.AddAudit(audiuserName, "Create", "Complaints");
            return RedirectToAction("ListOfComplains");
>>>>>>> 3c552410d40ec94cbecda862c77b7e85a15807a4
        }

        [Authorize(Roles = "Patient")]
        public ActionResult ListOfComplains()
        {
<<<<<<< HEAD
            try
            {
                var complain = db.Complaints.ToList();
                string audiuserName = User.Identity.GetUserName();
                AuditExtension.AddAudit(audiuserName, "Read", "Complaints");
                return View(complain);
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }

            //if we get here something is wrong
            return View();
=======
            var complain = db.Complaints.ToList();
            string audiuserName = User.Identity.GetUserName();
            AuditExtension.AddAudit(audiuserName, "Read", "Complaints");
            return View(complain);
>>>>>>> 3c552410d40ec94cbecda862c77b7e85a15807a4
        }

        [Authorize(Roles = "Patient")]
        public ActionResult EditComplain(int id)
        {
            var complain = db.Complaints.Single(c => c.Id == id);
            return View(complain);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditComplain(int id, Complaint model)
        {
<<<<<<< HEAD
            try
            {
                var complain = db.Complaints.Single(c => c.Id == id);
                complain.Complain = model.Complain;
                db.SaveChanges();
                string audiuserName = User.Identity.GetUserName();

                AuditExtension.AddAudit(audiuserName, "Updated Complaint", "Complaints");
                return RedirectToAction("ListOfComplains");
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }

            //if we get here something is wrong
            return View();
=======
            var complain = db.Complaints.Single(c => c.Id == id);
            complain.Complain = model.Complain;
            db.SaveChanges();
            string audiuserName = User.Identity.GetUserName();
            AuditExtension.AddAudit(audiuserName, "Update", "Complaints");
            return RedirectToAction("ListOfComplains");
>>>>>>> 3c552410d40ec94cbecda862c77b7e85a15807a4
        }

        [Authorize(Roles = "Patient")]
        public ActionResult DeleteComplain()
        {
            return View();
        }

        [HttpPost, ActionName("DeleteComplain")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteComplain(int id)
        {
<<<<<<< HEAD
            try
            {
                var complain = db.Complaints.Single(c => c.Id == id);
                db.Complaints.Remove(complain);
                db.SaveChanges();
                string audiuserName = User.Identity.GetUserName();
                AuditExtension.AddAudit(audiuserName, "Delete", "Complaints");
                return RedirectToAction("ListOfComplains");
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }

            //if we get here something is wrong
            return View();
=======
            var complain = db.Complaints.Single(c => c.Id == id);
            db.Complaints.Remove(complain);
            db.SaveChanges();
            string audiuserName = User.Identity.GetUserName();
            AuditExtension.AddAudit(audiuserName, "Delete", "Complaints");
            return RedirectToAction("ListOfComplains");
>>>>>>> 3c552410d40ec94cbecda862c77b7e85a15807a4
        }

        //End Complain Section

        //Start Prescription Section

        //List of Prescription
        [Authorize(Roles = "Patient")]
        public ActionResult ListOfPrescription()
        {
<<<<<<< HEAD
            try
            {
                string user = User.Identity.GetUserId();
                var patient = db.Patients.Single(c => c.ApplicationUserId == user);
                var prescription = db.Prescription.Include(c => c.Psychologist).Where(c => c.PatientId == patient.Id).ToList();
                return View(prescription);
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }

            //if we get here something is wrong
            return View();
=======
            string user = User.Identity.GetUserId();
            var patient = db.Patients.Single(c => c.ApplicationUserId == user);
            var prescription = db.Prescription.Include(c => c.Psychologist).Where(c => c.PatientId == patient.Id).ToList();
            return View(prescription);
>>>>>>> 3c552410d40ec94cbecda862c77b7e85a15807a4
        }

        //Prescription View
        public ActionResult PrescriptionView(int id)
        {
            var prescription = db.Prescription.Single(c => c.Id == id);
            return View(prescription);
        }

        //End Prescription 


        //List Of Schedules
        [Authorize(Roles = "Patient")]
        public ActionResult ListOfConsultation()
        {
<<<<<<< HEAD
            try
            {
                string user = User.Identity.GetUserId();
                var petient = db.Patients.Single(c => c.ApplicationUserId == user);
                var consultations = db.Consultations.Where(c => c.PatientId == petient.Id)
                    .Select(e => new ConsultationDto()
                    {
                        PatientName = db.Patients.FirstOrDefault(d => d.Id == e.Id).FullName,
                        PsychologistName = db.Psychologists.FirstOrDefault(d => d.Id == e.PsychologistId).FullName,
                        ConsultationDate = e.ConsultationDate,
                        Diagnosis = e.Diagnosis,
                        TreatmentPlan = e.TreatmentPlan,
                        Id = e.Id,
                    }).ToList();
                string audiuserName = User.Identity.GetUserName();
             
                AuditExtension.AddAudit(audiuserName, "Retrieved Consultation(s)", "Consultations");
                return View(consultations);
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }

            //if we get here something is wrong
            return View();
=======
            string user = User.Identity.GetUserId();
            var petient = db.Patients.Single(c => c.ApplicationUserId == user);
            var consultations = db.Consultations.Where(c => c.PatientId == petient.Id)
                .Select(e => new ConsultationDto()
                {
                    PatientName = db.Patients.FirstOrDefault(d => d.Id == e.Id).FullName,
                    PsychologistName = db.Psychologists.FirstOrDefault(d => d.Id == e.PsychologistId).FullName,
                    ConsultationDate = e.ConsultationDate,
                    Diagnosis = e.Diagnosis,
                    TreatmentPlan = e.TreatmentPlan,
                    Id = e.Id,
                }).ToList();
            string audiuserName = User.Identity.GetUserName();
            AuditExtension.AddAudit(audiuserName, "Read", "Consultations");
            return View(consultations);
>>>>>>> 3c552410d40ec94cbecda862c77b7e85a15807a4
        }
    }
}