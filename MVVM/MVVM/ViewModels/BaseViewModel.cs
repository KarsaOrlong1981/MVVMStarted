using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVVM.ViewModels
{
    //INotifyPropertyChanged
   // Die zu bindende Eigenschaft befindet sich im ViewModel(wie wir gesehen haben) und dann müssen wir INotifyPropertyChanged implementieren.
   // Diese Schnittstelle ist in jeder Ihrer ViewModel-Klassen implementiert, was mühsam wird, also verschieben wir sie zum Basisansichtsmodell. 
  //Das Basisansichtsmodell, das mir gefällt, macht ein wenig ausgefallene Fußarbeit: Es erstellt die SetValue-Methode,
  //um das Binden noch einfacher zu machen.Hier ist das Basisansichtsmodell:
    public abstract class BaseViewModel : INotifyPropertyChanged 
    {
        //deklariert das (erforderliche) Ereignis PropertyChanged, das von der Schnittstelle definiert wird.  
        public event PropertyChangedEventHandler PropertyChanged;
        //als nächstes wird überprüft, ob sich jemand für das Ereignis registriert hat,
        //und in diesem Fall wird das Ereignis mit dem Namen der aktualisierten Eigenschaft ausgelöst.
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        //Dies ist eine Hilfsmethode, die das Festlegen der Eigenschaft erleichtern soll. Im Moment können Sie dieses einfach im Glauben nehmen,
        //oder wenn Sie mit Generika vertraut sind, können Sie es ein wenig studieren, um zu sehen, wie es funktioniert.  
        protected bool SetProperty<T>(ref T backingStore, T value,
           [CallerMemberName] string propertyName = "",
           Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
