using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailTownAITest
{
    public class Geo
    {
        public string lat { get; set; }
        public string lng { get; set; }
        public override string ToString()
        {
            return "Geo: " + lat+","+lng;
        }
    }

    public class Address
    {
        public string street { get; set; }
        public string suite { get; set; }
        public string city { get; set; }
        public string zipcode { get; set; }
        public Geo geo { get; set; }
        public override string ToString()
        {
            return "Address: " + street + " " + suite + " " + city + " " + zipcode + " "+ geo;
        }
    }

    public class Company
    {
        public string name { get; set; }
        public string catchPhrase { get; set; }
        public string bs { get; set; }
        public override string ToString()
        {
            return "Company: " + name;
        }
    }

    public class User
    {
        public int id { get; set; }
        public User furthestUser { get; set; }
        public double distanceToFurthestUser { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public Address address { get; set; }
        public string phone { get; set; }
        public string website { get; set; }
        public Company company { get; set; }
        public override string ToString()
        {
            return "Name: " + name + " " + address + " " + company + " Phone: " + phone;
        }

        public void setFurthestUser(List<User> users)
        {
            int len = users.Count;
            User furthestuser = null;
            double maxDist = double.MinValue;
            for (int i = 0; i < len; i++)
            {
                var dist = getDistance(users[i]);
                if (dist > maxDist)
                {
                    maxDist = dist;
                    furthestuser = users[i];
                }
            }
            this.furthestUser = furthestuser;
            this.distanceToFurthestUser = maxDist;
        }

        public double getDistance(User u2)
        {
            //https://stackoverflow.com/a/21623206
            var p = 0.017453292519943295;    // Math.PI / 180
            float lat1 = float.Parse(this.address.geo.lat);
            float lon1 = float.Parse(this.address.geo.lng);
            float lat2 = float.Parse(u2.address.geo.lat);
            float lon2 = float.Parse(u2.address.geo.lng);
            double a = 0.5 - Math.Cos((lat2 - lat1) * p) / 2 +
                    Math.Cos(lat1 * p) * Math.Cos(lat2 * p) *
                    (1 - Math.Cos((lon2 - lon1) * p)) / 2;

            return 12742 * Math.Asin(Math.Sqrt(a));
        }
    }
    
}
