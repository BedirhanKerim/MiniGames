using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Match3Game
{
    public class Block : MonoBehaviour, IInteractable
    {
        public CubeTypes cubeType;
        public Vector2Int gridIndex;
        public Vector3 target;

        public virtual void Interact() { }

        public void MoveToTarget(float arriveTime)
        {
            transform.DOKill(); 
            transform.DOMove(target, arriveTime)
                .SetEase(Ease.OutBounce);
        }

        public virtual void UpdateSortingOrder() { }

        public virtual void DestroyFunc(float time = 0) { }
    }
}
