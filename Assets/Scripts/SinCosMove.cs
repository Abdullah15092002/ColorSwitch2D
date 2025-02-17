using UnityEngine;

public class SinCosMove : MonoBehaviour
{
    [Range(-10,10)]
    [SerializeField] int cosRange=1;
    [Range(-10, 10)]
    [SerializeField] int sinRange = 1;


    private float startX;
    private float startY;

    private void Start()
    {
        startX = transform.position.x;
        startY = transform.position.y;
    }
    void Update()
    {
        float x = startX+Mathf.Cos(Time.time)*cosRange;
        float y = startY+Mathf.Sin(Time.time)*sinRange;
        transform.position = new Vector2(x, y);
    }
}
