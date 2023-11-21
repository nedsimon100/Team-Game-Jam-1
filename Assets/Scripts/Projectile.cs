using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;


    public Rigidbody2D rb;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag != "Player") 
        {
        
            Destroy(collision.gameObject);
            
            Camera.main.orthographicSize /= 1.025f;
        }

        Destroy(this.gameObject);
    }
}
