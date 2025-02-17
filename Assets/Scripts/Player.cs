using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Player : MonoBehaviour
{
    //32A5FF->Blue  FFE61E->Yellow FF4BE6->Pink  912DFF->Purple
    List<Color> colors = new List<Color>(){
    new Color(50f / 255f, 165f / 255f, 255f / 255f, 255f / 255f),  // Mavi (#32A5FF)
    new Color(255f / 255f, 230f / 255f, 30f / 255f, 255f / 255f),  // Sarı (#FFE61E)
    new Color(255f / 255f, 75f / 255f, 230f / 255f, 255f / 255f),  // Pembe (#FF4BE6)
    new Color(145f / 255f, 45f / 255f, 255f / 255f, 255f / 255f)   // Mor (#912DFF)

};
    [SerializeField] GameManager gameManager;
    public SpriteRenderer playerSpriteRenderer;
    private Color myhtmLcolorCode = new Color(255f / 255f, 230f / 255f, 30f / 255f, 255f / 255f);
    GameObject startPos;
    GameObject fallPos;
    AudioSource crashSound;
    Rigidbody2D rigidbody2;

    void Start()
    {
      crashSound = gameObject.GetComponent<AudioSource>();     
      rigidbody2=gameObject.GetComponent<Rigidbody2D>();  
      playerSpriteRenderer.color=myhtmLcolorCode;
      startPos = GameObject.Find("StartPos");
      fallPos = GameObject.Find("FallPos");
    }
     void Update()
    {
       if (fallPos.transform.position.y >= gameObject.transform.position.y)
        { 
            gameManager.EndGame();
        }
    }
    public IEnumerator PlaySoundAndEndGame()
    {
        crashSound.Play();
        yield return new WaitForSeconds(crashSound.clip.length);
        gameManager.EndGame();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

         if (collision.gameObject.CompareTag("ColorChanger"))
        {
            Color randomColorCode;
            do
            {
                 randomColorCode = GetRandomColorCode();
            }
            while (randomColorCode == myhtmLcolorCode);
            myhtmLcolorCode = randomColorCode;
            playerSpriteRenderer.color = myhtmLcolorCode;

        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {            
            SpriteRenderer ObstacleSprite = collision.transform.GetComponent<SpriteRenderer>();
           
            if (ObstacleSprite.color != myhtmLcolorCode)
            {
                rigidbody2.constraints = RigidbodyConstraints2D.FreezePositionY;
                StartCoroutine(PlaySoundAndEndGame());
            }
        }
         
        else if (collision.gameObject.CompareTag("Player"))
        {           
            rigidbody2.constraints = RigidbodyConstraints2D.FreezePositionY;
        }

    }

  
    Color GetRandomColorCode()
     {
        int randomIndex = Random.Range(0, colors.Count);
        return colors[randomIndex];
    }
    
}
