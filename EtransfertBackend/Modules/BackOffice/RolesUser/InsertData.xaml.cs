
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
using EtransfertBackend.RolesUserModules.ViewModels;
using EtransfertBackend.Models;

namespace EtransfertBackend.RolesUserModules
{
    /// <summary>
    /// Interaction logic for InsertData.xaml
    /// </summary>
    public partial class InsertData : Window
    {
        string Etat = "";
        RolesUserViewModel viewVM;
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

        public InsertData(string etat, AspNetUserRoles ele, RolesUserViewModel view)
        {
            InitializeComponent();

            this.DataContext = viewVM = view;

            Etat = etat;

            if (etat == "AJOUT")
            {
                this.Title = "Attribution de role à un utilisateur";
            }
            else
            {
                this.Title = "Modification de role d'un utilisateur";
                rcbAspNetUser.IsHitTestVisible = false;
                rcbAspNetRoles.IsHitTestVisible = false;
            }
        }

        private void btnValider_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AspNetUserRoles ent = ((RolesUserViewModel)this.DataContext).SelectedData;

                //if (ent.NoChassis == null || ent.NoChassis.Trim() == "")
                //{
                //    lblMessageError.Text = "Remplir le champ NoChassis avant de continuer";
                //    lblMessageError.Visibility = System.Windows.Visibility.Visible;

                //    return;
                //}

                if (rcbAspNetUser.SearchText == "") { MessageBox.Show("Choississez un utilisateur svp!", "Attribution de role", MessageBoxButton.OK, MessageBoxImage.Information); return; }
                if (rcbAspNetRoles.SearchText == "") { MessageBox.Show("Choississez un role svp!", "Attribution de role", MessageBoxButton.OK, MessageBoxImage.Information); return; }

                if (Etat == "AJOUT")
                {
                    try
                    {

                        //ent.Etat = "ACTIF";

                        //Parametres param = model.Parametres.Where(c => c.idParametre == 1).First();

                        //ent.CodeEntrepot = GenerateFacture(param.ArtID.ToString(), 4);

                        //param.ArtID++;
                        //ent.Districts = rcbDistrict.SelectedItem as Districts;

                        ent.Id = Guid.NewGuid().ToString();
                        ent.CreatedAt = DateTime.UtcNow;
                       // ent.AspNetUsers.SeuilUnite = Convert.ToDouble(txtSeuil.Text);

                        viewVM.model.AspNetUserRoles.Add(ent);
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
                        //ent.Districts = rcbDistrict.SelectedItem as Districts;
                        ent.UpdatedAt = DateTime.UtcNow;
                       // ent.AspNetRoles.Name = rcbAspNetRoles.SearchText;
                        
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
            RolesUserViewModel vehi = this.DataContext as RolesUserViewModel;
            vehi.SelectedData = null;

            this.Close();
        }

        private void radButton_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void radButtonUsers_Click(object sender, RoutedEventArgs e)
        {

        }

        private void radButtonRoles_Click(object sender, RoutedEventArgs e)
        {
            RolesModules.ViewModels.RolesViewModel vm = new RolesModules.ViewModels.RolesViewModel();
            vm.model = viewVM.model;
            vm.SelectedData = new AspNetRoles();
            RolesModules.InsertData view = new RolesModules.InsertData("AJOUT", vm.SelectedData, vm);
            view.ShowDialog();

            if (view.Msg == "OK")
            {
                rcbAspNetRoles.SelectedItem = viewVM.model.AspNetRoles.Where(c => c.Id == vm.SelectedData.Id).FirstOrDefault();
                rcbAspNetRoles.Focus();

            }
            else if (view.Msg == "Error")
            {
                MessageBox.Show("   Echec Opération    ", "Roles ", MessageBoxButton.OK, MessageBoxImage.Warning);
                //Load();
                rcbAspNetRoles.Focus();

            }
            else
            {
                //viewM.Refresh();
            }
        }
    }
}
