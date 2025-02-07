using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyspawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] List<GameObject> enemyPoint;
    [SerializeField] List<GameObject> enemyPusula;
    [SerializeField] Transform balon;

    private void Start()
    {
        InvokeRepeating("enemySelector", 5f, 15f);
    }
    
    void enemySelector()
    {
        int randomValue = Random.Range(1,5);
        
        for (int i = 1; i <= randomValue; i++)
        {
            int randompos = Random.Range(0,enemyPoint.Count);

            switch (randompos)
            {
                case 0:
                    enemySpawner(enemyPoint[0].transform);
                    pusula(0);
                    break;
                case 1:
                    enemySpawner(enemyPoint[1].transform);
                    pusula(1);
                    break;
                case 2:
                    enemySpawner(enemyPoint[2].transform);
                    pusula(2);
                    break;

                case 3:
                    enemySpawner(enemyPoint[3].transform);
                    pusula(3);
                    break;

                case 4:
                    enemySpawner(enemyPoint[4].transform);
                    pusula(4);
                    break;

                case 5:
                    enemySpawner(enemyPoint[5].transform);
                    pusula(5);
                    break;

                case 6:
                    enemySpawner(enemyPoint[6].transform);
                    pusula(6);
                    break;

                case 7:
                    enemySpawner(enemyPoint[7].transform);
                    pusula(7);
                    break;


            }
        }
    }

    void enemySpawner(Transform pos)
    {
        GameObject newEnemy = Instantiate(enemyPrefab);
        newEnemy.transform.position = pos.position;
        newEnemy.GetComponent<enemy>().balon = balon;
    }

    void pusula(int value)
    {
        StartCoroutine(pusulaCorotine(value));

    }

    IEnumerator pusulaCorotine(int value)
    {
        for (int i = 0; i <= 7; i++)
        {
            yield return new WaitForSeconds(0.5f);
            enemyPusula[value].SetActive(true);
            yield return new WaitForSeconds(0.5f);
            enemyPusula[value].SetActive(false);
        }      
    }
}
