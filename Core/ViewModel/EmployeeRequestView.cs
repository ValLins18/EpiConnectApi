using EpiConnectAPI.Core.Model;

namespace EpiConnectAPI.Core.ViewModel {
    public class EmployeeRequestView : PersonRequestView{
        public DateTime EntryDate { get; set; }
        public int PostId { get; set; } 
        public User? User { get; set; }
    }
}
