using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentMovement : MonoBehaviour
{
    public float leftEdge, rightEdge, speedDiv;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * GameManager.instance.gameSpeed * Time.deltaTime / speedDiv;
        if (transform.position.x < leftEdge)
        {
            transform.position = new Vector3(rightEdge, transform.position.y, transform.position.z);
        }
    }
}
