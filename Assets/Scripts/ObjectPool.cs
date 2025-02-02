using UnityEngine;
using System.Collections.Generic;

public class ObjectPool
{
    private GameObject[] prefabs;
    private Queue<GameObject> queue;
    private int poolSize;


    public ObjectPool(GameObject prefab, int poolSize)
    {
        this.prefabs = new GameObject[] { prefab }; //no caso de ser apenas um prefab
        this.poolSize = poolSize;
        queue = new Queue<GameObject>();
        InitializePool();
    }

    public ObjectPool(GameObject[] prefabs, int poolSize) //mais de um prefab
    {
        this.prefabs = prefabs;
        this.poolSize = poolSize;
        InitializePool();
    }
    private void InitializePool()
    {
        queue = new Queue<GameObject>();

        for (int i = 0; i < this.poolSize; i++)
        {
            //Escolhe prefab aleatorio do array
            GameObject randomPrefab = prefabs[Random.Range(0, prefabs.Length)];

            GameObject obj = Object.Instantiate(randomPrefab);
            obj.SetActive(false);
            queue.Enqueue(obj);
            //objetivo: fila instanciada aleatoriamente a partir dos dois prefabs
        }
    }
    public GameObject GetFromPool()
    {
        GameObject obj = queue.Peek();
        if (!obj.activeSelf)
        {
            queue.Dequeue(); //se nao ativo, remove do inicio da fila
            queue.Enqueue(obj); //coloca obj no fim da fila
            obj.SetActive(true); //coloca obj como ativo 
            return obj;
        }
        return null;
    }




}

