using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Bricks : MonoBehaviour
{
    public GameObject brickParticle;

    public virtual void OnCollisionEnter(Collision collision)
    {
            Instantiate(brickParticle, transform.position, Quaternion.identity);
            GM.instance.DestroyBrick();
            Destroy(gameObject);
            GM.instance.score += 10;
    }
}
