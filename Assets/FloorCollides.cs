using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCollides : MonoBehaviour
{
    public GameObject RobotMagnes;
    private GameObject Hinge;


    // Use this for initialization
    void Awake()
    {
        RobotMagnes=GameObject.Find("RobotMkI");
        Hinge=GameObject.Find("");
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //void OnCollisionEnter(Collision col)
    //{
    //    //Debug.Log(col.collider.name+"\n");
    //    if (col.collider.name == "MagnetCollider")
    //    {
    //        Debug.Log("entr");
    //        //col.collider.attachedRigidbody.velocity = Vector3.zero;
    //        RobotMagnes.GetComponent<KeysControl>().enabled = false;
    //    }
    //}

    //void OnCollisionStay(Collision col)
    //{
    //    //Debug.Log(col.collider.name+"\n");
    //    if (col.collider.name=="MagnetCollider" )
    //    {
    //        Debug.Log("stay");
    //        //col.collider.attachedRigidbody.velocity = Vector3.zero;
    //        RobotMagnes.GetComponent<KeysControl>().enabled = false;
    //    }
    //}
    //void OnCollisionExit(Collision col)
    //{
    //    //Debug.Log(col.collider.name+"\n");
    //    if (col.collider.name == "MagnetCollider")
    //    {
    //        Debug.Log("ecit");
    //        RobotMagnes.GetComponent<KeysControl>().enabled = true;
    //    }
    //}


    void OnTriggerEnter(Collider col)
    {
        //Debug.Log(col.collider.name+"\n");
        if (col.name == "MagnetCollider")
        {
            Debug.Log("entr");
            //col.collider.attachedRigidbody.velocity = Vector3.zero;
            RobotMagnes.GetComponent<KeysControl>().enabled = false;
        }
    }

    void OnTriggerStay(Collider col)
    {
        //Debug.Log(col.collider.name+"\n");
        if (col.name == "MagnetCollider")
        {
            Debug.Log("stay");
            //col.collider.attachedRigidbody.velocity = Vector3.zero;
            RobotMagnes.GetComponent<KeysControl>().enabled = false;
        }

    }
    void OnTriggerExit(Collider col)
    {
        //Debug.Log(col.collider.name+"\n");
        if (col.name == "MagnetCollider")
        {
            Debug.Log("ecit");
            RobotMagnes.GetComponent<KeysControl>().enabled = true;
        }
    }
}
