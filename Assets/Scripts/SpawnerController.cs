using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefab;
    [SerializeField] private float txSpawnInicial = 12f;
    [SerializeField] private int poolSize = 10;
    [SerializeField] private float spawnMin = 3f; //tx min de spawn
    private ObjectPool enemyPool;
    private float txSpawnAtual;
    private float timer;

    void Start()
    {
        enemyPool = new ObjectPool(enemyPrefab, poolSize);
        timer = 0;
        txSpawnAtual = txSpawnInicial;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= txSpawnAtual) //spawna o inimigo de acordo com a tx de spawn atual
        {
            GameObject obj = enemyPool.GetFromPool();
            if (obj)
            {
                obj.transform.position = transform.position;
                txSpawnAtual = Random.Range(spawnMin, txSpawnInicial);
                timer = 0; //reseta timer 

            }
        }

        Debug.Log("Taxa de spawn atual: " + txSpawnAtual);
    }
}
