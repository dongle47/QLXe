using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLXe
{
    static class Globals
    {
        public static int globalUserId { get; private set; }
        public static string globalName { get; private set; }
        public static int maxChoTrong { get; private set; }
        public static void setName(string name)
        {
            globalName = name;
        }
        public static void setGlobalUserId(int userId)
        {
            globalUserId = userId;
        }
        public static void setMaxChoTrong(int userId)
        {
            maxChoTrong = userId;
        }
    }
}
