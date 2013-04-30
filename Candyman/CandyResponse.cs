using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Candyman
{
    public class CandyResponse
    {
        public string levelData { get; set; }
        public long seed { get; set; }
        public CurrentUser currentUser { get; set; }
    }
}
