using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [HideInInspector]
    public GameObject Player;
    public Rigidbody2D rb;
    // ||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        rb = this.GetComponent<Rigidbody2D>(); 
    }
    // ||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag != "Player") 
        {
        
            Destroy(collision.gameObject); // destroys anything that gets hit other than the player
            
            Camera.main.orthographicSize /= 1.025f; // reduces screen size on every collision
        }

        Destroy(this.gameObject); // destroys projectile
    }
}
