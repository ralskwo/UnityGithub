using UnityEngine;
using TMPro;

public class LoginView : MonoBehaviour, IUserView
{
    public TMP_InputField usernameInput;
    public TMP_InputField passwordInput;
    public TMP_Text messageText;

    private UserPresenter _presenter;

    private void Start()
    {
        _presenter = new UserPresenter(this);
    }

    public void OnLoginButtonClicked()
    {
        _presenter.OnLoginButtonClicked();
    }

    public void ShowLoginSuccess(string message)
    {
        messageText.text = message;
        messageText.color = Color.green;
    }

    public void ShowLoginFailure(string message)
    {
        messageText.text = message;
        messageText.color = Color.red;
    }

    public string GetUsername()
    {
        return usernameInput.text;
    }

    public string GetPassword()
    {
        return passwordInput.text;
    }
}
