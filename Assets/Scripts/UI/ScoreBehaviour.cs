using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBehaviour : MonoBehaviour
{

    private int score, gameSpeed, numObstaclesJumped, numObstaclesSlid;

    public int jumpScore, slideScore;

    private bool gamePlaying = false;

    private float timeElapsedInSeconds=0.0f;

    // Start is called before the first frame update
    void Start()
    {
        initializeVariables();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(gamePlaying);
        if(!gamePlaying)
        {
            return;
        }

        timeElapsedInSeconds += Time.deltaTime;
        if(timeElapsedInSeconds%20 == 0)
        {
            gameSpeed += 1;
        }
    }

    public void ObstableJumped(int numerOfObstacles)
    {
        numObstaclesJumped += numerOfObstacles;
    }
    public void ObstableSlid(int numerOfObstacles)
    {
        numObstaclesSlid += numerOfObstacles;
    }

    public int getScore()
    {
        score = ( gameSpeed * (int)timeElapsedInSeconds ) + ( numObstaclesJumped * jumpScore ) +( numObstaclesSlid * slideScore );
        return score;
    }

    public void startGame()
    {
        gamePlaying = true;
        initializeVariables();
    }
    public void endGame()
    {
        gamePlaying = false;
    }

    public void initializeVariables()
    {
        gameSpeed = 1;
        numObstaclesJumped = 0;
        numObstaclesSlid = 0;
    }

    public bool getGamePlaying()
    {
        return gamePlaying;
    }
}

