using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveableObject : MonoBehaviour
{
    public bool isPickedUpByPlayer = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnablePickedUpMode()
    {
        isPickedUpByPlayer = true;
        GetComponent<Collider>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
    }
    public void DisablePickedUpMode() {
        isPickedUpByPlayer = false;
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Collider>().enabled = true;
    }
}
