using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandySpawner : MonoBehaviour
{
    [SerializeField] float maxX;
    [SerializeField] float spawnInterval;
    [SerializeField] GameObject[] Candies;
    public static CandySpawner instance;
    public float level;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        StartSpawningCandies();
    }


    void Update()
    {
    }

    void SpawnCandy()
    {
        int randCandy = Random.Range(0, Candies.Length);
        float randX = Random.Range(-maxX, maxX);
        Vector3 randPos = new Vector3(randX, transform.position.y, transform.position.z);
        Instantiate(Candies[randCandy], randPos, transform.rotation);
    }

    IEnumerator SpawnCandies()
    {
        yield return new WaitForSeconds(.05f);

        while (true)
        {
            SpawnCandy();
            spawnInterval -= .005f;
            spawnInterval = Mathf.Clamp(spawnInterval, .50f, 2);
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public void StartSpawningCandies()
    {
        StartCoroutine("SpawnCandies");
    }

    public void StopSpawningCandies()
    {
        StopCoroutine("SpawnCandies");
    }

}
