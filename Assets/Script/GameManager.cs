using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public int Score=0;
    public GameObject Enemy;
    private GameObject Player;
    private Text SC;
    public Text GOSC;
    public Image GameOver;
    public UpgradesManager UM;
    private bool save = false;

	// Use this for initialization
	void Awake () {
        Player = GameObject.FindGameObjectWithTag("Player");
        Score = 0;
        SC = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        StartCoroutine(Spawn());
        GameOver.gameObject.SetActive(false);
        StartCoroutine(Scoreps());
	}

    IEnumerator Scoreps() {
        yield return new WaitForSeconds(1f);
        if (Player)
        {
            Score++;
            StartCoroutine(Scoreps());
        }
    }
	
	// Update is called once per frame
	void Update () {
        SC.text = Score.ToString();
        GOSC.text = Score.ToString();
        if (!Player && !save) {
            StartCoroutine(delay());
            GameOverCall();
            save = true;
        }
	}

    IEnumerator delay() {
        yield return new WaitForSeconds(1f);
        gameObject.GetComponent<SceneLoader>().Inst();
    }

    IEnumerator Spawn() {
        yield return new WaitForSeconds(10f);
        if (Player) {
            Instantiate(Enemy, RandomPos(), Player.transform.rotation);
            StartCoroutine(Spawn());
        }
    }

    void GameOverCall() {
        UM.Money += Score;
        UM.SaveF();
    }

    private Vector3 RandomPos() {
        Vector3 T = new Vector3(Random.Range(-300f, 300f), 1f, Random.Range(-300f, 300f));
        return T;
    }

}
