using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LatarkaOnOff : MonoBehaviour
{
    public Light MyFlashlight;
	
	void ToggleFlashlight ()
	{
	    MyFlashlight.enabled= !MyFlashlight.enabled;
	}
}
