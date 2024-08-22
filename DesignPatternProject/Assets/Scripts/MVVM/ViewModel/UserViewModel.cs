using System.ComponentModel;
using System.Runtime.CompilerServices;

public class UserViewModel : INotifyPropertyChanged
{
    private UserDataModel _userDataModel;

    public UserViewModel()
    {
        _userDataModel = new UserDataModel();
    }

    public string Name
    {
        get => _userDataModel.Name;
        set
        {
            _userDataModel.Name = value;
            OnPropertyChanged();
        }
    }

    public int Age
    {
        get => _userDataModel.Age;
        set
        {
            _userDataModel.Age = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
