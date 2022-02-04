using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NutCellMachine : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Nut" && other.GetComponent<Nut>().isChocolate)
        {

            other.GetComponent<Nut>().isNutCelled = true;
            GameManager.Instance.money++;

        }

    }


   

}
