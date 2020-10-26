using System.ComponentModel;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using System.IO;
using System;

namespace netcore
{
    public enum VehicleType
    {
        Car,
        Boat
    }

    public class CarModel : INotifyPropertyChanged
    {
        public CarModel()
        {
            Id = 0;
            Type = VehicleType.Car;
            Make = "toyota";
            Model = "camry";
            Engine = "v8";
            Doors = 4;
            Wheels = 4;
            BodyType = "sedan";
        }

        public CarModel(int id, VehicleType vehicleType, string make, string model, string engine, int doors, int wheels, string bodyType)
        {
            Id = id;
            Type = vehicleType;
            Make = make;
            Model = model;
            Engine = engine;
            Doors = doors;
            Wheels = wheels;
            BodyType = bodyType;
        }

        public int Id { get; set; }
        public VehicleType Type { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Engine { get; set; }
        public int Doors { get; set; }
        public int Wheels { get; set; }
        public string BodyType { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class CarList : ObservableCollection<CarModel>
    {
    }
}
