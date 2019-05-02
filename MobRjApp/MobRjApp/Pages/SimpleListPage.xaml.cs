using MobRjApp.Controls;
using MobRjApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static MobRjApp.Pages.Utils;

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
            await RestRunAsync(this, viewModel.LoadAsync);

        private async void SearchBar_SearchButtonPressed(object sender, EventArgs e) =>
            await RestRunAsync(this, viewModel.LoadAsync);

        private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e) =>
            await RestRunAsync(this, viewModel.DelayedLoadAsync);

    }

    class ListViewModel : BusyObject
    {
        private readonly DataService _data = DataService.Instance;
        private List<State> _states;

        public List<State> States
        {
            get { return _states; }
            set { _states = value; OnPropertyChanged(); }
        }

        public string SearchText { get; set; }

        public async Task LoadAsync()
        {
            using (BusyState())
            {
                States = await _data.GetStatesAsync(SearchText);
            }
        }

        public async Task DelayedLoadAsync()
        {
            await Task.Delay(500);
            await LoadAsync();
        }
    }
}