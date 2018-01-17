using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimaryLaser : MonoBehaviour {

	private Ship Tgt;

	void Start() {
		StartCoroutine(Die());
	}

	void OnTriggerEnter(Collider Col) {
		Tgt = Col.gameObject.GetComponent<Ship>();
		if(Tgt)
			Tgt.takeDamage(false,isCrit());
		Destroy(this.gameObject);
	}

	bool isCrit() {
		return Random.value>0.75f;
	}

	IEnumerator Die(){
		yield return new WaitForSeconds(5);
		Destroy(this.gameObject);
	}
}
