﻿
using EtransfertBackend.COMMON;
using EtransfertBackend.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Telerik.Windows.Controls;

using Telerik.Windows.Data;

namespace EtransfertBackend.RechargementModules.ViewModels
{
    public class RechargementViewModel : ObservableObject
    {

        #region Members
        public eTransferttestEntities model;
        private BackgroundWorker worker = new BackgroundWorker();
        ObservableCollection<RechargeCptePrincTrace> _data = new ObservableCollection<RechargeCptePrincTrace>();
        //ObservableCollection<Sections> _allSections = new ObservableCollection<Sections>();
        RechargeCptePrincTrace _selectedData = new RechargeCptePrincTrace();
        bool _isBusy;
        int _count = 0;
        #endregion

        #region Properties
        public ObservableCollection<RechargeCptePrincTrace> AllData
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

        //public ObservableCollection<Sections> AllSections
        //{
        //    get
        //    {
        //        return _allSections;
        //    }
        //    set
        //    {
        //        _allSections = value;
        //        RaisePropertyChanged("AllSections");
        //    }
        //}

        public RechargeCptePrincTrace SelectedData
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
        public RechargementViewModel()
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

            model = new eTransferttestEntities();

            var resultat = from res in model.RechargeCptePrincTrace.OrderByDescending(c=>c.DateTransaction)
                          // where res.etat == "ACTIF"
                           select res;

            AllData = new ObservableCollection<RechargeCptePrincTrace>(resultat.ToList());

            //var resultat2 = from res in model.Sections
            //                where res.Etat == "ACTIF"
            //                select res;

            //AllSections = new ObservableCollection<Sections>(resultat2.ToList());

        }

        public void CancelChanged()
        {

            var resultat = from res in model.RechargeCptePrincTrace.OrderByDescending(c => c.DateTransaction)
                               //where res.etat == "ACTIF"
                           select res;

            AllData = new ObservableCollection<RechargeCptePrincTrace>(resultat.ToList());

        }

        public void SaveChanged()
        {

            model.SaveChanges();

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
