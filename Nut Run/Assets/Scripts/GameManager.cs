using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public static GameManager Instance;
    public bool isGameStarted;

    public Image swipeToPlay;

    public Text levelNumber;

    public Text moneyText;
    public int money;

    public int totallevelScore;
    public TextMeshProUGUI savedMoneyText;

    public bool isLevelFinished;
    private void Awake()
    {
         
        if(Instance == null)
        {

            Instance = this;

        }

    }


    void Start()
    {

        levelNumber.text = SceneManager.GetActiveScene().buildIndex + 1.ToString();

    }

    // Update is called once per frame
    void Update()
    {
     
        if(isGameStarted && swipeToPlay.gameObject.activeSelf)
        {

            swipeToPlay.gameObject.SetActive(false);

        }

        moneyText.text = "" + money;

        if (isLevelFinished)
            savedMoneyText.text = "" + money;
            totallevelScore = money;

    }

    public void NextLevel()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        DataManager.Instance.totalMoney += GameManager.Instance.money;
        savedMoneyText.text = "" + DataManager.Instance.totalMoney;

    }
}
