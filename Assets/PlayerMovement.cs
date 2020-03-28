using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float lookSpeed = 3;
    private Vector2 rotation = Vector2.zero;
    private Rigidbody rb;
    public float moveSpeed = 5f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();

    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Look();
        if(Input.GetKey(KeyCode.W)){
            //rb.AddForce(transform.forward * moveSpeed);
            rb.MovePosition(transform.position + transform.forward * moveSpeed * Time.fixedDeltaTime);

        }
        if (Input.GetKey(KeyCode.S))
        {
            //rb.AddForce(-transform.forward * moveSpeed);
            rb.MovePosition(transform.position + -transform.forward * moveSpeed * Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.MovePosition(transform.position + transform.right * moveSpeed * Time.fixedDeltaTime);
            //rb.AddForce(transform.right * moveSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.MovePosition(transform.position + -transform.right * moveSpeed * Time.fixedDeltaTime);
            //rb.AddForce(-transform.right * moveSpeed);
        }
    }
    public void Look() // Look rotation (UP down is Camera) (Left right is Transform rotation)
    {
        rotation.y += Input.GetAxis("Mouse X");
        rotation.x += -Input.GetAxis("Mouse Y");
        rotation.x = Mathf.Clamp(rotation.x, -15f, 15f);
        transform.eulerAngles = new Vector2(0, rotation.y) * lookSpeed;
        Camera.main.transform.localRotation = Quaternion.Euler(rotation.x * lookSpeed, 0, 0);
    }
}
