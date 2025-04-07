using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Match3Game
{
    public class GameEventManager : Singleton<GameEventManager>
    {//GameManager
        public event UnityAction<int> OnScoreChanged;
        //SpawnManager
        public event UnityAction<CubeTypes , Vector3 > OnSpawnCubeCrackParticle;
        public event Func<Transform> OnSpawnRandomBlockCube;
        public event Func<Transform> OnSpawnBlockRocket;
//GridManager
        public event Func<Block[,]> OnRequestAllBlocks;
        //NeighbourManager
        public event Func<Vector2Int, CubeTypes, List<Block>> OnFindConnectedCubes;
        public event Func<Vector2Int, List<Vector2Int>> OnFindHorizontalBlocks;
        public event Func<Vector2Int, List<Vector2Int>> OnFindVerticalBlocks;
        
        //FillManager
        public event UnityAction<BlockTypes, Vector2Int> OnFillOnlyOneBlock;
        public event UnityAction OnFill;
        //FallManager
        public event UnityAction OnFall;

        public  void ScoreChanged(int arg0)
        {
            OnScoreChanged?.Invoke(arg0);
        }

        public  Block[,] RequestAllBlocks()
        {
          return  OnRequestAllBlocks?.Invoke();
        }

        public  Transform SpawnRandomBlockCube()
        {
          return  OnSpawnRandomBlockCube?.Invoke();
        }

        public  Transform SpawnBlockRocket()
        {
          return  OnSpawnBlockRocket?.Invoke();
        }

        public  void SpawnCubeCrackParticle(CubeTypes colorType, Vector3 spawnPosition)
        {
            OnSpawnCubeCrackParticle?.Invoke( colorType,  spawnPosition);
        }

        public  List<Block> FindConnectedCubes(Vector2Int arg1, CubeTypes arg2)
        {
          return  OnFindConnectedCubes?.Invoke(arg1, arg2);
        }

        public List<Vector2Int> FindHorizontalBlocks(Vector2Int arg)
        {
          return  OnFindHorizontalBlocks?.Invoke(arg);
        }

        public List<Vector2Int> FindVerticalBlocks(Vector2Int arg)
        {
          return  OnFindVerticalBlocks?.Invoke(arg);
        }
        public void FillOnlyOneBlock(BlockTypes blockType, Vector2Int gridIndex)
        {
          OnFillOnlyOneBlock?.Invoke(blockType, gridIndex);
        }
        public void Fill()
        {
          OnFill?.Invoke();
        }
        public void Fall()
        {
          OnFall?.Invoke();
        }
    }
}