﻿//
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
//  Descrizione: ICSVCol
//               Contiene l'Interfaccia ICSVCol
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
    public interface ICSVCol
    {
        public int Index
        {
            get;
            set;
        }

        public bool AddCell(string Value);
        public bool AddCellAt(string Value, int Index);
        public bool AddCellAtStart(string Value);

        public string RemoveCell();
        public string RemoveCellAt(int Index);
        public string RemoveCellAtStart();

        public bool SetCell(string Value, int Index);
        public bool SetFirstCell(string Value);
        public bool SetLastCell(string Value);

        public string GetCellValue(int Index);
        public string GetFirstCellValue();
        public string GetLastCellValue();
        public ICSVCell GetCell(int Index);
        public ICSVCell GetFirstCell();
        public ICSVCell GetLastCell();
        public T GetCellAs<T>(int Index);
        public T GetFirstCellAs<T>();
        public T GetLastCellAs<T>();

        public bool SwapCell(int Index1, int Index2);
        public bool DuplicateCell(int Index, int NewIndex);

        public bool MoveCellTo(int Index, int NewIndex);
        public bool MoveCellToStart(int Index);
        public bool MoveCellToEnd(int Index);

        public bool Contains(string Value);
        public int IndexOf(string Value);
        public int IndexOf(string Value, int Start);
        public int LastIndexOf(string Value);

        public int GetCellCount();
        public int GetFirstCellIndex();
        public int GetLastCellIndex();
        public bool CellExists(int Index);
        public bool CellCanExists(int Index);

        public List<ICSVCell> ToCellsList();
        public List<T> ToList<T>();
    }
}