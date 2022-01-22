using ContactBook.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactBook
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DataAccessShowcasePage : ContentPage
    {
        private SQLiteAsyncConnection _connection;
        private ObservableCollection<Recipe> _recipes;

        public DataAccessShowcasePage()
        {
            InitializeComponent();

            //SQLite connection
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();

        }

        protected override async void OnAppearing()
        {
            //Load from application properties storage if any:
            if (Application.Current.Properties.ContainsKey("Notifications"))
            {
                notifications_switch.IsToggled = (bool)Application.Current.Properties["Notifications"];
            }

            //SQLite Setup:
            await _connection.CreateTableAsync<Recipe>();
            var recipes = await _connection.Table<Recipe>().ToListAsync();
            _recipes = new ObservableCollection<Recipe>(recipes);
            recipesListView.ItemsSource = _recipes;
        }

        private void OnChange(object sender, EventArgs e)
        {
            Application.Current.Properties["Notifications"] = notifications_switch.IsToggled;
            Application.Current.SavePropertiesAsync();
        }

        private async void OnAdd(object sender, EventArgs e)
        {
            Recipe newRecipe = new Recipe { Name = "New recipe " + DateTime.Now.Ticks };
            await _connection.InsertAsync(newRecipe);
            _recipes.Add(newRecipe);
        }

        private async void OnUpdate(object sender, EventArgs e)
        {
            if(_recipes.Count > 0)
            {
                var recipe = _recipes[0];
                recipe.Name += " UPDATED";

                await _connection.UpdateAsync(recipe);
            }
            return;
        }

        private async void OnDelete(object sender, EventArgs e)
        {
            if(_recipes.Count > 0)
            {
                var recipe = _recipes[0];
                await _connection.DeleteAsync(recipe);
                _recipes.Remove(recipe);
            }
            return;
        }
    }
}