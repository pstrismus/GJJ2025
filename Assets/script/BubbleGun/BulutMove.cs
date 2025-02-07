using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BulutMove : MonoBehaviour
{
    bool Moved = true;
    int speed=75;

    void Update()
    {
        if (Moved)
        {
            Move();
        }  
    }

    void Move()
    {
        if (transform.position.y > -1500)
        {
            transform.position -= Vector3.up * speed * Time.deltaTime;
        }

        else if(Moved == true)
        {
            Moved = false;
            Move();
            StartCoroutine(timeSleep());
        }
    }

    IEnumerator timeSleep()
    {
        yield return new WaitForSeconds(4);
        transform.position = new Vector3(0, 700, 0);
        Moved = true;
        speed = 95;
    }


}
