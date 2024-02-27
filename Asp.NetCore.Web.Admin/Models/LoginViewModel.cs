namespace Asp.NetCore.Web.Admin.Models
{
    public class LoginViewModel
    {
        public string? Username { get; set; }

        public string? Password { get; set; }

        public bool RememberMe { get; set; } = false;

        public string? ReturnUrl { get; set; }
    }
}
