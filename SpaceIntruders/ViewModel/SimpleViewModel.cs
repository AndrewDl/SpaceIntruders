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
            CosmoSpace = new Space(480, 640);

            userShip = new Ship("../Battleship.png", CosmoSpace.Width/2, CosmoSpace.Heigth - 42, "UserShip", 10);

            //initialize key bindings
            MoveLeft = new Command(moveLeft, canMoveLeft);
            MoveRight = new Command(moveRight, canMoveRight);
            Fire = new Command(fire, canFire);

            shipList = new ObservableCollection<Ship>();
            shipList.Add(userShip);

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
        
        public ICommand MoveLeft { get; set; }

        public ICommand MoveRight { get; set; }

        public ICommand Fire { get; set; }

        private void moveLeft(object param)
        {
            userShip.X -= 10;
        }

        private void moveRight(object param)
        {
            userShip.X += 10;
        }

        private void fire(object param)
        {

        }

        private bool canMoveLeft(object param)
        {
            return userShip.X > 0;
        }

        private bool canMoveRight(object param)
        {
            return userShip.X+userShip.Width < CosmoSpace.Width;
        }

        private bool canFire(object param)
        {
            return true;
        }

    }

}