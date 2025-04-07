using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3Game
{
  
        public enum BlockTypes
        {
            Cube,
            Rocket,
        }

        public enum CubeTypes
        {
            Red,
            Green,
            Yellow,
            Purple,
            Blue,
            Rocket,
            Empty
        }

        public enum GameState
        {
            Playing,
            Paused

        }
    
        public enum RocketDirection
        {
            Vertical,
            Horizontal
        }
}