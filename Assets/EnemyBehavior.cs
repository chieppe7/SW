using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour{

	#region variables
	protected NavMeshAgent navAgent;
	protected GameObject CurrTarget;

	//public float aggroRadius;

	//Game Object com os colisores para ataque

	#endregion

	#region Monobehaviour methods

	protected void Update(){
		if (this.transform.position.y < -10) {
			Destroy (this.gameObject);
		}

        if (CurrTarget != null) {
			//If the current target is dead, dismiss the target
		
				LookAtTarget ();

					//Raio de ataque
					//print("dist " + (CurrTarget.transform.position - claws.transform.position).magnitude);
					if ((CurrTarget.transform.position - transform.position).magnitude <= navAgent.stoppingDistance) {
						Stop ();
					} else
						Chase ();
		}
		//PATRULHANDO/PARADO
		else
			Stop ();
	}

	protected void Start () {
		if (navAgent == null)
			navAgent = GetComponent<NavMeshAgent>();
		
		CurrTarget = GameObject.FindGameObjectWithTag("Player");

		//GetComponent<SphereCollider> ().radius = aggroRadius;
	}
	#endregion 


	#region EnemyBehaviour methods

	public void Stop(){
		navAgent.isStopped = true;
	}


	/*
	 * Função usada para a perseguição
	 */
	public void Chase(){
		navAgent.isStopped = false;
		navAgent.SetDestination(CurrTarget.transform.position);
	}

	/**
	 * Função usada para sempre encarar o alvo.
	 */
	public void LookAtTarget(){
		Vector3 lookVector = CurrTarget.transform.position - transform.position;
		lookVector.y = 0;

		Quaternion lookRotation = Quaternion.LookRotation (lookVector);//Calcula a rotação para encarar o Alvo

		//Lerp faz a transição da original para a final.
		transform.rotation = Quaternion.Lerp (transform.rotation, lookRotation, Time.deltaTime * 3 );
	}

	#endregion
}

