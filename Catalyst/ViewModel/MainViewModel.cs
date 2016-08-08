using System.Collections.ObjectModel;
using Catalyst.ViewModel;
using Catalyst.Model;
using Catalyst.Helpers;
using System.IO;
using System.Drawing;
using System.Windows.Input;
using System.ComponentModel;

namespace Catalyst
{
    public class MainViewModel : ViewModelBase
    {

        ObservableCollection<CatalystMember> _People;
        CatalystMemberBusinessObject personnel;
        CatalystMember Member;
        private BackgroundWorker worker;

        #region Properties
        public string FirstName
        {
            get
            {
                return Member.FirstName;
            }
            set
            {
                Member.FirstName = value;

            }
        }

        public string LastName
        {
            get
            {
                return Member.LastName;
            }
            set
            {
                Member.LastName = value;

            }
        }

        public int Age
        {
            get
            {
                return Member.Age;
            }
            set
            {

                Member.Age = value;

            }
        }

        public string Address
        {
            get
            {
                return Member.Address;
            }
            set
            {

                Member.Address = value;

            }
        }

        public string Interests
        {
            get
            {
                return Member.Interests;
            }
            set
            {

                Member.Interests = value;

            }
        }

        public byte[] Pic
        {
            get
            {
                return Member.Pic;
            }
            set
            {

                Member.Pic = value;
                RaisePropertyChanged("Pic");
            }
        }

        private string _selectedPath;
        public string SelectedPath
        {
            get { return _selectedPath; }
            set
            {
                _selectedPath = value;
                if (_selectedPath != "")
                {
                    FileStream stream = new FileStream(
                   _selectedPath, FileMode.Open, FileAccess.Read);
                    BinaryReader reader = new BinaryReader(stream);

                    Pic = reader.ReadBytes((int)stream.Length);

                }
                RaisePropertyChanged("SelectedPath");
            }
        }

      
        string _SearchText;
        public string SearchText
        {
            get
            {
                return _SearchText;
            }
            set
            {
                if (_SearchText != value)
                {
                    _SearchText = value;
                    RaisePropertyChanged("SearchText");
                }
            }
        }
        
        public ObservableCollection<CatalystMember> People
        {
            get
            {
                return _People;
            }
            set
            {
                _People = value;
                RaisePropertyChanged("People");
            }

        }

        #endregion

        public MainViewModel()
        {
            personnel = new CatalystMemberBusinessObject();
            Member = new Model.CatalystMember();
            ReSet();
        }

        #region Commands

        public ICommand OpenCommand { get { return new RelayCommand(openFileDialogueExecute, CanopenFileDialogue); } }
        bool CanopenFileDialogue()
        {
            return true;
        }


        public ICommand AddCommand { get { return new RelayCommand(DoSaveExecute, CanSave); } }
        bool CanSave()
        {
            return true;
        }

        public ICommand SearchCommand { get { return new RelayCommand(SearchExecute, CanSearch); } }
        bool CanSearch()
        {
            return true;
        }

        public ICommand ResetCommand { get { return new RelayCommand(RefreshExecute, CanRefresh); } }
        bool CanRefresh()
        {
            return true;
        }

        void openFileDialogueExecute()
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            // dialog.Filter = "Image Files *.*";
            dialog.ShowDialog();

            SelectedPath = dialog.FileName;
        }
        void DoSaveExecute()
        {
            personnel.Create(Member);
            Member = new Model.CatalystMember();
            ReSet();
        }
       

        void RefreshExecute()
        {
            ReSet();
        }
        void SearchExecute()
        {
            People = new ObservableCollection<CatalystMember>();
            this.worker = new BackgroundWorker();
            this.worker.WorkerReportsProgress = true;
            this.worker.DoWork += this.DoSearch;
            this.worker.ProgressChanged += this.ProgressChanged;
            this.worker.RunWorkerAsync();

        }
        public void ReSet()
        {
            FirstName = "";
            LastName = "";
            Age = 0;
            Interests = "";
            Address = "";
            SelectedPath = "";
            SearchText = "";
            People = new ObservableCollection<Model.CatalystMember>();
            this.worker = new BackgroundWorker();
            this.worker.WorkerReportsProgress = true;
            this.worker.DoWork += this.DoWork;
            this.worker.ProgressChanged += this.ProgressChanged;
            this.worker.RunWorkerAsync();


        }

        #endregion

        #region ProgressBar
        private double _currentProgress;
        public double CurrentProgress
        {
            get { return _currentProgress; }
            private set
            {
                _currentProgress = value;
                RaisePropertyChanged("CurrentProgress");
            }
        }

        private void DoSearch(object sender, DoWorkEventArgs e)
        {
            if (_SearchText != "")
            {
               
                IsLoading = true;
                for (int i = 0; i < 10; i++)
                {
                    System.Threading.Thread.Sleep(1000);
                    worker.ReportProgress(i * (100 / 10));
                   
                }

               
                People = personnel.Search(SearchText);
                IsLoading = false;
            }
            else
                ReSet();
           
        }
        private void DoWork(object sender, DoWorkEventArgs e)
        {
            // do time-consuming work here, calling ReportProgress as and when you can
            IsLoading = true;
            for (int i = 0; i < 10; i++)
            {
                System.Threading.Thread.Sleep(1000);
                worker.ReportProgress(i * (100 / 10));
                //CurrentProgress = i;
                //RaisePropertyChanged("CurrentProgress");
            }

            _People = new ObservableCollection<CatalystMember>();

            People = personnel.GetAll();
            IsLoading = false;
        }

        private void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.CurrentProgress = e.ProgressPercentage;
        }

        private bool _isLoading = false;
        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                _isLoading = value;
                RaisePropertyChanged("IsLoading");
            }
        }

        #endregion
        
        
    }
}
