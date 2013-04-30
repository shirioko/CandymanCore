using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Candyman
{
    public class LevelData
    {
        public string protocolVersion { get; set; }
        public int numberOfColours { get; set; }
        public int pepperCandyExplosionTurns { get; set; }
        public int[] scoreTargets { get; set; }
        public string gameModeName { get; set; }
        public int pepperCandySpawn { get; set; }
        public int licoriceMax { get; set; }
        public int randomSeed { get; set; }
        public int[][][] portals { get; set; }
        public int[][] tileMap { get; set; }
        public int moveLimit { get; set; }
        public int pepperCandyMax { get; set; }
        public int licoriceSpawn { get; set; }
    }
}
