using System;
using System.Collections.Generic;

namespace Bank.Models.Interfaces
{
    public interface IPrintStatement
    {
        public List<string> Print(List<IInteraction> history);

    }
}
