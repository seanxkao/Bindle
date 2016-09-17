using UnityEngine;
using System.Collections;

public class Theme : MonoBehaviour {
    public GameObject ball;
    public float spawnRate;
    public float radius;
    float time;

	// Use this for initialization
	void Start () {
        time = 0;
	}
	
	// Update is called once per frame
	void Update () {
        float period = 1f/spawnRate;
	    if(time > period){
            time -= period;
            float r = Random.Range(0f, radius);
            float angle = Random.Range(0f, Mathf.PI*2);
            Vector3 pos = new Vector3(r*Mathf.Cos(angle), 30, r*Mathf.Sin(angle));
            Instantiate(ball, pos, Quaternion.identity);
        }
        time += Time.deltaTime;
	}
}
