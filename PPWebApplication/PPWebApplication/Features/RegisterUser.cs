namespace PPWebApplication.Features
{
    public static class RegisterUser
    {
        public record Request(string Email, string Initals, string Password);


    }
}
