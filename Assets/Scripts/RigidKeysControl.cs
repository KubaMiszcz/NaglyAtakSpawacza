using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidKeysControl : MonoBehaviour {

    //OCS- object coordinate system
    public GameObject S4OCS,S3OCS,S2OCS,S1OCS;
    public float speed = 25f;
    // Use this for initialization
    void Start()
    {
        //S1OCS = GameObject.Find("S1OCS");
        //S2OCS = GameObject.Find("S2OCS");
        //S3OCS = GameObject.Find("S3OCS");
        //S4OCS = GameObject.Find("S4OCS");
    }

    // Update is called once per frame
    void Update()
    {
        //S1
        if (Input.GetKey(KeyCode.Y))
            S1OCS.transform.Rotate(Vector3.up * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.U))
            S1OCS.transform.Rotate(-Vector3.up * speed * Time.deltaTime);
        
        //S2
        if (Input.GetKey(KeyCode.H))
            S2OCS.transform.Rotate(Vector3.forward * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.J))
            S2OCS.transform.Rotate(-Vector3.forward * speed * Time.deltaTime);

        //S3
        if (Input.GetKey(KeyCode.N))
            S3OCS.transform.Rotate(Vector3.forward * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.M))
            S3OCS.transform.Rotate(-Vector3.forward * speed * Time.deltaTime);
        //S4
        //S4OCS.transform.eulerAngles = (new Vector3(S3OCS.transform.eulerAngles.x, S3OCS.transform.eulerAngles.y, 0));
        //if (Input.GetKey(KeyCode.R))
        //    S4OCS.transform.Rotate(Vector3.forward * speed * Time.deltaTime);
        //if (Input.GetKey(KeyCode.F))
        //    S4OCS.transform.Rotate(-Vector3.forward * speed * Time.deltaTime);
    }
}
