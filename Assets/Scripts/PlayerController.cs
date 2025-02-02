using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float minLimit;
    [SerializeField] private float maxLimit;
    [SerializeField] private float gravity;
    [SerializeField] private float impulse; //afeta vel em y
    private float x;
    private bool isPressed; //controle de bug: não andar com ambas as teclas pressionadas 
    private bool jumping;
    private float ground;
    private float yVel;
    void Start()
    {
        ground = transform.position.y;
        isPressed = false;
        jumping = false;
        yVel = 0;


    }

    void Update()
    {
        x = transform.position.x;
        float dx = Input.GetAxis("Horizontal") * speed * Time.deltaTime;//pego informações para deslocamento em x

        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))//checo a cada frame se está sendo pressionado ao mesmo tempo
            isPressed = true;
        else
            isPressed = false;

        float newX = transform.position.x + dx;
        if (newX <= minLimit || newX >= maxLimit)
            dx = 0;
        if (!isPressed)
        {
            if (x > minLimit && x < maxLimit)
            {
                if (Input.GetKey(KeyCode.A)) // retorna -1
                    transform.Translate(dx, 0, 0);
                if (Input.GetKey(KeyCode.D)) //retorna 1
                    transform.Translate(dx, 0, 0);
            }
        }
        if (jumping)
        {
            if (transform.position.y <= ground)
            {
                transform.position = new Vector3(transform.position.x, ground, 0);
                jumping = false;
                yVel = 0;
            }
            else
            {
                yVel -= gravity * Time.deltaTime; //cair mais rápido 
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                yVel = impulse;
                jumping = true;

            }
        }

        float dy = yVel * Time.deltaTime;
        transform.Translate(dx, dy, 0);
        //enemys spawners
        // parallax com chão, e background
        //sistema de score aparecendo em tela
        //telas de inicio e de score ao final da partida, comparando com outras jogadas prévias.
        //animação personagem
    }

}
