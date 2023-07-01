using EpiConnectAPI.Core.Model;
using EpiConnectAPI.Core.ViewModel;

namespace EpiConnectAPI.Data.Repository.Interfaces {
    public interface IEpiRepository {
        Task<IEnumerable<Epi>> GetEpis();
        Task<Epi> GetEpiById(int epiId);
        Task<Epi> CreateEpi(Epi epi);
        Task<Epi> UpdateEpi(int id, Epi epi);
        Task<Epi> DeleteEpi(int epiId);

        Task<List<AlertsEpiView>> GetAlertsByEpi();
    }
}
