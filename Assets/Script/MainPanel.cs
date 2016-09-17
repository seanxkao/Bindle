using UnityEngine;
using System.Collections;

public class MainPanel : MonoBehaviour {
    public GameObject configPanel;

    public void newGame() {
        configPanel.SetActive(true);
        gameObject.SetActive(false);
    }
}
