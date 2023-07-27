using EpiConnectAPI.Core.Model;
using EpiConnectAPI.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EpiConnectAPI.Data.Repository.Implementation {
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

        public async Task<Alert> GetLastAlertByEpiId(int epiId) {
            return await _context.Alerts
                .Include(a => a.Metrics)
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
