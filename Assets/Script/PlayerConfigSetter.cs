using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class PlayerConfigSetter : MonoBehaviour {
    public string[] joyNames;
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
        joyNames = Input.GetJoystickNames();
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
            for (KeyCode keyCode = KeyCode.Joystick1Button0; keyCode < KeyCode.Joystick1Button19; keyCode++) {
                if (Input.GetKeyDown(keyCode)) {
                    setJoystickText("Joystick1");
                    config.joystick = "Joystick1";
                    isReadingKey = false;
                    yield break;
                }
            }
            for (KeyCode keyCode = KeyCode.Joystick2Button0; keyCode < KeyCode.Joystick2Button19; keyCode++)
            {
                if (Input.GetKeyDown(keyCode))
                {
                    setJoystickText("Joystick2");
                    config.joystick = "Joystick2";
                    isReadingKey = false;
                    yield break;
                }
            }
            for (KeyCode keyCode = KeyCode.Joystick3Button0; keyCode < KeyCode.Joystick3Button19; keyCode++)
            {
                if (Input.GetKeyDown(keyCode))
                {
                    setJoystickText("Joystick3");
                    config.joystick = "Joystick3";
                    isReadingKey = false;
                    yield break;
                }
            }
            for (KeyCode keyCode = KeyCode.Joystick4Button0; keyCode < KeyCode.Joystick4Button19; keyCode++)
            {
                if (Input.GetKeyDown(keyCode))
                {
                    setJoystickText("Joystick4");
                    config.joystick = "Joystick4";
                    isReadingKey = false;
                    yield break;
                }
            }
            yield return null;
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
