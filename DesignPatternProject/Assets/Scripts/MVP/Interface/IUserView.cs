public interface IUserView
{
    void ShowLoginSuccess(string message);
    void ShowLoginFailure(string message);
    string GetUsername();
    string GetPassword();
}
