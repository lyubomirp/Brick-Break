using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleCubeB : Bricks {

    public TextMesh livesText;
    public int lives = 3;

    public override void OnCollisionEnter(Collision collision)
    {
        lives--;
        livesText.text = "" + lives;
        if (lives == 1)
        {
            Destroy(gameObject);
            Instantiate(GM.instance.cubes[5], transform.position, Quaternion.identity);
        }
    }
}
