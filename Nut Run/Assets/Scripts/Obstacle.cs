using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
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

        if (other.tag == "StackParent")
        {

            for (int i = 0; i < Stack.Instance.stackList.Count; i++)
            {

                Stack.Instance.stackList[i].GetComponent<BoxCollider>().enabled = true;

            }

        }

        if (other.tag == "Nut" && this.gameObject.tag == "Puncher")
        {

            int index = Stack.Instance.stackList.IndexOf(other.gameObject);

            int counter=0;

            for(int i = Stack.Instance.stackList.Count-1; i >= index; i--)
            {

                Stack.Instance.stackList[i].SetActive(false);
                Stack.Instance.stackList[i].transform.parent = null;
                Stack.Instance.stackList.RemoveAt(i);
                counter++;

            }

            if (Stack.Instance.stackParentCollider.size.z >= (counter*other.GetComponent<BoxCollider>().size.z))
            {
                Stack.Instance.stackParentCollider.size -= new Vector3(0, 0, counter * other.GetComponent<BoxCollider>().size.z);
                Stack.Instance.stackParentCollider.center -= new Vector3(0, 0, counter * (other.GetComponent<BoxCollider>().size.z / 2));
            }

            if (index - 1 >= 0)
            {
                Stack.Instance.previous = Stack.Instance.stackList[index - 1];
            }
            else
            {

                Stack.Instance.previous = Stack.Instance.stackParent;

            }

            GameManager.Instance.money -= counter * 1;


        }

    }

}
