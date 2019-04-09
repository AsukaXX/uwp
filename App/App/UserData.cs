using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace App
{
    class UserData : INotifyPropertyChanged
    {
        #region
        private static UserData _userData = null;
        private int _count = default(int);
        #endregion
        static UserData()
        {
            _userData = new UserData();
        }
        public int Count
        {
            get { return _count; }
            set
            {
                if(value != _count)
                {
                    _count = value;
                    OnPropertyChangde();
                }
            }
        }
        public static UserData CurrentInstance
        {
            get
            {
                return _userData;
            }
        }
        public static void LoadData()
        {
            object settingVal = null;
            if (ApplicationData.Current.LocalSettings.Values.TryGetValue("num",out settingVal))
            {
                CurrentInstance.Count = Convert.ToInt32(settingVal);
            }
            else
            {
                CurrentInstance.Count = 0;
            }
        }
        public static void SaveData()
        {
            ApplicationData.Current.LocalSettings.Values["num"] = CurrentInstance.Count;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChangde([CallerMemberName] string propName = "")
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
