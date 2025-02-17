using UnityEngine;

public class Rotating : MonoBehaviour
{
    [Range(0,10)]
    [SerializeField] int xSize = 0;
    [Range(0,10)]
    [SerializeField] int ySize = 0;
    [Range(0, 10)]
    [SerializeField] int zSize = 0;
    void Update()
    {
        Vector3 vector = new Vector3(xSize* Time.deltaTime*10f, ySize*Time.deltaTime*10f, zSize*Time.deltaTime*10f);
            transform.Rotate(vector);
        
    }

}

