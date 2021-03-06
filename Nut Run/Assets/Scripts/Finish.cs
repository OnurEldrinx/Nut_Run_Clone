using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    // Start is called before the first frame update

    public List<GameObject> heartBoxes;
    public int counter = 0;
    public GameObject finishMoney;
    private List<GameObject> finishMoneyList;
    public Cinemachine.CinemachineVirtualCamera finishCam;
    public GameObject panel;
    public TextMeshProUGUI panelMoneyText;

    public Image fullHeart;


    public bool isTotalUpdated;
    private void Awake()
    {

        finishMoneyList = new List<GameObject>();

        for(int i = 0; i < 10; i++)
        {

            GameObject g = Instantiate(finishMoney, finishMoney.transform);
            g.transform.localScale = Vector3.one;
            g.transform.localPosition = new Vector3(0,-(i+1)*g.transform.localScale.z,0);
            finishMoneyList.Add(g);

        }

    }
    public void FinishScreen()
    {
        
        finishCam.gameObject.SetActive(true);
        Debug.Log((Mathf.RoundToInt(GameManager.Instance.money / 100) * 100).ToString());
        finishMoney.transform.parent = GameObject.Find("Player").transform;
        finishMoney.transform.localPosition = new Vector3(0, 0.4f, 0);

        if (GameObject.Find((Mathf.RoundToInt(GameManager.Instance.money / 100) * 100).ToString()) != null)
        {

            GameObject.Find("Player").transform.DOMoveY(GameObject.Find((Mathf.RoundToInt(GameManager.Instance.money / 100) * 100).ToString()).transform.position.y, GameManager.Instance.money / 200).OnComplete(() => panel.gameObject.SetActive(true));
        
        }
        panelMoneyText.text = PlayerPrefs.GetInt("TotalMoney").ToString();

        if(!isTotalUpdated)
            PlayerPrefs.SetInt("TotalMoney", PlayerPrefs.GetInt("TotalMoney") + GameManager.Instance.money);
            fullHeart.DOFillAmount((float)GameManager.Instance.money / 1000, 5);
            isTotalUpdated = true;




    }


}
