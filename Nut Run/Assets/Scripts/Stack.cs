using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Stack : MonoBehaviour
{

    public static Stack Instance;

    public GameObject stackParent;
    public GameObject previous;
    public List<GameObject> stackList;
    public BoxCollider stackParentCollider;


    private void Awake()
    {
        
        if(Instance == null)
        {

            Instance = this;

        }

    }

    // Start is called before the first frame update
    void Start()
    {

        stackParentCollider = stackParent.GetComponent<BoxCollider>();

    }

    // Update is called once per frame
    void Update()
    {

        if (stackList.Count > 1)
        {

            WaveMovement();

        }

    }

    public void WaveMovement()
    {

        for(int i = 0; i < stackList.Count; i++)
        {

            if ((i + 1) < stackList.Count)
            {
                stackList[i+1].transform.DOMoveX(stackList[i].transform.position.x, 0.05f).SetEase(Ease.InOutSine);
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "Nut")
        {


            //other.transform.rotation = stackParent.transform.rotation;
            other.transform.parent = previous.transform;

            if (stackList.Count == 0)
            {
                other.transform.localPosition = new Vector3(0, 0, 0);

            }
            else
            {
                other.transform.localPosition = new Vector3(0, 0, previous.transform.localScale.z);
                stackParentCollider.size += new Vector3(0,0,other.GetComponent<BoxCollider>().size.z);
                stackParentCollider.center += new Vector3(0,0, other.GetComponent<BoxCollider>().size.z / 2);
            }

            previous = other.gameObject;
            stackList.Add(other.gameObject);
            other.gameObject.GetComponent<BoxCollider>().enabled = false;

        }

    }

}
