namespace Training.FoodApp.API.Security.DTOs
{
    public class LoginResultDto
    {
        public string Message { get; set; }
        public bool IsOk { get; set; }
        public string Token { get; set; }
        public string Type { get; set; }
    }
}
