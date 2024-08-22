public class UserPresenter
{
    private readonly IUserView _view;
    private UserModel _model;

    public UserPresenter(IUserView view)
    {
        _view = view;
    }

    public void OnLoginButtonClicked()
    {
        string username = _view.GetUsername();
        string password = _view.GetPassword();

        // 단순한 인증 로직 (예를 들어 "admin" / "1234" 조합으로만 성공 처리)
        if (username == "admin" && password == "1234")
        {
            _model = new UserModel(username, password);
            _view.ShowLoginSuccess("Login successful! Welcome " + _model.Username);
        }
        else
        {
            _view.ShowLoginFailure("Login failed! Please check your credentials.");
        }
    }
}