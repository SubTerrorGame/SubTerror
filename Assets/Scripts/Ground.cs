using UnityEngine;

public class Ground : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // tiling the ground texture to animate correctly
    void Update()
    {
        float speed = GameManager.instance.gameSpeed / transform.localScale.x;
        meshRenderer.material.mainTextureOffset= Vector2.right * speed * Time.deltaTime;
    }
}
