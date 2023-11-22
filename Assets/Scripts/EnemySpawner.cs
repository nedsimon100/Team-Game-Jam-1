using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> enemies = new List<GameObject>(); // list of enemies so lots can be added without any code changes

    public int hardestEnemyIndex=1;
    public float spawnTimerMin=1f, spawnTimerMax=3f;

    // ||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||

    void Start()
    {
        StartCoroutine("spawnTimer"); // a random timer to spawn more enimies
    }

    // ||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||

    void FixedUpdate()
    {
        if(Time.timeSinceLevelLoad%20 == 20) // every 20 seconds stronger enemies can spawn
        {
            if(hardestEnemyIndex < enemies.Count - 1)
            {
                hardestEnemyIndex++;
            }
            spawnTimerMin *= 0.9f; // reduces min and max spwan timer
            spawnTimerMax *= 0.95f;
        }
       
    }
    // ||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||

    IEnumerator spawnTimer()
    {
        while(true)
        {
            
            int side = Random.Range(0, 4); // finds random number to decide which side to spawn on
            switch (side)
            {
                case 0:
                    Instantiate(enemies[Random.Range(0, hardestEnemyIndex)], Camera.main.ViewportToWorldPoint(new Vector3(1.1f, Random.Range(0f, 1f))), this.transform.rotation);
                    break;
                case 1:
                    Instantiate(enemies[Random.Range(0, hardestEnemyIndex)], Camera.main.ViewportToWorldPoint(new Vector3(-0.1f, Random.Range(0f, 1f))), this.transform.rotation);
                    break;
                case 2:
                    Instantiate(enemies[Random.Range(0, hardestEnemyIndex)], Camera.main.ViewportToWorldPoint(new Vector3( Random.Range(0f, 1f), 1.1f)), this.transform.rotation);
                    break;
                case 3:
                    Instantiate(enemies[Random.Range(0, hardestEnemyIndex)], Camera.main.ViewportToWorldPoint(new Vector3( Random.Range(0f, 1f), -0.1f)), this.transform.rotation);
                    break;
            }
            

            yield return new WaitForSeconds(Random.Range(spawnTimerMin,spawnTimerMax));
        }
    }
}
