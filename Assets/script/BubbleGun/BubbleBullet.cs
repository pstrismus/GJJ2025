using System.Collections;
using UnityEngine;

public class BubbleBullet : MonoBehaviour
{
    [SerializeField] private float scaleLimit = 1f;
    [SerializeField] private float scaleSpeed = 1f;
    [SerializeField] private Material purple, blue,yellow;
    [SerializeField] private GameObject gun;
    private Renderer bubbleRenderer;
    private Vector3 mainPos;
    private int speed = 12;

    AudioSource AS;
    [SerializeField]AudioClip sis, patla;

    private void Awake()
    {
        AS = GetComponent<AudioSource>();
        bubbleRenderer = GetComponent<Renderer>();
        mainPos = new Vector3(0.01376308f, 0.06729873f, -0.01082177f);
    }

    private void OnEnable()
    {
        transform.localScale = Vector3.one * 0.01f; // Reset scale
        bubbleRenderer.material = Random.Range(0, 2) == 0 ? purple : blue;

        StartCoroutine(ScaleEnlarge());
        StartCoroutine(NullValueHit());
        soundPlayer(sis);
    }

    private IEnumerator ScaleEnlarge()
    {
        while (transform.localScale.x < scaleLimit)
        {
            transform.localScale -= Vector3.one * scaleSpeed * Time.deltaTime;
            yield return null;
        }
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private IEnumerator NullValueHit()
    {
        yield return new WaitForSeconds(4f);
        soundPlayer(patla);
        yield return new WaitForSeconds(0.07f);
        ResetBubble();
    }

    private void ResetBubble()
    {
        transform.parent = gun.transform;
        transform.localPosition = mainPos;
        transform.localRotation = Quaternion.Euler(0, 180, 0);
        gameObject.SetActive(false);
    }

    private void bombBubble(GameObject enemy)
    {
        enemy.transform.parent = gameObject.transform;
        StartCoroutine(ScaleEnlarge());
        Destroy(enemy,0.6f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
            bombBubble(collision.gameObject);
        }
        
    }

    void soundPlayer(AudioClip clip)
    {
        AS.clip = clip;
        AS.PlayOneShot(clip);
    }
}
