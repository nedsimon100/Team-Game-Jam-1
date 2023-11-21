using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Camera sceneCamera;
    public Vector2 mousePosition;
    public GameObject bullet;
    public float fireForce = 5;
    public float topSpeed = 10;
    private float shootOffset = 1;
    public bool dead = false;
    public float playerSizeMult = 1.025f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }
    void Aim()
    {
        mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
    }
    // Update is called once per frame
    void shoot()
    {

        if (Input.GetMouseButtonDown(0))
        {
            GameObject projectile = Instantiate(bullet, this.transform.position+(this.transform.up*shootOffset), this.transform.rotation);
           
            projectile.GetComponent<Rigidbody2D>().AddForce((transform.up) * fireForce, ForceMode2D.Impulse);
            this.rb.AddForce(((-transform.up) * fireForce)/2, ForceMode2D.Impulse);
            sceneCamera.orthographicSize *= 1.02f;
            this.transform.localScale *= playerSizeMult;
            shootOffset *= playerSizeMult;
        }
    }
    void Update()
    {
        

        Aim();
        shoot();
        rb.velocity = Vector2.ClampMagnitude(rb.velocity,topSpeed);
        
        if (dead)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        this.transform.localScale /= 2f;
        shootOffset /= 2f;
        if (this.transform.localScale.y < 0.4f)
        {
            dead = true;
        }
        Destroy(collision.gameObject);
    }
}
