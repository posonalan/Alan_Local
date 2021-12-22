
using ECF.Controllers;
using ECF.Data;
using ECF.Data.Dtos;
using ECF.Data.Models;
using ECF.Data.Profiles;
using ECF.Formulaires;
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

namespace ECF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EcfContext _context;
        MusiciensController _controller;
        public MainWindow()
        {
            InitializeComponent();
            //_context = new EcfContext;
            //_controller = new MusiciensController(_context);
            //ActualiserListe(); 
            // centrer la fenetre

            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            _context = new EcfContext();
        }


        //private void btnMusicien_Click(object sender, RoutedEventArgs e)
        //{
        //    ListeMusiciens actions = new ListeMusiciens(_context);

        //    MusiciensDTOIn Musicien = (MusiciensDTOIn)ListeMusicien.SelectedItem;
        //    string nom = (string)((Button)sender).Content;
        //    if (Musicien == null && (nom == "Modifier" || nom == "Supprimer"))
        //    {
        //        MessageBox.Show("Veuillez Selectionner un Musicien !!!");
        //    }
        //    else
        //    {
        //        FormulaireMusicien formulaire = new FormulaireMusicien(nom, this, Musicien, _context);
        //        this.Opacity = 0.7;
        //        formulaire.ShowDialog();
        //        this.Opacity = 1;
        //    }
        //}

        //public void ActionMusicien(MusiciensDTOIn Musicien, string action, int id)
        //{
        //    switch (action)
        //    {
        //        case "Ajouter":
        //            _controller.CreateMusicien(Musicien);
        //            break;
        //        case "Modifier":
        //            _controller.UpdateMusicien(id, Musicien);
        //            break;
        //        case "Supprimer":
        //            _controller.DeleteMusicien(id);
        //            break;
        //        default:
        //            break;

        //    }
        //    ActualiserListe();
        //}


        //public void ActionGroupe(GroupesDTOIn Groupe, string action, int id)
        //{
        //    switch (action)
        //    {
        //        case "Ajouter":
        //            _controller.CreateGroupe(Groupe);
        //            break;
        //        case "Modifier":
        //            _controller.UpdateGroupe(id, Groupe);
        //            break;
        //        case "Supprimer":
        //            _controller.DeleteGroupe(id);
        //            break;
        //        default:
        //            break;

        //    }
        //    ActualiserListe();
        //}




        private void btnGroupe_Click(object sender, RoutedEventArgs e)
        {
            ListeGroupes actions = new ListeGroupes(_context);

            this.Opacity = 0.7;
            actions.ShowDialog();
            this.Opacity = 1;
        }

        //private void ActualiserListe()
        //{
        //    ListeMusicien.ItemsSource = _controller.GetAllMusiciens();
        //}


    }
}
