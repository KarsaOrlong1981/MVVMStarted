using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using MVVM.Views;
using MVVM.ViewModels;
using System.Windows.Input;
using System.Threading.Tasks;
using MVVM.Models;

namespace MVVM.ViewModels
{
    public class Page1ViewModel : BaseViewModel
    {
        string welcomeText = "Hello world";
        string entryText;
        public ICommand ButtonClickedCommand { get; set; }
        public ICommand ButtonEntryCommand { get; set; }
        public ICommand ButtonNextPage { get; set; }

        public INavigation Navigation { get; set; }

        AllData Tdata;
        public Page1ViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            ButtonNextPage = new Command(async () => await GotoPage2());
            ButtonClickedCommand = new Command(OnBottun1Clicked);
            ButtonEntryCommand = new Command(OnButtonEntryClicked);
            
        }
        public string WelcomeText
        {
            get => welcomeText;
            set => SetProperty(ref welcomeText, value);
        }
        public string EntryText
        {
            get => entryText;
            set => SetProperty(ref entryText, value);
        }
        void OnBottun1Clicked()
        {
            WelcomeText = "Hello Bound Command!!!";
        }
        void OnButtonEntryClicked()
        {
            Tdata = new AllData();

            WelcomeText = EntryText;
            Tdata.TextEintrag = WelcomeText;
        }
        

        public async Task GotoPage2()
        {
          
            await Navigation.PushAsync(new Page2(EntryText));
        }
        //Damit das Databinding funktioniert, benötigen Sie vier Zutaten:

        // Das Binding-Schlüsselwort in der XAML
        //Ein verbindlicher Kontext
        // Die Eigenschaft, an die gebunden werden soll
        // Implementierung von INotifyPropertyChanged


    }
}
