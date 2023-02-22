//
//  CSVNet Legacy
//
//  Classica CSVNet Riscritta in C#.
//
//  Una Libreria .NET per Scrivere, Leggere
//  e Modificare File in Formato CSV.
//
//  Questo File fa Parte del Progetto CSVNet
//  ed è Distribuito sotto Licenza MIT.
//
//  GitHub:      https://github.com/reallukee/csvnet
//  Autore:      Luca Pollicino
//  Descrizione: Header
//               Permette la Gestione dell'Header
//               di una Tabella CSV.
//  Versione:    1.0.0
//
//  Leggere README.md per Maggiori Informazioni.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace CSVNet.Legacy
{
    public partial class CSVDocument
    {
        public void AddHeader(List<string> Values)
        {
            AddRowAtStart(Values);
        }


        public List<string> RemoveHeader()
        {
            return RemoveRow();
        }


        public void SetHeader(List<string> Values)
        {
            SetFirstRow(Values);
        }


        public List<string> GetHeader()
        {
            return GetFirstRow();
        }
    }
}
