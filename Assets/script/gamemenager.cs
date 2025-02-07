using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class gamemenager : MonoBehaviour
{
    [SerializeField]GameObject EndPanel;
    [SerializeField] TextMeshProUGUI scoreTmp,HighScoreTmp;
    public float speed;
    public static gamemenager instance = null;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        speed = 7;
        Time.timeScale = 1;
        InvokeRepeating(nameof(SpeedChange), 2f, 2f);
    }

    public void gameOver()
    {
        if (heal.instance.Healt <= 0)
        {
            EndPanel.SetActive(true);
            scoreTmp.text = FtCalculator.ft.ToString();
            HighScoreTmp.text = PlayerPrefs.GetFloat("HighScore").ToString();
            Time.timeScale = 0;
            FtCalculator.resetExporuseChange();
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }



    void OnApplicationQuit()
    {
        FtCalculator.resetExporuseChange();
    }

    void SpeedChange()
    {
        
        if (speed<=15)
        {
            speed += 0.2f;
            Debug.Log(speed);
        }

        else
        {
            CancelInvoke(nameof(SpeedChange));
        }

    }
}


