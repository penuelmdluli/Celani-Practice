using System;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;


namespace Hospital_Management_System.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string UserRole { get; set; }

        public DateTime RegisteredDate { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Centre> Centre { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Psychologist> Psychologists { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Prescription> Prescription { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Complaint> Complaints { get; set; }
        public DbSet<Consultation>  Consultations { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<AuditTrial> AuditTrials { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }


        /// <summary>
        /// I could not import the namespace.
        /// </summary>
        public class AuditTrial
        {
            public int Id { get; set; }
            [Required]
            public string Who { get; set; }
            [Required]
            public string Transaction { get; set; }

            [Required]
            public string Where { get; set; }
            public DateTime When { get; set; }
            
        }

        /// <summary>
        /// I could not import the namespace.
        /// </summary>
        public static class AuditExtension
        {
            public static void AddAudit(string who, string what, string tableName)
            {
                var context = new ApplicationDbContext();

                var newTrial = new AuditTrial
                {
                    When = DateTime.Now,
                    Who = who,
                    Transaction = what,
                    Where = tableName
                };

                context.AuditTrials.Add(newTrial);
                context.SaveChanges();
            }
        }
    }
}