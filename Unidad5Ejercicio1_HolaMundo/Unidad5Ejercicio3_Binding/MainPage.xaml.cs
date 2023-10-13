using System.ComponentModel;

namespace Unidad5Ejercicio3_Binding
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MyViewModel();
        }
    }
}

public class MyViewModel : INotifyPropertyChanged
{
    private string text;

    public string Text
    {
        get { return text; }
        set
        {
            if (text != value)
            {
                text = value;
                OnPropertyChanged("Text");
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}