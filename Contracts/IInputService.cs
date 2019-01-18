using System;
using System.Collections.Generic;

namespace Contracts
{
    public interface IInputService
    {
        void ReadDataIn(string[] args);
        List<string> ReadFileData(string fileName);
        List<string> ReadUserData();
    }
}
