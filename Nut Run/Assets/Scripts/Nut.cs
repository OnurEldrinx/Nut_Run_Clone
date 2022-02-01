using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nut : MonoBehaviour
{

    public GameObject nut;
    public bool isCracked;

    private List<GameObject> cells;

    // Start is called before the first frame update
    void Start()
    {

        cells = new List<GameObject>();

        isCracked = false;

        

        for(int i = 0; i < nut.transform.childCount; i++)
        {

            cells.Add(nut.transform.GetChild(i).gameObject);

        }

    }

    // Update is called once per frame
    void Update()
    {

        if (isCracked)
        {

            

            for(int i = 0; i < cells.Count; i++)
            {

                /*cells[i].GetComponent<SphereCollider>().isTrigger = false;
                cells[i].GetComponent<Rigidbody>().useGravity = true;
                cells[i].GetComponent<Rigidbody>().AddExplosionForce(0.2f, nut.transform.position,0.2f);*/

                StartCoroutine(Cell(2f,cells[i]));

            }




        }

    }

    IEnumerator Cell(float time,GameObject g)
    {

        g.GetComponent<SphereCollider>().isTrigger = false;
        g.GetComponent<Rigidbody>().useGravity = true;
        g.GetComponent<Rigidbody>().AddExplosionForce(0.2f, nut.transform.position, 0.2f);
        yield return new WaitForSeconds(time);
        g.SetActive(false);

    }
}
