using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Agar.io
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
    

        private readonly Game _game;
        private TimeSpan _last;

        public MainWindow()
        {
            InitializeComponent();

            _game = new Game(this);
            _game.Objects.Add(new Player() { Size = 32, X = 100, Y = 80,SpeedX=200,SpeedY=200 });

            DataContext = _game;

            CompositionTarget.Rendering += CompositionTarget_Rendering;
        }

        // Déclenché à fois que la fenêtre se redessine (WPF : 60x par seconde)
        private void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            RenderingEventArgs re = (RenderingEventArgs)e;

            if (_last != TimeSpan.Zero)
            {
                // Durée écoulée entre deux rendus.
                TimeSpan dt = re.RenderingTime - _last;

                // Rafraîchit l'objet animé.
                _game.Update(dt);
            }

            _last = re.RenderingTime;
        }
    }
}
