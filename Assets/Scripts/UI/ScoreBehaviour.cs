using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBehaviour : MonoBehaviour
{

    private int score, gameSpeed, numObstaclesJumped, numObstaclesSlid;

    public int jumpScore, slideScore;

    private float timeElapsedInSeconds=0.0f;

    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        initializeVariables();
        gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(gamePlaying);
        if(!gm.getGamePlaying())
        {
            return;
        }
        gameSpeed = gm.getGameSpeed();
        timeElapsedInSeconds += Time.deltaTime;
      /*  if(timeElapsedInSeconds%20 == 0)
        {
            gameSpeed += 1;
        }*/
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
        initializeVariables();
        gm.NewGame();
    }

 

    public void initializeVariables()
    {
        gameSpeed = 1;
        numObstaclesJumped = 0;
        numObstaclesSlid = 0;
        timeElapsedInSeconds = 0;
    }
}

