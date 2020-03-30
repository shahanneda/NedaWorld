using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUserNameText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(Camera.main.transform.position);
        Quaternion targetRotation = Quaternion.LookRotation(Camera.main.transform.position - transform.position);
        transform.rotation = targetRotation; 


    }
}
