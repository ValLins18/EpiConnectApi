using EpiConnectAPI.Core.Model;

namespace EpiConnectAPI.Data.Repository.Interfaces {
    public interface IEpiRepository {
        Task<IEnumerable<Epi>> GetEpis();
        Task<Epi> GetEpiById(int epiId);
        Task<Epi> CreateEpi(Epi epi);
        Task<Epi> UpdateEpi(int id, Epi epi);
        Task<Epi> DeleteEpi(int epiId);
    }
}
