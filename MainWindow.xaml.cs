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

namespace InterpolacionNumericaNewton
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        private IList<Iteracion> _iteraciones;

        public MainWindow()
        {
            InitializeComponent();
        }

        private double ObtenerPrimeraDerivada(double x)
        {
            return (2 * Math.Cos(x)) - (x / 5);
        }

        private double ObtenerSegundaDerivada(double x)
        {
            return (-2 * Math.Sin(x)) - 0.2;
        }

        private double ObtenerXiMa1(double xi, double fpxi, double fppxi)
        {
            return xi - (fpxi / fppxi);
        }

        private void BtnCalcular_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(TxtValorX0.Text, out double xi))
            {
                int i;
                Iteracion iteracion, iteracionAnterior;

                i = 0;
                iteracionAnterior = new Iteracion();
                _iteraciones = new List<Iteracion>();

                do
                {
                    iteracion = new Iteracion();
                    iteracion.I = i;

                    if (iteracion.I == 0)
                    {
                        iteracion.Xi = xi;
                    }
                    else
                    {
                        iteracion.Xi = iteracionAnterior.XiMa1;
                    }

                    iteracion.FPXi = ObtenerPrimeraDerivada(iteracion.Xi);
                    iteracion.FPPXi = ObtenerSegundaDerivada(iteracion.Xi);
                    iteracion.XiMa1 = ObtenerXiMa1(iteracion.Xi, iteracion.FPXi, iteracion.FPPXi);
                    iteracion.Error = Math.Abs((iteracion.XiMa1 - iteracionAnterior.XiMa1) / iteracion.XiMa1) * 100;

                    _iteraciones.Add(iteracion);
                    iteracionAnterior = iteracion;
                    i++;

                } while (/*iteracion.Error != 0 && iteracion.Error != 0.001*/ i != 5);

                DgIteraciones.ItemsSource = _iteraciones;
            }
        }

        private void BtnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            TxtValorX0.Clear();
            DgIteraciones.ItemsSource = null;
            TxtValorX0.Focus();
        }
    }
}
