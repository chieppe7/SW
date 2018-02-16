using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

	public string Name;
	public int Power;

	public void ExecuteATK(GameObject Ref){
		Ref.GetComponent<Animator>().SetInteger("Power", Power);
		Ref.GetComponent<Animator>().SetTrigger(Name);
		Debug.Log(Name);


	}
}
