using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
   

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "StackParent")
        {

            for (int i = 0; i < Stack.Instance.stackList.Count; i++)
            {

                Stack.Instance.stackList[i].GetComponent<BoxCollider>().enabled = true;

            }

        }


        // Puncher
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


        //Fire Machine
        if(other.tag == "Nut" && this.gameObject.tag == "FireMachine")
        {


            if(other.gameObject.GetComponent<Nut>().isChocolate && !other.gameObject.GetComponent<Nut>().isNutCelled && !other.gameObject.GetComponent<Nut>().isPackaged)
            {

                Nut.Instance.currentNutModel.SetActive(false);

                Nut.Instance.currentNutModel = Nut.Instance.NutModels[1];

                Nut.Instance.currentNutModel.SetActive(true);

                other.gameObject.GetComponent<Nut>().isChocolate = false;
                GameManager.Instance.money -= 5;

            }

        }

        //Obstacle Hand
        if(other.tag == "Nut" && this.gameObject.tag == "ObstacleHand")
        {

            int counter = 0;


            for (int i = Stack.Instance.stackList.Count - 1; i >= 0; i--)
            {

                Stack.Instance.stackList[i].SetActive(false);
                Stack.Instance.stackList[i].transform.parent = null;
                Stack.Instance.stackList.RemoveAt(i);
                counter++;

            }

            if (Stack.Instance.stackParentCollider.size.z >= (counter * other.GetComponent<BoxCollider>().size.z))
            {
                Stack.Instance.stackParentCollider.size -= new Vector3(0, 0, counter * other.GetComponent<BoxCollider>().size.z);
                Stack.Instance.stackParentCollider.center -= new Vector3(0, 0, counter * (other.GetComponent<BoxCollider>().size.z / 2));
            }

            

            Stack.Instance.previous = Stack.Instance.stackParent;

            GameManager.Instance.money -= counter * 1;

        }


    }

}
