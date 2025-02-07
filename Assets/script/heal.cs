using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heal : MonoBehaviour
{
    public int Healt = 3;
    public static heal instance = null;
    public List<GameObject> healUI;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
