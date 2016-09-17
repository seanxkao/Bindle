using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class PlayerConfigSetter : MonoBehaviour {
    public PlayerConfig config;

    public Toggle enableToggle;
    public Toggle inputToggle;
    public InputField nameInput;
    public GameObject keyboardPanel;
    public GameObject joystickPanel;
    public Button keyUpInput;
    public Button keyDownInput;
    public Button keyLeftInput;
    public Button keyRightInput;
    public Button joystickInput;
    public Slider redSlider;
    public Slider greenSlider;
    public Slider blueSlider;
    bool isReadingKey;

    void Awake() {
        isReadingKey = false;
        enableToggle.onValueChanged.AddListener(setEnable);
        nameInput.onEndEdit.AddListener(setName);
        inputToggle.onValueChanged.AddListener(setInputType);
        keyUpInput.onClick.AddListener(setKeyUp);
        keyDownInput.onClick.AddListener(setKeyDown);
        keyLeftInput.onClick.AddListener(setKeyLeft);
        keyRightInput.onClick.AddListener(setKeyRight);
        joystickInput.onClick.AddListener(setJoystick);

    }

    public void setEnable(bool enable)
    {
        config.enable = enable;
    }
    public void setName(string name)
    {
        config.name = name;
    }
    public void setInputType(bool inputType)
    {
        config.inputType = inputType;
        if (inputType)
        {
            inputToggle.transform.GetChild(0).GetComponent<Text>().text = "Keyboard";
            keyboardPanel.SetActive(true);
            joystickPanel.SetActive(false);
        }
        else
        {
            inputToggle.transform.GetChild(0).GetComponent<Text>().text = "Joystick";
            keyboardPanel.SetActive(false);
            joystickPanel.SetActive(true);
        }
    }
    public void setKeyUp()
    {
        StartCoroutine(readKeyUp());
    }
    public void setKeyDown()
    {
        StartCoroutine(readKeyDown());
    }
    public void setKeyLeft()
    {
        StartCoroutine(readKeyLeft());
    }
    public void setKeyRight()
    {
        StartCoroutine(readKeyRight());
    }
    public void setJoystick()
    {
        StartCoroutine(readJoystick());
    }



    public void setKeyUpText(string text)
    {
        keyUpInput.transform.GetChild(0).GetComponent<Text>().text = text;
    }
    public void setKeyDownText(string text)
    {
        keyDownInput.transform.GetChild(0).GetComponent<Text>().text = text;
    }
    public void setKeyLeftText(string text)
    {
        keyLeftInput.transform.GetChild(0).GetComponent<Text>().text = text;
    }
    public void setKeyRightText(string text)
    {
        keyRightInput.transform.GetChild(0).GetComponent<Text>().text = text;
    }
    public void setJoystickText(string text)
    {
        joystickInput.transform.GetChild(0).GetComponent<Text>().text = text;
    }

    KeyCode readKey() {
        foreach (KeyCode key in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(key))
            {
                if (key == KeyCode.Mouse0)
                    return KeyCode.None;
                else if (key == KeyCode.Mouse1)
                    return KeyCode.None;
                else if (key == KeyCode.Mouse2)
                    return KeyCode.None;
                else if (key == KeyCode.Mouse3)
                    return KeyCode.None;
                else if (key == KeyCode.Mouse4)
                    return KeyCode.None;
                else if (key == KeyCode.Mouse5)
                    return KeyCode.None;
                else if (key == KeyCode.Mouse6)
                    return KeyCode.None;
                else
                    return key;
            }
        }
        return KeyCode.None;
    }

    IEnumerator readKeyUp()
    {
        if (isReadingKey) yield break;
        isReadingKey = true;
        setKeyUpText("");
        while(true){
            KeyCode key = readKey();
            if(key != KeyCode.None){
                config.keyUp = key;
                setKeyUpText(key.ToString());
                isReadingKey = false;
                yield break;
            }
            yield return null;
        }
    }

    IEnumerator readKeyDown()
    {
        if (isReadingKey) yield break;
        isReadingKey = true;
        setKeyDownText("");
        while (true)
        {
            KeyCode key = readKey();
            if (key != KeyCode.None)
            {
                config.keyDown = key;
                setKeyDownText(key.ToString());
                isReadingKey = false;
                yield break;
            }
            yield return null;
        }
    }

    IEnumerator readKeyLeft()
    {
        if (isReadingKey) yield break;
        isReadingKey = true;
        setKeyLeftText("");
        while (true)
        {
            KeyCode key = readKey();
            if (key != KeyCode.None)
            {
                config.keyLeft = key;
                setKeyLeftText(key.ToString());
                isReadingKey = false;
                yield break;
            }
            yield return null;
        }
    }

    IEnumerator readKeyRight()
    {
        if (isReadingKey) yield break;
        isReadingKey = true;
        setKeyRightText("");
        while (true)
        {
            KeyCode key = readKey();
            if (key != KeyCode.None)
            {
                config.keyRight = key;
                setKeyRightText(key.ToString());
                isReadingKey = false;
                yield break;
            }
            yield return null;
        }
    }


    IEnumerator readJoystick()
    {
        if (isReadingKey) yield break;
        isReadingKey = true;
        setJoystickText("");
        while (true)
        {
            KeyCode key = readKey();
            config.joystick = "Joystick1";
            yield break;
            /*
            Debug.Log(key.ToString());
            if (key == KeyCode.JoystickButton7 || key == KeyCode.Joystick1Button9)
            {
                config.joystick = "Joystick1";
                setJoystickText(config.joystick);
                isReadingKey = false;
                yield break;
            }
            else if (key == KeyCode.Joystick2Button7 || key == KeyCode.Joystick2Button9)
            {
                config.joystick = "Joystick2";
                setJoystickText(config.joystick);
                isReadingKey = false;
                yield break;
            }
            else if (key == KeyCode.Joystick3Button7 || key == KeyCode.Joystick3Button9)
            {
                config.joystick = "Joystick3";
                setJoystickText(config.joystick);
                isReadingKey = false;
                yield break;
            }
            else if (key == KeyCode.Joystick4Button7 || key == KeyCode.Joystick4Button9)
            {
                config.joystick = "Joystick4";
                setJoystickText(config.joystick);
                isReadingKey = false;
                yield break;
            }
            else if (key == KeyCode.Joystick5Button7 || key == KeyCode.Joystick5Button9)
            {
                config.joystick = "Joystick5";
                setJoystickText(config.joystick);
                isReadingKey = false;
                yield break;
            }
            else if (key == KeyCode.Joystick6Button7 || key == KeyCode.Joystick6Button9)
            {
                config.joystick = "Joystick6";
                setJoystickText(config.joystick);
                isReadingKey = false;
                yield break;
            }
            yield return null;
             * */
        }
    }

    public void loadConfig(PlayerConfig playerConfig)
    {
        config = playerConfig;
        enableToggle.isOn = config.enable;
        nameInput.text = config.name;
        inputToggle.isOn = config.inputType;
        if (config.inputType)
        {
            inputToggle.transform.GetChild(0).GetComponent<Text>().text = "Keyboard";
            keyboardPanel.SetActive(true);
            joystickPanel.SetActive(false);
        }
        else
        {
            inputToggle.transform.GetChild(0).GetComponent<Text>().text = "Joystick";
            keyboardPanel.SetActive(false);
            joystickPanel.SetActive(true);
        }
        setKeyUpText(config.keyUp.ToString());
        setKeyDownText(config.keyDown.ToString());
        setKeyLeftText(config.keyLeft.ToString());
        setKeyRightText(config.keyRight.ToString());
        setJoystickText(config.joystick.ToString());
    }

}
