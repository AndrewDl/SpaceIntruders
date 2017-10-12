using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceIntruders.Model;
using System.Collections.ObjectModel;
using System.Timers;
using System.ComponentModel;

namespace SpaceIntruders.ViewModel 
{
    class SimpleViewModel : INotifyPropertyChanged
    {
        ObservableCollection<Ship> shipList;

        public ObservableCollection<Ship> Ships
        {
            get;
            set;
        }

        public Ship userShip { get; set; }

        private Timer timer = new Timer(100);

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(PropertyName));
            }
        }

        public SimpleViewModel()
        {
            shipList = new ObservableCollection<Ship>();
            shipList.Add(new Ship("Battleship.png", 10, 10, "Test1", 10));
            shipList.Add(new Ship("Battleship.png", 10, 110, "Test2", 10));
            shipList.Add(new Ship("Battleship.png", 10, 210, "Test3", 10));
            shipList.Add(new Ship("Battleship.png", 100, 110, "Test4", 10));
            
            Ships = shipList;

            timer.Elapsed += Timer_Elapsed;
            timer.Enabled = true;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {

            foreach (Ship ship in shipList )
            {
                ship.X += 10;
            }
        }
    }
}
