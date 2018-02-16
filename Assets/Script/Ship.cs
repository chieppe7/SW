using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ship : MonoBehaviour {

	//ship properties
	public string Name;
	public int hull;
	public int shield;
	public int power;
	public float engine;
	public float Speed;
    private float BSpeed;
    private float ASpeed;
	public float turnSpeed;
    public float Throttle;
    public Image HB;
    public Image FuelCanvas;
    public int Fuel;
    public float BoostF;

    public GameObject Explode;

	private Rigidbody rig;

	// Use this for initialization
	void Start () {
		rig = gameObject.GetComponent<Rigidbody>();
        BSpeed = 2f * Speed;
        ASpeed = Speed;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Boost")) {
            Boost();
        }
		move();
        HB.fillAmount = (float)shield / 3f;
	}

    void Boost() {
        float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");
        Throttle = h * h + v * v;
        if (Throttle < 0.1 || Fuel <= 0)
            return;
        Fuel--;
        FuelCanvas.fillAmount = (float)Fuel / 3f;
        Vector3 BoostV = new Vector3(h, 0f, v);
        rig.AddForce(BoostV*BoostF, ForceMode.Impulse);
        StartCoroutine(Spidi());
    }

    IEnumerator Spidi() {
        ASpeed = BSpeed;
        yield return new WaitForSeconds(1f);
        ASpeed = Speed;
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

	void die() {
        Instantiate(Explode, this.transform.position, this.transform.rotation);
		Destroy(this.gameObject);
	}

	void move() {
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");
        Throttle = h * h + v * v;
		if(Throttle<0.1){
			return;
		}
		//anim.SetBool("IsMoving",true);

		Vector3 movement = new Vector3(h, 0.0f, v);

		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), turnSpeed);
		rig.AddForce(movement*engine, ForceMode.Acceleration);
		rig.velocity=Vector3.ClampMagnitude(rig.velocity, ASpeed);
	}
}
