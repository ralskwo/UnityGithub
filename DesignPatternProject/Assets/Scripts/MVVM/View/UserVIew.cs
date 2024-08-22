using UnityEngine;
using TMPro;

public class UserView : MonoBehaviour
{
    public TMP_InputField nameInputField;
    public TMP_InputField ageInputField;
    public TMP_Text displayText;

    private UserViewModel _userViewModel;

    private void Start()
    {
        _userViewModel = new UserViewModel();

        // 초기 데이터 바인딩
        nameInputField.onValueChanged.AddListener(OnNameChanged);
        ageInputField.onValueChanged.AddListener(OnAgeChanged);

        UpdateDisplay();
    }

    public void OnNameChanged(string newName)
    {
        _userViewModel.Name = newName;
        UpdateDisplay();
    }

    public void OnAgeChanged(string newAge)
    {
        if (int.TryParse(newAge, out int age))
        {
            _userViewModel.Age = age;
            UpdateDisplay();
        }
    }

    private void UpdateDisplay()
    {
        displayText.text = $"Name: {_userViewModel.Name}, Age: {_userViewModel.Age}";
    }
}
