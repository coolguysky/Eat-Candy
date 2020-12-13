using System.Collections;
using UnityEngine;

public class CandySpawner : MonoBehaviour
{
    [SerializeField] float maxX;
    [SerializeField] float spawnInterval;
    [SerializeField] GameObject[] candies;
    public static CandySpawner instance;
    public float level;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        StartSpawningCandies();
    }
    private void SpawnCandy()
    {
        int randCandy = Random.Range(0, candies.Length);
        float randX = Random.Range(-maxX, maxX);
        Vector3 randPos = new Vector3(randX, transform.position.y, transform.position.z);
        Instantiate(candies[randCandy], randPos, transform.rotation);
    }
    private IEnumerator SpawnCandies()
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
        StartCoroutine(nameof(SpawnCandies));
    }
    public void StopSpawningCandies()
    {
        StopCoroutine(nameof(SpawnCandies));
    }
}
