using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exe_personne
{
    //Créer le viewModel; il doit implementer  INotifyPropertyChanged
    //pour aviser l'interface utilisateur des changements


    public class MonViewModel: INotifyPropertyChanged
    {   //C'est l'evenement necessaire pour implementer  INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;
        // ObservationColllection permetr d'utiliser le biending
        public ObservableCollection<Personne> ListePersonnes { get; set; }
        //objet courrant selectionné avec encapsulation
        private Personne _selectedPersonne;
        
               
        public Personne PersonneSelectionnee
        {
            get { return _selectedPersonne; }
            set { _selectedPersonne = value; OnPropertyChanged(nameof(PersonneSelectionnee)); }

        }
        public MonViewModel()

        {   //Initialiser les propriété  di viewModel avec les valeurs qui seron afficher
            ListePersonnes = new ObservableCollection<Personne>

                {
                new Personne { Nom ="Alice", Age = 25}, // Utilise le constructeur
                new Personne { Nom = "Bob", Age = 35},
                new Personne { Nom = "Charlie", Age = 35},

                };
            PersonneSelectionnee = ListePersonnes[0];  
            
                  
        
        }
        protected void OnPropertyChanged(string propertyName)
        { 
            // Déclancher l'évenement pour informer l'interface utilisateur d'un changement
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));       
        
        }





    }
}
