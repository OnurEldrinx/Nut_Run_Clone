using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PriceTag : MonoBehaviour
{

    public Image priceTagImg;

    

    // Update is called once per frame
    void FixedUpdate()
    {

        Vector3 p = Camera.main.WorldToScreenPoint(this.transform.position);
        priceTagImg.transform.position = p;

        if (GameManager.Instance.isLevelFinished)
        {

            priceTagImg.gameObject.SetActive(false);

        }

    }
}
