using EtransfertBackend.Models;
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
using Telerik.Windows.Controls;

namespace EtransfertBackend

{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RadRibbonWindow
    {
        public MainWindow()
        {

            //Windows8Colors.PaletteInstance.MainColor = Colors.White;
            Windows8Palette.Palette.AccentColor = (Color)ColorConverter.ConvertFromString("#FF09A6F7");
            Windows8Palette.Palette.BasicColor = Colors.DarkGray;
            Windows8Palette.Palette.StrongColor = Colors.Gray;
            //Windows8Colors.PaletteInstance.MarkerColor = Colors.White;
            //Windows8Colors.PaletteInstance.ValidationColor = Colors.Red;

            Windows8Palette.Palette.FontSizeXS = 10;
            Windows8Palette.Palette.FontSizeS = 11;
            Windows8Palette.Palette.FontSize = 12;
            Windows8Palette.Palette.FontSizeL = 14;
            Windows8Palette.Palette.FontSizeXL = 16;
            Windows8Palette.Palette.FontSizeXXL = 19;
            Windows8Palette.Palette.FontSizeXXXL = 24;
            //Windows8Palette.Palette.FontFamily = new FontFamily("Segoe Print");
            //Windows8Palette.Palette.FontFamilyLight = new FontFamily("Segoe Print");
            //Windows8Palette.Palette.FontFamilyStrong = new FontFamily("Segoe Print");

            StyleManager.ApplicationTheme = new Windows8Theme();

            InitializeComponent();

            //FirstLayout.Visibility = System.Windows.Visibility.Collapsed;
            //logControl.Visibility = System.Windows.Visibility.Visible;

            //GlobalData.Main = this;
            //GlobalData.PaneGroup = rpgMainView;
            //GlobalData.rrvMain = this.rrvMain;

        }

        public bool VerifyDock(string Header)
        {
            foreach (RadDocumentPane item in rpgMainView.Items)
            {
                string str = item.Header.ToString();
                if (str == Header)
                {
                    rpgMainView.SelectedItem = item;
                    return true;
                }
            }

            return false;
        }

        public void Init()
        {
            if (GlobalData.Nom != null)
            {
                string mess = "Bienvenue " + GlobalData.Nom;

                //txtLoginInfo.Text = mess;

                //lblSociete.Content = GlobalData.CurrentEntrepots.Libelle;

            }
        }

        private void RadRibbonWindow_Loaded_1(object sender, RoutedEventArgs e)
        {



        }

        public void LoadModule()
        {
            foreach (var item in rrvMain.Items)
            {
                bool rtEtat = false;
                RadRibbonTab rt = item as RadRibbonTab;

                foreach (var item1 in rt.Items)
                {

                    RadRibbonGroup pan = item1 as RadRibbonGroup;

                    foreach (var item2 in pan.Items)
                    {

                        RadRibbonButton btn = item2 as RadRibbonButton;

                        string tag = btn.Tag.ToString();
                        if (GlobalData.VerificationDroit(tag))
                        {
                            rt.Visibility = System.Windows.Visibility.Visible;
                            pan.Visibility = System.Windows.Visibility.Visible;
                            btn.Visibility = System.Windows.Visibility.Visible;
                        }

                    }

                }
            }
        }

        public void CleanModule()
        {

        }

        #region Menu

        //private void btnUtilisateurs_Click(object sender, RoutedEventArgs e)
        //{
        //    RadDocumentPane rad = new RadDocumentPane();
        //    rad.Content = new EtransfertBackend.UtilisateursModules.DataGridView();
        //    rad.Header = "Utilisateurs";
        //    rrvMain.Title = "Utilisateurs";
        //    rad.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
        //    rad.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;


        //    if (!VerifyDock("Utilisateurs"))
        //    {
        //        rpgMainView.AddItem(rad, Telerik.Windows.Controls.Docking.DockPosition.Center);
        //    }
        //    else
        //    {

        //    }
        //}

        //private void btnDistricts_Click(object sender, RoutedEventArgs e)
        //{
        //    RadDocumentPane rad = new RadDocumentPane();
        //    rad.Content = new EtransfertBackend.DistrictsModules.DataGridView();
        //    rad.Header = "Districts";
        //    rrvMain.Title = "Districts";
        //    rad.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
        //    rad.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;


        //    if (!VerifyDock("Districts"))
        //    {
        //        rpgMainView.AddItem(rad, Telerik.Windows.Controls.Docking.DockPosition.Center);
        //    }
        //    else
        //    {

        //    }
        //}

        //private void btnRegions_Click(object sender, RoutedEventArgs e)
        //{
        //    RadDocumentPane rad = new RadDocumentPane();
        //    rad.Content = new GESIDENTITY.RegionsModules.DataGridView();
        //    rad.Header = "Regions";
        //    rrvMain.Title = "Regions";
        //    rad.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
        //    rad.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;


        //    if (!VerifyDock("Regions"))
        //    {
        //        rpgMainView.AddItem(rad, Telerik.Windows.Controls.Docking.DockPosition.Center);
        //    }
        //    else
        //    {

        //    }
        //}

        //private void btnFederations_Click(object sender, RoutedEventArgs e)
        //{
        //    RadDocumentPane rad = new RadDocumentPane();
        //    rad.Content = new GESIDENTITY.FederationsModules.DataGridView();
        //    rad.Header = "Federations";
        //    rrvMain.Title = "Federations";
        //    rad.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
        //    rad.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;


        //    if (!VerifyDock("Federations"))
        //    {
        //        rpgMainView.AddItem(rad, Telerik.Windows.Controls.Docking.DockPosition.Center);
        //    }
        //    else
        //    {

        //    }
        //}

        //private void btnDepartements_Click(object sender, RoutedEventArgs e)
        //{
        //    RadDocumentPane rad = new RadDocumentPane();
        //    rad.Content = new GESIDENTITY.DepartementsModules.DataGridView();
        //    rad.Header = "Departements";
        //    rrvMain.Title = "Departements";
        //    rad.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
        //    rad.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;


        //    if (!VerifyDock("Departements"))
        //    {
        //        rpgMainView.AddItem(rad, Telerik.Windows.Controls.Docking.DockPosition.Center);
        //    }
        //    else
        //    {

        //    }
        //}

        //private void btnEntreprise_Click(object sender, RoutedEventArgs e)
        //{
        //    RadDocumentPane rad = new RadDocumentPane();
        //    rad.Content = new GESIDENTITY.EntrepriseModules.DataGridView();
        //    rad.Header = "Entreprise";
        //    rrvMain.Title = "Entreprise";
        //    rad.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
        //    rad.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;


        //    if (!VerifyDock("Entreprise"))
        //    {
        //        rpgMainView.AddItem(rad, Telerik.Windows.Controls.Docking.DockPosition.Center);
        //    }
        //    else
        //    {

        //    }
        //}

        //private void btnSections_Click(object sender, RoutedEventArgs e)
        //{
        //    RadDocumentPane rad = new RadDocumentPane();
        //    rad.Content = new GESIDENTITY.SectionsModules.DataGridView();
        //    rad.Header = "Sections";
        //    rrvMain.Title = "Sections";
        //    rad.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
        //    rad.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;


        //    if (!VerifyDock("Sections"))
        //    {
        //        rpgMainView.AddItem(rad, Telerik.Windows.Controls.Docking.DockPosition.Center);
        //    }
        //    else
        //    {

        //    }
        //}

        //private void btnBases_Click(object sender, RoutedEventArgs e)
        //{
        //    RadDocumentPane rad = new RadDocumentPane();
        //    rad.Content = new GESIDENTITY.BasesModules.DataGridView();
        //    rad.Header = "Bases";
        //    rrvMain.Title = "Bases";
        //    rad.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
        //    rad.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;


        //    if (!VerifyDock("Bases"))
        //    {
        //        rpgMainView.AddItem(rad, Telerik.Windows.Controls.Docking.DockPosition.Center);
        //    }
        //    else
        //    {

        //    }
        //}


        //private void btnClients_Click(object sender, RoutedEventArgs e)
        //{
        //    RadDocumentPane rad = new RadDocumentPane();
        //    rad.Content = new GESIDENTITY.ClientsModules.DataGridView();
        //    rad.Header = "Clients";
        //    rrvMain.Title = "Clients";
        //    rad.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
        //    rad.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;


        //    if (!VerifyDock("Clients"))
        //    {
        //        rpgMainView.AddItem(rad, Telerik.Windows.Controls.Docking.DockPosition.Center);
        //    }
        //    else
        //    {

        //    }
        //}

        //private void btnRapport_Click(object sender, RoutedEventArgs e)
        //{
        //    //RadDocumentPane rad = new RadDocumentPane();
        //    //rad.Content = new GESIDENTITY.Rapports.Viewers.ListeRapportView();
        //    //rad.Header = "Rapports";
        //    //rrvMain.Title = "Rapports";
        //    //rad.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
        //    //rad.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;


        //    //if (!VerifyDock("Rapports"))
        //    //{
        //    //    rpgMainView.AddItem(rad, Telerik.Windows.Controls.Docking.DockPosition.Center);
        //    //}
        //    //else
        //    //{

        //    //}
        //}

        //private void btnListeMilitant_Click(object sender, RoutedEventArgs e)
        //{
        //    RadDocumentPane rad = new RadDocumentPane();
        //    rad.Content = new GESIDENTITY.IdentificationsModules.DataGridView();
        //    rad.Header = "Liste des Militants";
        //    rrvMain.Title = "Liste des Militants";
        //    rad.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
        //    rad.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;


        //    if (!VerifyDock("Liste des Militants"))
        //    {
        //        rpgMainView.AddItem(rad, Telerik.Windows.Controls.Docking.DockPosition.Center);
        //    }
        //    else
        //    {

        //    }
        //}

        //private void btnEnregMilitant_Click(object sender, RoutedEventArgs e)
        //{
        //    RadDocumentPane rad = new RadDocumentPane();
        //    rad.Content = new GESIDENTITY.IdentificationsModules.Recensement();
        //    rad.Header = "Militant";
        //    rrvMain.Title = "Militant";
        //    rad.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
        //    rad.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;


        //    if (!VerifyDock("Militant"))
        //    {
        //        rpgMainView.AddItem(rad, Telerik.Windows.Controls.Docking.DockPosition.Center);
        //    }
        //    else
        //    {

        //    }
        //}

        //private void btnOrganes_Click(object sender, RoutedEventArgs e)
        //{
        //    RadDocumentPane rad = new RadDocumentPane();
        //    rad.Content = new GESIDENTITY.OrganesModules.DataGridView();
        //    rad.Header = "Organes";
        //    rrvMain.Title = "Organes";
        //    rad.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
        //    rad.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;


        //    if (!VerifyDock("Organes"))
        //    {
        //        rpgMainView.AddItem(rad, Telerik.Windows.Controls.Docking.DockPosition.Center);
        //    }
        //    else
        //    {

        //    }
        //}

        //private void btnFonctionParti_Click(object sender, RoutedEventArgs e)
        //{
        //    RadDocumentPane rad = new RadDocumentPane();
        //    rad.Content = new GESIDENTITY.FonctionPartiModules.DataGridView();
        //    rad.Header = "Fonction Parti";
        //    rrvMain.Title = "Fonction Parti";
        //    rad.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
        //    rad.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;


        //    if (!VerifyDock("Fonction Parti"))
        //    {
        //        rpgMainView.AddItem(rad, Telerik.Windows.Controls.Docking.DockPosition.Center);
        //    }
        //    else
        //    {

        //    }
        //}

        //private void btnFonctions_Click(object sender, RoutedEventArgs e)
        //{
        //    RadDocumentPane rad = new RadDocumentPane();
        //    rad.Content = new GESIDENTITY.FonctionsModules.DataGridView();
        //    rad.Header = "Fonctions";
        //    rrvMain.Title = "Fonctions";
        //    rad.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
        //    rad.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;


        //    if (!VerifyDock("Fonctions"))
        //    {
        //        rpgMainView.AddItem(rad, Telerik.Windows.Controls.Docking.DockPosition.Center);
        //    }
        //    else
        //    {

        //    }
        //}

        //private void btnNaturePiece_Click(object sender, RoutedEventArgs e)
        //{
        //    RadDocumentPane rad = new RadDocumentPane();
        //    rad.Content = new GESIDENTITY.NaturePieceModules.DataGridView();
        //    rad.Header = "NaturePiece";
        //    rrvMain.Title = "NaturePiece";
        //    rad.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
        //    rad.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;


        //    if (!VerifyDock("NaturePiece"))
        //    {
        //        rpgMainView.AddItem(rad, Telerik.Windows.Controls.Docking.DockPosition.Center);
        //    }
        //    else
        //    {

        //    }
        //}

        #endregion

       

        private void PromoButton_Click(object sender, RoutedEventArgs e)
        {
            RadDocumentPane rad = new RadDocumentPane();
            rad.Content = new EtransfertBackend.PromoModules.DataGridView();
            rad.Header = "Offre Promo";
            rrvMain.Title = "Offre Promo";
            rad.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
            rad.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;


            if (!VerifyDock("Utilisateurs"))
            {
                rpgMainView.AddItem(rad, Telerik.Windows.Controls.Docking.DockPosition.Center);
            }
            else
            {

            }


        }

        private void RadRibbonButton_Click(object sender, RoutedEventArgs e)
        {

        }

       

        private void RolesBtnClick(object sender, RoutedEventArgs e)
        {
            RadDocumentPane rad = new RadDocumentPane();
            rad.Content = new EtransfertBackend.RolesModules.DataGridView();
            rad.Header = "Roles utilisateur";
            rrvMain.Title = "Roles utilisateur";
            rad.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
            rad.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;


            if (!VerifyDock("Utilisateurs"))
            {
                rpgMainView.AddItem(rad, Telerik.Windows.Controls.Docking.DockPosition.Center);
            }
            else
            {

            }


        }

        private void AjouterRoleBtnClick(object sender, RoutedEventArgs e)
        {
            RadDocumentPane rad = new RadDocumentPane();
            rad.Content = new EtransfertBackend.RolesUserModules.DataGridView();
            rad.Header = "Attribution de roles à un utilisateur";
            rrvMain.Title = "Attribution de roles à un utilisateur";
            rad.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
            rad.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;


            
           rpgMainView.AddItem(rad, Telerik.Windows.Controls.Docking.DockPosition.Center);
            
        }
    }
}