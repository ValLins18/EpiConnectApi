namespace EpiConnectAPI.Core.Model {
    public class Team {
        public int TeamId { get; set; }
        public Leader Leader { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
