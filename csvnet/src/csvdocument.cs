//
//  CSVNet
//
//  Una Libreria .NET per Scrivere, Leggere
//  e Modificare File in Formato CSV.
//
//  Questo File fa Parte del Progetto CSVNet
//  ed è Distribuito sotto Licenza MIT.
//
//  GitHub:      https://github.com/reallukee/csvnet
//  Autore:      Luca Pollicino
//  Descrizione: CSVDocument
//               Contiene l'Interfaccia ICSDocument
//               e l'Implementazione CSVDocument.
//  Versione:    2.0.0
//
//  Leggere README.md per Maggiori Informazioni.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace CSVNet
{
    public partial class CSVDocument
    {
        private List<List<string>> Content;


        public CSVDocument()
        {
            Content = new() { new() { "" } };
        }


        public bool Initialize(int Rows, int Cols)
        {
            try
            {
                for (int Y = 0; Y < Rows; Y++)
                {
                    List<string> T = new();

                    for (int X = 0; X < Cols; X++)
                    {
                        T.Add("");
                    }

                    Content.Add(T);
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool Unload()
        {
            try
            {
                Content.Clear();
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
