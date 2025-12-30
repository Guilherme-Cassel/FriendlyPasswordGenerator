using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FriendlyPasswordGenerator.Model;

public class UserSettings : INotifyPropertyChanged
{
    //Default values
    private bool allowNonAsciiCaracters = false;
    private int amountOfWords = 3;
    private int minimumLenght = 40;
    public bool AutoAdjustLenght = true;


    public bool AllowNonAsciiCaracters
    {
        get => allowNonAsciiCaracters;
        set
        {
            if (allowNonAsciiCaracters != value)
            {
                allowNonAsciiCaracters = value;
                OnPropertyChanged();
            }
        }
    }

    public int AmountOfWords
    {
        get => amountOfWords;
        set
        {
            if (amountOfWords != value)
            {
                amountOfWords = value;
                OnPropertyChanged();
            }
        }
    }

    public int MinimumLenght
    {
        get => minimumLenght;
        set
        {
            if (minimumLenght != value)
            {
                minimumLenght = value;
                OnPropertyChanged();
            }
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
