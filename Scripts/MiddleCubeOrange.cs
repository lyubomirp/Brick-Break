using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleCubeOrange : Bricks {

    public TextMesh livesText;
    public int lives = 5;

    public override void OnCollisionEnter(Collision collision)
    {
        lives--;
        livesText.text = "" + lives;
        if (lives < 1)
        {
            Instantiate(brickParticle, transform.position, Quaternion.identity);
            GM.instance.DestroyBrick();
            Destroy(gameObject);
            GM.instance.score += 50;
        }
    }
}
