using System.Text.RegularExpressions;
using UsingBinding.Services;

namespace UsingBinding.Views;

public partial class LogIn : ContentPage
{
	public LogIn()
	{
		InitializeComponent();
	}
    private async void OnRegisterClicked(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new Register());
    }
    private async void OnSignInClicked(object sender, EventArgs e)
    {
        string email = Email.Text;
        string password = PassWord.Text;

        errEmail.Text = "";
        errPassword.Text = "";

        if (email == null || email == "")
        {
            errEmail.Text = "Email can't be Empty.";
            return;
        }

        if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
        {
            errEmail.Text = "Please enter a valid email address.";
            return;
        }

        if (password == null || password == "")
        {
            errPassword.Text = "Password can't be Empty.";
            return;
        }

        // Find the registered user.
        var user = DataRepository.FindUser(email, password);

        if (user == null)
        {
            errPassword.Text = "Incorrect email or password.";
            return;
        }

        // Login successful!
        await DisplayAlert(
            "Welcome!",
            $"Hello, {user.UserName}! You have successfully logged in.",
            "OK");

        await Navigation.PushAsync(new MuscleList());

        // You can navigate to your home page here later.
    }
}