using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleMagnet : MonoBehaviour
{
    private Toggle toggle;
	// Use this for initialization
	void Start ()
	{
	    toggle = this.GetComponent<Toggle>();
	}
	
	// Update is called once per frame
	void SwitchMagnet ()
	{
	    toggle.isOn = !toggle.isOn;
	}
}
