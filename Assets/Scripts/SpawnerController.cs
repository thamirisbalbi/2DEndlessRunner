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
        enemyPool = new ObjectPool(enemyPrefab, 10);
        timer = 0;
        txSpawnAtual = txSpawnInicial;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= txSpawnAtual)
        {
            GameObject obj = enemyPool.GetFromPool();
            if (obj)
            {
                obj.transform.position = transform.position;
                txSpawnAtual = Mathf.Max(txSpawnAtual - aumentoSpawn, spawnMin);//diminui intervalo de spawn ao aumentar spawn rate
                //se a subtração retornar menor que o min, sempre retorno o min(que sera o valor max)
                timer = 0; //reseta timer 

            }
        }
        if (txSpawnAtual == spawnMin)
        {
            txSpawnAtual = Random.Range(txSpawnInicial, spawnMin); //-1
            timer = 0;
        } //variando tx spawn atual
        Debug.Log("Taxa de spawn atual: " + txSpawnAtual);
    }
    //if enemypool
}
