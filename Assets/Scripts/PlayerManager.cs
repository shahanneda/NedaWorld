using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private PlayerHand playerHand;
    public GameObject currentObjectInCrosshairIsOn;

    void Start()
    {
        playerHand = GetComponent<PlayerHand>();    
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        Physics.Raycast(ray, out hit);
        if (hit.collider != null) { 
            currentObjectInCrosshairIsOn = hit.collider.gameObject;
        }
        else {
            currentObjectInCrosshairIsOn = null; 
        }
    }
}
