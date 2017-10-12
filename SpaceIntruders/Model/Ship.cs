using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SpaceIntruders.Model 
{
    class Ship : INotifyPropertyChanged
    {
        
        private string name = "Untitled";
        private int hp = 0;

        private string imageURL = "";
        private double width = 32;
        private double height = 32;
        private int x = 0;
        private int y = 0;

        public event PropertyChangedEventHandler PropertyChanged;

        public Ship(string image, int x, int y, string Name, int HP)
        {
            imageURL = image;
            this.x = x;
            this.y = y;
            this.HP = hp;
            this.Name = Name;
        }

        public Ship()
        {
        }

        public int X { get { return x; } set
            {
                x = value;
                NotifyPropertyChanged("X");
                NotifyPropertyChanged("Margin");
            }
        }
        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
                NotifyPropertyChanged("Y");
                NotifyPropertyChanged("Margin");
            }
        }
        public double Width { get { return width; } }
        public double Height { get { return height; } }
        public string ImageSouce { get { return imageURL; } }

        public Thickness Margin
        {
            get
            {
                return new Thickness(x,y,0,0);
            }
        }

        public int HP
        {
            get
            {
                return hp;
            }
            set
            {
                hp = (value >= 0) ? value : 0;
                NotifyPropertyChanged("HP");
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                NotifyPropertyChanged("Name");
            }
        }

        public void NotifyPropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(PropertyName));
            }
        }
    }
}
