using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TestMAH1.View;


namespace TestMAH1.ViewModel
{
    class MainWindowViewModel : INotifyPropertyChanged
    {


        private UserControl _MainPage;
        public UserControl MainPage
        {
            get
            {
                return _MainPage;
            }
            set
            {
               
                _MainPage = value;
                OnPropertyChanged("MainPage");
            }
        }

        private ICommand _ExecuteCommand;
        public ICommand ExecuteCommand
        {
            get
            {
                return _ExecuteCommand;

            }

            set
            {
                _ExecuteCommand = value;
            }
        }

        private ICommand _HomePage;
        public ICommand HomePage
        {
            get
            {
                return _HomePage;

            }

            set
            {
                OnPropertyChanged("HomePage");
                _HomePage = value;
            }
        }

        private ICommand _CreateModel;
        public ICommand CreateModel
        {
            get
            {
                return _CreateModel;

            }

            set
            {
                //OnPropertyChanged("CreateModel");
                _CreateModel = value;
            }
        }


        public MainWindowViewModel()
        {
            
            ExecuteCommand = new CommandHandler(Execute, () => true);
            HomePage = new CommandHandler(SetHomePage, () => true);
            CreateModel = new CommandHandler(SetCreateModelPage, () => true);
        }

        private void Execute()
        {
            MessageBox.Show("Its life");
        }

        public void SetHomePage()
        {
            
            MainPage = new HomeUserControl();
           
            
        }

        public void SetCreateModelPage()
        {
            MainPage = new CreateModelUserControl();
        }
        #region Property Changed
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if(handler!=null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion

    }


}
