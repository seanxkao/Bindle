using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
    public float life;

    void Awake() {
        float r = Random.Range(0f, 1f);
        float g = Random.Range(0f, 1f);
        float b = Random.Range(0f, 1f);
        GetComponent<MeshRenderer>().material.color = new Color(r, g, b);
        Destroy(gameObject, life);
    }
	
}
