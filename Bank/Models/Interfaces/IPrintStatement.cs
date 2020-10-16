using System;
using System.Collections.Generic;

namespace Bank.Models.Interfaces
{
    public interface IPrintStatement
    {
        public string Print(List<IInteraction> history);

    }
}
