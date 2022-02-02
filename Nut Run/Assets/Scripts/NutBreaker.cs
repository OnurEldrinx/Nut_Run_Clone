using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NutBreaker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "StackParent")
        {

            for(int i=0;i< Stack.Instance.stackList.Count; i++)
            {

                Stack.Instance.stackList[i].GetComponent<BoxCollider>().enabled = true;

            }

        }

        if(other.tag == "Nut" && other.GetComponent<Nut>().isCracked == false)
        {


            other.GetComponent<Nut>().isCracked = true;
            GameManager.Instance.money++;

        }

    }
}
