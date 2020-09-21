
using System.ComponentModel;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace TravelRecordApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public static string DatabaseLocation = string.Empty;
        public MainPage()
        {
            InitializeComponent();
        }

        void LoginButton_Clicked(System.Object sender, System.EventArgs e)
        {
            bool IsEmailEmpty = string.IsNullOrWhiteSpace(EmailEntry.Text);
            bool IsPassWordEmpty = string.IsNullOrWhiteSpace(PasswordEntry.Text);

            if(IsEmailEmpty || IsPassWordEmpty)
            {
                DisplayAlert("Mensagem", "Email e senha são obrigatórios", "OK");
            }
            else if (!EmailIsValid(EmailEntry.Text))
            {
                DisplayAlert("Mensagem", "Email está incorreto, verifique.", "OK");
            }
            else
            {
                Navigation.PushAsync(new HomePage());
            }
        }

        bool EmailIsValid(string email)
        {
            string expression = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

            if (Regex.IsMatch(email, expression))
            {
                if (Regex.Replace(email, expression, string.Empty).Length == 0)
                {
                    return true;
                }
            }
            return false;
        }

        void CancelButton_Clicked(System.Object sender, System.EventArgs e)
        {
            EmailEntry.Text = string.Empty;
            PasswordEntry.Text = string.Empty;
        }

    }
}
