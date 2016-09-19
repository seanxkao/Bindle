using UnityEngine;
using System.Collections;

public class MainPanel : MonoBehaviour {
    public GameObject configPanel;

    public void main()
    {
        configPanel.SetActive(false);
        gameObject.SetActive(true);
    }
    public void config() {
        configPanel.SetActive(true);
        gameObject.SetActive(false);
    }
}
