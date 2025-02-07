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

    // Manuel sayaç
    private float customTime = 0f;

    private void Awake()
    {
        FtTmp = gameObject.GetComponent<TextMeshProUGUI>();
        _skybox = skybox;
    }

    private void Start()
    {
        ft = 0;
        customTime = 0f;  // Zamaný sýfýrlayýn
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
        customTime += Time.deltaTime;  // Zamaný manuel olarak arttýrýn
        ft = Mathf.Floor(customTime * 2f * 100f) / 100f; // Zamaný FT'ye dönüþtürün

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
