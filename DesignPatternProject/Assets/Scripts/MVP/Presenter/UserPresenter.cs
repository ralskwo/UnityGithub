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

        // �ܼ��� ���� ���� (���� ��� "admin" / "1234" �������θ� ���� ó��)
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