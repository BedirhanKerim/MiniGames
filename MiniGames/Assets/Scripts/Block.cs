using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Match3Game
{
    public class Block : MonoBehaviour, IInteractable
    {
        //[SerializeField] protected Vector2Int  gridIndex;

        public CubeTypes cubeType;
        public Vector2Int  gridIndex;
        public Vector3 target;

        public virtual void Interact()
        {

        }
        public void MoveToTarget(float arriveTime)
        {
            DOTween.Kill(transform);
            transform.DOKill();
            transform.DOMove(target, arriveTime).SetEase(Ease.OutBounce).OnComplete(() => { });
        }

        public virtual void UpdateSortingOrder()
        {
        }
    }
}
