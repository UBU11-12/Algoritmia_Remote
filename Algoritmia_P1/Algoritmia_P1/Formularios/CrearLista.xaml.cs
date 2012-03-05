using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Algoritmia_P1.Formularios
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {


        datosFormularioCrear datos;

        bool confirmaDatos = false;

        public Window1()
        {
            InitializeComponent();
        }

        private void bt_Crear(object sender, RoutedEventArgs e)
        {
            bool ok = true;
            string messageBoxText = "";
            string caption = "Algoritmia_P1";
            MessageBoxButton button;
            MessageBoxImage icon;
            if (txtElementos.Text != "")
            {
                try
                {
                    datos.Elementos = Convert.ToInt32(txtElementos.Text);
                }
                catch (Exception)
                {
                    ok = false;
                    button = MessageBoxButton.OK;
                    icon = MessageBoxImage.Error;
                    messageBoxText = "Formato incorrecto";
                    System.Windows.MessageBox.Show(messageBoxText, caption, button, icon);

                }

            }
            else
            {
                ok = false;
                button = MessageBoxButton.OK;
                icon = MessageBoxImage.Warning;
                messageBoxText = "El campo número de elementos no puede estar vacío";
                System.Windows.MessageBox.Show(messageBoxText, caption, button, icon);
            }

            if (txtListas.Text != "")
            {
                try
                {
                    datos.NListas = Convert.ToInt32(txtListas.Text);
                }
                catch (Exception)
                {
                    ok = false;
                    button = MessageBoxButton.OK;
                    icon = MessageBoxImage.Error;
                    messageBoxText = "Formato incorrecto";
                    System.Windows.MessageBox.Show(messageBoxText, caption, button, icon);
                }
            }
            else
            {
                datos.NListas = 1;
            }
            if(rBtAleatorio.IsChecked==true){
                datos.ModoGeneración = ModoGeneración.Aleatorio;
            }
            else if (rBtAscendente.IsChecked == true)
            {
                datos.ModoGeneración = ModoGeneración.Ascendente;
            }
            else{
                datos.ModoGeneración = ModoGeneración.Descendente;
            }
            confirmaDatos = true;
            if(ok)
                Close();
            
        }

        public datosFormularioCrear DatosFormulario
        {
            get
            {
                return datos;
            }
        }

        public bool ConfirmaDatos
        {
            get
            {
                return confirmaDatos;
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {

            confirmaDatos = false;
            Close();
        }
    }
}
