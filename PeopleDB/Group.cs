using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleDB
{
    internal class Group
    {
        public string Name { get; set; }

        public List<Person> People { get; set; } = new List<Person>();

        // TODO: voeg serialize en deserialize functies toe

        public string Serialize()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static Group Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<Group>(json);
        }
    }
}