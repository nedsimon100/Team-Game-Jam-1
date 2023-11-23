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
    public float playerSizeMult = 0.05f;

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
            this.GetComponent<Scaler>().changeCamSize(0.01f); // changes player size using scaler script
            this.GetComponent<Scaler>().changeSize(playerSizeMult); // changes player size using scaler script
           
        }
    }
    // ||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
    void Update()
    {
        

        Aim(); // you can probably figure this one out
        shoot();// you can probably figure this one out
        rb.velocity = Vector2.ClampMagnitude(rb.velocity,topSpeed); // prevent player from attaining infinate speed
        checkDead();
        colourChanger();
    }
    // ||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
    public void checkDead()
    {
        if (this.transform.localScale.y < 0.5f)//*camera.main.orthegraphicSize/10
        {
            dead = true; // kills player if they are under half original size
        }

        if (dead) // restarts level on death (Temporary till end screen is implemented
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    // ||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
    public void colourChanger()
    {
        Color colour = new Color(0.25f / transform.localScale.y, transform.localScale.y*0.25f, transform.localScale.x* 0.25f); // changes player color based off of size as form of health bar
        this.gameObject.GetComponent<TrailRenderer>().startColor = colour; // sets trail color to match player
        this.gameObject.GetComponent<SpriteRenderer>().color = colour; // sets player color
    }
    // ||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||

    private void OnCollisionEnter2D(Collision2D collision)
    {
        this.GetComponent<Scaler>().changeSize(-0.5f); // halfs player size on collision

        Destroy(collision.gameObject); // destroys what hit player so they dont get hit again next frame
    }
}
