using CSVNet;

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


        /*
        static void ShowRow(ICSVRow Row)
        {
            foreach (string Cell in Row.ToList<string>())
            {
                Console.WriteLine(Cell);
            }
        }


        static void ShowCol(ICSVCol Col)
        {
            foreach (string Cell in Col.ToList<string>())
            {
                Console.WriteLine(Cell);
            }
        }
        */
    }
}
