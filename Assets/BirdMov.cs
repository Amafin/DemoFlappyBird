using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class BirdMov : MonoBehaviour
{
    private Rigidbody2D rb;
    private float jumpForce = 5f;

    private Animator anim;

    public TextMeshProUGUI scoreText;

    public GameObject gameOverUI;

    private int score = 0;
    private bool isDead = false;
    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
        Time.timeScale = 1f;
        UpdateScoreDisplay();

        if (anim == null)
        {
            anim = GetComponent<Animator>();
        }

        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
    }

    void Update()
    {
        if (isDead)
        {
            if (Keyboard.current != null && Keyboard.current.rKey.wasPressedThisFrame)
            {
                ResetGame();
            }
            return;
        }

        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            rb.linearVelocity = Vector2.up * jumpForce;
        }

        if (anim != null)
        {
            anim.speed = (rb.linearVelocity.y > 0.1f) ? 1f : 0f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameOver();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isDead && other.gameObject.name == "ScoreZone")
        {
            score++;
            UpdateScoreDisplay();
        }
    }

    private void UpdateScoreDisplay()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score : " + score.ToString();
        }
    }

    private void GameOver()
    {
        isDead = true;

        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
        }

        Time.timeScale = 0f;
    }


    private void ResetGame()
    {
        GameObject[] existingPipes = GameObject.FindGameObjectsWithTag("Pipe");
        foreach (GameObject pipe in existingPipes)
        {
            Destroy(pipe);
        }

        transform.position = initialPosition;
        transform.rotation = Quaternion.identity;
        rb.linearVelocity = Vector2.zero;

        score = 0;
        UpdateScoreDisplay();

        if (gameOverUI != null)
        {
            gameOverUI.SetActive(false);
        }

        isDead = false;
        Time.timeScale = 1f;
    }

}
