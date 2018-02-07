using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour {

    public string Name;
	public int hull;
	public int shield;
	public int power;


	public float cooldown=0.5f;
	public float delay=0.1f;
	private float delaya;
	public float cycle=0.3f;
	public Transform[] t;
	public Rigidbody proj;
	private bool shooting;
    private Transform Player;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update () {
		if(power>0 && !shooting && Vector3.Distance(Player.position,transform.position)<50f){
			StartCoroutine(FireDelay(0,0));
		}
	}

    void die() {
        GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>().Score += 100;
		Destroy(this.gameObject);
	}

    public void takeDamage(bool IS, bool CH) {
		int dmg=1;
		if(CH)
			dmg=2;
		if(!IS){
			shield-=dmg;
			if(shield<0){
				hull+=shield;
				shield=0;
			}
		}
		else
			hull-=dmg;
		if(hull<=0)
			die();
	}

	void Fire(Transform T) {
		Rigidbody Clone = (Rigidbody) Instantiate(proj, T.position, T.rotation);
		Clone.velocity = Clone.transform.TransformDirection(Vector3.forward * 200f);
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
