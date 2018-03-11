using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCollision : MonoBehaviour {

    public AudioSource AS;

    private void OnCollisionEnter(Collision Col) {
        Ship P = Col.collider.gameObject.GetComponent<Ship>();
        if (P) {
            P.takeDamage(true,false);
            AS.Play();
        }
    }
}
