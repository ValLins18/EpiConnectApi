using AutoMapper;
using EpiConnectAPI.Core.Model;
using EpiConnectAPI.Core.ViewModel;
using EpiConnectAPI.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EpiConnectAPI.Data.Repository.Implementation {
    public class EmployeeRepository : IEmployeeRepository {

        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context) {
            _context = context;
        }

        public async Task<Employee> CreateEmployee(Employee employee) {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> DeleteEmployee(int id) {
            Employee employee = await GetEmployeeById(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> GetEmployeeById(int employeeId) {
            return await _context.Employees
                .Include(e => e.Address)
                .Include(e => e.Phone)
                .Include(e => e.Post)
                    .ThenInclude(p => p.Department)
                .Include(e => e.Warnings)
                .Include(e => e.Epis)
                    .ThenInclude(ep => ep.Metrics)
                .Include(e => e.Epis)
                    .ThenInclude(ep => ep.Alerts).FirstOrDefaultAsync(e => e.PersonId == employeeId);

        }

        public async Task<List<Employee>> GetEmployees() {
            return await _context.Employees
                .Include(e => e.Phone)
                .Include(e => e.Address)
                .Include(e => e.Post)
                .ThenInclude(P => P.Department).ToListAsync();
        }

        public async Task<List<EmployeeMonitoringView>> GetEmployeesForMonitoring() {
            return await _context.People.OfType<Employee>()
                .Select(e => new EmployeeMonitoringView {
                    PersonId = e.PersonId,
                    Name = e.Name,
                    Phone = e.Phone,
                    Post = new Post {
                        PostId = e.PostId,
                        Description = e.Post.Description,
                        Department = e.Post.Department,
                        Salary = e.Post.Salary 
                    },
                    IsOpenAlert = e.Epis.Any(ep => ep.Alerts.Any(a => a.IsOpen))
                }).ToListAsync();
        }

        public async Task<Employee> UpdateEmployee(int id, Employee employee) {
            employee.PersonId = id;
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
            return employee;
        }
    }
}
