using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public enum Lanes
{
    Right, centre, Left
}

public class PlayerMovement : MonoBehaviour
{

    Lanes currentlane;
    [SerializeField] Transform[] lanesTransform;
    public float speed = 5f;
    //private Rigidbody2D rb;
    [SerializeField] SpriteRenderer _spriteRenderer;
    [SerializeField] Sprite[] sprites;
    private float playerPositionY;
    private const string PLAYERTAG = "Player";
    
    public Text scoreText;


    void Start()
    {
        GridShape();
        //rb = GetComponent<Rigidbody2D>();
        playerPositionY = transform.position.y;
        scoreText.text = "Score: " + Scoring.totalScore;
    }

    private void GridShape()
    {
        int rand = Random.Range(0, sprites.Length);
        _spriteRenderer.sprite = sprites[rand];
        switch (rand)
        {
            case 0:
                gameObject.tag = "Circle";
                break;

            case 1:
                gameObject.tag = "Square";
                break;
            case 2:
                gameObject.tag = "Triangle";
                break;
        }
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveRight();
        }


        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLeft();
        }


    }
    private void MoveRight()
    {
        switch (currentlane)
        {
            case (global::Lanes.Right):
                return;
            case (global::Lanes.centre):
                currentlane = global::Lanes.Left;
                transform.position = new Vector3(lanesTransform[0].position.x,playerPositionY, 0);
                return;
            case (global::Lanes.Left):
                currentlane = global::Lanes.centre;
                transform.position = new Vector3(lanesTransform[1].position.x, playerPositionY, 0);
                return;
        }
    }
    private void MoveLeft()
    {
        switch (currentlane)
        {
            case (global::Lanes.Right):
                currentlane = global::Lanes.centre;
                transform.position = new Vector3(lanesTransform[1].position.x, playerPositionY,  0);
                return;
            case (global::Lanes.centre):
                currentlane = global::Lanes.Left;
                transform.position = new Vector3(lanesTransform[2].position.x,playerPositionY, 0);
                return;
            case (global::Lanes.Left):
                return;
        }

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {

         Debug.Log("collision");
        if (collision.gameObject.tag == gameObject.tag)
        {
            Scoring.totalScore += 1;
            scoreText.text = "Score: " + Scoring.totalScore;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag != gameObject.tag)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        Destroy(gameObject);
        Debug.Log("GameOver");
    } 
}
