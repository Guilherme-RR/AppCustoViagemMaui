using AppCustoViagemMaui.Models;

namespace AppCustoViagemMaui.Views;

public partial class CalcViagem : ContentPage
{
	public CalcViagem()
	{
		InitializeComponent();
	}

    private async void btn_calc_Clicked(object sender, EventArgs e)
    {
        double consumo_carro = ((MainPage.viag.Distancia / MainPage.viag.Rendimento) * MainPage.viag.Rendimento);
        double valor_pedagio = 0;
        double total = 0;

        List<Pedagio> pedagios = await App.Db.GetAll();
        foreach (Pedagio p in pedagios)
        {
            valor_pedagio += p.Valor;
        }

        total = consumo_carro + valor_pedagio;
        await DisplayAlert("Soma total:", $"Pedagio: {valor_pedagio.ToString("C")}\n" +
            $"Consumo: {consumo_carro.ToString("C")}\n---------\nTotal: {total.ToString("C")}", "Ok");
        lbl_valor.Text = "Valor: " + total.ToString("C");
        lbl_valor.IsVisible = true;

        lbl_origem.Text = MainPage.viag.Origem;
        lbl_destino.Text = MainPage.viag.Destino;
        lbl_valor.Text = total.ToString("C");
    }

    private async void btn_novo_Clicked(object sender, EventArgs e)
    {
        List<Pedagio> pedagios = await App.Db.GetAll();
        foreach (Pedagio p in pedagios)
        {
            await App.Db.Delete(p.Id);
        }

        MainPage.viag.Distancia = -1;
        MainPage.viag.Rendimento = -1;
        MainPage.viag.Origem = " ";
        MainPage.viag.Preco = -1;
        MainPage.viag.Destino = " ";

        await Navigation.PushAsync(new MainPage());
    }
}