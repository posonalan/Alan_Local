using GestionStockAppli.Data;
using GestionStockAppli.Data.Controllers;
using GestionStockAppli.Data.Models;
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


namespace GestionStockAppli
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window

    {
        MyDbContext _context = new MyDbContext();
        MyDbContext context;
        article NouvelArticle = new article();
        article SelectionArticle = new article();
        public MainWindow(MyDbContext context)
        {
            this._context = context;

            InitializeComponent();
            ArticleController controllerArticle = new ArticleController(context);
            GetArticle();
            NouvelArticleGrid.DataContext = NouvelArticle;
            //MyDbContext _context = new MyDbContext();
            //ArticleService _service = new ArticleService(_context);


            alan.ItemsSource = controllerArticle.GetAllArticle();


            //dataGrid.ItemsSource = _context.Articles.ToList();
        }
        private void GetArticle()
        {
            ArticleDataGrid.ItemsSource = context.Articles.ToList();
        }
        private void AjouterArticle(object sender, RoutedEventArgs e)
        {
            context.Articles.Add(NouvelArticle);
            context.SaveChanges();
            GetArticle();
            article NouvelleArticle = new article();
            AddNouvelArticleGrid.DataContext = NouvelArticle; 
            }

        private void UpdateArticle(object sender, RoutedEventArgs e )
        {
            context.Update(ArticleSelection);
            context.SaveChanges();
            GetArticle();
        }

        private void SelectionArticleModif(object sender, RoutedEventArgs e)
        {
           ArticleSelection = (sender as FrameworkElement).DataContext as article;
            UpdateArticleGrid.DataContext = ArticleSelection;
        }

        private void DeleteArticle(object sender, RoutedEventArgs e)
        {
            var ArticleSupression = (sender as FrameworkElement).DataContext as article;
            context.Articles.Remove(ArticleSupression);
            context.SaveChanges();
            GetArticle();
        }



        //private void BoutonFenetre_Click(object sender, RoutedEventArgs e)
        //{
        //    //if (sender == Ajouter)
        //    //{
        //        Ajouter f = new Ajouter(tbxMot.Text, this);
        //        this.Opacity = 0.7;
        //        this.Visibility = Visibility.Hidden;
        //        f.ShowDialog();

        //        this.Visibility = Visibility.Visible;
        //        this.Opacity = 1;
        //}
        //else if (sender == Modifier)
        //{
        //    Modifier f = new Modifier(tbxMot.Text, this);
        //    this.Opacity = 0.7;
        //    this.Visibility = Visibility.Hidden;
        //    f.ShowDialog();

        //    this.Visibility = Visibility.Visible;
        //    this.Opacity = 1;
        //}


    }
    //public void MAJRetour(string valeur)
    //{
    //    this.BoutonRetour.Content = valeur;
}





//    }
//}

