using EpiConnectAPI.Core.Model;

namespace EpiConnectAPI.Data.Repository.Interfaces {
    public interface IEmployeeRepository {
        Task<List<Employee>> GetEmployees();
        Task<Employee> GetEmployeeById(int employeeId);
        Task<Employee> CreateEmployee(Employee employee);
        Task<Employee> UpdateEmployee(int id, Employee employee);
        Task<Employee> DeleteEmployee(int id);
    }
}
