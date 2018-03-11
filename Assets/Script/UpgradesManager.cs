using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;

public class UpgradesManager : MonoBehaviour {

    public Ship PS;
    public PrimaryWeapons PW;
    public SceneLoader SL;

    public Text TotalMoney;

    public int Money;

    private int HullUp;
    private int ShieldsUp;
    private int LaserUp;
    private int BoostUp;
    private int MissileUp;

    public Text[] Custo;
    public Text[] Upnumber;

    private void Update() {
        if(TotalMoney)
            TotalMoney.text = Money.ToString();
        if (Custo[0]) {
            if (HullUp < 3)
                Custo[0].text = (20000 * ((HullUp * 3) + 1)).ToString();
            else Custo[0].text = "MAX";
            if (ShieldsUp < 3)
                Custo[1].text = (10000 * ((ShieldsUp * 2) + 1)).ToString();
            else
                Custo[1].text = "MAX";
            if(LaserUp<3)
                Custo[2].text = (15000 * ((LaserUp * 2) + 1)).ToString();
            else
                Custo[2].text = "MAX";
            if(MissileUp<3)
                Custo[3].text = (7500 * ((MissileUp * 2) + 1)).ToString();
            else
                Custo[3].text = "MAX";
            if(BoostUp<3)
                Custo[4].text = (5000 * ((BoostUp * 2) + 1)).ToString();
            else
                Custo[4].text = "MAX";
        }
        if(Upnumber[0]) {
            Upnumber[0].text = HullUp.ToString();
            Upnumber[1].text = ShieldsUp.ToString();
            Upnumber[2].text = LaserUp.ToString();
            Upnumber[3].text = MissileUp.ToString();
            Upnumber[4].text = BoostUp.ToString();
        }
    }
    // Use this for initialization
    void Awake () {
        if (File.Exists(Application.persistentDataPath + "/SerialData.dat"))
        {
            BinaryFormatter BF = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/SerialData.dat", FileMode.Open);
            Save data = (Save)BF.Deserialize(file);
            file.Close();
            if ((data.Money != (data.MoneyCheck1 / 2)) && (data.Money != (data.MoneyCheck2 - 1273586))) {
                resetAll();
            }
            if ((data.BoostUp != (data.BoostValue / 2))) {
                resetAll();
            }
            if ((data.HullUp != (data.HullValue - 1))) {
                resetAll();
            }
            if ((data.LaserUp != (data.LaserValue -1 ))) {
                resetAll();
            }
            if ((data.MissileUp != (data.MissileValue / 2))) {
                resetAll();
            }
            if ((data.ShieldUp != (data.ShieldValue/2 - 2))) {
                resetAll();
            }
            Money = data.Money;
            HullUp = data.HullUp;
            ShieldsUp = data.ShieldUp;
            LaserUp = data.LaserUp;
            BoostUp = data.BoostUp;
            MissileUp = data.MissileUp;
            if (PS) {
                PS.Fuel = data.BoostValue;
                PS.power = data.LaserValue;
                PS.engine = data.Engine;
                PS.Speed = data.Speed;
                PS.hull = data.HullValue;
                PS.shield = data.ShieldValue;
                PS.maxhull = data.HullValue;
            }
            if (PW) {
                PW.AmmoM = data.MissileValue;
                PW.cooldown = data.LaserCD;
                PW.cycle = data.LaserCycle;
                PW.delay = data.LaserDelay;
            }
        }
        else
        {
            BinaryFormatter BF = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/SerialData.dat");
            Save data = new Save();
            data.Money = 0;
            data.MoneyCheck1 = 0;
            data.MoneyCheck2 = 1273586;
            data.BoostUp = 0;
            data.BoostValue = 0;
            data.Engine = 50f;
            data.HullUp = 0;
            data.HullValue = 1;
            data.LaserCD = .5f;
            data.LaserCycle = .3f;
            data.LaserDelay = .1f;
            data.LaserUp = 0;
            data.LaserValue = 1;
            data.MissileUp = 0;
            data.MissileValue = 0;
            data.ShieldUp = 0;
            data.ShieldValue = 2;
            data.Speed = 70f;
            BF.Serialize(file, data);
		    file.Close();
        }
	}

    public void UpBoost() {
        if (BoostUp < 3) {
            if (Money > 5000 * ((BoostUp * 2) + 1)) {
                Money -= 5000*((BoostUp*2)+1);
                BoostUp++;
                SaveF();
            }
        }
    }
    public void UpHull() {
        if (HullUp < 3) {
            if (Money > 20000 * ((HullUp * 3) + 1)) {
                Money -= 20000 * ((HullUp * 3) + 1);
                HullUp++;
                SaveF();
            }
        }
    }
    public void UpLaser() {
        if (LaserUp < 3) {
            if (Money > 15000 * ((LaserUp * 2) + 1)) {
                Money -= 15000 * ((LaserUp * 2) + 1);
                LaserUp++;
                SaveF();
            }
        }
    }
    public void UpMissile() {
        if (MissileUp < 3) {
            if (Money > 7500 * ((MissileUp * 2) + 1)) {
                Money -= 7500 * ((MissileUp * 2) + 1);
                MissileUp++;
                SaveF();
            }
        }
    }
    public void UpShield() {
        if (ShieldsUp < 3) {
            if (Money > 10000 * ((ShieldsUp * 2) + 1)) {
                Money -= 10000 * ((ShieldsUp * 2) + 1);
                ShieldsUp++;
                SaveF();
            }
        }
    }

    public void SaveF() {
            BinaryFormatter BF = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/SerialData.dat");
            Save data = new Save();
            data.Money = Money;
            data.MoneyCheck1 = Money * 2;
            data.MoneyCheck2 = Money + 1273586;
            data.BoostUp = BoostUp;
            data.BoostValue = BoostUp*2;
            data.Engine = (float)BoostUp*10f+50f;
            data.HullUp = HullUp;
            data.HullValue = HullUp+1;
            data.LaserCD = 0.5f-(float)BoostUp*0.15f;
            data.LaserCycle = 0.3f-(float)BoostUp*0.05f;
            data.LaserDelay = 0.1f-(float)BoostUp*0.025f;
            data.LaserUp = LaserUp;
            data.LaserValue = LaserUp+1;
            data.MissileUp = MissileUp;
            data.MissileValue = MissileUp*2;
            data.ShieldUp = ShieldsUp;
            data.ShieldValue = (ShieldsUp*2)+2;
            data.Speed = (float)BoostUp*5f+70f;
            BF.Serialize(file, data);
		    file.Close();
    }

    void resetAll() {
        File.Delete(Application.persistentDataPath + "/SerialData.dat");
        SL.StartGame();
    }
}

[Serializable]
class Save {


	public int Money;
	public int MoneyCheck1;
	public int MoneyCheck2;

	public int HullValue;
	public int HullUp;

	public int ShieldValue;
    public int ShieldUp;

	public int LaserValue;
    public float LaserCD;
    public float LaserDelay;
    public float LaserCycle;
	public int LaserUp;

	public int MissileValue;
	public int MissileUp;

	public int BoostValue;
    public float Engine;
    public float Speed;
	public int BoostUp;
}
