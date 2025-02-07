using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Move : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float speed;

    float horizontal;
    float vertical;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Haraket(horizontal, vertical);
    }

    private void Haraket(float horizontal, float vertical)
    {
        Vector3 move = speed * (transform.right * horizontal + transform.forward * vertical) * Time.deltaTime;
        rb.velocity = move;
    }
}
