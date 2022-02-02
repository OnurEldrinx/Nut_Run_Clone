using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChocolateDoor : MonoBehaviour
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
        
        if(other.tag == "Nut" && other.GetComponent<Nut>().isCracked)
        {

            other.GetComponent<Nut>().isChocolate = true;
            GameManager.Instance.money++;

        }

    }

}
