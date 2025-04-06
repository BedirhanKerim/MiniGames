using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3Game
{
    public class GameManager : Singleton<GameManager>
    {
        public GridManager gridManager;
        public SpawnManager spawnManager;
        public NeighbourManager neighbourManager;
    }
}