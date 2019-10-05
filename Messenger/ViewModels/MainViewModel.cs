using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messenger.Views;

namespace Messenger.ViewModels
{
    class MainViewModel : ViewModel
    {
        public MainViewModel()
        {
            Foo();
        }

        private ViewModel viewModel;
        public ViewModel ViewModel
        {
            get => viewModel;
            set
            {
                SetProperty(ref viewModel, value);
                //setLocation(Location);
            }
        }

        private int viewIndex;
        public int ViewIndex
        {
            get => viewIndex;
            set
            {
                SetProperty(ref viewIndex, value);
                ConvertViewIndexToLocation((Locations)viewIndex);
            }
        }

        private int viewModelIndex;
        public int ViewModelIndex
        {
            get => viewModelIndex;
            set => SetProperty(ref viewModelIndex, value);
        }

        private string background;
        public string Background
        {
            get => background;
            set => SetProperty(ref background, value);
        }

        public async void Foo()
        {
            //Background = "red";
            ViewModel = new LoginViewModel();
            ViewIndex = 0;
            //await Task.Delay(2000);
            ////Background = "green";
            //ViewModel = new IntroViewModel2();
            //ViewIndex = 1;
        }

        public void ConvertViewIndexToLocation(Locations location)
        {
            ViewModel destination = null;
            switch (location)
            {
                case Locations.Intro:
                    destination = new LoginViewModel();
                    break;
                case Locations.Intro2:
                    destination = new IntroViewModel2();
                    break;
            }
            ViewModel = destination;
            //System.Windows.MessageBox.Show(ViewModel.ToString());
        }
    }
}
