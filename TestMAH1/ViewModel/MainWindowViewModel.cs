using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

#region Variables
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

        private string _GoalTextBlock;
        public string GoalTextBlock
        {
            get
            {
                return _GoalTextBlock;
            }
            set
            {
                _GoalTextBlock = value;
                OnPropertyChanged("GoalTextBlock");
            }
        }

        private int _CriterionNum;
        public int CriterionNum
        {
            get
            {
                return _CriterionNum;
            }
            set
            {
                _CriterionNum = value;
                OnPropertyChanged("CriterionNum");
            }
        }

        private int _AlternativeNum;
        public int AlternativeNum
        {
            get
            {
                return _AlternativeNum;
            }
            set
            {
                _AlternativeNum = value;
                OnPropertyChanged("AlternativeNum");
            }
        }

        private Visibility _AcceptModel;
        public Visibility AcceptModel
        {
            get
            {
                return _AcceptModel;
            }
            set
            {
                _AcceptModel = value;
                OnPropertyChanged("AcceptModel");
            }
        }

        private ObservableCollection<string> _items;
        public ObservableCollection<string> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                this.OnPropertyChanged("Items");
            }
        }

        private string _myString;
        public string MyStringProperty
        {
            get { return _myString; }
            set
            {
                _myString = value;
                this.OnPropertyChanged("MyStringProperty");
            }
        }



        public ObservableCollection<string> SomeCollection { get; set; }
        #endregion


        #region Commands
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

        private ICommand _EnterDataC;
        public ICommand EnterDataC
        {
            get
            {
                return _EnterDataC;

            }

            set
            {
                //OnPropertyChanged("CreateModel");
                _EnterDataC = value;
            }
        }

        private ICommand _CreateModelBtn_Click;
        public ICommand CreateModelBtn_Click
        {
            get
            {
                return _CreateModelBtn_Click;

            }

            set
            {
                //OnPropertyChanged("CreateModel");
                _CreateModelBtn_Click = value;
            }
        }


        #endregion
#region Menu
        public MainWindowViewModel()
        {

            SomeCollection = new ObservableCollection<string>();
            Items = new ObservableCollection<string>();
            //MainPage = new MenuUserControl();
            AcceptModel = Visibility.Hidden;
            ExecuteCommand = new CommandHandler(Execute, () => true);
            HomePage = new CommandHandler(SetHomePage, () => true);
            CreateModel = new CommandHandler(SetCreateModelPage, () => true);
            EnterDataC = new CommandHandler(SetEnterDataPage, () => true);
            CreateModelBtn_Click = new CommandHandler(CreateModelMethod, () => true);


            //ObservableCollection<TextBlock> Columns{ G }

        }

        private void Execute()
        {
            MessageBox.Show("Its life");
        }

        public void SetHomePage()
        {
            
            MainPage = new MenuUserControl();
           
            
        }

        public void SetCreateModelPage()
        {
            
            MainPage = new CreateModelUserControl();
            
        }

        public void SetEnterDataPage()
        {

            MainPage = new EnterData();

        }
        #endregion

#region Method
        private void CreateModelMethod()
        {
            MessageBox.Show(String.Format("test wartosci to {0}{1}{2}",GoalTextBlock, CriterionNum,AlternativeNum));
            AcceptModel = Visibility.Visible;
            SomeCollection.Clear();
            for(int i=0;i<CriterionNum;i++)
            {
                SomeCollection.Add("text: "+i);
                Items.Add(MyStringProperty);
            }
        }

#endregion

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
