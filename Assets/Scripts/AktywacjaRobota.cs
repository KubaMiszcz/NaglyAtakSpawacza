using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AktywacjaRobota : MonoBehaviour
{
    public GameObject targetRobot;
    public String RobotName = "Robot...";
    public bool State = true;
    public GameObject Button;
    public ScriptableObject Keycontrol;
    // Use this for initialization
    
    
    public void SwitchControl()
    {
        if (State)
        {
            Button.GetComponentInChildren<Text>().text = "Aktywuj " + RobotName;
            State = !State;
            targetRobot.SendMessage("SwitchControl",State);
        }
        else
        {
            Button.GetComponentInChildren<Text>().text = "Deaktywuj " + RobotName;
            State = !State;
            targetRobot.SendMessage("SwitchControl", State);
        }
    }
}
