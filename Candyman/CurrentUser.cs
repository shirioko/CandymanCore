using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Candyman
{
    public class CurrentUser
    {
        public int userId { get; set; }
        public int lives { get; set; }
        public int timeToNextRegeneration { get; set; }
        public int gold { get; set; }
        public string[] unlockedBoosters { get; set; }
        public bool soundFx { get; set; }
        public bool soundMusic { get; set; }
        public int maxLives { get; set; }
        public bool immortal { get; set; }
        public bool mobileConnected { get; set; }
        public string currency { get; set; }
        public string altCurrency { get; set; }
        public bool preAuth { get; set; }
    }
}
