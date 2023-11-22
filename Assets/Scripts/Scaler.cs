using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaler : MonoBehaviour
{
    public float changeTimeIncrement = 0.01f; // how long between each incremental change in size
    public float changeTime = 0.5f; // total time for complete size change

    // ||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
    public void changeSize(float sizeMult)
    {
        StartCoroutine(manyLilChanges(sizeMult)); // makes it easy to change size from different scripts by the change amount
    } 
    IEnumerator manyLilChanges(float changeAmount)
    {
        
        for(int i = 0; i < changeTime / changeTimeIncrement; i++) // loops for as long as the change total change times
        {
            this.transform.localScale *= 1+(changeAmount/(changeTime / changeTimeIncrement));

            yield return new WaitForSeconds(changeTimeIncrement);
        }
    }
    // ||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
    
    // same as above but for the camera
    public void changeCamSize(float sizeMult)
    {
        StartCoroutine(manyLilCamChanges(sizeMult)); // makes it easy to change size from different scripts by the change amount
    }
    IEnumerator manyLilCamChanges(float changeAmount)
    {
        for (int i = 0; i < changeTime / changeTimeIncrement; i++) // loops for as long as the change total change times
        {
            Camera.main.orthographicSize *= 1+(changeAmount / (changeTime / changeTimeIncrement));

            yield return new WaitForSeconds(changeTimeIncrement);
        }
    }
}
