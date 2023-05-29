using UnityEngine;
using static System.Math;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    private Player player;
    private Spawner spawner;
    public float gameSpeed {  get; private set; }
    public float initalSpeed = 5f;
    public float step = 0.1f;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        } else
        {
            DestroyImmediate(gameObject);
        }
    }

    private void OnDestroy()
    {
        if(instance == this)
        {
            instance = null;
        }
    }

    private void Start()
    {
        player = FindObjectOfType<Player>();
        spawner = FindObjectOfType<Spawner>();

        NewGame();
    }

    private void Update()
    {
        gameSpeed += step * Time.deltaTime;
    }

    private void NewGame()
    {
        // clear all pre-existing obstacles
        Obstacle[] obstacles = FindObjectsOfType<Obstacle>();
        foreach(Obstacle obstacle in obstacles)
        {
            Destroy(obstacle.gameObject);
        }

        // set inital condition & enable elements
        gameSpeed = initalSpeed;
        enabled = true;
        player.gameObject.SetActive(true);
        spawner.gameObject.SetActive(true);
    }

    public void GameOver()
    {
        gameSpeed = 0f;
        enabled = false;

        player.gameObject.SetActive(false);
        spawner.gameObject.SetActive(false);
    }
}
