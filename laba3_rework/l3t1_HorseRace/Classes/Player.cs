using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace l3t1_HorseRace.Classes
{
    public class Player : INotifyPropertyChanged
    {
        
        private double _bankAccount;

        public double BankAccount
        {
            get => _bankAccount;
            set
            {
                if (value < 0) return;
                _bankAccount = value;
                OnPropertyChanged();
            }
        }
        public string Bet_HorseName { get; set; }
        public string Bet_Amount { get; set; }

        public Player()
        {
            BankAccount = 250;
        }

        
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}