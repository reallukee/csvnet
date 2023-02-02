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
//  Descrizione: Exception
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
    public class TableIsInvalidException : Exception
    {
        public TableIsInvalidException() : base()
        {
            Message_ = "Table is Invalid!";
        }

        public TableIsInvalidException(string Message) : base(Message)
        {
            Message_ = Message;
        }

        private string Message_;

        public override string Message
        {
            get
            {
                return Message_;
            }
        }
    }


    public class CantValidateTableException : Exception
    {
        public CantValidateTableException() : base()
        {
            Message_ = "Can't Validate Table!";
        }

        public CantValidateTableException(string Message) : base(Message)
        {
            Message_ = Message;
        }

        private string Message_;

        public override string Message
        {
            get
            {
                return Message_;
            }
        }
    }


    public class RowCantExistException : Exception
    {
        public RowCantExistException() : base()
        {
            Message_ = "Row Can't Exist!";
        }

        public RowCantExistException(string Message) : base(Message)
        {
            Message_ = Message;
        }

        private string Message_;

        public override string Message
        {
            get
            {
                return Message_;
            }
        }
    }


    public class RowDosentExistException : Exception
    {
        public RowDosentExistException() : base()
        {
            Message_ = "Row Dosen't Exist!";
        }

        public RowDosentExistException(string Message) : base(Message)
        {
            Message_ = Message;
        }

        private string Message_;

        public override string Message
        {
            get
            {
                return Message_;
            }
        }
    }


    public class ColCantExistException : Exception
    {
        public ColCantExistException() : base()
        {
            Message_ = "Col Can't Exist!";
        }

        public ColCantExistException(string Message) : base(Message)
        {
            Message_ = Message;
        }

        private string Message_;

        public override string Message
        {
            get
            {
                return Message_;
            }
        }
    }


    public class ColDosentExistException : Exception
    {
        public ColDosentExistException() : base()
        {
            Message_ = "Col Dosen't Exist!";
        }

        public ColDosentExistException(string Message) : base(Message)
        {
            Message_ = Message;
        }

        private string Message_;

        public override string Message
        {
            get
            {
                return Message_;
            }
        }
    }


    public class CellCantExistException : Exception
    {
        public CellCantExistException() : base()
        {
            Message_ = "Cell Can't Exist!";
        }

        public CellCantExistException(string Message) : base(Message)
        {
            Message_ = Message;
        }

        private string Message_;

        public override string Message
        {
            get
            {
                return Message_;
            }
        }
    }


    public class CellDosentExistException : Exception
    {
        public CellDosentExistException() : base()
        {
            Message_ = "Cell Dosen't Exist!";
        }

        public CellDosentExistException(string Message) : base(Message)
        {
            Message_ = Message;
        }

        private string Message_;

        public override string Message
        {
            get
            {
                return Message_;
            }
        }
    }
}
