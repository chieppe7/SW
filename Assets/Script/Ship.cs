using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {

	//ship properties
	public string name;
	public int hull;
	public int shield;
	public int power;
	public float engine;
	public float Speed;
	public float turnSpeed;

	private Rigidbody rig;

	// Use this for initialization
	void Start () {
		rig = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		move();
	}

	void takeDamage(int dmg) {
		hull-=dmg;
		if (hull<=0)
			die();
	}

	void die() {
		
	}

	void move() {
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");

		if(h*h+v*v<0.1){
			return;
		}
		//anim.SetBool("IsMoving",true);

		Vector3 movement = new Vector3(h, 0.0f, v);

		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), turnSpeed);
		rig.AddForce(movement*engine, ForceMode.Acceleration);
		rig.velocity=Vector3.ClampMagnitude(rig.velocity, Speed);
	}
}
