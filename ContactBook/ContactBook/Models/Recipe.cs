using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ContactBook.Models
{
    //INotifyPropertyChanged is interface for ObservableCollection class
    //Which notifies its subscribers if any change happends. For example
    //Update recipe in Data Access Page
    public class Recipe : INotifyPropertyChanged
    {
        //On update
        public event PropertyChangedEventHandler PropertyChanged;

        private string _name;

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(255)]
        public string Name 
        {
            get { return _name; }
            set 
            {
                if (_name == value)
                {
                    return;
                }
                else
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }        
    }
}
