using System;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobRjApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SimpleListPage : ContentPage
	{
        private readonly ListViewModel viewModel;

		public SimpleListPage ()
		{
			InitializeComponent ();
            viewModel = BindingContext as ListViewModel;
		}

        private async void ContentPage_Appearing(object sender, EventArgs e) => 
            await viewModel.LoadAsync();

        private async void SearchBar_SearchButtonPressed(object sender, EventArgs e) => 
            await viewModel.LoadAsync();

        private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e) => 
            await viewModel.DelayedLoadAsync();

    }
}