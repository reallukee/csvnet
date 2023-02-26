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
//  Descrizione: Core
//               Permette la Gestione delle Eccezioni
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
        private List<List<string>> Content;


        public CSVDocument()
        {
            Content = new() { new() };
        }

        public CSVDocument(int Rows, int Cols)
        {
            Content = new() { new() };

            Initialize(Rows, Cols);
        }

        public CSVDocument(string FileName, char Separator)
        {
            Content = new() { new() };

            Load(FileName, Separator);
        }

        public CSVDocument(string FileName)
        {
            Content = new() { new() };

            Load(FileName);
        }

        public CSVDocument(string[] Content, char Separator)
        {
            this.Content = new() { new() };

            Load(Content, Separator);
        }

        public CSVDocument(string[] Content)
        {
            this.Content = new() { new() };

            Load(Content);
        }


        public void Initialize(int Rows, int Cols)
        {
            try
            {
                Content.Clear();

                for (int Y = 0; Y < Rows; Y++)
                {
                    List<string> T = new();

                    for (int X = 0; X < Cols; X++)
                    {
                        T.Add("");
                    }

                    Content.Add(T);
                }
            }
            catch
            {
                throw;
            }
        }

        public void Unload()
        {
            try
            {
                Content.Clear();
            }
            catch
            {
                throw;
            }
        }


        public void Load(string FileName, char Separator)
        {
            try
            {
                Content.Clear();

                string[] FileText = File.ReadAllLines(FileName);

                foreach (string FileLine in FileText)
                {
                    List<string> T = new();
                    bool Protected = false;
                    string Field = "";

                    for (int I = 0; I < FileLine.Length; I++)
                    {
                        if (FileLine[I] == Breaker)
                        {
                            Protected = !Protected;
                        }

                        if (FileLine[I] == Separator)
                        {
                            if (Protected)
                            {
                                Field += FileLine[I];
                            }
                            else
                            {
                                T.Add(Field);
                                Field = "";
                            }
                        }
                        else if (I == FileLine.Length - 1)
                        {
                            Field += FileLine[I];
                            T.Add(Field);
                        }
                        else
                        {
                            Field += FileLine[I];
                        }
                    }

                    this.Content.Add(T);
                }

                if (AutoVerification)
                {
                    if (!Verify())
                    {
                        throw new TableIsInvalidException();
                    }
                }

                if (AutoValidation)
                {
                    if (!Validate())
                    {
                        throw new CantValidateTableException();
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public void Load(string FileName)
        {
            Load(FileName, Separator);
        }

        public void Load(string[] Content, char Separator)
        {
            try
            {
                this.Content.Clear();

                foreach (string FileLine in Content)
                {
                    List<string> T = new();
                    bool Protected = false;
                    string Field = "";

                    for (int I = 0; I < FileLine.Length; I++)
                    {
                        if (FileLine[I] == Breaker)
                        {
                            Protected = !Protected;
                        }

                        if (FileLine[I] == Separator)
                        {
                            if (Protected)
                            {
                                Field += FileLine[I];
                            }
                            else
                            {
                                T.Add(Field);
                                Field = "";
                            }
                        }
                        else if (I == FileLine.Length - 1)
                        {
                            Field += FileLine[I];
                            T.Add(Field);
                        }
                        else
                        {
                            Field += FileLine[I];
                        }
                    }

                    this.Content.Add(T);
                }

                if (AutoVerification)
                {
                    if (!Verify())
                    {
                        throw new TableIsInvalidException();
                    }
                }

                if (AutoValidation)
                {
                    if (!Validate())
                    {
                        throw new CantValidateTableException();
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public void Load(string[] Content)
        {
            Load(Content, Separator);
        }


        public void Save(string FileName, char Separator)
        {
            try
            {
                if (AutoVerification)
                {
                    if (!Verify())
                    {
                        throw new TableIsInvalidException();
                    }
                }

                if (AutoValidation)
                {
                    if (!Validate())
                    {
                        throw new CantValidateTableException();
                    }
                }

                string[] FileText = new string[RowCount];

                for (int Y = 0; Y < RowCount; Y++)
                {
                    string T = "";

                    for (int X = 0; X < ColCount; X++)
                    {
                        T += Content[Y][X] + Separator;
                    }

                    FileText[Y] = T.Substring(0, T.Length - 1);
                }

                File.WriteAllLines(FileName, FileText);
            }
            catch
            {
                throw;
            }
        }

        public void Save(string FileName)
        {
            Save(FileName, Separator);
        }

        public void Save(ref string[] Content, char Separator)
        {
            try
            {
                if (AutoVerification)
                {
                    if (!Verify())
                    {
                        throw new TableIsInvalidException();
                    }
                }

                if (AutoValidation)
                {
                    if (!Validate())
                    {
                        throw new CantValidateTableException();
                    }
                }

                Content = new string[RowCount];

                for (int Y = 0; Y < RowCount; Y++)
                {
                    string T = "";

                    for (int X = 0; X < ColCount; X++)
                    {
                        T += this.Content[Y][X] + Separator;
                    }

                    Content[Y] = T.Substring(0, T.Length - 1);
                }
            }
            catch
            {
                throw;
            }
        }

        public void Save(ref string[] Content)
        {
            Save(ref Content, Separator);
        }


        public bool Verify()
        {
            try
            {
                int T = 0;

                for (int I = 0; I < RowCount; I++)
                {
                    if (Content[I].Count() > T)
                    {
                        T = Content[I].Count();
                    }
                }

                for (int I = 0; I < RowCount; I++)
                {
                    if (Content[I].Count() != T)
                    {
                        return false;
                    }
                }
            }
            catch
            {
                throw;
            }

            return true;
        }

        public bool Validate()
        {
            try
            {
                int T = 0;

                for (int I = 0; I < RowCount; I++)
                {
                    if (Content[I].Count() > T)
                    {
                        T = Content[I].Count();
                    }
                }

                for (int I = 0; I < RowCount; I++)
                {
                    while (Content[I].Count != T)
                    {
                        if (ColCanExist(Content[I].Count))
                        {
                            Content[I].Add("");
                        }
                    }
                }
            }
            catch
            {
                throw;
            }

            return true;
        }


        private bool AutoVerification_ = true;

        public bool AutoVerification
        {
            get => AutoVerification_;
            set => AutoVerification_ = value;
        }


        private bool AutoValidation_ = true;

        public bool AutoValidation
        {
            get => AutoValidation_;
            set => AutoValidation_ = value;
        }


        private static char Separator_ = ';';

        public char Separator
        {
            get => Separator_;
            set => Separator_ = value;
        }


        private static char Breaker_ = '"';

        public char Breaker
        {
            get => Breaker_;
            set => Breaker_ = value;
        }


        private static readonly int MaxRowCount = 512;
        private static readonly int MaxColCount = 512;


        public bool IsEmpty
        {
            get => CellCount == 0;
        }


        public string ToString(char Separator)
        {
            string Content = "";

            for (int Y = 0; Y < RowCount; Y++)
            {
                string T = "";

                for (int X = 0; X < ColCount; X++)
                {
                    T += this.Content[Y][X] + Separator;
                }

                Content += T.Substring(0, T.Length - 1) + "\n";
            }

            return Content;
        }

        public override string ToString()
        {
            return ToString(Separator);
        }

        public override bool Equals(object Obj)
        {
            if (Obj.GetType() == typeof(CSVDocument))
            {
                return ToString() == Obj.ToString();
            }

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
