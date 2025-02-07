using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gun : MonoBehaviour
{
    [SerializeField] private List<GameObject> BulletPool = new List<GameObject>();
    private float timeslepp = 0.5f; 
    private float nextFire = 0f;
    int i = 0;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Fire();
        }
    }

    void Fire()
    {
        if (Time.time > nextFire) 
        {
            nextFire = Time.time + timeslepp;

            if (i >= BulletPool.Count)
            {
                i = 0;
            }

            for (;i < BulletPool.Count; i++)
            {
                if (!BulletPool[i].activeSelf)
                {
                    BulletPool[i].SetActive(true);
                    BulletPool[i].transform.parent = null;
                    i = i + 1;
                    break;
                }
                
            }
        }
    }
}
