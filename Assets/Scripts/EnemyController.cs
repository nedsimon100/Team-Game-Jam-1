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

    // ||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
    }
    // ||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
    void Update()
    {
        if((transform.position-Player.transform.position).magnitude > dashDist)
        {
            rb.velocity = Player.transform.position - transform.position; // aims at player and dashes towards them but stops changing direction if in certain radius of player
        }
        
    }
    
}
