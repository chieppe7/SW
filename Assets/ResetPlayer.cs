using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayer : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        collision.collider.transform.position = new Vector3(0f, 1f, 0f);
    }
}
