using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemy : MonoBehaviour
{
    
    public Transform balon;
    

    private void Update()
    {
        Vector3 direction = balon.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * gamemenager.instance.speed);
        transform.Translate(Vector3.forward * gamemenager.instance.speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("balon"))
        {

            if (collision.gameObject.GetComponent<heal>().Healt>0)
            {
                UIhealt();
                collision.gameObject.GetComponent<heal>().Healt--;
                Debug.Log(collision.gameObject.GetComponent<heal>().Healt);
                gamemenager.instance.gameOver();
                Destroy(gameObject, 0.2f);
            }

        }
    }

    void UIhealt()
    {
        if (heal.instance.healUI != null)
        {
            heal.instance.healUI[0].GetComponent<Image>().color = Color.black;
            heal.instance.healUI.RemoveAt(0);
        }

    }
}
