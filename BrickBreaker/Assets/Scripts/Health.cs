using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public int health;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        health--;

        // if brick health is zero, brick is destroyed
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }


}
