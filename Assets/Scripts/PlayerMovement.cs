using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;
public class PlayerMovement : NetworkBehaviour
{
    public float lookSpeed = 3;
    private Vector2 rotation = Vector2.zero;
    private Rigidbody rb;
    public float moveSpeed = 5f;
    public float jumpSpeed = 0.05f;
    private Text fpsText;
    private float hudRefreshRate = 1f;

    public Transform temp;
    void Start()
    {
        fpsText = GameObject.FindGameObjectWithTag("fpsCounter").GetComponent<Text>();
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
    }
    private float timer;
    void Update()
    {
        if (Time.unscaledTime > timer)
        {
            int fps = (int)(1f / Time.unscaledDeltaTime);
            fpsText.text = fps.ToString();
            timer = Time.unscaledTime + hudRefreshRate;
        }
    }

    private void FixedUpdate()
    {
        if(!isLocalPlayer){
            return;
        }
        Look();
        if(Input.GetKeyDown(KeyCode.Space)){
            rb.AddForce(transform.up * jumpSpeed, ForceMode.Impulse);
        }
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
