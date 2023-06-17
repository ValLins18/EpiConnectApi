namespace EpiConnectAPI.Core.ViewModel {
    public class LoginResultView {
        public bool Successful { get; set; }
        public string? Error { get; set; }
        public string? Token { get; set; }
    }
}
