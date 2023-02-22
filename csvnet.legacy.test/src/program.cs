using CSVNet.Legacy;

namespace CSVNet.Test
{
    internal class Program
    {
        static CSVDocument Doc = new();


        static void Main(string[] Args)
        {
            string[] Content = new string[]
            {
                "Nome;Cognome;Città",
                "Luigi;Giallo;Mozzo",
                "Mario;Rossi;Torino",
                "Luigi;Verdi;Milano",
                "Franco;Blu;Firenze",
            };

            Doc.Load(Content);

            Doc.Unload();
        }


        static void TestGetCell(int Row, int Col)
        {
            Console.WriteLine(Doc.GetCell(Row, Col));
        }

        static void TestGetCellAs<T>(int Row, int Col)
        {
            Console.WriteLine(Doc.GetCellAs<T>(Row, Col));
        }


        static void TestSetCell(int Row, int Col, string Value)
        {
            Doc.SetCell(Row, Col, Value);
            TestGetCell(Row, Col);
        }


        static void TestSwapCell(int Row1, int Col1, int Row2, int Col2)
        {
            Console.WriteLine(Doc.GetCell(Row1, Col1));
            Console.WriteLine(Doc.GetCell(Row2, Col2));
            Doc.SwapCell(Row1, Col1, Row2, Col2);
            Console.WriteLine(Doc.GetCell(Row1, Col1));
            Console.WriteLine(Doc.GetCell(Row2, Col2));
        }


        static void TestGetCellCount()
        {
            Console.WriteLine(Doc.CellCount);
        }


        static void TestCellExist(int Row, int Col)
        {
            Console.WriteLine(Doc.CellExist(Row, Col));
        }

        static void TestCellCanExist(int Row, int Col)
        {
            Console.WriteLine(Doc.CellCanExist(Row, Col));
        }


        static void TestAddRow(string InitValue)
        {
            Doc.AddRow(InitValue);
            ShowRow(Doc.LastRowIndex);
        }

        static void TestAddRowAt(int Index, string InitValue)
        {
            Doc.AddRowAt(Index, InitValue);
            ShowRow(Index);
        }


        static void TestRemoveRow()
        {
            Doc.RemoveRow();
            ShowRow(Doc.LastRowIndex);
        }

        static void TestRemoveRowAt(int Index)
        {
            Doc.RemoveRowAt(Index);
            ShowRow(Index);
        }

        static void TestRemoveRowRange(int Index, int Count)
        {
            Doc.RemoveRowRange(Index, Count);
            ShowRow(Index);
        }


        static void TestSwapRow(int Row1, int Row2)
        {
            ShowRow(Row1);
            ShowRow(Row2);
            Doc.SwapRow(Row1, Row2);
            ShowRow(Row1);
            ShowRow(Row2);
        }


        static void TestMoveRow(int Index, int NewIndex)
        {
            ShowRow(Index);
            ShowRow(NewIndex);
            Doc.MoveRow(Index, NewIndex);
            ShowRow(Index);
            ShowRow(NewIndex);
        }


        static void TestDuplicateRow(int Index, int NewIndex)
        {
            Doc.DuplicateRow(Index, NewIndex);
            ShowRow(NewIndex);
        }


        static void TestAddCol(string InitValue)
        {
            Doc.AddCol(InitValue);
            ShowCol(Doc.LastColIndex);
        }

        static void TestAddColAt(int Index, string InitValue)
        {
            Doc.AddColAt(Index, InitValue);
            ShowCol(Index);
        }


        static void TestRemoveCol()
        {
            Doc.RemoveCol();
            ShowCol(Doc.LastColIndex);
        }

        static void TestRemoveColAt(int Index)
        {
            Doc.RemoveColAt(Index);
            ShowCol(Index);
        }

        static void TestRemoveColRange(int Index, int Count)
        {
            Doc.RemoveColRange(Index, Count);
            ShowCol(Index);
        }


        static void TestSwapCol(int Col1, int Col2)
        {
            ShowCol(Col1);
            ShowCol(Col2);
            Doc.SwapCol(Col1, Col2);
            ShowCol(Col1);
            ShowCol(Col2);
        }


        static void TestMoveCol(int Index, int NewIndex)
        {
            ShowCol(Index);
            ShowCol(NewIndex);
            Doc.MoveCol(Index, NewIndex);
            ShowCol(Index);
            ShowCol(NewIndex);
        }


        static void TestDuplicateCol(int Index, int NewIndex)
        {
            Doc.DuplicateCol(Index, NewIndex);
            ShowCol(NewIndex);
        }


        static void ShowRow(int Index)
        {
            List<string> T = Doc.GetRow(Index);

            foreach (string Str in T)
            {
                Console.WriteLine(Str);
            }
        }


        static void ShowCol(int Index)
        {
            List<string> T = Doc.GetCol(Index);

            foreach (string Str in T)
            {
                Console.WriteLine(Str);
            }
        }
    }
}
