using GestionStockAppli.Data;
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
        public MainWindow()
        {
            InitializeComponent();
            //MyDbContext _context = new MyDbContext();
            //ArticleService _service = new ArticleService(_context);
            var _context = new MyDbContext();
            var _service = new ArticleService(_context);
            alan.ItemsSource = _service.GetAllArticle(); 

            //dataGrid.ItemsSource = _context.Articles.ToList();

        }
    }
}
