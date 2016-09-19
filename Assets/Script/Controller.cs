using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour
{
    public PlayerConfig playerConfig;
    public GameObject plane;
    public float speed;
    protected float mass;

    protected Vector2 axis;

    protected bool keyLeft;
    protected bool keyRight;
    protected bool keyUp;
    protected bool keyDown;

    void Start()
    {
        mass = GetComponent<Rigidbody>().mass;
    }

    void Update()
    {
        getControlKey();
    }

    void FixedUpdate() { 
        Vector3 basis1 = plane.transform.right;
        Vector3 basis2 = plane.transform.forward;
        Vector3 move = Vector3.zero;
        move += axis.x * basis1 * speed * mass;
        move += axis.y * basis2 * speed * mass;
        GetComponent<Rigidbody>().AddForce(move);
    }
    void OnGUI() {
        Vector2 pos = Camera.main.WorldToScreenPoint(transform.position);
        pos.y = Screen.height - pos.y;
        pos += new Vector2(-30, -70);
        Vector2 size = new Vector2(50, 30);
        GUIStyle style = new GUIStyle();
        style.alignment = TextAnchor.MiddleCenter;
        style.fontSize = 24;
        style.normal.textColor = Color.black;
        GUI.Label(new Rect(pos, size), playerConfig.name, style);

        pos += new Vector2(2, 0);
        GUI.Label(new Rect(pos, size), playerConfig.name, style);

        pos += new Vector2(-2, 2);
        GUI.Label(new Rect(pos, size), playerConfig.name, style);

        pos += new Vector2(2, 0);
        GUI.Label(new Rect(pos, size), playerConfig.name, style);

        pos += new Vector2(-1, -1);
        Color color = GetComponent<MeshRenderer>().material.color;
        style.normal.textColor = Color.Lerp(color, Color.white, 0.2f);
        GUI.Label(new Rect(pos, size), playerConfig.name, style);
    }
    protected virtual void getControlKey()
    {
        if (playerConfig.inputType)
        {
            keyUp = Input.GetKey(playerConfig.keyUp);
            keyDown = Input.GetKey(playerConfig.keyDown);
            keyLeft = Input.GetKey(playerConfig.keyLeft);
            keyRight = Input.GetKey(playerConfig.keyRight);
            axis = Vector2.zero;
            if (keyLeft && !keyRight)
            {
                axis.x = -1f;
            }
            else if (!keyLeft && keyRight)
            {
                axis.x = 1f;
            }
            if (keyDown && !keyUp)
            {
                axis.y = -1f;
            }
            else if (!keyDown && keyUp)
            {
                axis.y = 1f;
            }
        }
        else
        {
            axis.x = Input.GetAxis(playerConfig.joystick + "X");
            axis.y = Input.GetAxis(playerConfig.joystick + "Y");
        }
        if (axis != Vector2.zero) axis.Normalize();
    }
}
