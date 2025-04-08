using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner
{
    public class PlayerRunner : MonoBehaviour
    {
        public float speed = 10f; // İleri hareket hızı
        public float swerveSpeed = 5f; // Sağa-sola hareket hızı
        public float maxSwerveAmount = 2f; // Maksimum sağ-sol hareket mesafesi

        private float lastFrameFingerPositionX;

        private float moveFactorX;

        //  [SerializeField] private Transform crowdMainObjTransform;
        private bool _bIsStarted = true;

        [SerializeField] private Transform fogMainObj;

        private void OnEnable()
        {
            GameEventManager.Instance.OnEndGame += EndGame;
        }

        private void OnDisable()
        {
            GameEventManager.Instance.OnEndGame -= EndGame;
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                lastFrameFingerPositionX = Input.mousePosition.x;
                if (!_bIsStarted)
                {
                    return; //  GameEventManager.Instance.LevelStart();
                }
            }
            else if (Input.GetMouseButton(0))
            {
                float deltaX = Input.mousePosition.x - lastFrameFingerPositionX;
                moveFactorX = deltaX * 0.01f;
                lastFrameFingerPositionX = Input.mousePosition.x;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                moveFactorX = 0f;
            }



            transform.position += Vector3.forward * speed * Time.deltaTime;
            fogMainObj.position = new Vector3(0, 0, transform.position.z + 70);
            float newX = transform.transform.position.x + moveFactorX * swerveSpeed;
            newX = Mathf.Clamp(newX, -maxSwerveAmount, maxSwerveAmount);

            transform.position =
                new Vector3(newX, transform.position.y, transform.position.z);
        }

        private void OnTriggerEnter(Collider other)
        {
            IInteractable interactable = other.GetComponent<IInteractable>();

            if (interactable != null)
            {
                interactable.Interact();
            }
        }

        private void EndGame()
        {
            _bIsStarted = false;
            gameObject.SetActive(false);
        }
    }
}