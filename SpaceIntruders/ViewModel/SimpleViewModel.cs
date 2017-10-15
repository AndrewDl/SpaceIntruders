using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceIntruders.Model;
using System.Collections.ObjectModel;
using System.Timers;
using System.ComponentModel;
using System.Windows.Input;

namespace SpaceIntruders.ViewModel
{
    class SimpleViewModel : INotifyPropertyChanged
    {
        ObservableCollection<Ship> shipList;

        public ObservableCollection<Ship> Ships { get; set; }

        public Space CosmoSpace { get; set; }

        private Timer timer = new Timer(100);

        private Ship userShip;

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
            CosmoSpace = Space.getInstance(480, 640);

            userShip = new Ship("../Battleship.png", 0, CosmoSpace.Heigth - 42, "UserShip", 10);

            shipList = new ObservableCollection<Ship>();
            shipList.Add(userShip);
            /*branching test*/
            Ships = shipList;

            timer.Elapsed += Timer_Elapsed;
            timer.Enabled = true;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            /*
            foreach (Ship ship in shipList)
            {
                if (ship.X + ship.Width < CosmoSpace.Width)
                    ship.X += 10;
            }*/
        }
                
    }

}