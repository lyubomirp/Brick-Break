using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        GM.instance.LoseLife();
        Destroy(collision.gameObject);
    }
}
