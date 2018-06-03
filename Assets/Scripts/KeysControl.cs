using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.UI;

public class KeysControl : MonoBehaviour {

    //OCS- object coordinate system
    public GameObject Target,S1OCS, S2OCS,S3OCS,S4OCS;
    public Toggle magnetSwitch, LatarkaSwitch;
    public String RobotName = "Robot...";
    public bool ControlEnable = true;
    public float speed = 25f;
    private GameObject S3end;
    public Text btnText;
    // Use this for initialization
    void Awake()
    {
        //S1OCS = GameObject.Find("S1OCS");
        //S2OCS = GameObject.Find("S2OCS");
        //S3OCS = GameObject.Find("S3OCS");
        //S4OCS = GameObject.Find("S4OCS");
        S3end = GameObject.Find("S3end");
        magnetSwitch=GameObject.Find("ToggleMagnesChwytaka").GetComponent<Toggle>();
        LatarkaSwitch = GameObject.Find("ToggleLatarka").GetComponent<Toggle>();
        btnText=GameObject.Find("btnChwytak").GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {


        if (ControlEnable)
        {
            if (Input.anyKey)
            {
                if (speed < 40f) speed *= 1.5f;
            }
            else
            {
                    speed = 1f;
            }
            //S1
            if (Input.GetKey(KeyCode.Y))
                S1OCS.transform.Rotate(-Vector3.up*speed*Time.deltaTime);
            if (Input.GetKey(KeyCode.H))
                S1OCS.transform.Rotate(Vector3.up*speed*Time.deltaTime);

            //S2
            if (Input.GetKey(KeyCode.U))
                S2OCS.transform.Rotate(Vector3.forward*speed*Time.deltaTime);
            if (Input.GetKey(KeyCode.J))
                S2OCS.transform.Rotate(-Vector3.forward*speed*Time.deltaTime);

            //S3
            if (Input.GetKey(KeyCode.I))
                S3OCS.transform.Rotate(Vector3.forward*speed*Time.deltaTime);
            if (Input.GetKey(KeyCode.K))
                S3OCS.transform.Rotate(-Vector3.forward*speed*Time.deltaTime);

            //if (Input.GetKey(KeyCode.R))
            //    S4OCS.transform.Rotate(Vector3.forward * speed * Time.deltaTime);
            //if (Input.GetKey(KeyCode.F))
            //    S4OCS.transform.Rotate(-Vector3.forward * speed * Time.deltaTime);

            //inne
            if (Input.GetKeyDown(KeyCode.Space))
                magnetSwitch.isOn = !magnetSwitch.isOn;

            if (Input.GetKeyDown(KeyCode.Alpha9))
                LatarkaSwitch.isOn = !LatarkaSwitch.isOn;

            //S4
            //S4OCS.transform.eulerAngles = (new Vector3(S3OCS.transform.eulerAngles.x, S3OCS.transform.eulerAngles.y, 0));
            //S4OCS.transform.position = S3end.transform.position;
            //ControlInverseKinematic();

        }

    }

    public void SwitchControl(bool state)
    {
        ControlEnable = state;
        if (ControlEnable)
        {
            btnText.text = "Deaktywuj Robo Chwytak";
        }
        else
        {
            btnText.GetComponent<Text>().text = "Aktywuj Robo Chwytak";
        }
    }
    public void SwitchControl()
    {
        if (ControlEnable)
        {
            ControlEnable=false;
            btnText.GetComponent<Text>().text = "Aktywuj Robo Chwytak";
        }
        else
        {
            ControlEnable = true;
            btnText.GetComponent<Text>().text = "Deaktywuj Robo Chwytak ";
        }
    }

    public float curAngleOX;
    public float curX,curY,curZ,th1,th2;
    public float speedKinInv;
    private float x2,y2,L1,L2,R;
    void ControlInverseKinematic()
    {
        speedKinInv = 10f;
#region dlugosci ramion TUTAJ LICZE
        float xb, yb, zb, xe, ye, ze;
        xb = S2OCS.transform.position.x;
        yb = S2OCS.transform.position.y;
        zb = S2OCS.transform.position.z;
        xe = S3OCS.transform.position.x;
        ye = S3OCS.transform.position.y;
        ze = S3OCS.transform.position.z;
        L1 = Mathf.Sqrt(Mathf.Pow(xe-xb, 2) + Mathf.Pow(ye-yb, 2)+ Mathf.Pow(ze - zb, 2));

        xb = S3OCS.transform.position.x;
        yb = S3OCS.transform.position.y;
        zb = S3OCS.transform.position.z;
        xe = S4OCS.transform.position.x;
        ye = S4OCS.transform.position.y;
        ze = S4OCS.transform.position.z;
        L2 = Mathf.Sqrt(Mathf.Pow(xe - xb, 2) + Mathf.Pow(ye - yb, 2) + Mathf.Pow(ze - zb, 2));
        #endregion

        //XXXXXXXXX
        if (Input.GetKey(KeyCode.LeftArrow))
            S1OCS.transform.Rotate(Vector3.up * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.RightArrow))
            S1OCS.transform.Rotate(-Vector3.up * speed * Time.deltaTime);

        //YYYYYYYYYY
        if (Input.GetKey(KeyCode.UpArrow))
            S2OCS.transform.Rotate(Vector3.forward * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.DownArrow))
            S2OCS.transform.Rotate(-Vector3.forward * speed * Time.deltaTime);


        curX = S2OCS.transform.position.x-S4OCS.transform.position.x;
        curY = S2OCS.transform.position.y - S4OCS.transform.position.y;
        curZ = S2OCS.transform.position.z - S4OCS.transform.position.z;
        curAngleOX = Mathf.Atan2(curX,curZ)*180/Mathf.PI; //kat obu ramion wzlgedem globalmnego UCS

        float R = Mathf.Sqrt(Mathf.Pow(x2, 2) + Mathf.Pow(y2, 2));
        th2 = Mathf.Acos((Mathf.Pow(x2, 2) + Mathf.Pow(y2, 2) - Mathf.Pow(L1, 2) - Mathf.Pow(L2, 2))/(2*L1*L2));
        th1 = Mathf.Atan(y2/x2) - Mathf.Asin(L2*Mathf.Sin(th2)/R);
        
        S2OCS.transform.eulerAngles = new Vector3(S2OCS.transform.eulerAngles.x, S2OCS.transform.eulerAngles.y,th1);
        S3OCS.transform.eulerAngles = new Vector3(S3OCS.transform.eulerAngles.x, S3OCS.transform.eulerAngles.y, th2);






        
        //S4
        S4OCS.transform.eulerAngles = (new Vector3(S3OCS.transform.eulerAngles.x, S3OCS.transform.eulerAngles.y, 0));
        //if (Input.GetKey(KeyCode.R))
        //    S4OCS.transform.Rotate(Vector3.forward * speed * Time.deltaTime);
        //if (Input.GetKey(KeyCode.F))
        //    S4OCS.transform.Rotate(-Vector3.forward * speed * Time.deltaTime);

        //inne
        if (Input.GetKeyDown(KeyCode.Space))
            magnetSwitch.isOn = !magnetSwitch.isOn;

        if (Input.GetKeyDown(KeyCode.L))
            LatarkaSwitch.isOn = !LatarkaSwitch.isOn;


    }




}
