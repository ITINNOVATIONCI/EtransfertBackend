
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
using EtransfertBackend.RolesModules.ViewModels;
using EtransfertBackend.Models;

namespace EtransfertBackend.RolesModules
{
    /// <summary>
    /// Interaction logic for InsertData.xaml
    /// </summary>
    public partial class InsertData : Window
    {
        string Etat = "";
        RolesViewModel viewVM;
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

        public InsertData(string etat, AspNetRoles ele, RolesViewModel view)
        {
            InitializeComponent();

            this.DataContext = viewVM = view;

            Etat = etat;

            if (etat == "AJOUT")
            {
                this.Title = "Enregistrement d'un role";
                //ele.Code = "BA000";
               
                //txtCode.IsEnabled = false;
            }
            else
            {
                this.Title = "Modification d'un role";
                
            }
        }

        private void btnValider_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AspNetRoles ent = ((RolesViewModel)this.DataContext).SelectedData;

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
                        ent.CreatedAt = DateTime.UtcNow;


                        viewVM.model.AspNetRoles.Add(ent);
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


                        ent.UpdatedAt = DateTime.UtcNow;
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
            RolesViewModel vehi = this.DataContext as RolesViewModel;
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
