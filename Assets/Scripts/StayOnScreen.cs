using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayOnScreen : MonoBehaviour
{
    [HideInInspector]
    public TrailRenderer tr;
    // ||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||

    void Start()
    {
        tr = GetComponent<TrailRenderer>();
    }
    // ||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||

    void Update()
    {
        tr.widthMultiplier = transform.localScale.x; // changes trail size to match objects width
        Vector3 thisScreenPos = Camera.main.WorldToViewportPoint(this.transform.position); // converts object transform to screen point
        
        if (thisScreenPos.x < -0.01|| thisScreenPos.x > 1.01) // checks if player is off either side of the screen
        {
            // flips x position but only 99% so that it dosent teleport back on the frame straight after
            this.transform.position = new Vector2((-this.transform.position.x * 0.99f), this.transform.position.y); 
            tr.Clear(); // clears trail renderer to prevent lines accross screen
        }
        if (thisScreenPos.y < -0.01 || thisScreenPos.y > 1.01)// same as above but for y position
        {
            
            this.transform.position = new Vector2(this.transform.position.x, (-this.transform.position.y*0.99f));
            tr.Clear();
        }
    }
}
