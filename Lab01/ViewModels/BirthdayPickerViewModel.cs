using KMA.ProgrammingInCSharp2024.Models;
using Lab1.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace KMA.ProgrammingInCSharp2024.ViewModels
{
    internal class BirthdayPickerViewModel : INotifyPropertyChanged
    {
        #region Fields
        private UserCandidate _user = new UserCandidate();
        private RelayCommand<object> _submitCommand;
        public event PropertyChangedEventHandler? PropertyChanged;
        #endregion

        #region Properties
        public DateTime BirthDate
        {
            get { return _user.BirthDate; }
            set
            {
                _user.BirthDate = value;
                OnPropertyChanged();
            }

        }

        public string Age
        {
            get { return _user.Age; }
            set
            {
                _user.Age = value;
                OnPropertyChanged();
            }
        }


        public string WesternZodiac
        {
            get { return _user.WesternZodiac; }
            set
            {
                _user.WesternZodiac = value;
                OnPropertyChanged();
            }
        }

        public string ChineseZodiac
        {
            get { return _user.ChineseZodiac; }
            set
            {
                _user.ChineseZodiac = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand<object> SubmitCommand
        {
            get
            {
                return _submitCommand ??= (_submitCommand = new RelayCommand<object>(
                    ProcessWithSubmit));
            }
        }


        #endregion


        #region Logic
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        

        private void ProcessWithSubmit(object obj)
        {
            DateTime atTheMoment = DateTime.Today;
            int age = atTheMoment.Year - BirthDate.Year;

            if (((atTheMoment.Month == BirthDate.Month) && (BirthDate.Day > atTheMoment.Day)) || BirthDate.Month > atTheMoment.Month)
            {
                age--;
            }

            if (age >= 0 && age < 135)
            {
                Age ="" + age;
            }
            else
            {
                if (age < 0)
                {
          
                    MessageBox.Show("Sorry bud, you're not born yet to believe in zodiac signs...");
                    return;
                }
                else  
                {
                    MessageBox.Show("Sorry bud, you're too old to believe in zodiac signs...");
                    return;

                }

            }

            if (DateTime.Today.Month == BirthDate.Month && DateTime.Today.Day == BirthDate.Day)
            {
                MessageBox.Show("Happy birthday to an oldie, but goodie!");
            }
            WesternZodiac = CalculateUserWesternZodiac(BirthDate);
            ChineseZodiac = CalculateUserChineseZodiac(BirthDate);
        }

        private string CalculateUserWesternZodiac(DateTime birthDate)
        {
            int day = birthDate.Day;
            int month = birthDate.Month;

            return
                (month == 1 && day >= 20) || (month == 2 && day <= 18) ? "Aquarius" :
                (month == 2 && day >= 19) || (month == 3 && day <= 20) ? "Pisces" :
                (month == 3 && day >= 21) || (month == 4 && day <= 19) ? "Aries" :
                (month == 4 && day >= 20) || (month == 5 && day <= 20) ? "Taurus" :
                (month == 5 && day >= 21) || (month == 6 && day <= 20) ? "Gemini" :
                (month == 6 && day >= 21) || (month == 7 && day <= 22) ? "Cancer" :
                (month == 7 && day >= 23) || (month == 8 && day <= 22) ? "Leo" :
                (month == 8 && day >= 23) || (month == 9 && day <= 22) ? "Virgo" :
                (month == 9 && day >= 23) || (month == 10 && day <= 22) ? "Libra" :
                (month == 10 && day >= 23) || (month == 11 && day <= 21) ? "Scorpio" :
                (month == 11 && day >= 22) || (month == 12 && day <= 21) ? "Sagittarius" :
                (month == 12 && day >= 22) || (month == 1 && day <= 19) ? "Capricorn" :
                string.Empty;
        }

        private string CalculateUserChineseZodiac(DateTime birthDate)
        {
            int zodiacYear = (birthDate.Year - 4) % 12;

            switch (zodiacYear)
            {
                case 0: return "Rat";
                case 1: return "Ox";
                case 2: return "Tiger";
                case 3: return "Rabbit";
                case 4: return "Dragon";
                case 5: return "Snake";
                case 6: return "Horse";
                case 7: return "Sheep";
                case 8: return "Monkey";
                case 9: return "Rooster";
                case 10: return "Dog";
                case 11: return "Pig";
                default: return string.Empty;
            }
        }

       
        #endregion


    }
}
