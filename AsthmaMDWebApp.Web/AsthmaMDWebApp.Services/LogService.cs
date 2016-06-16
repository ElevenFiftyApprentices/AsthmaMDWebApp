using AsthmaMDWebApp.Data;
using AsthmaMDWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AsthmaMDWebApp.Services
{
    public class LogService
    {
        private readonly Lazy<LogService> _svc;

        private readonly Guid _userId;

        public LogService(Guid userId)
        {
            _userId = userId;
        }

        public IEnumerable<LogViewModel> GetLogs(int childId)
        {
            using (var ctx = new AsthmaDbContext())
            {
                return
                    ctx
                    .Logs
                    .Where()
            }
        }


    }
}