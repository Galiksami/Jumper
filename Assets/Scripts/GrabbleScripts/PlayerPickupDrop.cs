using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickupDrop : MonoBehaviour 
{

    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private LayerMask pickUpLayerMask;
    [SerializeField] private Transform objectGrabPointTransform;

    private ObjectGrabbable objectGrabbable;
    
       
    private void Update() {
        if (Input.GetKeyDown(KeyCode.E))  {
            if (objectGrabbable ==  null) {
                // Not carrying an object, try to grab
                float pickUpDistance = 10f;
                float raycastStartHeight = playerCameraTransform.localScale.y * 0.1f;


                if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickUpDistance, pickUpLayerMask))

                    if (raycastHit.transform.TryGetComponent(out objectGrabbable))
                    {
                        objectGrabbable.Grab(objectGrabPointTransform);
                        Debug.Log(objectGrabbable);
                    }

            } else {

                    objectGrabbable.Drop();
                    objectGrabbable = null;
            }           
        }   
    }   
}
