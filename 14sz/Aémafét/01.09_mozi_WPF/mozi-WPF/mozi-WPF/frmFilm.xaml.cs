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

namespace mozi_WPF
{
    /// <summary>
    /// Interaction logic for frmFilm.xaml
    /// </summary>
    public partial class frmFilm : Window
    {
        public frmFilm()
        {
            InitializeComponent();
            Uri iconUri = new Uri("images/mozi.ico", UriKind.RelativeOrAbsolute);
            this.Icon = BitmapFrame.Create(iconUri);

        }
    }
}
