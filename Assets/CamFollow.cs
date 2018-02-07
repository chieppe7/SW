using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour {

    private Transform Tgt;

	// Use this for initialization
	void Start () {
        Tgt = GameObject.FindGameObjectWithTag("Player").transform;
        Debug.Log(Tgt);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(Tgt.position.x, 10f, Tgt.position.z);
        Debug.Log(transform.position);
	}
}
