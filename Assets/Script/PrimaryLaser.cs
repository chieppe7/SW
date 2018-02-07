using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimaryLaser : MonoBehaviour {

	private Ship Tgt;
    private EnemyShip IAtgt;

	void Start() {
		StartCoroutine(Die());
	}

	void OnTriggerEnter(Collider Col) {
		Tgt = Col.gameObject.GetComponent<Ship>();
        IAtgt = Col.gameObject.GetComponent<EnemyShip>();
		if(Tgt)
			Tgt.takeDamage(false,isCrit());
        if (IAtgt)
            IAtgt.takeDamage(false, isCrit());
        if(Col.gameObject.layer != 0 )
		    Destroy(this.gameObject);
	}

	bool isCrit() {
		return Random.value>0.75f;
	}

	IEnumerator Die(){
		yield return new WaitForSeconds(2);
		Destroy(this.gameObject);
	}
}
