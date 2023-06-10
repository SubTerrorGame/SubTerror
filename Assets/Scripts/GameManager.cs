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

    public Animator animatorTerra;
    private bool gamePlaying;

    public GameObject introScreen;

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
        gamePlaying = false;
        //disabled these so that they arent running unless we hit start
        player.gameObject.SetActive(false);
        spawner.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(!gamePlaying) return;
        gameSpeed += step * Time.deltaTime;
    }
    public void clearObstacles()
    {
        // clear all pre-existing obstacles
        Obstacle[] obstacles = FindObjectsOfType<Obstacle>();
        foreach(Obstacle obstacle in obstacles)
        {
            Destroy(obstacle.gameObject);
        }

    }

    public void NewGame()
    {
        clearObstacles();
        // set inital condition & enable elements
        gameSpeed = initalSpeed;
        gamePlaying = true;
        player.gameObject.SetActive(true);
        spawner.gameObject.SetActive(true);
        animatorTerra.SetBool("Dead", false);

    }

    public void GameOver()
    {
        gameSpeed = 0f;
        gamePlaying = false;

        player.gameObject.SetActive(false);
        spawner.gameObject.SetActive(false);

        animatorTerra.SetBool("Dead", true);
    }

    public void setGamePlaying(bool status)
    {
        gamePlaying = status;
    }

    public bool getGamePlaying()
    {
        return gamePlaying;
    }

    public void disableIntro()
    {
        //disable the intro screen
        introScreen.SetActive(false);
    }
    public void enableIntro()
    {
        //disable the intro screen
        introScreen.SetActive(true);
    }
    public int getGameSpeed()
    {
        return (int)Mathf.Ceil(gameSpeed);
    }
}
