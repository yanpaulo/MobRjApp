using MobRjApp.Controls;
using MobRjApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobRjApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CachedListPage : ContentPage
	{
        private readonly CachedListViewModel viewModel;

		public CachedListPage()
		{
			InitializeComponent ();
            viewModel = (CachedListViewModel)BindingContext;
		}

        private async void ContentPage_Appearing(object sender, EventArgs e) => 
            await viewModel.LoadAsync();

        private async void SearchBar_SearchButtonPressed(object sender, EventArgs e) => 
            await viewModel.LoadAsync();

        private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e) => 
            await viewModel.DelayedLoadAsync();

    }

    class CachedListViewModel : BusyObject
    {
        private readonly DataService _data = DataService.Instance;
        private List<LocalState> _states;

        public List<LocalState> States
        {
            get { return _states; }
            set { _states = value; OnPropertyChanged(); }
        }

        public string SearchText { get; set; }

        public virtual async Task LoadAsync(int delay = 0)
        {
            States = await _data.GetLocalStatesAsync(SearchText);
            await Task.Delay(delay);
            using (BusyState())
            {
                States = await _data.FetchLocalStatesAsync(SearchText);
            }
        }

        public async Task DelayedLoadAsync()
        {
            await LoadAsync(500);
        }
    }
}