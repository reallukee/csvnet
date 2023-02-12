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
//  Descrizione: Row
//               Permette la Gestione delle Righe
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
        public void AddRow(string InitValue)
        {
            try
            {
                if (RowCanExist(RowCount))
                {
                    List<string> T = new();

                    for (int I = 0; I < ColCount; I++)
                    {
                        T.Add(InitValue);
                    }

                    Content.Add(T);
                }
                else
                {
                    throw new RowCantExistException();
                }
            }
            catch
            {
                throw;
            }
        }

        public void AddRow(List<string> InitValues)
        {
            try
            {
                if (InitValues.Count() != RowCount)
                {
                    throw new RowIsInvalidException();
                }

                if (RowCanExist(RowCount))
                {
                    List<string> T = new();

                    for (int I = 0; I < ColCount; I++)
                    {
                        T.Add(InitValues[I]);
                    }

                    Content.Add(T);
                }
                else
                {
                    throw new RowCantExistException();
                }
            }
            catch
            {
                throw;
            }
        }

        public void AddRow()
        {
            AddRow("");
        }

        public void AddRowAt(int Index, string InitValue)
        {
            try
            {
                if (RowCanExist(RowCount))
                {
                    List<string> T = new();

                    for (int I = 0; I < ColCount; I++)
                    {
                        T.Add(InitValue);
                    }

                    Content.Insert(Index, T);
                }
                else
                {
                    throw new RowCantExistException();
                }
            }
            catch
            {
                throw;
            }
        }

        public void AddRowAt(int Index, List<string> InitValues)
        {
            try
            {
                if (InitValues.Count() != RowCount)
                {
                    throw new RowIsInvalidException();
                }

                if (RowCanExist(RowCount))
                {
                    List<string> T = new();

                    for (int I = 0; I < ColCount; I++)
                    {
                        T.Insert(Index, InitValues[I]);
                    }

                    Content.Insert(Index, T);
                }
                else
                {
                    throw new RowCantExistException();
                }
            }
            catch
            {
                throw;
            }
        }

        public void AddRowAt(int Index)
        {
            AddRowAt(Index, "");
        }

        public void AddRowAtStart(string InitValue)
        {
            AddRowAt(0, InitValue);
        }

        public void AddRowAtStart(List<string> InitValues)
        {
            AddColAt(0, InitValues);
        }

        public void AddRowAtStart()
        {
            AddRowAt(0, "");
        }


        public List<string> RemoveRow()
        {
            try
            {
                List<string> T = GetRow(LastRowIndex);

                if (RowExist(LastRowIndex))
                {
                    Content.RemoveAt(LastRowIndex);
                }
                else
                {
                    throw new RowDosentExistException();
                }

                return T;
            }
            catch
            {
                throw;
            }
        }

        public List<string> RemoveRowAt(int Index)
        {
            try
            {
                List<string> T = GetRow(Index);

                if (RowExist(Index))
                {
                    Content.RemoveAt(Index);
                }
                else
                {
                    throw new RowDosentExistException();
                }

                return T;
            }
            catch
            {
                throw;
            }
        }

        public List<string> RemoveRowAtStart()
        {
            return RemoveRowAt(0);
        }

        public void RemoveRowRange(int Index, int Count)
        {
            try
            {
                if (RowExist(Index) && RowExist(Index + Count))
                {
                    for (int I = 0; I < Count; I++)
                    {
                        RemoveRowAt(Index);
                    }
                }
                else
                {
                    throw new RowDosentExistException();
                }
            }
            catch
            {
                throw;
            }
        }


        public List<string> GetRow(int Index)
        {
            try
            {
                List<string> T = new();

                for (int I = 0; I < ColCount; I++)
                {
                    if (ColExist(I))
                    {
                        T.Add(Content[Index][I]);
                    }
                    else
                    {
                        throw new ColDosentExistException();
                    }
                }

                return T;
            }
            catch
            {
                throw;
            }
        }

        public List<T> GetRowAs<T>(int Index)
        {
            try
            {
                List<T> B = new();

                for (int I = 0; I < ColCount; I++)
                {
                    if (ColExist(I))
                    {
                        B.Add((T)Convert.ChangeType(Content[Index][I], typeof(T)));
                    }
                    else
                    {
                        throw new ColDosentExistException();
                    }
                }

                return B;
            }
            catch
            {
                throw;
            }
        }

        public List<string> GetFirstRow()
        {
            return GetRow(0);
        }

        public List<T> GetFirstRowAs<T>()
        {
            return GetRowAs<T>(0);
        }

        public List<string> GetLastRow()
        {
            return GetRow(LastRowIndex);
        }

        public List<T> GetLastRowAs<T>()
        {
            return GetRowAs<T>(LastRowIndex);
        }


        public void SetRow(int Index, string Value)
        {
            try
            {
                if (RowExist(Index))
                {
                    for (int I = 0; I < ColCount; I++)
                    {
                        Content[Index][I] = Value;
                    }
                }
                else
                {
                    throw new RowDosentExistException();
                }
            }
            catch
            {
                throw;
            }
        }

        public void SetRow(int Index, List<string> Values)
        {
            try
            {
                if (!RowExist(Index))
                {
                    throw new RowDosentExistException();
                }

                if (Values.Count == RowCount)
                {
                    for (int I = 0; I < ColCount; I++)
                    {
                        Content[Index][I] = Values[I];
                    }
                }
                else
                {
                    throw new ColDosentExistException();
                }
            }
            catch
            {
                throw;
            }
        }

        public void SetFirstRow(string Value)
        {
            SetRow(0, Value);
        }

        public void SetFirstRow(List<string> Values)
        {
            SetRow(0, Values);
        }

        public void SetLastRow(string Value)
        {
            SetRow(LastRowIndex, Value);
        }

        public void SetLastRow(List<string> Values)
        {
            SetRow(LastRowIndex, Values);
        }


        public void SwapRow(int Index1, int Index2)
        {
            try
            {
                if (RowExist(Index1) && RowExist(Index2))
                {
                    for (int I = 0; I < ColCount; I++)
                    {
                        SwapCell(Index1, I, Index2, I);
                    }
                }
                else
                {
                    throw new RowDosentExistException();
                }
            }
            catch
            {
                throw;
            }
        }


        public void MoveRow(int Index, int NewIndex)
        {
            try
            {
                if (RowExist(Index) && RowExist(NewIndex))
                {
                    if (Index < NewIndex)
                    {
                        for (int I = Index; I < NewIndex; I++)
                        {
                            for (int J = 0; J < ColCount; J++)
                            {
                                SwapCell(I, J, I + 1, J);
                            }
                        }
                    }

                    if (Index > NewIndex)
                    {
                        for (int I = NewIndex; I < Index; I++)
                        {
                            for (int J = 0; J < ColCount; J++)
                            {
                                SwapCell(I, J, I + 1, J);
                            }
                        }
                    }
                }
                else
                {
                    throw new RowDosentExistException();
                }
            }
            catch
            {
                throw;
            }
        }

        public void MoveRowToStart(int Index)
        {
            MoveRow(Index, 0);
        }

        public void MoveRowToEnd(int Index)
        {
            MoveRow(Index, LastRowIndex);
        }


        public void DuplicateRow(int Index, int NewIndex)
        {
            try
            {
                if (RowExist(Index))
                {
                    AddRowAt(NewIndex);

                    for (int I = 0; I < ColCount; I++)
                    {
                        SetCell(NewIndex, I, GetCell(Index, I));
                    }
                }
                else
                {
                    throw new RowDosentExistException();
                }
            }
            catch
            {
                throw;
            }
        }


        public bool RowContains(int Index, string Value)
        {
            try
            {
                if (RowExist(Index))
                {
                    for (int I = 0; I < ColCount; I++)
                    {
                        if (GetCell(Index, I).Contains(Value))
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    throw new RowDosentExistException();
                }
            }
            catch
            {
                throw;
            }

            return false;
        }

        public int RowIndexOf(int Index, string Value)
        {
            return RowIndexOf(Index, Value, 0);
        }

        public int RowIndexOf(int Index, string Value, int Start)
        {
            try
            {
                if (!RowExist(Index))
                {
                    throw new RowDosentExistException();
                }

                if (!CellExist(Index, Start))
                {
                    throw new CellDosentExistException();
                }

                for (int I = Start; I < ColCount; I++)
                {
                    if (GetCell(Index, I).Contains(Value))
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

        public int RowLastIndexOf(int Index, string Value)
        {
            try
            {
                if (RowExist(Index))
                {
                    for (int I = LastColIndex; I >= 0; I++)
                    {
                        if (GetCell(Index, I).Contains(Value))
                        {
                            return I;
                        }
                    }
                }
                else
                {
                    throw new RowDosentExistException();
                }
            }
            catch
            {
                throw;
            }

            return -1;
        }


        public int RowCount
        {
            get => Content.Count();
        }

        public int FirstRowIndex
        {
            get => 0;
        }

        public int LastRowIndex
        {
            get => RowCount - 1;
        }


        public bool RowExist(int Row)
        {
            return Row >= 0 && Row < Content.Count();
        }

        public bool RowCanExist(int Row)
        {
            return Row >= 0 && Row <= Content.Count();
        }
    }
}
