using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject MainCamera;
    public float strafeSpeed = 4f;
    public float moveSpeed = 6f;
    public float ZoomSpeed = 25f;
    public float panSpeed = 1.0f;

    public float speedH = 2.0f;
    public float speedV = 4.0f;
    private float yaw = 0.0f;
    private float pitch = 0.0f;

    private Vector3 lastPosition;

    public float smooth = 20.0F;

    // Use this for initialization
    void Awake()
    {
        yaw = MainCamera.transform.eulerAngles.y;
        pitch = MainCamera.transform.eulerAngles.x;
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        //WSAD keys, RF 
        if (Input.GetKey(KeyCode.D))
            MainCamera.transform.Translate(Vector3.right*strafeSpeed*Time.deltaTime);
        if (Input.GetKey(KeyCode.A))
            MainCamera.transform.Translate(-Vector3.right*strafeSpeed*Time.deltaTime);
        if (Input.GetKey(KeyCode.W))
            MainCamera.transform.Translate(Vector3.forward*moveSpeed*Time.deltaTime);
        if (Input.GetKey(KeyCode.S))
            MainCamera.transform.Translate(-Vector3.forward*moveSpeed*Time.deltaTime);
        if (Input.GetKey(KeyCode.R))
            MainCamera.transform.Translate(Vector3.up*moveSpeed*Time.deltaTime);
        if (Input.GetKey(KeyCode.F))
            MainCamera.transform.Translate(-Vector3.up*moveSpeed*Time.deltaTime);
        //mouse scroll
        if (Input.GetAxis("Mouse ScrollWheel") > 0) // forward
        {
            MainCamera.transform.Translate(Vector3.forward*ZoomSpeed*Time.deltaTime);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0) // back
        {
            MainCamera.transform.Translate(-Vector3.forward*ZoomSpeed*Time.deltaTime);
        }

        //rotate
        if (Input.GetMouseButton(1)) //RMB
        {
            yaw += speedH*Input.GetAxis("Mouse X");
            pitch -= speedV*Input.GetAxis("Mouse Y");
            Quaternion target = Quaternion.Euler(pitch, yaw, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime*smooth);
        }

        //Paning

            if (Input.GetMouseButtonDown(0))
            {
                lastPosition = Input.mousePosition;
                Debug.Log("LMB");
            }

            if (Input.GetMouseButton(0))
            {
                Vector3 delta = Input.mousePosition - lastPosition;
                transform.Translate(delta.x*panSpeed*Time.deltaTime, delta.y*panSpeed*Time.deltaTime, 0);
                lastPosition = Input.mousePosition;
            }
        }
    }



