using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject ball;
    List<GameObject> balls = new List<GameObject>();

    public Vector3 startPosition;

    public GameObject player1Paddle;
    public GameObject player1Goal;

    public GameObject player2Paddle;
    public GameObject player2Goal;

    public GameObject Player1Text;
    public GameObject Player2Text;

    private int Player1Score;
    private int Player2Score;

    private int ballLimit;
    private int nextBallId;

    void Start()
    {
        startPosition = ball.GetComponent<Ball>().startPosition;
        balls.Add(ball);
        ballLimit = 2;
        nextBallId = 2;
    }
    
    public void Player1Scored(Collider2D collision){
        Player1Score++;
        if (Player1Score == 10) {
            SceneManager.LoadScene("P1End");
        }
        Player1Text.GetComponent<TextMeshProUGUI>().text = Player1Score.ToString();
        randomBall(collision);
        ResetPosition(collision);
    }
    public void Player2Scored(Collider2D collision){
        Player2Score++;
        if (Player2Score == 10) {
            SceneManager.LoadScene("P2End");
        }
        Player2Text.GetComponent<TextMeshProUGUI>().text = Player2Score.ToString();
        randomBall(collision);    
        ResetPosition(collision);
    }

    private void randomBall(Collider2D collision) 
    {
        int rnd = Random.Range(0,2);

        if (balls.Count <= ballLimit && rnd == 0) 
        {   
            GameObject newBall = Instantiate(ball, startPosition, Quaternion.identity);
            newBall.GetComponent<Ball>().id = nextBallId;
            nextBallId++;
            balls.Add(newBall);
        } else if (balls.Count > 1 && rnd == 1 && collision.GetComponent<Ball>().id != ball.GetComponent<Ball>().id) {
            for (int i = 0; i < balls.Count; i++)
            {
                if (collision.GetComponent<Ball>().id == balls[i].GetComponent<Ball>().id )
                {
                    Destroy(balls[i].GetComponent<Ball>());
                    balls.RemoveAt(i);
                }   
            }
        }
    }

    private void ResetPosition(Collider2D collision)
    {   
        for (int i = 0; i < balls.Count; i++)
        {
            if (collision.GetComponent<Ball>().id == balls[i].GetComponent<Ball>().id)
            {
                balls[i].GetComponent<Ball>().Reset();
            }   
        }
        player1Paddle.GetComponent<PlayerMovement>().Reset();
        player2Paddle.GetComponent<PlayerMovement>().Reset();
    }
}
