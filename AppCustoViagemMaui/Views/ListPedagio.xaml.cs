using AppCustoViagemMaui.Models;
using System.Collections.ObjectModel;
using AppCustoViagemMaui.Views;

namespace AppCustoViagemMaui.Views;

public partial class ListPedagio : ContentPage
{
	ObservableCollection<Pedagio> lista_pedagios = new ObservableCollection<Pedagio>();
	public ListPedagio()
	{
		InitializeComponent();
		lst_pedagio.ItemsSource = lista_pedagios;
	}

	protected async void OnAppearing()
	{
		if (lista_pedagios.Count == 0)
		{
			List<Pedagio> tmp = await App.Db.GetAll();
			foreach (Pedagio p in tmp)
			{
				lista_pedagios.Add(p);
			}
		}
	}

    private void btn_salvar_Clicked(object sender, EventArgs e)
    {

    }
}