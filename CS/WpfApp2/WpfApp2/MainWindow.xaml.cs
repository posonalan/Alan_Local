
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
using WpfApp2.Controllers;
using WpfApp2.Data;
using WpfApp2.Data.Profiles;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MyDbContext _context = new MyDbContext();
            //  Mapper _mapper = new Mapper();
            // Entite1Controller _controller = new Entite1Controller(_context,_mapper);
            dataGrid.ItemsSource = _context.Entite1.ToList();//_controller.GetAllEntite1();
        }
    }
}
