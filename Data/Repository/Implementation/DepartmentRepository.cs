using EpiConnectAPI.Core.Model;
using EpiConnectAPI.Core.ViewModel;
using EpiConnectAPI.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EpiConnectAPI.Data.Repository.Implementation {
    public class DepartmentRepository : IDepartmentRepository {

        private readonly AppDbContext _context;

        public DepartmentRepository(AppDbContext appDbContext) {
            _context = appDbContext;
        }
        public async Task<List<Department>> GetDepartmentsAsync() {
            return await _context.Departments.ToListAsync();
        }
        public async Task<List<DepartmentAlertsView>> GetCountAlertsByDepartment() {
            var resultado = from d in _context.Departments
                            join p in _context.Posts on d.DepartmentId equals p.DepartmentId
                            join em in _context.Employees on p.PostId equals em.PostId
                            join epi in _context.Epis on em.PersonId equals epi.EmployeeId into epiGroup
                            from epi in epiGroup.DefaultIfEmpty()
                            join a in _context.Alerts on epi.EpiId equals a.EpiId into alertGroup
                            from a in alertGroup.DefaultIfEmpty()
                            group a by d.Description into g
                            select new DepartmentAlertsView {
                                DepartmentName = g.Key,
                                AlertCount = g.Count(x => x != null)
                            };
            return await resultado.ToListAsync();
        }
    }
}
