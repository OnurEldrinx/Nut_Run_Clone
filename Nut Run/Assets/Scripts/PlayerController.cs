using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    private float horizontalInput;

    void Start()
    {
        
    }

    void Update()
    {

        horizontalInput = Input.GetAxis("Horizontal");


        if (horizontalInput != 0)
        {

            GameManager.Instance.isGameStarted = true;

        }

        if (GameManager.Instance.isGameStarted)
        {
            
            Move();
        

        }
        
    }

    private void AutoMoveForward()
    {

        transform.Translate(Vector3.forward * speed * 0.5f * Time.deltaTime);

    }

    void Move()
    {

        AutoMoveForward();


        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);



    }
}
