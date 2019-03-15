using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MvvmDemo.ViewModel
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public HomeViewModel()
        {
            CheckDate = new Command(Check);
        }
        private DateTime selecteddate { get; set; }

        public DateTime SelectedDate
        {
            get { return selecteddate; }
            set
            {
                selecteddate = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedDate"));
            }
        }
        private string totalage { get; set; }
        public string TotalAge
        {
            get { return totalage; }
            set
            {
                totalage = value;
                PropertyChanged(this, new PropertyChangedEventArgs("TotalAge"));
            }
        }
        public ICommand CheckDate { protected set; get; }



        public void Check()
        {
            DateTime currentdate = DateTime.Now;
            var totlaldays = (currentdate - selecteddate).TotalDays;

            var totalYears = Math.Truncate(totlaldays / 365);
            var totalMonth = Math.Truncate((totlaldays % 365) / 30);
            var remaningday = Math.Truncate((totlaldays % 365) % 30);
            TotalAge = "Year :" + totalYears + " Month: " + totalMonth + " Day :" + remaningday;



        }

    }
}
