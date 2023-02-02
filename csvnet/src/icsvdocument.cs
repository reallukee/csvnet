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
//  Descrizione: ICSVDocument
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
    public partial interface ICSVDocument
    {
        public bool Initialize(int Rows, int Cols);
        public bool Unload();

        public bool Load(string FileNane, string Separator);
        public bool Load(string FileName);
        public bool Load(List<ICSVCell> Cells);
        public bool Load(List<ICSVRow> Rows);
        public bool Load(List<ICSVCol> Cols);
        public bool Load(string[] Content, string Separator);
        public bool Load(string[] Content);

        public bool Save(string FileNane, string Separator);
        public bool Save(string FileName);
        public bool Save(List<ICSVCell> Cells);
        public bool Save(List<ICSVRow> Rows);
        public bool Save(List<ICSVCol> Cols);
        public bool Save(string[] Content, string Separator);
        public bool Save(string[] Content);

        public bool Validate();
        public bool Verify();
    }
}
