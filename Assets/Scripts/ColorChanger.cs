using System.Drawing;
using TMPro;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    AudioSource colorChangerAudio;
    
    void Start()
    {
        colorChangerAudio=gameObject.GetComponent<AudioSource>();
    }

    
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {         
            
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
            colorChangerAudio.Play();
            Destroy(gameObject, colorChangerAudio.clip.length);
        }
    }
}
