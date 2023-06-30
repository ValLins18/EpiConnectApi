using EpiConnectAPI.Core.Model;
using EpiConnectAPI.Core.ViewModel;

namespace EpiConnectAPI.Data.Repository.Interfaces {
    public interface IDepartmentRepository {
        Task<List<Department>> GetDepartmentsAsync();
        Task<List<DepartmentAlertsView>> GetCountAlertsByDepartment();
    }
}
