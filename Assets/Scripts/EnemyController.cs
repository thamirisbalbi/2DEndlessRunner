using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using System;
using Unity.Mathematics;
public class EnemyController : MonoBehaviour
{
    [SerializeField] private float speed;


    void Update()
    {

        transform.Translate(-speed * Time.deltaTime, 0, 0, Space.World);
        if (transform.position.x <= -9.36)
        {
            gameObject.SetActive(false);

        }
    }
}
