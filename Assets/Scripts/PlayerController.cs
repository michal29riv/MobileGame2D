using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Animator playerAnimator;

    public int numberOfSlots = 5;

    public int startingPlayerSlot = 3;

    public float distanceBetweenSlots = 2f;

    public float playerSpeed = 0.1f;

    private int currentPlayerSlot;

    Vector3 playerStartPosition;

    public GameObject deathCanvas;

    public Text scoreText;

    public Text resultText;

    private int score = 0;



    // Start is called before the first frame update
    void Start()
    {
        currentPlayerSlot = startingPlayerSlot;
        playerStartPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(playerStartPosition.x + (currentPlayerSlot - startingPlayerSlot) * distanceBetweenSlots, playerStartPosition.y, playerStartPosition.z), playerSpeed * Time.deltaTime);


    }

    public void MoveLeft()
    {
        if (currentPlayerSlot > 1)
        {
            currentPlayerSlot--;

            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);

            playerAnimator.SetTrigger("jump");
        }
    }

    public void MoveRight()
    {
        if (currentPlayerSlot < numberOfSlots)
        {
            currentPlayerSlot++;

            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);

            playerAnimator.SetTrigger("jump");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle") == true)
        {
            Destroy(collision.gameObject);

            resultText.text = "Score: " + score;

            deathCanvas.gameObject.SetActive(true);
        }
        else if (collision.CompareTag("Collectible") == true)
        {
            score++;

            scoreText.text = "Score: " + score;

            Destroy(collision.gameObject);


        }
    }
}
