using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nut : MonoBehaviour
{

    public static Nut Instance;

    public GameObject nut;
    public bool isCracked;
    public bool isChocolate;
    public bool isNutCelled;
    public bool isPackaged;

    private List<GameObject> cells;

    public GameObject[] NutModels;
    public GameObject currentNutModel;

    private void Awake()
    {

        if (Instance == null)
        {

            Instance = this;

        }

    }

    // Start is called before the first frame update
    void Start()
    {

        cells = new List<GameObject>();

        isCracked = false;

        currentNutModel = NutModels[0];

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

            

            foreach (GameObject c in cells)
            {


                c.transform.parent = null;

            }

            currentNutModel.SetActive(false);

            for (int i = 0; i < cells.Count; i++)
            {

                
                /*cells[i].GetComponent<SphereCollider>().isTrigger = false;
                cells[i].GetComponent<Rigidbody>().useGravity = true;
                cells[i].GetComponent<Rigidbody>().AddExplosionForce(0.2f, nut.transform.position,0.2f);*/

                StartCoroutine(Cell(2f,cells[i]));

            }

            currentNutModel = NutModels[1];
            currentNutModel.SetActive(true);
            
        }


        if (isChocolate)
        {

            currentNutModel.SetActive(false);

            currentNutModel = NutModels[2];

            currentNutModel.SetActive(true);

        }

        if (isNutCelled)
        {

            currentNutModel.SetActive(false);

            currentNutModel = NutModels[3];

            currentNutModel.SetActive(true);


        }

        if (isPackaged)
        {

            currentNutModel.SetActive(false);

            currentNutModel = NutModels[4];

            currentNutModel.SetActive(true);

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
