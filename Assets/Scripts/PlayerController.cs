using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("Required Components")]
    public Rigidbody2D rb;
    public Camera sceneCamera;
    public GameObject bullet;

    [Header("Variables")]
    public float fireForce = 5;
    public float topSpeed = 10;
    public bool dead = false;
    public float playerSizeMult = 1.025f;

    [HideInInspector]
    public Vector2 mousePosition;
    // ||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }
    void Aim()
    {
        mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition); // finds mouse position and converts it to a world space co-ordinate
        Vector2 aimDirection = mousePosition - rb.position; // finds mouse position relative to player position
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f; // maths to find which angle the player should be facing
        rb.rotation = aimAngle; // assigning correct rotation to player
    }

    // ||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
    void shoot()
    {

        if (Input.GetMouseButtonDown(0)) // left mouse clicked = true?
        {
            // instantiates a bullet slightly infront of the player and assigns it under the temporary variable "projectile" and offsets projectile by player size so player dosent die when they scale
            GameObject projectile = Instantiate(bullet, this.transform.position+(this.transform.up* this.transform.localScale.y), this.transform.rotation); 
           
            projectile.GetComponent<Rigidbody2D>().AddForce((transform.up) * fireForce, ForceMode2D.Impulse); // adds force to bullet
            this.rb.AddForce(((-transform.up) * fireForce)/2, ForceMode2D.Impulse); // adds force to player (could scale with Player size?)
            sceneCamera.orthographicSize *= 1.02f;// increases screen size (if switched to projection it may be alot smoother by using a rigid body and setting its velocity to (0,0,targetScreenSize - currentPosition.z)
            this.transform.localScale *= playerSizeMult; // increases player size
           
        }
    }
    // ||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
    void Update()
    {
        

        Aim(); // you can probably figure this one out
        shoot();// you can probably figure this one out
        rb.velocity = Vector2.ClampMagnitude(rb.velocity,topSpeed); // prevent player from attaining infinate speed
        
        if (dead) // restarts level on death (Temporary till end screen is implemented
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }
    // ||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
    private void OnCollisionEnter2D(Collision2D collision)
    {
        this.transform.localScale /= 2f; // halfs player size on collision
        if (this.transform.localScale.y < 0.5f)
        {
            dead = true; // kills player if they are under half original size
        }
        Destroy(collision.gameObject); // destroys what hit player so they dont get hit again next frame
    }
}
