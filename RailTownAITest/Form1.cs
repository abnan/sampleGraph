using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RailTownAITest
{
    public partial class Form1 : Form
    {
        static HttpClient client = new HttpClient();
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = int.Parse(System.Configuration.ConfigurationManager.AppSettings["timerInterval"]);
            string baseUri = System.Configuration.ConfigurationManager.AppSettings["baseUri"];
            client.BaseAddress = new Uri(baseUri);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                updateData();
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message, "Error!");
            }
        }

        private void updateData()
        {
            List<User> users = GetUsersAsync().GetAwaiter().GetResult();
            User checkFurthestUser = null;
            Double maxDist = double.MinValue;
            foreach (User u in users)
            {
                u.setFurthestUser(users);
                if (u.distanceToFurthestUser>maxDist)
                {
                    checkFurthestUser = u;
                }
            }
            if (checkFurthestUser!=null)
            {
                label1.Text = checkFurthestUser.ToString() + " Distance: " + checkFurthestUser.distanceToFurthestUser + " km";
                label2.Text = checkFurthestUser.furthestUser.ToString() + " Distance: " + checkFurthestUser.furthestUser.distanceToFurthestUser + " km";
            }
        }

        

        static async Task<List<User>> GetUsersAsync()
        {
            List<User> users = null;
            string userPath = System.Configuration.ConfigurationManager.AppSettings["getUsers"];
            HttpResponseMessage response = await client.GetAsync(userPath).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                users = JsonConvert.DeserializeObject<List<User>>(responseBody);
            }
            return users;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            updateData();
        }
    }
}
