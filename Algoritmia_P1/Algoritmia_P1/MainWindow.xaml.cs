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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using System.Collections;
using System.Xml;
using System.IO;
using System.Xml.Schema;
using Algoritmos;
using Utilidades;
using System.Threading;

namespace Algoritmia_P1
{


    #region "Estructuras"

    public struct Lista
    {
        public int id { set; get; }
        public ModoGeneración orden { set; get; }
        public int nElementos { set; get; }
        public int nIntercambios { set; get; }
        public int nComparaciones { set; get; }
        public double tiempo { set; get; }
        public EntradaDatos vectorD { set; get; }
        public EntradaDatos vectorO { set; get; }
        public Ordenado ordenado { set; get; }
    }

    public struct datosOrdenar
    {
        Algoritmo algoritmo;
        Orden criterio;

        public Algoritmo Algoritmo
        {
            get
            {
                return algoritmo;
            }
            set
            {
                algoritmo = value;

            }

        }

        public Orden Criterio
        {
            get
            {
                return criterio;
            }
            set
            {
                criterio = value;

            }

        }

    }

    public struct resultadosOrdenación
    {
        int nComparaciones;
        int nIntercambios;
        double tiempo;

        public int Comparaciones
        {
            get
            {
                return nComparaciones;
            }
            set
            {
                nComparaciones = value;

            }

        }

        public int Intercambios
        {
            get
            {
                return nIntercambios;
            }
            set
            {
                nIntercambios = value;

            }

        }

        public double Tiempo
        {
            get
            {
                return tiempo;
            }
            set
            {
                tiempo = value;

            }

        }


    }

    public struct datosFormularioCrear
    {
        int nElementos;
        int nListas;
        ModoGeneración modo;

        public int Elementos
        {
            get
            {
                return nElementos;
            }
            set
            {
                nElementos = value;
            }
        }

        public ModoGeneración ModoGeneración
        {
            get
            {
                return modo;
            }
            set
            {
                modo = value;
            }
        }

        public int NListas
        {
            get
            {
                return nListas;
            }
            set
            {
                nListas = value;
            }

        }


    }


    #endregion

    #region "Enumerados"

    public enum Algoritmo
    {
        Insercion,
        Seleccion,
        Quicksort
    }

    public enum ModoGeneración
    {
        Aleatorio,
        Ascendente,
        Descendente
    }

    public enum Ordenado
    {
        Si,
        No

    }

    #endregion




    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Formularios.Window1 w;

        static Thread hiloOrdena;

        public datosFormularioCrear datosLista;

        public datosOrdenar datosOrdenar;

        public ObservableCollection<Lista> listas;

        public int id_click_muestra;
        public int id_click_muestra_old;
        public int id_click_elimina;
        public int id_click_elimina_old;


        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Evento para crear una lista.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btCrearLista_Click(object sender, RoutedEventArgs e)
        {
            w = new Formularios.Window1();
            w.ShowDialog();

            if (w.ConfirmaDatos)
            {
                EntradaDatos entD = new EntradaDatos(Convert.ToInt32(w.DatosFormulario.Elementos));
                EntradaDatos entO = new EntradaDatos(Convert.ToInt32(w.DatosFormulario.Elementos));
                if (w.DatosFormulario.ModoGeneración.CompareTo(ModoGeneración.Aleatorio) == 0)
                {
                    entD.insertaAleatorio();
                }
                else if (w.DatosFormulario.ModoGeneración.CompareTo(ModoGeneración.Ascendente) == 0)
                {
                    entD.insertaAscendente();
                }
                else
                {
                    entD.insertaDescendente();
                }

                //Añadir al grid los datos de la lista creada.
                edicionGridLista(Convert.ToInt32(w.DatosFormulario.Elementos), Convert.ToInt32(w.DatosFormulario.NListas),w.DatosFormulario.ModoGeneración, Ordenado.No, entD, entO);
                visibilidadBarra_Final();
            }
        }

        /// <summary>
        /// Edita una nueva lista en funcion de los parametros.
        /// </summary>
        /// <param name="tam"></param>
        /// <param name="tipo"></param>
        /// <param name="entD"></param>
        /// <param name="entO"></param>
        private void edicionGridLista(int tam,int nListas, ModoGeneración tipo, Ordenado ordenado, EntradaDatos entD, EntradaDatos entO)
        {
            for (int i = 0; i < nListas ; i++ )
            {
                listas.Add(new Lista() { id = listas.Count, orden = tipo, nElementos = tam, nComparaciones = 0, nIntercambios = 0, tiempo = 0, ordenado = ordenado, vectorD = entD, vectorO = entO });            
            }
            dtListas.ItemsSource = listas;
            refreshGrid();
        }
        
        /// <summary>
        /// Evento para ordenar las listas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btOrdenar_Click(object sender, RoutedEventArgs e)
        {

            recogeDatos();

            if(hiloOrdena==null||!hiloOrdena.IsAlive)
            {
                visibilidadBarra_Ordenando();
                hiloOrdena = new Thread(new ThreadStart(this.HiloOrdena));
                hiloOrdena.SetApartmentState(ApartmentState.STA);
                hiloOrdena.Start();
                
            }
        }


        /// <summary>
        /// Recoge los parametros de algoritmo de ordenación y criterio. 
        /// </summary>
        public void recogeDatos()
        {

            if (cmbOrdenacion.SelectionBoxItem.ToString() == "Inserción")
            {
                datosOrdenar.Algoritmo = Algoritmo.Insercion;
            }
            else if (cmbOrdenacion.SelectionBoxItem.ToString() == "Selección")
            {
                datosOrdenar.Algoritmo = Algoritmo.Seleccion;
            }
            else
            {
                datosOrdenar.Algoritmo = Algoritmo.Quicksort;
            }


            if (cmbCriterio.SelectionBoxItem.ToString() == "Ascendente")
            {
                datosOrdenar.Criterio = Orden.Ascendente;
            }
            else
            {
                datosOrdenar.Criterio = Orden.Descendente;
            }
        }

        /// <summary>
        /// Hilo para la ordenación en función de los criterios establecidos.
        /// </summary>
        public void HiloOrdena()
        {
            Ordenación ord;
            NanoTemporizador nano = new NanoTemporizador();
            
            if (datosOrdenar.Algoritmo.CompareTo(Algoritmo.Insercion)==0)
            {
                
                for (int i = 0; i < listas.Count; i++)
                {
                    if (listas.ElementAt(i).ordenado.CompareTo(Ordenado.No) == 0)
                    {
                        ord = new Inserción(datosOrdenar.Criterio);
                        nano.Start();
                        listas.ElementAt(i).vectorD.Vector.CopyTo(listas.ElementAt(i).vectorO.Vector, 0);
                        ord.Ordenar((int[])listas.ElementAt(i).vectorO.Vector);
                        nano.Stop();
                        //asignar los valores derivados de la ordenacion a la lista.
                        Lista aux = listas.ElementAt(i);
                        aux.nComparaciones = ord.NComparaciones;
                        aux.nIntercambios = ord.NIntercambios;
                        aux.tiempo = nano.ElapsedMilliseconds;
                        aux.ordenado = Ordenado.Si;
                        System.Windows.Application.Current.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, (Action)delegate()
                        {
                            listas.RemoveAt(i);
                            listas.Insert(aux.id, aux);
                        });
                    }
                }
            }
            else if (datosOrdenar.Algoritmo.CompareTo(Algoritmo.Seleccion) == 0)
            {
                
                for (int i = 0; i < listas.Count; i++)
                {
                    if (listas.ElementAt(i).ordenado.CompareTo(Ordenado.No) == 0)
                    {
                        ord = new Selección(datosOrdenar.Criterio);
                        nano.Start();
                        listas.ElementAt(i).vectorD.Vector.CopyTo(listas.ElementAt(i).vectorO.Vector, 0);
                        ord.Ordenar((int[])listas.ElementAt(i).vectorO.Vector);
                        nano.Stop();
                        //falta capturar los tiempos de ordenacion
                        Lista aux = listas.ElementAt(i);
                        aux.nComparaciones = ord.NComparaciones;
                        aux.nIntercambios = ord.NIntercambios;
                        aux.tiempo = nano.ElapsedMilliseconds;
                        aux.ordenado = Ordenado.Si;
                        System.Windows.Application.Current.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, (Action)delegate()
                        {
                            listas.RemoveAt(i);
                            listas.Insert(aux.id, aux);
                        });
                    }
                    
                }
            }
            else
            {
                
                for (int i = 0; i < listas.Count; i++)
                {
                    if (listas.ElementAt(i).ordenado.CompareTo(Ordenado.No) == 0)
                    {
                        ord = new QuickSort(datosOrdenar.Criterio);
                        nano.Start();
                        listas.ElementAt(i).vectorD.Vector.CopyTo(listas.ElementAt(i).vectorO.Vector, 0);
                        ord.Ordenar((int[])listas.ElementAt(i).vectorO.Vector);
                        nano.Stop();
                        //falta capturar los tiempos de ordenacion
                        Lista aux = listas.ElementAt(i);
                        aux.nComparaciones = ord.NComparaciones;
                        aux.nIntercambios = ord.NIntercambios;
                        aux.tiempo = nano.ElapsedMilliseconds;
                        aux.ordenado = Ordenado.Si;
                        System.Windows.Application.Current.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, (Action)delegate()
                        {
                            listas.RemoveAt(i);
                            listas.Insert(aux.id, aux);

                        });
                    }
                }
            }
            refreshGrid();
            visibilidadBarra_Final();
        }

        /// <summary>
        /// Evento para eliminar la fila seleccionada.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btEliminar_Click(object sender, RoutedEventArgs e)
        {
            Lista lista = (Lista)dtListas.SelectedItem;
            listas.Remove(lista);
            id_click_elimina = lista.id;
            id_click_elimina_old = id_click_muestra;
            if (id_click_elimina == id_click_elimina_old)
            {
                tbDesorden.Document.Blocks.Clear();
                tbOrden.Document.Blocks.Clear();
                expander1.IsExpanded = false;
            }
        }

        /// <summary>
        /// Evento para visualizar los valores de la lista seleccionada.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btMostrar_Click(object sender, RoutedEventArgs e)
        {
            
            Lista listaSel;
            listaSel = (Lista)dtListas.SelectedItem;
            id_click_muestra_old = id_click_muestra;
            id_click_muestra = listaSel.id;
            tbDesorden.Document.Blocks.Clear();
            tbOrden.Document.Blocks.Clear();
            visualizarLista(listaSel);
            if (!expander1.IsExpanded)
                expander1.IsExpanded = true;
            else if (expander1.IsExpanded && (id_click_muestra != id_click_muestra_old))
                expander1.IsExpanded = true;
            else
            {
                expander1.IsExpanded = false;
            }
        }

        /// <summary>
        /// Imprime los vectores de elementos ordenados y desordenados correspondiente a la fila seleccionada de la tabla.
        /// </summary>
        private void visualizarLista(Lista lista)
        {
            string sms = "";
            tbDesorden.AppendText("");
            tbOrden.AppendText("");
            if (lista.vectorD != null)
            {
                for (int i = 0; i < lista.vectorD.Vector.Length; i++)
                {
                    sms += Convert.ToString(lista.vectorD.Vector.GetValue(i));
                    sms += " - ";
                }
                tbDesorden.AppendText(sms);
                lblDesordenL.Content = "Lista " + Convert.ToString(lista.id) + " desordenada ";
            }

            if (lista.vectorO != null)
            {
                sms = "";
                for (int i = 0; i < lista.vectorO.Vector.Length; i++)
                {
                    sms += Convert.ToString(lista.vectorO.Vector.GetValue(i));
                    sms += " - ";
                }
                tbOrden.AppendText(sms);
                lblDesordenL.Content = "Lista " + Convert.ToString(lista.id) + " ordenada ";
            }

        }


        /// <summary>
        /// Evento para guardar la configuración establecida.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btGuardar_Click(object sender, RoutedEventArgs e)
        {
            string messageBoxText = "";
            string caption = "Algoritmia_P1";
            MessageBoxButton button;
            MessageBoxImage icon;
            if (save())
            {
                button = MessageBoxButton.OK;
                icon = MessageBoxImage.Information;
                messageBoxText = "Archivo guardado con éxito";
                System.Windows.MessageBox.Show(messageBoxText, caption, button, icon);
            }

        }

        /// <summary>
        /// Guarda la configuración establecida en el programa en el momento especificado.
        /// </summary>
        /// <returns></returns>
        private Boolean save()
        {
            bool saved = false;
            string path = "";
            string outputPath = "";
            Configuracion configSave;
            TreeNode nodo = new TreeNode();
            SaveFileDialog saveWindow = new SaveFileDialog();
            DialogResult resultado;
            saveWindow.AddExtension = true;
            saveWindow.Title = "Save ALG file";
            saveWindow.FileName = saveWindow.FileName;
            saveWindow.Filter = "ALG File (.alg)|*.alg";
            saveWindow.ValidateNames = true;
            resultado = saveWindow.ShowDialog();
            if (resultado == System.Windows.Forms.DialogResult.OK)
            {
                path = saveWindow.FileName;
                int position = path.LastIndexOf("\\");
                outputPath = path;
                if (path.EndsWith(".alg"))
                {

                    nodo.Text = path.Substring(position + 1);
                    nodo.Text = nodo.Text.Replace(".alg", "");
                }
                else
                    nodo.Text = path.Substring(position + 1);
                configSave = compruebaParametros();
                saved = Config.saveConfig(configSave, nodo, outputPath);
            }
            return saved;
        }


        private Configuracion compruebaParametros()
        {
            Configuracion config=new Configuracion();
            List<CfgLista> lista = new List<CfgLista>();
            //Habría que coger los parámetros con las que hemos generado las listas
            foreach (Lista l in listas)
            {
                CfgLista cfg=new CfgLista();
                cfg.nElementos = l.nElementos;
                cfg.mGeneracion = l.orden;
                lista.Add(cfg);
            }
            config.cfgsListas = lista;
            if (cmbOrdenacion.SelectionBoxItem.ToString() == "Inserción")
            {
                config.algoritmo = Algoritmo.Insercion;
            }
            else if (cmbOrdenacion.SelectionBoxItem.ToString() == "Selección")
            {
                config.algoritmo = Algoritmo.Seleccion;
            }
            else
            {
                config.algoritmo = Algoritmo.Quicksort;
            }


            if (cmbCriterio.SelectionBoxItem.ToString() == "Ascendente")
            {
                config.orden = Orden.Ascendente;
            }
            else
            {
                config.orden = Orden.Descendente;
            }
            config.nListas = listas.Count;
            return config;
        }

        /// <summary>
        /// Carga una configuración previamente guardada.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btCargar_Click(object sender, RoutedEventArgs e)
        {
            load();
        }

        /// <summary>
        /// Muestra la ayuda de la aplicación.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btAyuda_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private Boolean load()
        {
            string file = "";
            OpenFileDialog openWindow = new OpenFileDialog();
            DialogResult result;
            openWindow.Multiselect = false;
            openWindow.Title = "Open ALG file";
            openWindow.Filter = "ALG File (.alg)|*.alg";
            openWindow.ValidateNames = true;
            result = openWindow.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.Cancel)
                return false;
            else if (result == System.Windows.Forms.DialogResult.OK)
            {
                file = openWindow.FileName;
                if (check(file))
                {
                    open(file);
                }

            }
            return true;
        }

        private void open(string file)
        {
            string messageBoxText = "";
            string caption = "Algoritmia_P1";
            MessageBoxButton button;
            MessageBoxImage icon;

            if (!file.EndsWith(".alg"))
                file += ".alg";

            //hay que pasarle la ruta
            if (loadConfig(file))
            {
                button = MessageBoxButton.OK;
                icon = MessageBoxImage.Information;
                messageBoxText = "Archivo cargado con éxito";
                System.Windows.MessageBox.Show(messageBoxText, caption, button, icon);
            }
            else
            {
                button = MessageBoxButton.OK;
                icon = MessageBoxImage.Error;
                messageBoxText = "Error al guardar el archivo";
                System.Windows.MessageBox.Show(messageBoxText, caption, button, icon);
            }
        }

        private Boolean loadConfig(string file)
        {
            XmlReaderSettings preferences = new XmlReaderSettings();
            XmlReader reader = XmlReader.Create(file, preferences);
            int numListas;
            List<CfgLista> cfgListas = new List<CfgLista>();
            while (reader.Read()) if (reader.NodeType == XmlNodeType.Element)
                {
                    switch (reader.Name)
                    {

                        case "Listas":
                            numListas = Convert.ToInt32(reader.GetAttribute(2).ToString());
                            if (reader.GetAttribute(1).ToString().CompareTo("Ascendente") == 0)
                            {
                                cmbCriterio.SelectedIndex = 0;
                            }
                            else
                            {
                                cmbCriterio.SelectedIndex = 1;
                            }
                            if (reader.GetAttribute(0).ToString().CompareTo("Insercion") == 0)
                            {
                                cmbOrdenacion.SelectedIndex = 0;
                            }
                            else if (reader.GetAttribute(0).ToString().CompareTo("Seleccion") == 0)
                            {
                                cmbOrdenacion.SelectedIndex = 1;
                            }
                            else
                            {
                                cmbOrdenacion.SelectedIndex = 2;
                            }
                            break;


                        case "Lista":
                            int nElementos;
                            ModoGeneración modo;
                            CfgLista list = new CfgLista();
                            nElementos = Convert.ToInt32(reader.GetAttribute(0).ToString());
                            if (reader.GetAttribute(1).ToString().CompareTo("Ascendente") == 0)
                            {
                                modo = ModoGeneración.Ascendente;
                            }
                            else if (reader.GetAttribute(1).ToString().CompareTo("Descendente") == 0)
                            {
                                modo = ModoGeneración.Descendente;
                            }
                            else
                            {
                                modo = ModoGeneración.Aleatorio;
                            }
                            list.mGeneracion = modo;
                            list.nElementos = nElementos;
                            cfgListas.Add(list);
                            break;

                    }
                }

            insertaListasDt(cfgListas);
            return true;
        }

        /// <summary>
        /// Añade informacion de las listas al datagrid.
        /// </summary>
        /// <param name="cfgListas"></param>
        public void insertaListasDt(List<CfgLista> cfgListas)
        {
            int id = 0;
            EntradaDatos entD;
            EntradaDatos entO;
            foreach (CfgLista cfg in cfgListas)
            {
                entD = new EntradaDatos(cfg.nElementos);
                entO = new EntradaDatos(cfg.nElementos);
                listas.Add(new Lista() { id = id, orden = cfg.mGeneracion, nElementos = cfg.nElementos, nComparaciones = 0, nIntercambios = 0, tiempo = 0, vectorD = entD, vectorO = entO });
                dtListas.ItemsSource = listas;
                refreshGrid();
                id++;
            }
        }

        private Boolean check(String file)
        {
            if (!File.Exists(file))
            {
                //fichero no existe
                //mostrar mensaje??
                return false;
            }
            if (checkFile(file))
            {
                return true;
            }
            else
            {
                //archivo no válido
                return false;
            }
        }


        /// <summary>
        /// Refresca la información visualizada en el Grid tras la modificación del origen de datos.
        /// </summary>
        private void refreshGrid()
        {
            System.Windows.Application.Current.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, (Action)delegate()
            {
                ((DataGridTextColumn)dtListas.Columns[0]).Binding = new System.Windows.Data.Binding("id");
                ((DataGridTextColumn)dtListas.Columns[1]).Binding = new System.Windows.Data.Binding("orden");
                ((DataGridTextColumn)dtListas.Columns[2]).Binding = new System.Windows.Data.Binding("nElementos");
                ((DataGridTextColumn)dtListas.Columns[3]).Binding = new System.Windows.Data.Binding("nIntercambios");
                ((DataGridTextColumn)dtListas.Columns[4]).Binding = new System.Windows.Data.Binding("nComparaciones");
                ((DataGridTextColumn)dtListas.Columns[5]).Binding = new System.Windows.Data.Binding("tiempo");
                ((DataGridTextColumn)dtListas.Columns[7]).Binding = new System.Windows.Data.Binding("ordenado");
            });
                
        }


        private Boolean checkFile(String file)
        {
            XmlSchemaSet sPosiciones = new XmlSchemaSet();
            XmlReaderSettings settingsPositions = new XmlReaderSettings();
            try
            {
                sPosiciones.Add("", Environment.CurrentDirectory + ".\\..\\..\\Validar\\validar.xsd");
            }
            catch (Exception)
            {
                //no se encuentra el fichero de validacion
                return false;
            }
            settingsPositions.ValidationType = ValidationType.Schema;
            settingsPositions.Schemas = sPosiciones;
            settingsPositions.ValidationEventHandler += new ValidationEventHandler(callCheckFile);

            XmlReader rPositions = XmlReader.Create(file, settingsPositions);
            try
            {
                while (rPositions.Read()) { }
            }
            catch (Exception)
            {
                return false;
            }
            rPositions.Close();
            return true;
        }

        private void callCheckFile(object sender, ValidationEventArgs e)
        {

        }

        private void expander1_Expanded(object sender, RoutedEventArgs e)
        {

            this.Height = this.Height + expander1.Height;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void expander1_Collapsed(object sender, RoutedEventArgs e)
        {
            this.Height = this.Height - expander1.Height;
        }

        /// <summary>
        /// Evento parea recoger el control expander.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void expander1_Collapsed_1(object sender, RoutedEventArgs e)
        {
            this.Height = this.Height - expander1.Height;
        }

        /// <summary>
        /// Inicializacion de la ventana principal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            visibilidadBarra_Inicial();
            listas = new ObservableCollection<Lista>();
            id_click_elimina = -1;
            id_click_elimina_old = -1;
            id_click_muestra = -1;
            id_click_muestra_old = -1;
        }

        /// <summary>
        /// Metodo para establecer la visibilidad del interfaz al iniciar la aplicación.
        /// </summary>
        private void visibilidadBarra_Inicial()
        {
            System.Windows.Application.Current.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, (Action)delegate()
            {
            dtListas.IsEnabled = true;
            expander1.IsEnabled = false;
            btGuardar.IsEnabled = false;
            btOrdenar.IsEnabled = false;
            btDetener.IsEnabled = false;
            btLimpiar.IsEnabled = false;
            lblOrdenacion.IsEnabled = false;
            lblOrden.IsEnabled = false;
            cmbOrdenacion.IsEnabled = false;
            cmbCriterio.IsEnabled = false;
            });
        }

        /// <summary>
        /// Metodo para establecer la visibilidad del interfaz al iniciar la aplicación.
        /// </summary>
        private void visibilidadBarra_Ordenando()
        {
            System.Windows.Application.Current.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, (Action)delegate()
            {
            dtListas.IsEnabled = false;
            btAyuda.IsEnabled = false;
            btCargar.IsEnabled = false;
            expander1.IsEnabled = false;
            btGuardar.IsEnabled = false;
            btOrdenar.IsEnabled = false;
            btDetener.IsEnabled = true;
            btLimpiar.IsEnabled = false;
            lblOrdenacion.IsEnabled = false;
            lblOrden.IsEnabled = false;
            cmbOrdenacion.IsEnabled = false;
            cmbCriterio.IsEnabled = false;
            });
        }

        /// <summary>
        /// Metodo para establecer la visibilidad del interfaz tras realizar una ordenación.
        /// </summary>
        private void visibilidadBarra_Final()
        {
            System.Windows.Application.Current.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, (Action)delegate()
            {
                expander1.IsEnabled = true;
            dtListas.IsEnabled = true;
            btAyuda.IsEnabled = true;
            btCargar.IsEnabled = true;
            expander1.IsEnabled = true;
            btGuardar.IsEnabled = true;
            btOrdenar.IsEnabled = true;
            btDetener.IsEnabled = false;
            btLimpiar.IsEnabled = true;
            lblOrdenacion.IsEnabled = true;
            lblOrden.IsEnabled = true;
            cmbOrdenacion.IsEnabled = true;
            cmbCriterio.IsEnabled = true;
            });
        }


        /// <summary>
        /// Metodo para establecer la visibilidad del interfaz si se aborta una ordenación.
        /// </summary>
        private void visibilidadBarra_Detener()
        {
            System.Windows.Application.Current.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, (Action)delegate()
            {
                expander1.IsEnabled = false;
                dtListas.IsEnabled = false;
                btAyuda.IsEnabled = true;
                btCargar.IsEnabled = true;
                expander1.IsEnabled = true;
                btGuardar.IsEnabled = true;
                btOrdenar.IsEnabled = true;
                btDetener.IsEnabled = false;
                btLimpiar.IsEnabled = true;
                lblOrdenacion.IsEnabled = true;
                lblOrden.IsEnabled = true;
                cmbOrdenacion.IsEnabled = true;
                cmbCriterio.IsEnabled = true;
                lblOrdenacion.IsEnabled = false;
                lblOrden.IsEnabled = false;
                cmbOrdenacion.IsEnabled = false;
                cmbCriterio.IsEnabled = false;
            });
        }

        /// <summary>
        /// Detiene el proceso de ordenación.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btDetener_Click(object sender, RoutedEventArgs e)
        {
            visibilidadBarra_Detener();
            hiloOrdena.Abort();
        }

        private void btLimpiar_Click(object sender, RoutedEventArgs e)
        {
            cmbCriterio.SelectedIndex = -1;
            cmbOrdenacion.SelectedIndex = -1;
            id_click_elimina = -1;
            id_click_elimina_old = -1;
            id_click_muestra=-1;
            id_click_muestra_old = -1;
            int cont = listas.Count;
            int i=0;
            while (i<cont ){
                listas.RemoveAt(0); 
                i++;
            }
            dtListas.ItemsSource = listas;
            visibilidadBarra_Inicial();
            refreshGrid();
        }




    }
}