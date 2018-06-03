using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollideWithMagnet : MonoBehaviour
{
    public Canvas MessageTitle;
    public bool MagnetReady;
    public bool MagnetOn;
    public Toggle magnetSwitch;
    public Transform RangeMagnet;
    public Transform Magnet;
    public float thrustMax;
    public float thrustMin;
    private Rigidbody rb;
    private Vector3 v;
    

    void Awake()
    {
        MessageTitle = GameObject.Find("MagnetMessage").GetComponent<Canvas>();
        MessageTitle.enabled=false;

        magnetSwitch = GameObject.Find("ToggleMagnesChwytaka").GetComponent<Toggle>();
        MagnetOn = magnetSwitch.isOn;
        MagnetReady = false;

        RangeMagnet = GameObject.Find("RangeCollider").transform;
        Magnet = GameObject.Find("MagnetCollider").transform;

        rb = this.GetComponent<Rigidbody>();
        thrustMax = 3000f;
        thrustMin = 0f;
    }

    void Start()
    {
        MessageTitle.enabled = false;
    }

    void Update()
    {
        MagnetOn = magnetSwitch.isOn;
        if (MagnetReady && MagnetOn)
        {
            LiftUp();
        }
        else Release();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.name == "RangeCollider")
        {
            MessageTitle.enabled = true;
            MagnetReady = true; 
        }
        if (other.tag == "dwarf")
        {
            MessageTitle.enabled = true;
            MagnetReady = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.name == "RangeCollider")
        {
            MessageTitle.enabled = false;
            MagnetReady = false;
        }
        if (other.tag == "dwarf")
        {
            MessageTitle.enabled = false;
            MagnetReady = false;
        }
        rb.angularVelocity = Vector3.zero;
        rb.velocity = Vector3.zero;
    }


    public void LiftUp()
    {

        v = RangeMagnet.position - rb.position;
        float scale = v.magnitude;
        rb.AddForce(v * thrustMax);
        rb.velocity *= 0.5f;
        rb.angularVelocity=Vector3.zero;
        //rb.velocity=Vector3.zero;
    }
    public void Release()
    {
        rb.AddForce(v * thrustMin);
        rb.angularVelocity*=0.9f;
        rb.velocity *=0.9f;
    }

    //void OnCollisionStay(Collision col)
    //{
    //    if (col.collider.name == "MagnetCollider")
    //    {
    //        MessageTitle.GetComponent<Canvas>().enabled = true;
    //        //  Debug.Log("magnescolided");
    //    }

    //}
    // void OnCollisionExit(Collision col)
    //{
    //    if (col.collider.name == "MagnetCollider")
    //    {
    //        MessageTitle.GetComponent<Canvas>().enabled = false;
    //    }
    //}
}
