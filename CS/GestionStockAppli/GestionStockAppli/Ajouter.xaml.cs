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
using System.Windows.Shapes;

namespace GestionStockAppli
{
    public partial class Ajouter : Window
    {

  
    MainWindow fenetreMere;
    /// <summary>
    /// Logique d'interaction pour Ajouter.xaml
    /// </summary>
    public Ajouter(string mot, MainWindow w)
    {
        InitializeComponent();
        /* contenu du label mot */
        labelMot.Content = mot;
        fenetreMere = w;
    }

        //private void BoutonRetour_Click(object sender, RoutedEventArgs e)
        //{
        //    fenetreMere.MAJRetour("test");
        //    this.Close();
        //}
    }
}

