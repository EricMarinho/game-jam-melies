using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Interaction
{
    [RequireComponent(typeof(BoxCollider2D))]

    public class InteractableHandler : MonoBehaviour, IInteractable
    {
        [SerializeField] private GameObject requiredObject;
        [SerializeField] private Transform pileToReturn;
        [SerializeField] private bool isActive = false; // Serialized for testing purpose

        public void Interact()
        {
            
            if (PlayerController.Instance.currentGrabbedObject == null || !isActive) return;

            if(PlayerController.Instance.currentGrabbedObject != requiredObject) { 
                Debug.Log("Not the required object");
                return;
            }

            Debug.Log("Released " + requiredObject.name);

            requiredObject.transform.SetParent(pileToReturn, false);
            PlayerController.Instance.SetCurrentGrabbedObject(null);
            requiredObject.SetActive(false);
        }
    }
}