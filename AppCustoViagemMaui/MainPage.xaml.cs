using AppCustoViagemMaui.Models;

namespace AppCustoViagemMaui
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public static Viagem viag = new Viagem();
        private async void btn_AddPed_Clicked(object sender, EventArgs e)
        {
            viag.Origem = txt_origem.Text;
            viag.Destino = txt_destino.Text;
            viag.Distancia = Convert.ToDouble(txt_distancia.Text);
            viag.Rendimento = Convert.ToDouble(txt_rendimento.Text);
            viag.Preco = Convert.ToDouble(txt_combustivel.Text);

            await Navigation.PushAsync(new Views.AddPedagio());
        }

        private async void btn_calc_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.CalcViagem());
        }

        private async void btn_ListPed_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.ListPedagio());
        }
    }

}
