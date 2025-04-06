using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using DG.Tweening;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class BlockCube : MonoBehaviour,IInteractable
{
    public Vector2 gridIndex;
    public Transform target;
    public bool canClick = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public  void MoveToTarget(float arriveTime)
    {
        DOTween.Kill(transform);
        transform.DOKill();
        transform.DOMove(target.position, arriveTime).SetEase(Ease.OutBounce).OnComplete(() =>
        {

        });
    }
    public  void UpdateSortingOrder()
    {
       
          var  mySpriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();
        mySpriteRenderer.sortingOrder = (int)gridIndex.y + 1;
    }
    
    public  void SetSortingOrder(int index)
    {
        var     mySpriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();

        mySpriteRenderer.sortingOrder = index;
    }

    public void Interact()
    {
        if (canClick)
        {
            
        }
    }
}
