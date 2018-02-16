using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MissileP : MonoBehaviour {

    private NavMeshAgent NavMesh;
    private GameObject[] T;
    private Transform tgt;

	// Use this for initialization
	void Awake () {
        NavMesh = gameObject.GetComponent<NavMeshAgent>();
        T = GameObject.FindGameObjectsWithTag("Enemy");
        tgt = GetClosestEnemy(T);
        StartCoroutine(Die());
	}



    private void Update() {
        if (this.transform.position.y < -10) {
			Destroy (this.gameObject);
		}

        if (tgt != null) {
			//If the current target is dead, dismiss the target
		
				LookAtTarget ();

					//Raio de ataque
					//print("dist " + (CurrTarget.transform.position - claws.transform.position).magnitude);
					if ((tgt.transform.position - transform.position).magnitude <= NavMesh.stoppingDistance) {
						Stop ();
					} else
						Chase ();
		}
		//PATRULHANDO/PARADO
		else
			Stop ();
    }

    public void Stop(){
		NavMesh.isStopped = true;
	}

    public void Chase(){
		NavMesh.isStopped = false;
		NavMesh.SetDestination(tgt.position);
	}

    public void LookAtTarget(){
		Vector3 lookVector = tgt.transform.position - transform.position;
		lookVector.y = 0;

		Quaternion lookRotation = Quaternion.LookRotation (lookVector);//Calcula a rotação para encarar o Alvo

		//Lerp faz a transição da original para a final.
		transform.rotation = Quaternion.Lerp (transform.rotation, lookRotation, Time.deltaTime * 3 );
	}

    private void OnTriggerEnter(Collider other) {
        EnemyShip IAtgt = other.gameObject.GetComponent<EnemyShip>();
        if (IAtgt)
            IAtgt.takeDamage(false, true);
        if(other.gameObject.layer != 0 )
		    Destroy(this.gameObject);
    }

    IEnumerator Die(){
		yield return new WaitForSeconds(10f);
		Destroy(this.gameObject);
	}

    Transform GetClosestEnemy(GameObject[] enemies) {
        Transform tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (GameObject t in enemies) {
            float dist = Vector3.Distance(t.transform.position, currentPos);
            if (dist < minDist) {
                tMin = t.transform;
                minDist = dist;
            }
        }
        return tMin;
    }
}
