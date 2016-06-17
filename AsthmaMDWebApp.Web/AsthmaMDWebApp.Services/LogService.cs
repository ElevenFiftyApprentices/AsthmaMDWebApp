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
                            CreatedUtc = e.CreatedUtc
                        })
                .ToArray();
            }
        }

        public LogViewModel GetLogById(int logId, int childId)
        {
            LogEntity entity;
            using (var ctx = new AsthmaDbContext())
            {
                entity =
                    ctx
                    .Logs
                    .SingleOrDefault(e => e.ChildId == childId && e.LogId == logId);
            }
            return
                new LogViewModel
                {
                    LogId = entity.LogId,
                    LogDate = entity.LogDate,
                    LogPeakFlowMeter = entity.LogPeakFlowMeter,
                    LogFAV1 = entity.LogFAV1,
                    ChildId = entity.ChildId,
                    Child = entity.Child,
                    Medication = entity.Medication,
                    SeverityLevel = entity.SeverityLevel,
                    Symptoms = entity.Symptoms,
                    Triggers = entity.Triggers,
                    CreatedUtc = entity.CreatedUtc
                };
        }

        public bool CreateLog(LogViewModel vm, int logId)
        {
            using (var ctx = new AsthmaDbContext())
            {
                var entity =
                    new LogEntity
                    {
                        LogId = logId,
                        LogDate = vm.LogDate,
                        LogPeakFlowMeter = vm.LogPeakFlowMeter,
                        LogFAV1 = vm.LogFAV1,
                        Child = vm.Child,
                        ChildId = vm.ChildId,
                        Medication = vm.Medication,
                        SeverityLevel = vm.SeverityLevel,
                        Symptoms = vm.Symptoms,
                        Triggers = vm.Triggers,
                        CreatedUtc = vm.CreatedUtc
                    };
                ctx.Logs.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}