using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongCube : Bricks {

    public TextMesh livesText;
    public int lives = 7;

    public override void OnCollisionEnter(Collision collision)
    {
        lives--;
        livesText.text = "" + lives;
        switch (lives)
        {
            case 3:
                Destroy(gameObject);
                Instantiate(GM.instance.cubes[1], transform.position, Quaternion.identity);
                break;
            case 1:
                Destroy(gameObject);
                Instantiate(GM.instance.cubes[0], transform.position, Quaternion.identity);
                break;
        }
    }
}
