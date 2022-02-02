using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Packer : MonoBehaviour
{

    public GameObject packerEnd;

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

        if (other.tag == "Nut" && other.GetComponent<Nut>().isNutCelled)
        {

            other.GetComponent<Nut>().isPackaged = true;
            GameManager.Instance.money++;
            StartCoroutine(ResetPacker(0.1f));

        }

    }

    IEnumerator ResetPacker(float time)
    {
        packerEnd.GetComponent<Animator>().Play("PackerAnim");
        yield return new WaitForSeconds(time);
        packerEnd.GetComponent<Animator>().Play("Ready");

    }
}
