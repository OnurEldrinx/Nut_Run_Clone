using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChocolateDoor : MonoBehaviour
{
   

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "Nut" && other.GetComponent<Nut>().isCracked)
        {

            other.GetComponent<Nut>().isChocolate = true;
            GameManager.Instance.money++;

        }

    }

}
