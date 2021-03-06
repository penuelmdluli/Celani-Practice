﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hospital_Management_System.Models
{
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