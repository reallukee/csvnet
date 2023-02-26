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
//  Descrizione: Events
//               Permette la Gestione degli Eventi
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
    public partial class CSVDocument
    {
        public delegate void RowDataEventHandler(
            object Sender,
            RowDataEventArgs E
        );


        public event RowDataEventHandler RowAdded;

        protected virtual void OnRowAdded(RowDataEventArgs E)
        {
            RowDataEventHandler T = RowAdded;
            T?.Invoke(this, E);
        }


        public event RowDataEventHandler RowRemoved;

        protected virtual void OnRowRemoved(RowDataEventArgs E)
        {
            RowDataEventHandler T = RowRemoved;
            T?.Invoke(this, E);
        }


        public event RowDataEventHandler RowChanged;

        protected virtual void OnRowChanged(RowDataEventArgs E)
        {
            RowDataEventHandler T = RowChanged;
            T?.Invoke(this, E);
        }


        public delegate void ColDataEventHandler(
            object Sender,
            ColDataEventArgs E
        );


        public event ColDataEventHandler ColAdded;

        protected virtual void OnColAdded(ColDataEventArgs E)
        {
            ColDataEventHandler T = ColAdded;
            T?.Invoke(this, E);
        }


        public event ColDataEventHandler ColRemoved;

        protected virtual void OnColRemoved(ColDataEventArgs E)
        {
            ColDataEventHandler T = ColRemoved;
            T?.Invoke(this, E);
        }


        public event ColDataEventHandler ColChanged;

        protected virtual void OnColChanged(ColDataEventArgs E)
        {
            ColDataEventHandler T = ColChanged;
            T?.Invoke(this, E);
        }


        public delegate void CellDataEventHandler(
            object Sender,
            CellDataEventArgs E
        );


        public event CellDataEventHandler CellChanged;

        protected virtual void OnCellChanged(CellDataEventArgs E)
        {
            CellDataEventHandler T = CellChanged;
            T?.Invoke(this, E);
        }
    }


    public class RowDataEventArgs : EventArgs
    {
        public RowDataEventArgs(int Index, List<string> Values)
        {
            this.Index = Index;
            this.Values = Values;
        }

        public RowDataEventArgs()
        {
            this.Index = 0;
            this.Values = null;
        }

        private int Index_;

        public int Index
        {
            get => Index_;
            set => Index_ = value;
        }

        private List<string> Values_;

        public List<string> Values
        {
            get => Values_;
            set => Values_ = value;
        }
    }


    public class ColDataEventArgs : EventArgs
    {
        public ColDataEventArgs(int Index, List<string> Values)
        {
            this.Index = Index;
            this.Values = Values;
        }

        public ColDataEventArgs()
        {
            this.Index = 0;
            this.Values = null;
        }

        private int Index_;

        public int Index
        {
            get => Index_;
            set => Index_ = value;
        }

        private List<string> Values_;

        public List<string> Values
        {
            get => Values_;
            set => Values_ = value;
        }
    }


    public class CellDataEventArgs : EventArgs
    {
        public CellDataEventArgs(int Row, int Col, string Value)
        {
            this.Row = Row;
            this.Col = Col;
            this.Value = Value;
        }

        public CellDataEventArgs()
        {
            this.Row = 0;
            this.Col = 0;
            this.Value = "";
        }

        private int Row_;

        public int Row
        {
            get => Row_;
            set => Row_ = value;
        }

        private int Col_;

        public int Col
        {
            get => Col_;
            set => Col_ = value;
        }

        private string Value_;

        public string Value
        {
            get => Value_;
            set => Value_ = value;
        }
    }
}
