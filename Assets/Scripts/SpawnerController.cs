using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public ObjectPool enemyPool;
    public float tempoDecorrido;

    void Start()
    {

        enemyPool = new ObjectPool(enemyPrefab, 6);
        tempoDecorrido = 0;
    }


    void Update()
    {
        tempoDecorrido += Time.deltaTime;
        if (tempoDecorrido >= 1)
        {
            GameObject obj = enemyPool.GetFromPool();
            if (obj)
            {
                obj.transform.position = transform.position;
                tempoDecorrido = 0;
            }
        }
    }
}
