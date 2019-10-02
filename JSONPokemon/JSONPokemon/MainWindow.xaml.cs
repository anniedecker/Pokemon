using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JSONPokemon
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //// string url = @"https://pokeapi.co/api/v2/pokemon?offset=0&limit=964";
            //string url = @"https://pokeapi.co/api/v2/pokemon?offset=0&limit=964";
            //using (HttpClient client = new HttpClient())
            //{
            //    HttpResponseMessage response = client.GetAsync(url).Result;
            //    if (response.IsSuccessStatusCode)
            //    {
            //        var content = response.Content.ReadAsStringAsync().Result;
            //        var stuff = JsonConvert.DeserializeObject<Results>(content);

            //        foreach (var item in stuff.results)
            //        {
            //            lstPokemon.Items.Add(item);
            //        }
            //    }
            //}
        }

        private void BtnInfo_Click(object sender, RoutedEventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync($@"https://pokeapi.co/api/v2/pokemon/{txtPokemon.Text}").Result;
                var content = response.Content.ReadAsStringAsync().Result;

                var poke = JsonConvert.DeserializeObject<Pokemon>(content);
                txtOutput.Text = "";
                txtOutput.Text = $"{txtPokemon.Text} has {poke.abilities.Count} abilities:\n";
                for (int i = 0; i < poke.abilities.Count; i++)
                {
                    var ability = poke.abilities[i];
                    txtOutput.Text += $"{i + 1}.\t{ability.ability.name}\n";
                }
            }
        }
    }
}
