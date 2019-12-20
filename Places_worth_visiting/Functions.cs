using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ТурОператор
{
    public static class Functions
    {
        public static string choice;
        public static List<Country> GeneralList = new List<Country>();

        public static List<Country> ReadSerialization()
        {
            FileStream fs = new FileStream("Country.bin", FileMode.OpenOrCreate, FileAccess.Read);
            List<Country> list = new List<Country>();
            BinaryFormatter bf = new BinaryFormatter();
            list = (List<Country>)bf.Deserialize(fs);
            GeneralList = list;
            fs.Close();

            return list;

        }

        public static List<Country> Read()
        {

            List<Country> list = new List<Country>();
            try
            {
                StreamReader temp = new StreamReader("Country.txt", Encoding.Default);
                temp.Close();
            }
            catch
            {
                MainWindow MW = new MainWindow();
                MW.ShowDialog();
            }
            StreamReader sr = new StreamReader("Country.txt", Encoding.Default);
            string line;
            string last_name = "";
            List<Sight> tempList = new List<Sight>();
            while ((line = sr.ReadLine()) != null)
            {


                string[] lineArray = line.Split(',');
                last_name = lineArray[0];
                int number = int.Parse(lineArray[1]);
                for (int i = 0; i < number; i++)
                {
                    string[] sightArray = sr.ReadLine().Split(',');
                    tempList.Add(new Sight(sightArray[0], sightArray[1], sightArray[2]));
                }

                list.Add(new Country(last_name, tempList));

            }

            GeneralList = list;
            sr.Close();
            return list;


        }
        public static void SerializationWrite()
        {
            FileStream fs = new FileStream("Country.bin", FileMode.Open, FileAccess.Write);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, GeneralList);
            fs.Close();
        }

        public static void Write()
        {
            List<Country> list = GeneralList;
            try
            {
                FileStream fs1 = new FileStream("Country.txt", FileMode.Open, FileAccess.Write);
                StreamWriter temp = new StreamWriter(fs1, Encoding.Default);
                temp.Close();
                fs1.Close();
            }
            catch
            {
                MainWindow MW = new MainWindow();
                MW.ShowDialog();
            }
            FileStream fs = new FileStream("Country.txt", FileMode.Open, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs, Encoding.Default);
            for (int i = 0; i < list.Count; i++)
            {
                string temp = String.Format(list[i].Name + ',' + list[i].Sights.Count);
                sw.WriteLine(temp);
                for (int j = 0; j < list[i].Sights.Count; j++)
                    sw.WriteLine(String.Format(list[i].Sights[j].Name + ',' + list[i].Sights[j].Describe + ',' + list[i].Sights[j].Photo + ','));


            }
            sw.Close();
            fs.Close();
        }

    }
}