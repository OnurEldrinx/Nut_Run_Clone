using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DataManager : MonoBehaviour
{

    public static DataManager Instance;

    public GameObject highScoreImg;
    
    public TextMeshProUGUI totalMoneyText;
    public int totalMoney;
    public int highScore;

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

        highScore = PlayerPrefs.GetInt("HighScore");
        totalMoney = PlayerPrefs.GetInt("TotalMoney");

        if(GameObject.Find((Mathf.RoundToInt(PlayerPrefs.GetInt("HighScore") / 100) * 100).ToString()) != null){

            highScoreImg.transform.localPosition = new Vector3(-0.5f, 0.3f, GameObject.Find((Mathf.RoundToInt(PlayerPrefs.GetInt("HighScore") / 100) * 100).ToString()).transform.localPosition.z);

        }
        


    }

    // Update is called once per frame
    void Update()
    {

        if (GameObject.Find((Mathf.RoundToInt(PlayerPrefs.GetInt("HighScore") / 100) * 100).ToString()) != null)
        {

            highScoreImg.transform.localPosition = new Vector3(-0.5f, 0.3f, GameObject.Find((Mathf.RoundToInt(PlayerPrefs.GetInt("HighScore") / 100) * 100).ToString()).transform.localPosition.z);

        }


        if (GameManager.Instance.isLevelFinished)
        {
            if (GameManager.Instance.money > PlayerPrefs.GetInt("HighScore"))
            {

                PlayerPrefs.SetInt("HighScore", GameManager.Instance.money);
                
            }
        }

        totalMoneyText.text = PlayerPrefs.GetInt("TotalMoney").ToString();
        

    }
}
