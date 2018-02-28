using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryBottom : MonoBehaviour {
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Game Over");
        FindObjectOfType<GameManager>().SceneLoader(1);
    }
}
