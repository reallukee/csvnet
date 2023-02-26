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
//  Descrizione: CSVCell
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
    public partial class CSVCell
    {
        private string Value;


        public CSVCell(string Value, int Row, int Col)
        {
            this.Value = Value;
            this.Row = Row;
            this.Col = Col;
        }

        public CSVCell(string Value)
        {
            this.Value = Value;
            this.Row = 0;
            this.Col = 0;
        }

        public CSVCell()
        {
            this.Value = "";
            this.Row = 0;
            this.Col = 0;
        }


        private int Row_;

        public int Row
        {
            get => Row_;

            set
            {
                if (value >= 0)
                {
                    Row_ = value;
                }
                else
                {
                    Row_ = 0;
                }
            }
        }


        private int Col_;

        public int Col
        {
            get => Col_;

            set
            {
                if (value >= 0)
                {
                    Col_ = value;
                }
                else
                {
                    Col_ = 0;
                }
            }
        }


        public void Set(string Value)
        {
            this.Value = Value;
        }


        public string Get()
        {
            return Value;
        }

        public T GetAs<T>()
        {
            return (T)Convert.ChangeType(Value, typeof(T));
        }


        public override string ToString()
        {
            return Value;
        }

        public bool Equals(CSVCell Obj)
        {
            return ToString() == Obj.ToString();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
