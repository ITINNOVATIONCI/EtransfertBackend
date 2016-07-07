using EtransfertBackend.COMMON;
using EtransfertBackend.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Data.DataForm;
using Telerik.Windows.Data;

namespace EtransfertBackend.TransactionsModules.ViewModels
{
    public class TransactionsViewModel : ObservableObject
    {

        #region Members
        public eTransferttestEntities model;
        private BackgroundWorker worker = new BackgroundWorker();
        ObservableCollection<ListeTransactionsFull> _data = new ObservableCollection<ListeTransactionsFull>();
        AspNetUsers _Users = new AspNetUsers();
        ObservableCollection<AspNetUsers> _allUsers = new ObservableCollection<AspNetUsers>();
        //ObservableCollection<AspNetRoles> _allRoles = new ObservableCollection<AspNetRoles>();
        Transactions _selectedData = new Transactions();
        
        bool _isBusy;
        int _count = 0;
        #endregion

        #region Properties
        public ObservableCollection<ListeTransactionsFull> AllData
        {
            get
            {
                return _data;
            }
            set
            {
                _data = value;
                RaisePropertyChanged("AllData");
            }
        }

        public ObservableCollection<AspNetUsers> AllUsers
        {
            get
            {
                return _allUsers;
            }
            set
            {
                _allUsers = value;
                RaisePropertyChanged("AllUsers");
            }
        }

        public  AspNetUsers Users
        {
            get
            {
                return Users;
            }
            set
            {
                _Users = value;
                RaisePropertyChanged("Users");
            }
        }

        //public ObservableCollection<AspNetRoles> AllRoles
        //{
        //    get
        //    {
        //        return _allRoles;
        //    }
        //    set
        //    {
        //        _allRoles = value;
        //        RaisePropertyChanged("AllRoles");
        //    }
        //}







        public Transactions SelectedData
        {
            get
            {
                return _selectedData;
            }
            set
            {
                _selectedData = value;
                RaisePropertyChanged("SelectedData");
            }
        }
        

        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }
            set
            {
                _isBusy = value;
                RaisePropertyChanged("IsBusy");
            }
        }
        #endregion

        #region Construction
        public TransactionsViewModel()
        {
            worker.DoWork += this.WorkerDoWork;
            worker.RunWorkerCompleted += WorkerRunWorkerCompleted;

            Refresh();

        }

        public void Refresh()
        {

            //Demarre le Background Worker et commence le radBusyIndicator
            if (!worker.IsBusy)
            {
                this.IsBusy = true;
                worker.RunWorkerAsync();
            }

        }

        //La methode de demmarge du BackgroundWorker
        private void WorkerDoWork(object sender, DoWorkEventArgs e)
        {
            //appel la methode load
            Load();
        }

        //Met a jour le UI et stop le RadBusyIndicator
        private void UpdateDataSource()
        {

            this.IsBusy = false;

        }

        void WorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Quand la methode load a fini de charger les infos on appel la methode UpdateDataSource
            //pour mettre a jour le UI
            //Dispatcher.BeginInvoke(new Action(this.UpdateDataSource));

            this.IsBusy = false;
        }

        private void Load()
        {
            try
            {
                int mois = DateTime.UtcNow.Month;

                model = new eTransferttestEntities();

                var resultat = model.ListeTransactionsFull.OrderByDescending(r => r.DateTransaction);
                           //.OrderByDescending(d=>d.AspNetUsers.Email)
                               //where res.Etat == "ACTIF"
                          

            AllData = new ObservableCollection<ListeTransactionsFull>(resultat.ToList());

                
                
                //AllUsers = new ObservableCollection<AspNetUsers>();


            

                //foreach (var item in AllData)
                //{
                //   var rep =   model.AspNetUsers.Where(a => a.Id == item.Utilisateur).FirstOrDefault();
                //    AllUsers.Add(rep);
                //}

            

            //var resultat2 = from res in model.AspNetRoles
            //                //where res.Etat == "ACTIF"
            //                select res;

            //AllRoles = new ObservableCollection<AspNetRoles>(resultat2.ToList());


            }
            catch (Exception)
            {

               
            }





        }

        public void CancelChanged()
        {

            var resultat = from res in model.ListeTransactionsFull.OrderByDescending(r => r.DateTransaction).Take(950)
            // where res.Etat == "ACTIF"
            select res;

            AllData = new ObservableCollection<ListeTransactionsFull>(resultat.ToList());

        }

        public void SaveChanged()
        {

            model.SaveChangesAsync();

        }

        #endregion

        #region Commands
        void AddCommandExecute()
        {

            if (SelectedData != null)
            {

            }
        }

        bool CanAddCommandExecute()
        {
            return true;
        }

        public ICommand AddCommand { get { return new RelayCommand(AddCommandExecute, CanAddCommandExecute); } }


        #endregion

    }
}
