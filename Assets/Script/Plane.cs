using UnityEngine;
using System.Collections;

public class Plane : MonoBehaviour {

	// Use this for initialization
    float mass;
    public Vector3 rotate;
    public float k;
	void Start () {
        mass = GetComponent<Rigidbody>().mass;
	}
    void Update() {
    }

	// Update is called once per frame
	void FixedUpdate () {
        Vector3 rot = new Vector3(transform.rotation.x, 0, transform.rotation.z);
        rotate = rot;
        GetComponent<Rigidbody>().AddTorque(-rot*mass*k);

        //GetComponent<Rigidbody>().AddTorque(new Vector3(0,1,0)*mass*200);
	}
}
