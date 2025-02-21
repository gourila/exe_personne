using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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

        // propriété pour la pagination
        private int _CurrentIndex; //indice de la personne séléctionnée

        public int CurrentIndex
        {
            get => _CurrentIndex;
            set 
            { 
                if (_CurrentIndex != value && value >= 0 && value < ListePersonnes.Count)
                {
                    _CurrentIndex = value; 
                    OnPropertyChanged(nameof(CurrentIndex));
                    PersonneSelectionnee = ListePersonnes[_CurrentIndex]; //Synchroniser la selection
                    OnPropertyChanged(nameof(CanGoPrevious));      // Mettre à jour les bouttons
                    OnPropertyChanged(nameof(CanGoNext));
                }
            
            
            }







        }










        public ICommand PreviousCommand { get; set; }  //commandes pour les bouttons
        public ICommand NextCommand { get; set; }
        
        public MonViewModel()

        {   //Initialiser les propriété  di viewModel avec les valeurs qui seron afficher
            ListePersonnes = new ObservableCollection<Personne>

                {
                new Personne { Nom ="Alice", Age = 25}, // Utilise le constructeur par défaut
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
        private void Previous()
        {
            if (_CurrentIndex > 0 )
            { 
                _CurrentIndex--;
                PersonneSelectionnee = ListePersonnes[_CurrentIndex];
            }
        }
        private bool CanGoPrevious() => _CurrentIndex > 0;

        private void Next()
        {
            if (_CurrentIndex < ListePersonnes.Count - 1)
            {
                _CurrentIndex++;
                PersonneSelectionnee = ListePersonnes[_CurrentIndex];
            }
        }

        private bool CanGoNext() => _CurrentIndex < ListePersonnes.Count - 1;
    }






}

