namespace EpiConnectAPI.Core.Model {
    public class Post {
        public int PostId { get; set; }
        public string Description { get; set; }
        public decimal Salary{ get; set; }

        public int DepartmentId { get; set; }
        public virtual Department Department{ get; set; }
    }
}
