using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3Game
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private Camera mainCam;
        [SerializeField] private bool canClick = true;
    

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && canClick)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y); // Z'yi at

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if (hit.collider != null)
            {
                BlockCube clickedBlock = hit.collider.GetComponent<BlockCube>();
                if (clickedBlock != null)
                {
                    clickedBlock.Interact();
                }
            }
        }

    }
  
    private void EnableClicking()
    {
        
            canClick = true;
          
    }
    private void DisableClicking()
    {
        canClick = false;
    }
}
}