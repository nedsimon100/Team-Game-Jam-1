using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> enemies = new List<GameObject>(); // list of enemies so lots can be added without any code changes

    public int hardestEnemyIndex=1;
    public float spawnTimerMin=1f, spawnTimerMax=5f;

    // ||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||

    void Start()
    {
        StartCoroutine("spawnTimer"); // a random timer to spawn more enimies
    }

    // ||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||

    void FixedUpdate()
    {
        if(Time.timeSinceLevelLoad%20 == 20 && hardestEnemyIndex < enemies.Count - 1) // every 20 seconds stronger enemies can spawn
        {
            hardestEnemyIndex++;
            spawnTimerMin *= 0.9f; // reduces min and max spwan timer
            spawnTimerMax *= 0.95f;
        }
       
    }
    // ||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||

    IEnumerator spawnTimer()
    {
        while(true)
        {
            // spawns enemy at random offscreen position to right which is then switched around the camera by the stay on screen script until its visible
            Instantiate(enemies[Random.Range(0, hardestEnemyIndex)], new Vector3(Camera.main.ViewportToWorldPoint(new Vector2(Random.Range(1.2f, 2f),0)).x, Camera.main.ViewportToWorldPoint(new Vector2(0, Random.Range(-1f, 2f))).y, 0), this.transform.rotation);

            yield return new WaitForSeconds(Random.Range(spawnTimerMin,spawnTimerMax));
        }
    }
}
