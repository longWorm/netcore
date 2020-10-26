using System.IO;
using Newtonsoft.Json;

namespace netcore
{
    public class CarListFileManager: ICarManager
    {
        private const string OutputFile = "cars.json";

        public int Load(CarList carList)
        {
            return LoadFromAFile(OutputFile, carList);
        }

        public void Save(CarList carList)
        {
            SaveToAFile(OutputFile, carList);
        }

        static private void SaveToAFile(string filename, CarList carList)
        {
            string json = JsonConvert.SerializeObject(carList);
            File.WriteAllText(filename, json);
        }


        static private int LoadFromAFile(string filename, CarList carList)
        {
            if (File.Exists(filename))
            {
                string json = File.ReadAllText(filename);
                
                carList.Clear();
                int maxId = 0;
                CarList loadedList = JsonConvert.DeserializeObject<CarList>(json);
                foreach (var car in loadedList)
                {
                    if (car.Id > maxId)
                        maxId = car.Id;
                    carList.Add(car);
                }
                return maxId + 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
