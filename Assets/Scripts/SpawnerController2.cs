using UnityEngine;

public class SpawnerController2 : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float minRange;
    [SerializeField] private float maxRange;
    [SerializeField] private float spawnTime = 10;
    [SerializeField] private int poolSize = 5;

    private ObjectPool enemyPool;
    [SerializeField] private float timer;

    void Start()
    {
        enemyPool = new ObjectPool(enemyPrefab, poolSize);
        timer = 0;
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnTime)
        {
            GameObject obj = enemyPool.GetFromPool();
            if (obj)
            {
                float randomY = Random.Range(minRange, maxRange);
                obj.transform.position = new Vector3(transform.position.x, randomY, 0);
                float dy = Random.Range(minRange, maxRange);
                obj.transform.Translate(0, dy, 0);
                timer = 0;
                Debug.Log("Random y: " + dy);
            }
        }
    }
}
