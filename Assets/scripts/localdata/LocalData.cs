using System;
using System.Collections.Generic;

namespace localdata
{
    [Serializable]
    public class LocalData
    {
        public List<AuthData> users = new List<AuthData>();
    }
}