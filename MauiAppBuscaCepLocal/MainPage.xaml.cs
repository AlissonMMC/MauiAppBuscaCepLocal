using MauiAppBuscaCepLocal.Model;
using MauiAppBuscaCepLocal.Services;

namespace MauiAppBuscaCepLocal
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                Endereco? dados_endereco =
                    await DataServiceCep.GetEnderecoByCep(txt_cep.Text);

                BindindContext = dados_endereco;
            }
            catch (Exception ex) {
                await DisplayAlert("Ops", ex.Message, "OK");
            }

        }
    }

}
