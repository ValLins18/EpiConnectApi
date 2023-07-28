namespace EpiConnectAPI.Core.Model {
    public class Employee : Person{

        public DateTime EntryDate { get; set; }
        public List<Epi> Epis{ get; set; }
        public List<Warning>? Warnings { get; set; }

        public int PostId { get; set; }
        public virtual Post Post { get; set; }
        public int? UserId { get; set; }
        public virtual User User { get; set; }
        public string Workshift { get; set; }
    }
}
