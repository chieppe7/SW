using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Pokemon : MonoBehaviour {

	const string glyphs= "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
	private PC PlayerComp;
	public MatExch Mat;
	public string Name;
	private string Nick;

	public int BaseHP;
	public int BaseATK;
	public int BaseDEF;
	public int BaseSPA;
	public int BaseSPD;
	public int BaseSPE;

	public string type1;
	public string type2;

	public int malePer;
	public int lvlMin;
	public int lvlMax;

	private int evHP;
	private int evATK;
	private int evDEF;
	private int evSPA;
	private int evSPD;
	private int evSPE;

	private int ivHP;
	private int ivATK;
	private int ivDEF;
	private int ivSPA;
	private int ivSPD;
	private int ivSPE;

	private int lvl;
	private int XP;
	private bool Shiny;
	private bool male;

	private string CODE;

	void Start(){
		PlayerComp=GameObject.FindGameObjectWithTag("Player").GetComponent<PC>();
	}

	// Use this for initialization
	public void InitializeN () {
		evHP=0;
		evATK=0;
		evDEF=0;
		evSPA=0;
		evSPD=0;
		evSPE=0;
		ivHP=UnityEngine.Random.Range(0,31);
		ivATK=UnityEngine.Random.Range(0,31);
		ivDEF=UnityEngine.Random.Range(0,31);
		ivSPA=UnityEngine.Random.Range(0,31);
		ivSPD=UnityEngine.Random.Range(0,31);
		ivSPE=UnityEngine.Random.Range(0,31);
		Nick = "";

		lvl=UnityEngine.Random.Range(lvlMin,lvlMax);

		if(UnityEngine.Random.Range(1,100)>malePer)
			male=false;
		else
			male=true;

		if(UnityEngine.Random.Range(0,300)==1)
			Shiny=true;
		else
			Shiny=false;

		if(Shiny)
			Mat.MatEX(this.transform.GetChild(0).gameObject);

		Debug.Log(Shiny);
	}

	public void InitializeL (string Codef) {
		if(File.Exists(Application.persistentDataPath+"/"+ Codef +".dat")){
			BinaryFormatter BF = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath+"/"+ Codef +".dat", FileMode.Open);
			Poke data = (Poke)BF.Deserialize(file);

			file.Close();

			evHP = data.evHP;
			ivHP = data.ivHP;
			ivATK = data.ivATK;
			evATK = data.evATK;
			ivDEF = data.ivDEF;
			evDEF = data.evDEF;
			ivSPA = data.ivSPA;
			evSPA = data.evSPA;
			ivSPD = data.ivSPD;
			evSPD = data.evSPD;
			ivSPE = data.ivSPE;
			evSPE = data.evSPE;
			lvl = data.lvl;
			XP = data.XP;
			Nick = data.Nick;
			male = data.male;
			Shiny = data.Shiny;
		}
			
		if(Shiny)
			Mat.MatEX(this.transform.GetChild(0).gameObject);
	}

	public void Capture(){
		do{
			for(int i=0; i<5; i++)
				CODE += glyphs[UnityEngine.Random.Range(0, 35)];
		} while(File.Exists(Application.persistentDataPath+"/"+ CODE +".dat"));
		Debug.Log(CODE);
		PlayerComp.addMon(CODE,Name);
		Save();
	}

	private void Save(){
		BinaryFormatter BF = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath+"/"+ CODE +".dat");

		Poke data = new Poke();

		data.evHP = evHP;
		data.ivHP = ivHP;
		data.evATK = evATK;
		data.ivATK = ivATK;
		data.evDEF = evDEF;
		data.ivDEF = ivDEF;
		data.evSPA = evSPA;
		data.ivSPA = ivSPA;
		data.evSPD = evSPD;
		data.ivSPD = ivSPD;
		data.evSPE = evSPE;
		data.ivSPE = ivSPE;
		data.lvl = lvl;
		data.XP = XP;
		data.Nick = Nick;
		data.male = male;
		data.Shiny = Shiny;
		BF.Serialize(file, data);
		file.Close();
	}

	public void AddNick(string NickName){
		Nick = NickName;
	}

	// Update is called once per frame
	void Update () {
		
	}
}

[Serializable]
class Poke {

	public string Nick;

	public int evHP;
	public int evATK;
	public int evDEF;
	public int evSPA;
	public int evSPD;
	public int evSPE;

	public int ivHP;
	public int ivATK;
	public int ivDEF;
	public int ivSPA;
	public int ivSPD;
	public int ivSPE;

	public int lvl;
	public int XP;
	public bool Shiny;
	public bool male;
}
