using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.ViewModels
{
    public enum Locations
    {
        Intro,
        Intro2
    }

    public static class Navigation
    {
        private static Locations currentLocation;

        public static void SetCurrentLocation(Locations location)
        {
            currentLocation = location;
        }

        public static Locations GetCurrentLocation()
        {
            return currentLocation;
        }

        //public static ViewModel Convert(int)
    }
}
