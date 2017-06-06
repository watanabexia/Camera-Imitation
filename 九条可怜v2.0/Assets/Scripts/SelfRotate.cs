using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfRotate : MonoBehaviour {
    public bool is_rotate = false;
    public float speed = 10;
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (is_rotate) this.transform.Rotate(this.transform.rotation.x, this.transform.rotation.y + speed, this.transform.rotation.z, Space.World);
	}
}
