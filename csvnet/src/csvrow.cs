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
//  Descrizione: CSVRow
//               Contiene l'Interfaccia ICSVRow
//               e l'Implementazione CSVRow.
//               Permette l'Astrazione delle Righe
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
    public partial class CSVRow : ICSVRow
    {
        private List<ICSVCell> Cells;


        public CSVRow(List<ICSVCell> Cells, int Index)
        {
            this.Cells = Cells;
            this.Index = Index;

            if (this.Cells.Count() == 0)
                this.Cells.Add(new CSVCell("", Index, 0));
        }

        public CSVRow(List<ICSVCell> Cells)
        {
            this.Cells = Cells;
            this.Index = 0;

            if (this.Cells.Count() == 0)
                this.Cells.Add(new CSVCell("", Index, 0));
        }

        public CSVRow()
        {
            this.Cells = new() { new CSVCell("", Index, 0) };
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


        public void AddCell(string Value)
        {
            Cells.Add(new CSVCell(Value, Index, GetCellCount()));
        }

        public void AddCellAt(string Value, int Index)
        {
            try
            {
                if (CellCanExist(Index))
                {
                    Cells.Insert(Index, new CSVCell(Value, this.Index, Index));
                }
                else
                {
                    throw new CellCantExistException();
                }
            }
            catch
            {
                throw;
            }
        }

        public void AddCellAtStart(string Value)
        {
            AddCellAt(Value, 0);
        }


        public string RemoveCell()
        {
            return RemoveCellAt(GetLastCellIndex());
        }

        public string RemoveCellAt(int Index)
        {
            try
            {
                if (CellExist(GetLastCellIndex()))
                {
                    string T = GetCellValue(Index);
                    Cells.RemoveAt(Index);
                    return T;
                }
                else
                {
                    throw new CellDosentExistException();
                }
            }
            catch
            {
                throw;
            }
        }

        public string RemoveCellAtStart()
        {
            return RemoveCellAt(0);
        }


        public void SetCell(string Value, int Index)
        {
            try
            {
                if (CellExist(Index))
                {
                    Cells[Index].Set(Value);
                }
                else
                {
                    throw new CellDosentExistException();
                }
            }
            catch
            {
                throw;
            }
        }

        public void SetFirstCell(string Value)
        {
            SetCell(Value, 0);
        }

        public void SetLastCell(string Value)
        {
            SetCell(Value, Cells.Count() - 1);
        }


        public string GetCellValue(int Index)
        {
            try
            {
                if (CellExist(Index))
                {
                    return Cells[Index].Get();
                }
                else
                {
                    throw new CellDosentExistException();
                }
            }
            catch
            {
                throw;
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


        public void SwapCell(int Index1, int Index2)
        {
            try
            {
                if (CellExist(Index1) && CellExist(Index2))
                {
                    string T = GetCellValue(Index1);
                    SetCell(GetCellValue(Index2), Index1);
                    SetCell(T, Index2);
                }
                else
                {
                    throw new CellDosentExistException();
                }
            }
            catch
            {
                throw;
            }
        }

        public void DuplicateCell(int Index, int NewIndex)
        {
            try
            {
                if (CellExist(Index))
                {
                    AddCellAt(GetCellValue(Index), NewIndex);
                }
                else
                {
                    throw new CellDosentExistException();
                }
            }
            catch
            {
                throw;
            }
        }


        public void MoveCellTo(int Index, int NewIndex)
        {
            try
            {
                if (CellExist(Index) && CellExist(NewIndex))
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
                else
                {
                    throw new CellDosentExistException();
                }
            }
            catch
            {
                throw;
            }
        }

        public void MoveCellToStart(int Index)
        {
            MoveCellTo(Index, 0);
        }

        public void MoveCellToEnd(int Index)
        {
            MoveCellTo(Index, GetLastCellIndex());
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
                throw;
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
                throw;
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
                throw;
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

        public bool CellExist(int Index)
        {
            return Index >= 0 && Index <= GetLastCellIndex();
        }

        public bool CellCanExist(int Index)
        {
            return Index >= 0 && Index <= GetCellCount();
        }


        public List<ICSVCell> ToCellsList()
        {
            try
            {
                List<ICSVCell> T = new();

                for (int I = 0; I < GetCellCount(); I++)
                {
                    T.Add(new CSVCell(GetCellValue(I), I, 0));
                }

                return T;
            }
            catch
            {
                throw;
            }
        }

        public List<T> ToList<T>()
        {
            return (List<T>)Convert.ChangeType(Cells, typeof(List<T>));
        }


        public override string ToString()
        {
            string B = "";

            for (int I = 0; I < Cells.Count(); I++)
            {
                B += GetCell(I) + ";";
            }

            return B;
        }

        public string ToString(string Separator)
        {
            return ToString(Separator);
        }


        public bool Equals(ICSVRow Obj)
        {
            return ToString() == Obj.ToString();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
