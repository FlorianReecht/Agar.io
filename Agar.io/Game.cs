using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Agar.io
{
    public class Game
    {
        public static int GameWidth = 20;
        public static int GameHeight = 200;
        public double Clock { get; set; }
        private readonly ObservableCollection<GameObject> _objects = new ObservableCollection<GameObject>();

        public ObservableCollection<GameObject> Objects => _objects;
        public static List<String> ColorList = new List<string>();
        MainWindow fenetre;
        public Game(MainWindow w)
        {
            
           
            fenetre = w;
        }
        public void Update(TimeSpan dt)
        {
            Clock += dt.TotalSeconds;
            if(Clock>2)
            {
                _objects.Add(new Food(1000, 1000));
                Clock = 0;

            }
            foreach (GameObject o in _objects)//On les fait bouger
            {
                o.Update(dt,Mouse.GetPosition(fenetre));
                o.SetCentre();

            }
            for (int i=0;i<_objects.Count;i++)
            {
                for(int j=0;j<_objects.Count;j++)
                {
                    if(_objects[i].IsInRange(_objects[j]))
                    {
                        if(_objects[i].Equals(_objects[j])==false)
                        {
                            Manger(_objects[i], _objects[j]);
                        }
                    }
                }
            }
            
        }
        public void Manger(GameObject eater, GameObject eaten)
        {
            eater.Size += eaten.Size;
            _objects.Remove(eaten);

        }

    }
  

   
}
