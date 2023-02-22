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
//  Descrizione: ICSVRow
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
    public interface ICSVRow
    {
        public int Index
        {
            get;
            set;
        }

        public void AddCell(string Value);
        public void AddCellAt(string Value, int Index);
        public void AddCellAtStart(string Value);

        public string RemoveCell();
        public string RemoveCellAt(int Index);
        public string RemoveCellAtStart();

        public void SetCell(string Value, int Index);
        public void SetFirstCell(string Value);
        public void SetLastCell(string Value);

        public string GetCellValue(int Index);
        public string GetFirstCellValue();
        public string GetLastCellValue();
        public ICSVCell GetCell(int Index);
        public ICSVCell GetFirstCell();
        public ICSVCell GetLastCell();
        public T GetCellAs<T>(int Index);
        public T GetFirstCellAs<T>();
        public T GetLastCellAs<T>();

        public void SwapCell(int Index1, int Index2);
        public void DuplicateCell(int Index, int NewIndex);

        public void MoveCellTo(int Index, int NewIndex);
        public void MoveCellToStart(int Index);
        public void MoveCellToEnd(int Index);

        public bool Contains(string Value);
        public int IndexOf(string Value);
        public int IndexOf(string Value, int Start);
        public int LastIndexOf(string Value);

        public int CellCount
        {
            get;
        }

        public bool HasCell
        {
            get;
        }

        public int FirstCellIndex
        {
            get;
        }

        public int LastCellIndex
        {
            get;
        }

        public bool CellExist(int Index);
        public bool CellCanExist(int Index);

        public List<ICSVCell> ToCellsList();
        public List<T> ToList<T>();

        public string ToString(string Separator);
        public string ToString();

        public bool Equals(ICSVRow Obj);
        public int GetHashCode();
    }
}
