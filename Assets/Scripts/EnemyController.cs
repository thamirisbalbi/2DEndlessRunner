using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Mathematics;
public class EnemyController : MonoBehaviour
{
    [SerializeField] private float speed;
    void Update()
    {

        float dx = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(dx, 0, 0);
        if (transform.position.x <= -9.36)
        {
            gameObject.SetActive(false);
        }
    }
}
