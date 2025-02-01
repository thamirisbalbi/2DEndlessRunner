using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefab;
    [SerializeField] private float txSpawnInicial = 12f;
    [SerializeField] private float spawnMin = 3f; //tx min de spawn
    [SerializeField] private float aumentoSpawn = 2f;
    private ObjectPool enemyPool;
    private float txSpawnAtual;
    private float timer;

    void Start()
    {
        enemyPool = new ObjectPool(enemyPrefab, 5);
        timer = 0;
        txSpawnAtual = txSpawnInicial;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (txSpawnAtual - aumentoSpawn < spawnMin)
        {
            txSpawnAtual = txSpawnInicial; //reseta dificuldade ao longo do tempo, se chegar no min possivel com os valores setados
        }

        if (timer >= txSpawnAtual)
        {
            GameObject obj = enemyPool.GetFromPool();
            if (obj)
            {
                obj.transform.position = transform.position;
                txSpawnAtual = Mathf.Max(txSpawnAtual - aumentoSpawn, spawnMin);//diminui intervalo de spawn ao aumentar spawn rate
                timer = 0; //reseta timer

            }
        }
    }

}
