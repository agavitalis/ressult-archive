using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResultArchive.Models.AuditTrail
{
    public class AuditSession
    {
        private readonly DBContext _db;
        public AuditSession(DBContext db)
        {
            _db = db;
            Timestamp = DateTime.Now;
        }

        public int Id { get; set; }

        public string SessionId { get; set; }

        public string Name { get; set; }

        public string Comments { get; set; }

        public string Action { get; set; }

        public string PerformedBy { get; set; }

        public string IpAddress { get; set; }

        public DateTime Timestamp { get; set; }

        public void CreateAudit(Session session, string action, string userEmail, string userIpAddress)
        {
            var  newAuditSession = new AuditSession(_db)
            {
                SessionId = session.Id.ToString(),
                Name = session.Name,
               
                Comments = session.Comments,
                Action = action,
                PerformedBy = userEmail,
                IpAddress = userIpAddress
            };

            _db.AuditSessions.Add(newAuditSession);

            //save the school Audit Records
            _db.SaveChanges();

        }
    }

}
