using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchCameras : MonoBehaviour
{
    public GameObject MainCamera, Camera2nd;
    private GameObject MainCanvas, SecondCanvas;
    // Use this for initialization
    void Awake()
    {
        MainCamera = GameObject.Find("Main Camera");
        MainCanvas= MainCamera.transform.Find("CanvasMain").gameObject;
        Camera2nd = GameObject.Find("CameraPodawacz");
        SecondCanvas=Camera2nd.transform.Find("CanvasPodawacz").gameObject;
    }
    void Start()
    {
        MainCamera.GetComponent<Camera>().enabled = true;
        MainCanvas.SetActive(true);
        Camera2nd.GetComponent<Camera>().enabled = false;
        SecondCanvas.SetActive(false);
        
    }
    // Update is called once per frame
    public void SwitchCamera ()
	{
        MainCamera.GetComponent<Camera>().enabled = !MainCamera.GetComponent<Camera>().enabled;
        MainCanvas.SetActive(!MainCanvas.activeSelf);
        Camera2nd.GetComponent<Camera>().enabled = !Camera2nd.GetComponent<Camera>().enabled;
        SecondCanvas.SetActive(!SecondCanvas.activeSelf);

    }
}
