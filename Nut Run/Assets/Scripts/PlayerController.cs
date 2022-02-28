using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{

    public float speed;
    private float horizontalInput;
    private GameObject finish;
    public bool isOnFinishScreen;
    void Start()
    {

        DOTween.SetTweensCapacity(1500, 50);

        finish = GameObject.Find("Finish");

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

        if (GameManager.Instance.isLevelFinished && Stack.Instance.stackList.Count == 0)
        {

            if (!isOnFinishScreen)
            {
                transform.DOMove(finish.GetComponent<Finish>().finishMoney.transform.position - new Vector3(0,0.25f,0), 3).OnComplete(()=> isOnFinishScreen = true);
                
            }
            transform.GetChild(0).transform.DOLocalRotate(new Vector3(0, 180, 180), 3).OnComplete(()=>finish.GetComponent<Finish>().FinishScreen());
            speed = 0;
        }
        
    }

    private void AutoMoveForward()
    {

        transform.Translate(Vector3.forward * speed * 0.5f * Time.deltaTime);

    }

    void Move()
    {



        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);

        ClampPosition();


    }

    private void ClampPosition()
    {

        AutoMoveForward();

        float c = Mathf.Clamp(transform.position.x, -1f, 1f);

        transform.position = new Vector3(c, transform.position.y, transform.position.z);


    }

}
