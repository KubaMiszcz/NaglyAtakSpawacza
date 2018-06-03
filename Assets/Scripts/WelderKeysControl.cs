using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WelderKeysControl : MonoBehaviour
{

    //OCS- object coordinate system
    public GameObject Target, S1OCS, S2OCS, S3OCS, S4OCS;
    public Toggle weldingSwitch;
    public String RobotName = "Robot...";
    public bool ControlEnable = true;
    public float speed = 25f;
    public Text btnText;
    // Use this for initialization
    void Awake()
    {
        //S1OCS = GameObject.Find("S1OCS");
        //S2OCS = GameObject.Find("S2OCS");
        //S3OCS = GameObject.Find("S3OCS");
        //S4OCS = GameObject.Find("S4OCS");
        weldingSwitch = GameObject.Find("ToggleSpawaj").GetComponent<Toggle>();
        btnText = GameObject.Find("btnSpawacz").GetComponentInChildren<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        if (ControlEnable)
        {

            //S1
            if (Input.GetKey(KeyCode.Y))
                S1OCS.transform.Rotate(-Vector3.up * speed * Time.deltaTime);
            if (Input.GetKey(KeyCode.H))
                S1OCS.transform.Rotate(Vector3.up * speed * Time.deltaTime);

            //S2
            if (Input.GetKey(KeyCode.U))
                S2OCS.transform.Rotate(-Vector3.forward * speed * Time.deltaTime);
            if (Input.GetKey(KeyCode.J))
                S2OCS.transform.Rotate(Vector3.forward * speed * Time.deltaTime);

            //S3
            if (Input.GetKey(KeyCode.I))
                S3OCS.transform.Rotate(-Vector3.forward * speed * Time.deltaTime);
            if (Input.GetKey(KeyCode.K))
                S3OCS.transform.Rotate(Vector3.forward * speed * Time.deltaTime);
            //S4
            //S4OCS.transform.eulerAngles = (new Vector3(S3OCS.transform.eulerAngles.x, S3OCS.transform.eulerAngles.y, 0));
            if (Input.GetKey(KeyCode.O))
                S4OCS.transform.Rotate(-Vector3.forward * speed * Time.deltaTime);
            if (Input.GetKey(KeyCode.L))
                S4OCS.transform.Rotate(Vector3.forward * speed * Time.deltaTime);

            //inne
            if (Input.GetKeyDown(KeyCode.Alpha0))
                weldingSwitch.isOn = !weldingSwitch.isOn;
        }
    }

    public void SwitchControl(bool state)
    {
        ControlEnable = state;
        if (ControlEnable)
        {
            btnText.text = "Deaktywuj Robo Spawacz";
        }
        else
        {
            btnText.GetComponent<Text>().text = "Aktywuj Robo Spawacz";
        }
    }
    public void SwitchControl()
    {
        if (ControlEnable)
        {
            ControlEnable = false;
            btnText.GetComponent<Text>().text = "Aktywuj Robo Spawacz";
        }
        else
        {
            ControlEnable = true;
            btnText.GetComponent<Text>().text = "Deaktywuj Robo Spawacz ";
        }
    }
}
