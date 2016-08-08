using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Catalyst.Model
{
   public class CatalystMember : INotifyPropertyChanged
    {
        string _FirstName;
        public string FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                if (_FirstName != value)
                {
                    _FirstName = value;
                    RaisePropertyChanged("FirstName");
                }
            }
        }

        string _LastName;
        public string LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                if (_LastName != value)
                {
                    _LastName = value;
                    RaisePropertyChanged("LastName");
                }
            }
        }

        int _Age;
        public int Age
        {
            get
            {
                return _Age;
            }
            set
            {
                if (_Age != value)
                {
                    _Age = value;
                    RaisePropertyChanged("Age");
                }
            }
        }

        Nullable<decimal> _Salary;
        public Nullable<decimal> Salary
        {
            get
            {
                return _Salary;
            }
            set
            {
                if (_Salary != value)
                {
                    _Salary = value;
                    RaisePropertyChanged("Salary");
                }
            }
        }


        string _Address;
        public string Address
        {
            get
            {
                return _Address;
            }
            set
            {
                if (_Address != value)
                {
                    _Address = value;
                    RaisePropertyChanged("Address");
                }
            }
        }

        string _interests;
        public string Interests
        {
            get
            {
                return _interests;
            }
            set
            {
                if (_interests != value)
                {
                    _interests = value;
                    RaisePropertyChanged("Interests");
                }
            }
        }
 
        byte[] _pic;
        public byte[] Pic
        {
            get
            {
                return _pic;
            }
            set
            {
                if (_pic != value)
                {
                    _pic = value;
                    RaisePropertyChanged("Pic");
                }
            }
        }


      

        void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}

