using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {

	//ship properties
	public string Name;
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

	public void takeDamage(bool IS, bool CH) {
		int dmg=1;
		if(CH)
			dmg=2;
		if(!IS){
			shield-=dmg;
			if(shield<0){
				hull+=shield;
				shield=0;
			}
		}
		else
			hull-=dmg;
		if(hull<=0)
			die();
	}

	void die() {
		Destroy(this.gameObject);
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
