using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Variables")]
    public float dashDist = 10f;

    [HideInInspector]
    public GameObject Player;
    public Rigidbody2D rb;
    private int enemyType = 1;

    // ||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
    }
    // ||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
    void Update()
    {
        switch (enemyType)
        {
            case 1:
                enemy1Update(); // so its easier to add more enemy types
                break;
        }
        
        
    }
    // ||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||

    public void enemy1Update() // basic enemy that only moves towards the player
    {
        dartMovement();
    }
    // ||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||

    public void dartMovement()
    {
        if ((transform.position - Player.transform.position).magnitude > dashDist) // basic movement script for enemies that rush player
        {
            rb.velocity = Player.transform.position - transform.position; // aims at player and dashes towards them but stops changing direction if in certain radius of player
        }
    }
    
}
