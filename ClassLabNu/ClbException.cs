﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLabNu
{
    public class ClbException : Exception
    {
        public ClbException(string mensagem)
            : base(mensagem)
        {
        }
    }
}
