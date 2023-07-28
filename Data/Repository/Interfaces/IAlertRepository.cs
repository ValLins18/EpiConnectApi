using EpiConnectAPI.Core.Model;
using EpiConnectAPI.Core.ViewModel;

namespace EpiConnectAPI.Data.Repository.Interfaces
{
    public interface IAlertRepository {
        Task<Alert> OpenAlert(Alert alert);
        Task<Alert> CloseAlert(int id, Alert alert);
        Task<Alert> GetLastAlertByEpiId(int EpiId);
        Task<List<WorkshiftAlertsView>> GetAlertsCountByWorkshift();
    }
}
