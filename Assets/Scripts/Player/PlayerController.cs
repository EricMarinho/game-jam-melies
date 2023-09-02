using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{

    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent (typeof(CapsuleCollider2D))]
    [RequireComponent(typeof(MovementHandler))]
    [RequireComponent(typeof(InteractionHandler))]
    [RequireComponent(typeof(CollisionHandler))]

    public class PlayerController : MonoBehaviour
    {

        #region Singleton
        public static PlayerController Instance { get; private set; }
        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }
        #endregion

        [SerializeField] private PlayerData _data;
        [SerializeField] private MovementHandler _movementHandler;
        [SerializeField] private InteractionHandler _interactionHandler;
        public GameObject currentInteractingObject { get; private set; }
        public GameObject currentGrabbedObject { get; private set; }

        public void MovePlayer(Vector3 movementPosition)
        {
            _movementHandler.MovePlayer(movementPosition, _data.speed * Time.deltaTime);
        }

        public void SetCurrentInteractingObject(GameObject currentObject)
        {
            currentInteractingObject = currentObject;
        }

        public void SetCurrentGrabbedObject(GameObject currentObject)
        {
            currentGrabbedObject = currentObject;
        }

        public void EnablePlayerInteraction()
        {
            _interactionHandler.enabled = true;
        }

        public void DisablePlayerInteraction()
        {
            _interactionHandler.enabled = false;
        }
    }
}