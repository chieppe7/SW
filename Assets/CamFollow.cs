﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CamFollow : MonoBehaviour {

    private Transform Tgt;
    private AudioListener A;

	// Use this for initialization
	void Awake () {
        Tgt = GameObject.FindGameObjectWithTag("Player").transform;
        A = this.gameObject.GetComponent<AudioListener>();
        A.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Tgt)
        {
            transform.position = new Vector3(Tgt.position.x, 10f, Tgt.position.z);
            A.enabled = false;
        }
        else
            A.enabled = true;
            
	}
}
