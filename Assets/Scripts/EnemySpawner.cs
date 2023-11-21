using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> enemies = new List<GameObject>();

    public int hardestEnemyIndex=1;
    public float spawnTimerMin=1f, spawnTimerMax=5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("spawnTimer");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Time.timeSinceLevelLoad%20 == 20 && hardestEnemyIndex < enemies.Count - 1)
        {
            hardestEnemyIndex++;
            spawnTimerMin *= 0.9f;
            spawnTimerMax *= 0.95f;
        }
       
    }
    IEnumerator spawnTimer()
    {
        while(true)
        {
            Instantiate(enemies[Random.Range(0, hardestEnemyIndex)], new Vector3(Camera.main.ViewportToWorldPoint(new Vector2(Random.Range(1.2f, 2f),0)).x, Camera.main.ViewportToWorldPoint(new Vector2(0, Random.Range(-1f, 2f))).y, 0), this.transform.rotation);
            yield return new WaitForSeconds(Random.Range(spawnTimerMin,spawnTimerMax));
        }
    }
}
