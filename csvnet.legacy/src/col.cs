//
//  CSVNet Legacy
//
//  Classica CSVNet Riscritta in C#.
//
//  Una Libreria .NET per Scrivere, Leggere
//  e Modificare File in Formato CSV.
//
//  Questo File fa Parte del Progetto CSVNet
//  ed è Distribuito sotto Licenza MIT.
//
//  GitHub:      https://github.com/reallukee/csvnet
//  Autore:      Luca Pollicino
//  Descrizione: Col
//               Permette la Gestione delle Colonne
//               di una Tabella CSV.
//  Versione:    1.0.0
//
//  Leggere README.md per Maggiori Informazioni.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace CSVNet.Legacy
{
    public partial class CSVDocument
    {
        public void AddCol(string InitValue)
        {
            try
            {
                if (ColCanExist(GetColCount()))
                {
                    for (int I = 0; I < GetRowCount(); I++)
                    {
                        Content[I].Add(InitValue);
                    }
                }
                else
                {
                    throw new ColCantExistException();
                }
            }
            catch
            {
                throw;
            }
        }

        public void AddCol()
        {
            AddCol("");
        }

        public void AddColAt(int Index, string InitValue)
        {
            try
            {
                if (ColCanExist(GetColCount()))
                {
                    for (int I = 0; I < GetRowCount(); I++)
                    {
                        Content[I].Insert(Index, InitValue);
                    }
                }
                else
                {
                    throw new ColCantExistException();
                }
            }
            catch
            {
                throw;
            }
        }

        public void AddColAt(int Index)
        {
            AddColAt(Index, "");
        }

        public void AddColAtStart(string InitValue)
        {
            AddColAt(0, InitValue);
        }

        public void AddColAtStart()
        {
            AddColAt(0, "");
        }


        public void RemoveCol()
        {
            try
            {
                if (ColExist(GetLastColIndex()))
                {
                    for (int I = 0; I < GetRowCount(); I++)
                    {
                        Content[I].RemoveAt(GetLastColIndex());
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

        public void RemoveColAt(int Index)
        {
            try
            {
                if (ColExist(Index))
                {
                    for (int I = 0; I < GetColCount(); I++)
                    {
                        Content[I].RemoveAt(Index);
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

        public void RemoveColAtStart()
        {
            RemoveColAt(0);
        }

        public void RemoveColRange(int Index, int Count)
        {
            try
            {
                if (ColExist(Index) && ColExist(Index + Count))
                {
                    for (int I = 0; I < Count; I++)
                    {
                        RemoveColAt(Index);
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


        public List<string> GetCol(int Index)
        {
            try
            {
                List<string> T = new();

                for (int I = 0; I < GetRowCount(); I++)
                {
                    if (RowExist(I))
                    {
                        T.Add(Content[I][Index]);
                    }
                    else
                    {
                        throw new RowDosentExistException();
                    }
                }

                return T;
            }
            catch
            {
                throw;
            }
        }

        public List<T> GetColAs<T>(int Index)
        {
            try
            {
                List<T> B = new();

                for (int I = 0; I < GetRowCount(); I++)
                {
                    if (RowExist(I))
                    {
                        B.Add((T)Convert.ChangeType(Content[I][Index], typeof(T)));
                    }
                    else
                    {
                        throw new RowDosentExistException();
                    }
                }

                return B;
            }
            catch
            {
                throw;
            }
        }

        public List<string> GetFirstCol()
        {
            return GetCol(0);
        }

        public List<T> GetFirstColAs<T>()
        {
            return GetColAs<T>(0);
        }

        public List<string> GetLastCol()
        {
            return GetCol(GetLastColIndex());
        }

        public List<T> GetLastColAs<T>()
        {
            return GetColAs<T>(GetLastColIndex());
        }


        public void SetCol(int Index, string Value)
        {
            try
            {
                if (ColExist(Index))
                {
                    for (int I = 0; I < GetRowCount(); I++)
                    {
                        Content[I][Index] = Value;
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

        public void SetCol(int Index, List<string> Values)
        {
            try
            {
                if (!ColExist(Index))
                {
                    throw new ColDosentExistException();
                }

                if (Values.Count == GetRowCount())
                {
                    for (int I = 0; I < GetRowCount(); I++)
                    {
                        Content[I][Index] = Values[I];
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

        public void SetFirstCol(string Value)
        {
            SetCol(0, Value);
        }

        public void SetFirstCol(List<string> Values)
        {
            SetCol(0, Values);
        }

        public void SetLastCol(string Value)
        {
            SetCol(GetLastColIndex(), Value);
        }

        public void SetLastCol(List<string> Values)
        {
            SetCol(GetLastColIndex(), Values);
        }


        public void SwapCol(int Index1, int Index2)
        {
            try
            {
                if (ColExist(Index1) && ColExist(Index2))
                {
                    for (int I = 0; I < GetRowCount(); I++)
                    {
                        SwapCell(I, Index1, I, Index2);
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


        public void MoveCol(int Index, int NewIndex)
        {
            try
            {
                if (ColExist(Index) && ColExist(NewIndex))
                {
                    if (Index < NewIndex)
                    {
                        for (int I = Index; I < NewIndex; I++)
                        {
                            for (int J = 0; J < GetRowCount(); J++)
                            {
                                SwapCell(J, I + 1, J, I);
                            }
                        }
                    }

                    if (Index > NewIndex)
                    {
                        for (int I = NewIndex; I < Index; I++)
                        {
                            for (int J = 0; J < GetRowCount(); J++)
                            {
                                SwapCell(J, I + 1, J, I);
                            }
                        }
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

        public void MoveColToStart(int Index)
        {
            MoveCol(Index, 0);
        }

        public void MoveColToEnd(int Index)
        {
            MoveCol(Index, GetLastColIndex());
        }


        public void DuplicateCol(int Index, int NewIndex)
        {
            try
            {
                if (ColExist(Index))
                {
                    AddColAt(NewIndex);

                    for (int I = 0; I < GetRowCount(); I++)
                    {
                        SetCell(I, NewIndex, GetCell(I, Index));
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


        public bool ColContains(int Index, string Value)
        {
            try
            {
                if (ColExist(Index))
                {
                    for (int I = 0; I < GetRowCount(); I++)
                    {
                        if (GetCell(I, Index).Contains(Value))
                        {
                            return true;
                        }
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

            return false;
        }

        public int ColIndexOf(int Index, string Value)
        {
            return ColIndexOf(Index, Value, 0);
        }

        public int ColIndexOf(int Index, string Value, int Start)
        {
            try
            {
                if (!ColExist(Index))
                {
                    throw new ColDosentExistException();
                }

                if (!CellExist(Start, Index))
                {
                    throw new CellDosentExistException();
                }

                for (int I = Start; I < GetRowCount(); I++)
                {
                    if (GetCell(I, Index).Contains(Value))
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

        public int ColLastIndexOf(int Index, string Value)
        {
            try
            {
                if (ColExist(Index))
                {
                    for (int I = GetLastRowIndex(); I >= 0; I++)
                    {
                        if (GetCell(I, Index).Contains(Value))
                        {
                            return I;
                        }
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

            return -1;
        }


        public int GetColCount()
        {
            return Content[0].Count();
        }

        public int GetFirstColIndex()
        {
            return 0;
        }

        public int GetLastColIndex()
        {
            return GetColCount() - 1;
        }


        public bool ColExist(int Col)
        {
            return Col >= 0 && Col < Content[0].Count();
        }

        public bool ColCanExist(int Col)
        {
            return Col >= 0 && Col <= Content[0].Count();
        }
    }
}
