using System.Windows;
using Microsoft.EntityFrameworkCore;

namespace netcore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ICarManager carManager;
        public MainWindow()
        {
            InitializeComponent();
            carManager = CarManagerFactory.CreateCarManager(false);

            NextId = carManager.Load(ViewModel); 
/*            using (var ctx = new CarContext())
            {
                var list = ctx.Cars;

                var car = new CarModel(NextId, VehicleType.Car, "toyota", "camry", "v8", 4, 4, "sedan");
                ctx.Cars.Add(car);
                ctx.SaveChanges();
            }*/
        }

        private int NextId = 0;

        public CarList ViewModel
        {
            get
            {
                return (CarList)Resources["ViewModel"];
            }
        }

        private void NewCar_Clicked(object sender, RoutedEventArgs e)
        {
            ViewModel.Add(new CarModel(NextId, VehicleType.Car, "toyota", "camry", "v8", 4, 4, "sedan"));
            ++NextId;
        }

        private void DeleteCar_Clicked(object sender, RoutedEventArgs e)
        {
            var selectedCar = carsGrid.SelectedItem;
            if (selectedCar != null)
            {
                CarModel model = (CarModel)selectedCar;
                ViewModel.Remove(model);
            }
        }

        private void SaveCars_Clicked(object sender, RoutedEventArgs e)
        {
            carManager.Save(ViewModel);
        }

        private void Exit_Clicked(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
