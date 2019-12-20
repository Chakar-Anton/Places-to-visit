using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ТурОператор
{
    [Serializable]
    public class Country
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private List<Sight> sights;

        public List<Sight> Sights
        {
            get { return sights; }
            set { sights = value; }
        }
        public Country(string name, List<Sight> sight)
        {
            Name = name;
            Sights = sight;
        }
    }
}
