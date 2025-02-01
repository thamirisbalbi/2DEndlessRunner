using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public ObjectPool enemyPool;
    public float timePassed;

    void Start()
    {

        enemyPool = new ObjectPool(enemyPrefab, 6);
        timePassed = 0;
    }


    void Update()
    {
        timePassed += Time.deltaTime;
        if (timePassed >= 1)
        {
            GameObject obj = enemyPool.GetFromPool();
            if (obj)
            {
                obj.transform.position = transform.position;
                timePassed = 0;
            }
        }
    }
}
