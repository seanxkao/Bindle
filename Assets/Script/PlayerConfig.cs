using UnityEngine;
using System.Collections;

[System.Serializable]

public class PlayerConfig
{
    public string name;
    public bool enable;
    public bool inputType;      //true for keyboard, false for controller
    public string joystick;
    public KeyCode keyUp;
    public KeyCode keyDown;
    public KeyCode keyLeft;
    public KeyCode keyRight;

    public PlayerConfig(){
        enable = true;
        name = "Nameless";
        inputType = true;
        keyUp = KeyCode.None;
        keyDown = KeyCode.None;
        keyLeft = KeyCode.None;
        keyRight = KeyCode.None;
        joystick = "Joystick1";
    }
}
