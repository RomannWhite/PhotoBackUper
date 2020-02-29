using PhotoBackUper.M.Classes;
using System.Windows.Input;
using PhotoBackUper.M;
using System.Linq;
using System;

namespace PhotoBackUper.VM
{
    class MainWindowViewModel : ViewModel
    {
        public MainWindowViewModel()
        {
            ButtonCommand = new CustomCommand(StartMoving);
        }
        void StartMoving(object s)
        {
            Model.MoveFiles(FromPath, ToPath, StartTime, EndTime);
        }
        DateTime StartTime, EndTime;
        string frompath = @"F:\DCIM\100CANON";
        public string FromPath
        {
            get => frompath;
            set
            {
                Model.CheckFilesInfo(frompath = value, OnFilesOnfoChecked);
                OnPropertyChanged("FromPath");
            }
        }
        void OnFilesOnfoChecked(FilesInfo Info)
        {
            if(Info != null)
            {
                StartTime = Info.ContFromDates.LastOrDefault().Date.Date;
                EndTime = Info.ContFromDates.LastOrDefault().Date.Date.AddDays(1);
                ToPath = @"D:\Canon BackUp2\" +
                    Info.ContFromDates.LastOrDefault().Date.Year.ToString() + @"\" +
                    Info.ContFromDates.LastOrDefault().Date.Month.ToString("00") + @"\" +
                    Info.ContFromDates.LastOrDefault().Date.Day.ToString("00");
                FilesCount = Info.ContFromDates.LastOrDefault().Count;
            }
            else
            {
                ToPath = @"D:\Canon BackUp2";
                FilesCount = -1;
            }
        }
        string topath = @"D:\Canon BackUp2";
        public string ToPath
        {
            get => topath;
            set
            {
                topath = value;
                OnPropertyChanged("ToPath");
            }
        }
        int filescount;
        public int FilesCount
        {
            get => filescount;
            set
            {
                filescount = value;
                OnPropertyChanged("FilesCount");
            }
        }
        public ICommand ButtonCommand { get; set; }
    }
}
