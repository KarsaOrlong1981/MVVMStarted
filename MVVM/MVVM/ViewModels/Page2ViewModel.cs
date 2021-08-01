using System;
using System.Collections.Generic;
using System.Text;


namespace MVVM.ViewModels
{
    class Page2ViewModel : BaseViewModel
    {
        string txt;
        public Page2ViewModel(string str)
        {
            txt = str;
        }
        public string Text
        {
            get => txt;
            set => SetProperty(ref txt, value);
        }

    }
}
