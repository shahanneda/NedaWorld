using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class PlayerNetworkManager : NetworkBehaviour
{
    void Start()
    {
        if (!isLocalPlayer)
        {
            if (gameObject.GetComponentInChildren<Camera>() != null)
            {
                gameObject.GetComponentInChildren<Camera>().gameObject.SetActive(false);
            }
        }
        else
        {
            if (gameObject.GetComponentInChildren<Camera>() != null)
            {
                gameObject.GetComponentInChildren<Camera>().gameObject.SetActive(true);
            }
        }
    }

    void Update()
    {
        
    }
}
