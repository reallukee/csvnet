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
//  Descrizione: ICSVCell
//               Contiene l'Interfaccia ICSVCell
//               e l'Implementazione CSVCell.
//               Permette l'Astrazione delle Celle
//               di una Tabella CSV.
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
    public interface ICSVCell
    {
        public int Row
        {
            get;
            set;
        }

        public int Col
        {
            get;
            set;
        }

        public void Set(string Value);

        public string Get();
        public T GetAs<T>();

        public string ToString();

        public bool Equals(ICSVCell Obj);
        public int GetHashCode();
    }
}
