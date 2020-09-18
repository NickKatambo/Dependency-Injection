using System;
using System.Collections.Generic;
using System.Text;

namespace CoreLibrary.Utilities
{
    public interface IDataAccess
    {
        void LoadData();
        void SaveData(string name);
    }
}
