
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float leftEdge;
    public float y_Height;

    private void Start()
    {
        //leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 2f;
        leftEdge = -13.48f;
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, y_Height, transform.position.z); //I dont know how Brandan is handling the spawn location, so I am doing this
        transform.position += Vector3.left * GameManager.instance.gameSpeed * Time.deltaTime;
        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }
}