using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Laba4_ControlLib
{
    public static class GameCommands
    {
        static GameCommands()
        {
            Start = new RoutedCommand("Start", typeof(GameControl));
            Pause = new RoutedCommand("Pause", typeof(GameControl));
            Reset = new RoutedCommand("Reset", typeof(GameControl));
        }

        public static RoutedCommand Start { get; set; }
        public static RoutedCommand Pause { get; set; }
        public static RoutedCommand Reset { get; set; }
    }
}
