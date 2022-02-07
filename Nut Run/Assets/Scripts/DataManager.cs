using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{

    public static DataManager Instance;

    public int totalMoney;
    public int highScore = 0;
    private void Awake()
    {
        
        if(Instance == null)
        {

            Instance = this;

        }


        DontDestroyOnLoad(Instance);

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        

        if (GameManager.Instance.money > highScore && GameManager.Instance.isLevelFinished)
        {
            
            highScore = GameManager.Instance.money;
            Debug.Log("HighScore : " + highScore);
        }

    }
}
