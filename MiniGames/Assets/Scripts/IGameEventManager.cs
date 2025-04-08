using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IGameEventManager
{
    public event UnityAction OnEndGame;
    public  void EndGame() { }
    public event UnityAction<int> OnScoreChanged;
    public  void CollectGold(int arg0) { }
    public event UnityAction<int> OnScoreChangedUI;
    public  void CollectGoldUI(int arg0) { }
    
}
