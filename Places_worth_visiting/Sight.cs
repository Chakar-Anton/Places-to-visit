using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ТурОператор
{
    [Serializable]
    public class Sight
    {
        private string name;
        private string describe;
        private string photo;
        public Sight(string name, string describe, string photo)
        {
            Name = name;
            Describe = describe;
            Photo = photo;
        }
        public string Photo
        {
            get { return photo; }
            set { photo = value; }
        }

        public string Describe
        {
            get { return describe; }
            set { describe = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
