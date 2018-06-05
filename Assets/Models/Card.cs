#region
using System.Collections.Generic;
#endregion

namespace UnityDemo.Models
{
    public struct Card
    {
        public Card(int no, bool isKwang)
        {
            No = no;
            IsKwang = isKwang;
        }

        public int No { get; private set; }

        public bool IsKwang { get; private set; }

        public override string ToString()
        {
            if (IsKwang)
                return $"{No}K";
            else
                return $"{No}";
        }
    }
}