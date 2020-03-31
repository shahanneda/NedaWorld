using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerHand : NetworkBehaviour
{
    PlayerManager playerManager;
    public GameObject pickUpLocation;
    private Transform worldTransform;
    void Start()
    {
        playerManager = GetComponent<PlayerManager>();
        worldTransform = GameObject.FindGameObjectWithTag("worldParent").transform;
    }

    void Update()
    {
        if (isLocalPlayer && Input.GetKeyDown(KeyCode.E)) { 
                if(pickUpLocation.transform.childCount > 0) {
                DropObjectsInHand(); 
                }else
                if(playerManager.currentObjectInCrosshairIsOn != null) {
                    PickUp(playerManager.currentObjectInCrosshairIsOn);
                }        
        }
    }

    private void DropObjectsInHand() {
        PlayerMoveableObject playerMoveableObject = pickUpLocation.GetComponentInChildren<PlayerMoveableObject>();
        playerMoveableObject.transform.SetParent(worldTransform);
        playerMoveableObject.DisablePickedUpMode();

    }
    public void PickUp(GameObject obj) {
        PlayerMoveableObject playerMoveableObject = obj.GetComponent<PlayerMoveableObject>();
        if(playerMoveableObject  == null) {
            return;
        }
        print("HERE");
        playerMoveableObject.EnablePickedUpMode();
        playerMoveableObject.transform.SetParent(pickUpLocation.transform);
        playerMoveableObject.transform.localPosition = new Vector3(0, 0, 0) ;
        playerMoveableObject.transform.localRotation = Quaternion.identity;
    }
}
