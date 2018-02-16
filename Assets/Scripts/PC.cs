using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class PC : MonoBehaviour {

	private List <string> PokeComp;
	private List <string> SpeciesSlot;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this.gameObject);
		PokeComp = new List<string>();
		SpeciesSlot = new List<string>();
		if(File.Exists(Application.persistentDataPath+"/PC.dat")){
			BinaryFormatter BF = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath+"/PC.dat", FileMode.Open);
			PCdata data = (PCdata)BF.Deserialize(file);

			file.Close();

			PokeComp = data.PokeComp;
			SpeciesSlot = data.SpeciesSlot;
		}
	}

	public void addMon(string CODE, string Species){
		PokeComp.Add(CODE);
		SpeciesSlot.Add(Species);
		BinaryFormatter BF = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath+"/PC.dat");
		PCdata data = new PCdata();
		data.PokeComp = PokeComp;
		data.SpeciesSlot = SpeciesSlot; 
		BF.Serialize(file, data);
		file.Close();
	}

	public void NewMon(){
		this.transform.GetChild(0).gameObject.GetComponent<Pokemon>().InitializeN();
	}

	public void LoadMon(){
		this.transform.GetChild(0).gameObject.GetComponent<Pokemon>().InitializeL(PokeComp[0]);
	}
}

[Serializable]
class PCdata{
	public List<string> PokeComp;
	public List <string> SpeciesSlot;
}
