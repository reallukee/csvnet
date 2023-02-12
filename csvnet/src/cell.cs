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
//  Descrizione: Cell
//               Permette la Gestione delle Celle
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
        public string GetCell(int Row, int Col)
        {
            try
            {
                if (CellExist(Row, Col))
                {
                    return Content[Row][Col];
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

        public T GetCellAs<T>(int Row, int Col)
        {
            try
            {
                if (CellExist(Row, Col))
                {
                    return (T)Convert.ChangeType(Content[Row][Col], typeof(T)); ;
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


        public void SetCell(int Row, int Col, string Value)
        {
            try
            {
                if (CellExist(Row, Col))
                {
                    Content[Row][Col] = Value;
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


        public void SwapCell(int Row1, int Col1, int Row2, int Col2)
        {
            try
            {
                if (CellExist(Row1, Col1) && CellExist(Row2, Col2))
                {
                    string Value1 = GetCell(Row1, Col1);
                    string Value2 = GetCell(Row2, Col2);

                    SetCell(Row1, Col1, Value2);
                    SetCell(Row2, Col2, Value1);
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


        public int GetCellCount()
        {
            return RowCount * ColCount;
        }


        public bool CellExist(int Row, int Col)
        {
            return RowExist(Row) && ColExist(Col);
        }

        public bool CellCanExist(int Row, int Col)
        {
            return RowCanExist(Row) && ColCanExist(Col);
        }
    }
}
