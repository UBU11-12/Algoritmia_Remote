using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Windows.Forms;
using System.Collections;
using Algoritmos;

namespace Algoritmia_P1
{

    public struct CfgLista
    {
        public int nElementos;
        public ModoGeneración mGeneracion;
    }


    public struct Configuracion
    {
        public Algoritmo algoritmo;
        public Orden orden; 
        public int nListas;
        //Para almacenar el nElementos de cada lista generada
        public List<CfgLista> cfgsListas;
    }


    class Config
    {

        public static Boolean saveConfig(Configuracion config, TreeNode node, String outputPath)
        {
            string directory;
            string path = outputPath;
            int position = path.LastIndexOf('\\');
            if (position != -1)
            {
                directory = path.Remove(position);
            }
            else
            {
                return false;
            }
            XmlWriter writter;
            XmlWriterSettings configuracion = new XmlWriterSettings();
            configuracion.Indent = true;
            configuracion.OmitXmlDeclaration = true;
            configuracion.ConformanceLevel = ConformanceLevel.Auto;
            configuracion.Encoding = System.Text.Encoding.ASCII;
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);
            try
            {
                writter = XmlWriter.Create(outputPath, configuracion);

                writter.WriteStartDocument();
                writter.WriteStartElement("Configuracion");
                writter.WriteStartElement("Listas");
                writter.WriteAttributeString("Algoritmo", config.algoritmo.ToString());
                writter.WriteAttributeString("Criterio", config.orden.ToString());
                writter.WriteAttributeString("Numero_Listas", config.nListas.ToString());
                foreach (CfgLista i in config.cfgsListas)
                {
                    writter.WriteStartElement("Lista");
                    writter.WriteAttributeString("Numero_Elementos", i.nElementos.ToString());
                    writter.WriteAttributeString("Modo_Generacion", i.mGeneracion.ToString());
                    writter.WriteEndElement();
                }
                writter.WriteEndElement();
                writter.WriteEndElement();
                writter.WriteEndDocument();
                writter.Flush();
                writter.Close();
            }
            catch (Exception)
            {
                {
                    return false;
                }
            }
            return true;            
        }

        }

    }

