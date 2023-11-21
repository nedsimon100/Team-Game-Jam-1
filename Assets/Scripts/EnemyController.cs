using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject Player;
    public Rigidbody2D rb;
    public float dashDist = 10f;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if((transform.position-Player.transform.position).magnitude > dashDist)
        {
            rb.velocity = Player.transform.position - transform.position;
        }
        
    }
    
}
