using UnityEngine;
using System.Collections;

public class MainPanel : MonoBehaviour {
    public void showPanel(string name) { 
        foreach(Transform child in transform)
        {
            if (child.gameObject.name == name)
            {
                child.gameObject.SetActive(true);
            }
            else
            {
                child.gameObject.SetActive(false);
            }
        }

    }
}
