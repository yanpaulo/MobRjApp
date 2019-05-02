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
	public partial class GroupedListPage : ContentPage
	{
        private readonly GroupedListViewModel viewModel;

		public GroupedListPage()
		{
			InitializeComponent ();
            viewModel = BindingContext as GroupedListViewModel;
		}

        private async void ContentPage_Appearing(object sender, EventArgs e) =>
            await RestRunAsync(this, viewModel.LoadAsync);

        private async void SearchBar_SearchButtonPressed(object sender, EventArgs e) =>
            await RestRunAsync(this, viewModel.LoadAsync);

        private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e) =>
            await RestRunAsync(this, viewModel.DelayedLoadAsync);

    }

    class GroupedListViewModel : BusyObject
    {
        private readonly DataService _data = DataService.Instance;
        private List<StateGroup> _groups;

        public List<StateGroup> Groups
        {
            get { return _groups; }
            set { _groups = value; OnPropertyChanged(); }
        }

        public string SearchText { get; set; }

        public async Task LoadAsync()
        {
            using (BusyState())
            {
                var items = await _data.GetStatesAsync(SearchText);
                Groups =
                    items
                    .GroupBy(s => s.Fields.Regiao)
                    .Select(g => new StateGroup(g) { Regiao = g.Key })
                    .ToList(); 
            }
        }

        public async Task DelayedLoadAsync()
        {
            await Task.Delay(500);
            await LoadAsync();
        }


    }

    class StateGroup : List<State>
    {
        public StateGroup(IEnumerable<State> collection) : base(collection)
        {
        }

        public string Regiao { get; set; }
    }
    
}