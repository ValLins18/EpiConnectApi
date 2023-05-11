﻿namespace EpiConnectAPI.Core.Model {
    public class Warning {

        public int WarningId { get; set; }
        public DateTime WarningDate { get; set; }
        public int AlertId { get; set; }
        public virtual Alert Alert { get; set; }
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
