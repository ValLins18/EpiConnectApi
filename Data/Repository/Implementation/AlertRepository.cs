using EpiConnectAPI.Core.Model;
using EpiConnectAPI.Core.ViewModel;
using EpiConnectAPI.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EpiConnectAPI.Data.Repository.Implementation
{
    public class AlertRepository : IAlertRepository {
        private readonly AppDbContext _context;

        public AlertRepository(AppDbContext context) {
            _context = context;
        }

        public async Task<Alert> CloseAlert(int id, Alert alert) {
            _context.Alerts.Update(alert);
            await _context.SaveChangesAsync();
            return alert;
        }

        public async Task<List<WorkshiftAlertsView>> GetAlertsCountByWorkshift() {
            var result = from em in _context.Employees
                         join e in _context.Epis on em.PersonId equals e.EmployeeId
                         join a in _context.Alerts on e.EpiId equals a.EpiId
                         group a by em.Workshift into g
                         select new WorkshiftAlertsView {
                             WorkshiftName = g.Key,
                             AlertCount = g.Count(a => a != null)
                         };
            return await result.ToListAsync();
        }


        public async Task<Alert> GetLastAlertByEpiId(int epiId) {
            return await _context.Alerts
                .Include(a => a.Metrics)
                .Where(a => a.IsOpen)
                .OrderByDescending(a => a.AlertDate).AsNoTracking()
                .FirstOrDefaultAsync(a => a.EpiId == epiId);
        }

        public async Task<Alert> OpenAlert(Alert alert) {
            _context.Alerts.Add(alert);
            await _context.SaveChangesAsync();
            return alert;
        }
    }
}
