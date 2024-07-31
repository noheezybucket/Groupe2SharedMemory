using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppSharedMemory.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AppSharedMemory.Service
{
    public class CategorieService
    {
        /// <summary>
        /// cette methode permet de lister toute les categories
        /// </summary>
        /// <returns></returns>
        public List<Categorie> GetCategories()
        {
            HttpClient client;
            client = new HttpClient();
            var services = new List<Categorie>();
            client.BaseAddress = new Uri(System.Configuration.ConfigurationSettings.AppSettings["linkServeur"]);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.GetAsync("groupe2/Categories/GetCategorie").Result;
            if (response.IsSuccessStatusCode)
            {
                var responseData = response.Content.ReadAsStringAsync().Result;
                services = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Categorie>>(responseData);
            }
            return services;
        }
        public bool AddCategorie(Categorie categorie)
        {
            bool rep = false;
            string Id = categorie.idCategorie > 0 ? categorie.idCategorie.ToString() : "0";
            var values = new Dictionary<string, string>
            {
                {"idCategorie", Id },
                {"codeCategorie", categorie.codeCategorie },
                {"libelleCategorie", categorie.libelleCategorie }
            };
            var content = new FormUrlEncodedContent(values);
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(System.Configuration.ConfigurationSettings.AppSettings["linkServeur"]);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = client.PostAsync("groupe2/Categories/PostCategorie", content).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        rep = true;
                    }
                    else
                    {
                        rep = false;
                    }
                }

            }
            catch (Exception ex)
            {

            }
            return rep;


        }

        /// <summary>
        /// cette methode permet de mettre a jour une categorie
        /// </summary>
        /// <param name="categorie"></param>
        /// <returns></returns>
        public bool UpdateCategorie(Categorie categorie)
        {
            bool rep = false;
            string Id = categorie.idCategorie > 0 ? categorie.idCategorie.ToString() : "0";
            var values = new Dictionary<string, string>
    {
        {"idCategorie", Id },
        {"codeCategorie", categorie.codeCategorie },
        {"libelleCategorie", categorie.libelleCategorie }
    };
            var content = new FormUrlEncodedContent(values);
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(System.Configuration.ConfigurationSettings.AppSettings["linkServeur"]);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = client.PutAsync($"groupe2/Categories/PutCategorie/{Id}", content).Result;

                    // Ajout des messages de débogage pour la réponse
                    string responseBody = response.Content.ReadAsStringAsync().Result;
                    MessageBox.Show($"Réponse de l'API : {responseBody}", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (response.IsSuccessStatusCode)
                    {
                        rep = true;
                    }
                    else
                    {
                        rep = false;
                    }
                }
            }
            catch (Exception ex)
            {
                // Gestion des exceptions
                MessageBox.Show("Une erreur s'est produite : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return rep;
        }


        /// <summary>
        /// cette methode permet de trouver une categorie selon l'id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Categorie Find(int id)
        {
            var categories = GetCategories(); // Assume GetCategories retrieves all categories
            return categories.FirstOrDefault(c => c.idCategorie == id);
        }

        /// <summary>
        /// cette methode permet de supprimer une categorie
        /// </summary>
        /// <param name="idCategorie"></param>
        /// <returns></returns>
        public bool DeleteCategorie(int idCategorie)
        {
            bool rep = false;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(System.Configuration.ConfigurationSettings.AppSettings["linkServeur"]);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // Créer l'URL avec l'ID de la catégorie à supprimer
                    var response = client.DeleteAsync("groupe2/Categories/DeleteCategorie/{id}").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        rep = true;
                    }
                    else
                    {
                        // Vous pouvez loguer ou gérer les erreurs en cas de réponse échouée
                        Console.WriteLine($"Erreur lors de la suppression : {response.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                // Gestion des exceptions
                Console.WriteLine($"Exception lors de la suppression : {ex.Message}");
            }
            return rep;
        }



    }
}
