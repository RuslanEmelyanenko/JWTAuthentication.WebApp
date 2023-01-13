namespace JWTUtil.Abstraction
{
    public interface ICreateJWTToken
    {
        string GenerateJWT(string email, string password);
    }
}