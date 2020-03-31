using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerMoveableObject : NetworkBehaviour
{
    [SyncVar]
    public bool isPickedUpByPlayer;
        
    void Start()
    {
        
    }

    void Update()
    {
        if (isPickedUpByPlayer) { 
                GetComponent<Collider>().enabled = false;
                GetComponent<Rigidbody>().isKinematic = true;
        }else{  
                GetComponent<Collider>().enabled = true;
                GetComponent<Rigidbody>().isKinematic = false;
        }    
    }

    [ClientRpc]
    void RpcPickUpMode(bool state)
    {
        Debug.Log("Set Pick Up mode to " + state);
        isPickedUpByPlayer = state;
    }
    [Command]
    public void CmdPickUpMode(bool state) {
        Debug.Log("SET STATE FOR PICK UP MODE FROM COMMAND");
        isPickedUpByPlayer = state;
        RpcPickUpMode(state); 
    }

    public void EnablePickedUpMode() {
        if (isServer) { 
                RpcPickUpMode(true);
        }
        else {
            CmdPickUpMode(true); 
        }
    }
    public void DisablePickedUpMode() {
        if (isServer) { 
            RpcPickUpMode(false);
        }
        else {
            CmdPickUpMode(false); 
        }

    }

}
