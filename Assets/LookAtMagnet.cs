using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMagnet : MonoBehaviour
{
    public GameObject Magnet;
	// Use this for initialization
	void Start () {
	    if (!Magnet)
	    {
            Magnet = GameObject.Find("MagnetCollider");
        }
		
	}
	
	// Update is called once per frame
	void Update ()
	{
        float damping= 100f;
        Transform target =Magnet.transform;

        var lookPos = target.position - transform.position;
       // lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
    }
}
