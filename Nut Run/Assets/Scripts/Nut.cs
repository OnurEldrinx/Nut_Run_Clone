using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Nut : MonoBehaviour
{

    public static Nut Instance;

    public GameObject nut;
    public bool isCracked;
    public bool isChocolate;
    public bool isNutCelled;
    public bool isPackaged;

    public bool isCrackedDone;
    public bool isChocoDone;

    public bool isCelledDone;

    public bool isPackagedDone;

    public bool isCollected;

    public bool isHeartBoxed;

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

            isChocoDone = true;

        }

        if (isNutCelled)
        {

            currentNutModel.SetActive(false);

            currentNutModel = NutModels[3];

            currentNutModel.SetActive(true);

            isCelledDone = true;


        }

        if (isPackaged)
        {

            currentNutModel.SetActive(false);

            currentNutModel = NutModels[4];

            currentNutModel.SetActive(true);

            isPackagedDone = true;

        }

    }

    IEnumerator Cell(float time,GameObject g)
    {

        g.GetComponent<SphereCollider>().isTrigger = false;
        g.GetComponent<Rigidbody>().useGravity = true;
        g.GetComponent<Rigidbody>().AddExplosionForce(0.2f, nut.transform.position, 0.2f);
        yield return new WaitForSeconds(time);
        g.SetActive(false);
        isCrackedDone = true;



    }

    private void OnTriggerExit(Collider other)
    {
        
        if(other.tag == "FinishLine")
        {

            

            if (!isPackaged)
            {

                gameObject.SetActive(false);
                Stack.Instance.stackList.Remove(this.gameObject);
            }
            else
            {

                if (GameObject.Find("Finish").GetComponent<Finish>().counter < GameObject.Find("Finish").GetComponent<Finish>().heartBoxes.Count)
                {
                    transform.parent = null;
                    transform.DOMove(GameObject.Find("Finish").GetComponent<Finish>().heartBoxes[GameObject.Find("Finish").GetComponent<Finish>().counter].transform.localPosition + new Vector3(0, 0.075f, 0), 0.5f).OnComplete(() => Stack.Instance.stackList.Remove(this.gameObject));
                    //Debug.Log(GameObject.Find("Finish").GetComponent<Finish>().heartBoxes[GameObject.Find("Finish").GetComponent<Finish>().heartBoxes.Count - 1].transform.localPosition);
                    //transform.position = GameObject.Find("Finish").GetComponent<Finish>().heartBoxes[GameObject.Find("Finish").GetComponent<Finish>().heartBoxes.Count - 1].transform.position;
                    //GameObject.Find("Finish").GetComponent<Finish>().heartBoxes.RemoveAt(GameObject.Find("Finish").GetComponent<Finish>().heartBoxes.Count-1);
                    GameObject.Find("Finish").GetComponent<Finish>().counter++;
                    GameManager.Instance.money += 50;

                }
                else
                {

                    gameObject.SetActive(false);
                    Stack.Instance.stackList.Remove(this.gameObject);

                }



            }

        }

    }


}
