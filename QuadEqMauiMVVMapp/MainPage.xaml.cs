namespace QuadEqMauiMVVMapp;
public partial class MainPage : ContentPage, IDialogService
{
    public MainPage()
    {
        InitializeComponent();
        BindingContext = new QuadEqViewModel(this);
    }
    public void ShowMessage(string title, string msg)
    {
        DisplayAlert(title, msg, "Ok");
    }


}