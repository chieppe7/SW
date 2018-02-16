using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatExch : MonoBehaviour {

	public Material[] M;
	private int S;

	void Start(){
		S=M.Length;
	}

	// Use this for initialization
	public void MatEX(GameObject Ref){
		Material[] Mats = Ref.GetComponent<SkinnedMeshRenderer>().materials;
		for (int i=0;i<S;i++)
			Mats[i]=M[i];
		Ref.GetComponent<SkinnedMeshRenderer>().materials = Mats;
	}
}
