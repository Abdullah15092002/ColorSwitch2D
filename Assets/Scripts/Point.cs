using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]GameManager gameManager;
    AudioSource PointAudio;

    void Start()
    {
      PointAudio=  gameObject.GetComponent<AudioSource>();
    }

   
    void Update()
    {
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           
            gameManager.AddScore();          
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;      
            PointAudio.Play();
            Destroy(gameObject, PointAudio.clip.length);
        }
    }
}
