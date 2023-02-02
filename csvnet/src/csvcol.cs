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
//  Descrizione: CSVCol
//               Contiene l'Interfaccia CSVCol
//               e l'Implementazione CSVCol.
//               Permette l'Astrazione delle Colonne
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
    public partial class CSVCol : ICSVCol
    {
        private List<ICSVCell> Cells;


        public CSVCol(List<ICSVCell> Cells, int Index)
        {
            this.Cells = Cells;
            this.Index = Index;

            if (this.Cells.Count() == 0)
                this.Cells.Add(new CSVCell("", 0, Index));
        }

        public CSVCol(List<ICSVCell> Cells)
        {
            this.Cells = Cells;
            this.Index = 0;

            if (this.Cells.Count() == 0)
                this.Cells.Add(new CSVCell("", 0, Index));
        }

        public CSVCol()
        {
            this.Cells = new() { new CSVCell("", 0, Index) };
            this.Index = 0;
        }


        private int Index_;

        public int Index
        {
            get => Index_;

            set
            {
                if (value >= 0)
                {
                    Index_ = value;
                }
                else
                {
                    Index_ = 0;
                }
            }
        }


        public bool AddCell(string Value)
        {
            Cells.Add(new CSVCell(Value, GetCellCount(), Index));
            return true;
        }

        public bool AddCellAt(string Value, int Index)
        {
            try
            {
                Cells.Insert(Index, new CSVCell(Value, Index, this.Index));
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool AddCellAtStart(string Value)
        {
            return AddCellAt(Value, 0);
        }


        public string RemoveCell()
        {
            string T = GetLastCellValue();
            Cells.RemoveAt(Cells.Count() - 1);
            return T;
        }

        public string RemoveCellAt(int Index)
        {
            string T = GetCellValue(Index);
            Cells.RemoveAt(Index);
            return T;
        }

        public string RemoveCellAtStart()
        {
            return RemoveCellAt(0);
        }


        public bool SetCell(string Value, int Index)
        {
            try
            {
                Cells[Index].Set(Value);
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool SetFirstCell(string Value)
        {
            return SetCell(Value, 0);
        }

        public bool SetLastCell(string Value)
        {
            return SetCell(Value, Cells.Count() - 1);
        }


        public string GetCellValue(int Index)
        {
            try
            {
                return Cells[Index].Get();
            }
            catch
            {
                return "";
            }
        }

        public string GetFirstCellValue()
        {
            return GetCellValue(0);
        }

        public string GetLastCellValue()
        {
            return GetCellValue(Cells.Count() - 1);
        }

        public ICSVCell GetCell(int Index)
        {
            return Cells[Index];
        }

        public ICSVCell GetFirstCell()
        {
            return GetCell(0);
        }

        public ICSVCell GetLastCell()
        {
            return GetCell(Cells.Count() - 1);
        }

        public T GetCellAs<T>(int Index)
        {
            return Cells[Index].GetAs<T>();
        }

        public T GetFirstCellAs<T>()
        {
            return GetCellAs<T>(0);
        }

        public T GetLastCellAs<T>()
        {
            return GetCellAs<T>(Cells.Count() - 1);
        }


        public bool SwapCell(int Index1, int Index2)
        {
            try
            {
                string T = GetCellValue(Index1);
                SetCell(GetCellValue(Index2), Index1);
                SetCell(T, Index2);
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool DuplicateCell(int Index, int NewIndex)
        {
            try
            {
                AddCellAt(GetCellValue(Index), NewIndex);
            }
            catch
            {
                return false;
            }

            return true;
        }


        public bool MoveCellTo(int Index, int NewIndex)
        {
            try
            {
                if (Index < NewIndex)
                {
                    for (int I = Index; I < NewIndex; I++)
                    {
                        SwapCell(I, I + 1);
                    }
                }

                if (Index > NewIndex)
                {
                    for (int I = Index; I > NewIndex; I--)
                    {
                        SwapCell(I, I - 1);
                    }
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool MoveCellToStart(int Index)
        {
            return MoveCellTo(Index, 0);
        }

        public bool MoveCellToEnd(int Index)
        {
            return MoveCellTo(Index, GetLastCellIndex());
        }


        public bool Contains(string Value)
        {
            try
            {
                foreach (CSVCell T in Cells)
                {
                    if (T.Get().Contains(Value))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }

            return false;
        }

        public int IndexOf(string Value)
        {
            return IndexOf(Value, 0);
        }

        public int IndexOf(string Value, int Start)
        {
            try
            {
                for (int I = Start; I < GetCellCount(); I++)
                {
                    if (Cells[I].Get().Contains(Value))
                    {
                        return I;
                    }
                }
            }
            catch
            {
                return -1;
            }

            return -1;
        }

        public int LastIndexOf(string Value)
        {
            try
            {
                for (int I = GetLastCellIndex(); I >= 0; I--)
                {
                    if (Cells[I].Get().Contains(Value))
                    {
                        return I;
                    }
                }
            }
            catch
            {
                return -1;
            }

            return -1;
        }


        public int GetCellCount()
        {
            return Cells.Count();
        }

        public int GetFirstCellIndex()
        {
            return 0;
        }

        public int GetLastCellIndex()
        {
            return GetCellCount() - 1;
        }

        public bool CellExists(int Index)
        {
            return Index >= 0 && Index <= GetLastCellIndex();
        }

        public bool CellCanExists(int Index)
        {
            return Index >= 0 && Index <= GetCellCount();
        }


        public List<ICSVCell> ToCellsList()
        {
            List<ICSVCell> T = new();

            for (int I = 0; I < GetCellCount(); I++)
            {
                T.Add(new CSVCell(GetCellValue(I), 0, I));
            }

            return T;
        }

        public List<T> ToList<T>()
        {
            return (List<T>)Convert.ChangeType(Cells, typeof(List<T>));
        }


        public override string ToString()
        {
            return $"CSVCol";
        }
    }
}
