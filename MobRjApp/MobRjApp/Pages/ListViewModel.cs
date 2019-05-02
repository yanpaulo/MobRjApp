using MobRjApp.Controls;
using MobRjApp.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MobRjApp.Pages
{
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

        public virtual async Task LoadAsync()
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