
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using EtransfertBackend.Models;
using EtransfertBackend.RechargementModules.ViewModels;

namespace EtransfertBackend.RechargementModules
{
    /// <summary>
    /// Interaction logic for InsertData.xaml
    /// </summary>
    public partial class InsertData : Window
    {
        string Etat = "";
        RechargementViewModel viewVM;
        string msg;

        public string Msg
        {
            get { return msg; }
            set { msg = value; }
        }

        string errorMsg;

        public string ErrorMsg
        {
            get { return errorMsg; }
            set { errorMsg = value; }
        }

        public InsertData(string etat, RechargeCptePrincTrace ele, RechargementViewModel view)
        {
            InitializeComponent();

            this.DataContext = viewVM = view;

            Etat = etat;

            if (etat == "AJOUT")
            {
                this.Title = "Enregistrement d'un rechargement";
                //ele.Code = "BA000";
               
                //txtCode.IsEnabled = false;
            }
            else
            {
                this.Title = "Modification d'un rechargement";
                
            }
        }

        private void btnValider_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RechargeCptePrincTrace ent = ((RechargementViewModel)this.DataContext).SelectedData;

                //if (ent.NoChassis == null || ent.NoChassis.Trim() == "")
                //{
                //    lblMessageError.Text = "Remplir le champ NoChassis avant de continuer";
                //    lblMessageError.Visibility = System.Windows.Visibility.Visible;

                //    return;
                //}

                //if (rcbSection.SearchText == "") { MessageBox.Show("Choississez une section svp!", "Section", MessageBoxButton.OK, MessageBoxImage.Information); return; }

                if (Etat == "AJOUT")
                {
                    try
                    {
                        

                        ent.Id = Guid.NewGuid().ToString();
                        ent.DateTransaction = DateTime.UtcNow;

                        ent.Benef= Convert.ToDouble(txtmt.Text) * (0.03);
                        ent.Etat = "ACTIF";

                        ent.Montant = Convert.ToDouble(txtmt.Text) + ent.Benef;

                        viewVM.model.RechargeCptePrincTrace.Add(ent);



                        //mise a jour du solde principal a chaque rechargement
                        Comptes compte = new Comptes();
                        compte = viewVM.model.Comptes.Where(c => c.Id == "1").FirstOrDefault();
                        compte.SoldeUnite += ent.Montant;

                        viewVM.model.SaveChanges();

                        Msg = "OK";
                        this.Close();

                    }
                    catch (Exception ex)
                    {

                        Msg = "Error";
                        ErrorMsg = ex.Message;



                    }
                }
                else
                {
                    try
                    {
                        //ent.Sections = rcbSection.SelectedItem as Sections;


                       // ent.DateTransaction = DateTime.UtcNow;

                        ent.Benef = Convert.ToDouble(txtmt.Text) * (0.03);
                        

                        ent.Montant = Convert.ToDouble(txtmt.Text) + ent.Benef;


                        //mise a jour du solde principal a chaque rechargement
                        Comptes compte = new Comptes();
                        compte = viewVM.model.Comptes.Where(c => c.Id == "1").FirstOrDefault();
                        compte.SoldeUnite += ent.Montant;


                        viewVM.model.SaveChanges();

                        Msg = "OK";
                        this.Close();

                    }
                    catch (Exception ex)
                    {

                        Msg = "Error";
                        ErrorMsg = ex.Message;



                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void btnAnnuler_Click(object sender, RoutedEventArgs e)
        {
            RechargementViewModel vehi = this.DataContext as RechargementViewModel;
            vehi.SelectedData = null;

            this.Close();
        }

        //private void radButton_Click(object sender, RoutedEventArgs e)
        //{
        //    SectionsModules.ViewModels.SectionsViewModel vm = new SectionsModules.ViewModels.SectionsViewModel();
        //    vm.model = viewVM.model;
        //    vm.SelectedData = new Sections();
        //    SectionsModules.InsertData view = new SectionsModules.InsertData("AJOUT", vm.SelectedData, vm);
        //    view.ShowDialog();

        //    if (view.Msg == "OK")
        //    {
        //        rcbSection.SelectedItem = viewVM.model.Sections.Where(c=>c.ID == vm.SelectedData.ID).FirstOrDefault();
        //        rcbSection.Focus();

        //    }
        //    else if (view.Msg == "Error")
        //    {
        //        MessageBox.Show("   Echec Opération    ", "Sections ", MessageBoxButton.OK, MessageBoxImage.Warning);
        //        //Load();
        //        rcbSection.Focus();

        //    }
        //    else
        //    {
        //        //viewM.Refresh();
        //    }
        //}

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
