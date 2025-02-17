using System.Collections;
using UnityEngine;

public class Finish : MonoBehaviour
{
    AudioSource finishSound;
    [SerializeField]GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        finishSound= gameObject.GetComponent<AudioSource>();
    }
    public IEnumerator PlaySoundAndFinishGame()
    {
        finishSound.Play();
        yield return new WaitForSeconds(finishSound.clip.length);
        gameManager.FinishGame();
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(PlaySoundAndFinishGame());
        }
    }
}
