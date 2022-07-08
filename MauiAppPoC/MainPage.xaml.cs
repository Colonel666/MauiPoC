using MauiAppPoC.SQLRepository;
using Microsoft.Maui.Controls;

namespace MauiAppPoC;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
        var repository = new AccountRepository("chinook.db");
		//var bla = new CollectionView();
      //  bla.ItemsSource = repository.GetAccounts();
		stack.Text = "testinggg";
       collection1.ItemsSource = repository.GetAccounts();
		Account firstAccount = new Account { Id = 1, Balance = 1, Email = "bla@bla.com" };
		repository.CreateAccount(firstAccount);
      //var bla = repository.GetAccounts();
       var bla = repository.GetArtists();
        collection1.ItemsSource = bla;
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

}

