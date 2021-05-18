using OfficeOpenXml.FormulaParsing.Excel.Functions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResultArchive.Models.AuditTrail
{
    public class AuditSchool
    {
        private readonly DBContext _db;
        public AuditSchool(DBContext db)
        {
            _db = db;
            Timestamp = DateTime.Now;
        }

        public int Id { get; set; }

        public string SchoolId { get; set; }

        public string Name { get; set; }
              
        public string Acronym { get; set; }

        public string Comments { get; set; }

        public string Action { get; set; }

        public string PerformedBy { get; set; }

        public string IpAddress { get; set; }

        public DateTime Timestamp { get; set; }

        public void CreateAudit(School school, string action, string userEmail, string userIpAddress)
        {
            var newAuditSchool = new AuditSchool(_db)
            {
                SchoolId = school.Id.ToString(),
                Name = school.Name,
                Acronym = school.Acronym,
                Comments = school.Comments,
                Action = action,
                PerformedBy = userEmail,
                IpAddress = userIpAddress
            };

            _db.AuditSchools.Add(newAuditSchool);

            //save the school Audit Records
            _db.SaveChanges();

        }
    }
}
