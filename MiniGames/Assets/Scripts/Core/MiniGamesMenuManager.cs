using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGamesMenuManager : MonoBehaviour
{
 public void OpenGameIndex(int buildIndex)
 {
  SceneLoader.Instance.OpenMiniGame(buildIndex);
 }
}
