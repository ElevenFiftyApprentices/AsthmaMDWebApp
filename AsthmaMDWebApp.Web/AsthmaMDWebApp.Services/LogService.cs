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
                    .Where(e => e.ChildId == childId)
                    .Select(
                        e => new LogViewModel
                        {
                            LogId = e.LogId,
                            LogDate = e.LogDate,
                            LogPeakFlowMeter = e.LogPeakFlowMeter,
                            LogFAV1 = e.LogFAV1,
                            ChildId = e.ChildId,
                            Child = e.Child,
                            Medication = e.Medication,
                            SeverityLevel = e.SeverityLevel,
                            Symptoms = e.Symptoms,
                            Triggers = e.Triggers,
                            CreatedUtc = DateTimeOffset.UtcNow
                        })
                .ToArray();
            }
        }


    }
}