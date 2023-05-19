using EpiConnectAPI.Core.Model;
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
