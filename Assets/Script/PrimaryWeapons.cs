using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimaryWeapons : MonoBehaviour {

	public int type;
	private int power;
	private float cooldown=0.5f;
	private float delay=0.1f;
	private float delaya;
	private float cycle=0.3f;
	public Transform[] t;
	public Rigidbody proj;
	private bool shooting;

	// Use this for initialization
	void Start () {
		power = gameObject.GetComponent<Ship>().power;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButton("Fire1") && power>0 && !shooting){
			StartCoroutine(FireDelay(0,0));
		}
	}

	void Fire(Transform T) {
		Rigidbody Clone = (Rigidbody) Instantiate(proj, T.position, T.rotation);
		Clone.velocity = Clone.transform.TransformDirection(Vector3.forward * 30f);
	}

	IEnumerator FireDelay(int i, int j) {
		shooting=true;
		Fire(t[i++]);
		if(i>=t.Length){
			delaya = cycle;
			i=0;
			j++;
		}
		else
			delaya = delay;
		yield return new WaitForSeconds(delaya);
		if(j<power)
			StartCoroutine(FireDelay(i,j));
		else
			StartCoroutine(Cooldown());
	}

	IEnumerator Cooldown(){
		yield return new WaitForSeconds(cooldown);
		shooting=false;
	}
}
