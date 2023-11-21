using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayOnScreen : MonoBehaviour
{
    // Start is called before the first frame update
    public TrailRenderer tr;
    void Start()
    {
        tr = GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        tr.widthMultiplier = transform.localScale.x;
        Vector3 thisScreenPos = Camera.main.WorldToViewportPoint(this.transform.position);
        
        if (thisScreenPos.x < -0.01|| thisScreenPos.x > 1.01)
        {
            
            this.transform.position = new Vector2((-this.transform.position.x * 0.99f), this.transform.position.y);
            tr.Clear();
        }
        if (thisScreenPos.y < -0.01 || thisScreenPos.y > 1.01)
        {
            
            this.transform.position = new Vector2(this.transform.position.x, (-this.transform.position.y*0.99f));
            tr.Clear();
        }
    }
}
