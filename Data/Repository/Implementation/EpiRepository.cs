using EpiConnectAPI.Core.Model;
using EpiConnectAPI.Core.ViewModel;
using EpiConnectAPI.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EpiConnectAPI.Data.Repository.Implementation {
    public class EpiRepository : IEpiRepository {
        
        private readonly AppDbContext _context;
        public EpiRepository(AppDbContext context) {
            _context = context;
        }
        public async Task<Epi> CreateEpi(Epi epi) {
            _context.Epis.Add(epi);
            await _context.SaveChangesAsync();
            return epi;
        }

        public async Task<Epi> DeleteEpi(int epiId) {
            Epi epi = await GetEpiById(epiId);
            _context.Remove(epi);
            await _context.SaveChangesAsync();
            return epi;
        }

        public async Task<List<AlertsEpiView>> GetAlertsByEpi() {
            var query = from e in _context.Epis
                        join a in _context.Alerts on e.EpiId equals a.EpiId into alerts
                        from alert in alerts.DefaultIfEmpty()
                        group alert by e.Name into g
                        select new AlertsEpiView {
                            EpiName = g.Key,
                            AlertCount = g.Count(x => x != null)
                        };
            return await query.ToListAsync();
        }

        public async Task<Epi> GetEpiById(int epiId) {
            return await _context.Epis.FirstOrDefaultAsync(e => e.EpiId == epiId);
        }

        public async Task<IEnumerable<Epi>> GetEpis() {
            return await _context.Epis.ToListAsync();
        }

        public async Task<Epi> UpdateEpi(int id, Epi epi) {
            epi.EpiId = id;
            _context.Epis.Update(epi);
            await _context.SaveChangesAsync();
            return epi;
        }

    }
}
