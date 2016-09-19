using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Manager : MonoBehaviour
{
    public PlayerConfigSetter[] playerConfigSetters;
    public PlayerConfig[] playerConfigs;

    public GameObject planePrefab;
    public GameObject playerPrefab;

    public Material[] materials;

    public string[] joyNames;

    GameObject plane;
    GameObject[] players;


    public void Awake()
    {
        DontDestroyOnLoad(this);
        playerConfigs = new PlayerConfig[4];
        joyNames = Input.GetJoystickNames();
        string path = Application.persistentDataPath + "/playerConfig.dat";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = File.Open(path, FileMode.Open);
            playerConfigs = (PlayerConfig[])formatter.Deserialize(file);
            file.Close();
        }
        else
        {
            for (int i = 0; i < 4; i++)
            {
                playerConfigs[i] = new PlayerConfig();
            }
        }
        for (int i = 0; i < 4; i++)
        {
            playerConfigSetters[i].loadConfig(playerConfigs[i]);
        }
    }
    void OnGUI() {
        if (SceneManager.GetActiveScene().name == "Bindle")
        {
            FallTrigger fallTrigger = plane.transform.GetChild(0).GetComponent<FallTrigger>();
            if (fallTrigger.isFinished()) {
                Vector2 size = new Vector2(150, 100);
                float width = Camera.main.pixelWidth;
                float height = Camera.main.pixelHeight;
                Vector2 pos = new Vector2(width / 2 - size.x / 2, height / 3 - size.y / 2 - 30);
                GUIStyle style = new GUIStyle();
                style.alignment = TextAnchor.MiddleCenter;
                style.fontSize = 72;
                string msg = fallTrigger.getWinner().playerConfig.name + " Win!";
                GUI.Label(new Rect(pos, size), msg, style);
                pos += new Vector2(2, 0);
                GUI.Label(new Rect(pos, size), msg, style);
                pos += new Vector2(-2, 2);
                GUI.Label(new Rect(pos, size), msg, style);
                pos += new Vector2(2, 0);
                GUI.Label(new Rect(pos, size), msg, style);
                pos += new Vector2(-1, -1);
                Color color = fallTrigger.getWinner().GetComponent<MeshRenderer>().material.color;
                style.normal.textColor = Color.Lerp(color, Color.white, 0.2f);
                GUI.Label(new Rect(pos, size), msg, style);
            }
        }
    }
	
	void Update () {
        if (SceneManager.GetActiveScene().name == "Bindle")
        {
            string[] joyNames = Input.GetJoystickNames();
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Bindle");
            }
            else if (Input.GetKeyDown(KeyCode.Joystick1Button8) && joyNames[0] == "Logitech RumblePad 2 USB")
            {
                SceneManager.LoadScene("Bindle");
                
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("Menu");
                Destroy(gameObject);
            }
        }
    }
    public void save() {
        int size = playerConfigSetters.Length;
        playerConfigs = new PlayerConfig[size];
        for (int i = 0; i < size; i++)
        {
            playerConfigs[i] = playerConfigSetters[i].config;
        }
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerConfig.dat");
        formatter.Serialize(file, playerConfigs);
        file.Close();
    }
    public void gameStart()
    {
        SceneManager.LoadScene("Bindle");
    }

    public void OnLevelWasLoaded(){
        if (SceneManager.GetActiveScene().name == "Bindle")
        {
            if (plane != null)
            {
                Destroy(plane);
            }
            if (players != null)
            {
                foreach (GameObject player in players)
                {
                    Destroy(player);
                }
            }

            int size = playerConfigs.Length;
            plane = (GameObject)Instantiate(planePrefab);
            plane.transform.position = Vector3.zero;
            players = new GameObject[size];
            for (int i = 0; i < size; i++)
            {
                players[i] = (GameObject)Instantiate(playerPrefab);
                PlayerConfig config = playerConfigs[i];
                players[i].GetComponent<Controller>().playerConfig = config;
                Vector3 pos;
                pos.x = Mathf.Cos(i / (float)size * 2 * Mathf.PI + Mathf.PI/2);
                pos.y = 0.5f;
                pos.z = Mathf.Sin(i / (float)size * 2 * Mathf.PI + Mathf.PI / 2);
                players[i].transform.position = pos;
                players[i].GetComponent<Controller>().plane = plane;
                players[i].GetComponent<MeshRenderer>().material = materials[i];
            }

            FallTrigger fallTrigger = plane.transform.GetChild(0).GetComponent<FallTrigger>();
            fallTrigger.init(size);
            for (int i = 0; i < size; i++)
            {
                fallTrigger.players[i] = players[i].GetComponent<Controller>();
            }
        }
    }

}
