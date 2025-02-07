using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FtCalculator : MonoBehaviour
{
    public static float ft;
    float highScore;
    [SerializeField] Transform bubble;
    [SerializeField] Material skybox;
    public static Material _skybox;
    [SerializeField] TextMeshProUGUI FtTmp;
    float targetExposure = 3;

    // Manuel saya�
    private float customTime = 0f;

    private void Awake()
    {
        FtTmp = gameObject.GetComponent<TextMeshProUGUI>();
        _skybox = skybox;
    }

    private void Start()
    {
        ft = 0;
        customTime = 0f;  // Zaman� s�f�rlay�n
        FtTmp.text = ft.ToString() + " FT";

        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetFloat("HighScore");
        }

        StartCoroutine(exposureChange());
        _skybox.SetFloat("_Exposure", 3);
    }

    void Update()
    {
        customTime += Time.deltaTime;  // Zaman� manuel olarak artt�r�n
        ft = Mathf.Floor(customTime * 2f * 100f) / 100f; // Zaman� FT'ye d�n��t�r�n

        FtTmp.text = ft.ToString() + " FT";

        if (ft >= highScore)
        {
            highScore = ft;
            PlayerPrefs.SetFloat("HighScore", highScore);
            PlayerPrefs.Save();
        }
    }

    IEnumerator exposureChange()
    {
        if (targetExposure > 0.65f)
        {
            yield return new WaitForSeconds(0.2f);
            _skybox.SetFloat("_Exposure", targetExposure);
            targetExposure -= 0.01f;
            StartCoroutine(exposureChange());
        }
    }

    public static void resetExporuseChange()
    {
        _skybox.SetFloat("_Exposure", 3);
    }
}
