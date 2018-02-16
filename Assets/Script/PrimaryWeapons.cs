using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrimaryWeapons : MonoBehaviour {

	private int power;
	public float cooldown=0.5f;
	public float delay=0.1f;
	private float delaya;
	public float cycle=0.3f;
	public Transform[] t;
    public Transform[] m;
	public Rigidbody proj;
    public Rigidbody Missile;
	private bool shooting;
    private int AmmoM=2;
    public Image I;

	// Use this for initialization
	void Start () {
		power = gameObject.GetComponent<Ship>().power;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButton("Fire1") && power>0 && !shooting){
			StartCoroutine(FireDelay(0,0));
		}
        if(Input.GetButtonDown("Fire2") && AmmoM>0){
            FireOrdnance(m[AmmoM - 1]);
            AmmoM--;
            I.fillAmount = (float)AmmoM / 2f;
		}
	}

	void Fire(Transform T) {
		Rigidbody Clone = (Rigidbody) Instantiate(proj, T.position, T.rotation);
		Clone.velocity = Clone.transform.TransformDirection(Vector3.forward * 200f);
	}

    void FireOrdnance(Transform T) {
		Rigidbody Clone = (Rigidbody) Instantiate(Missile, T.position, T.rotation);
		//Clone.AddForce(Clone.transform.forward * 200f, ForceMode.Impulse);
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
