using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    public GameObject winText;
    public GameObject loseText;
    public GameObject restartButton;
    private bool gameOver = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (gameOver) return;
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(x, y);

        rb.linearVelocity = move * speed;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (gameOver) return;

        if (other.gameObject.name == "Goal")
        {
            gameOver = true;
            winText.SetActive(true);
            restartButton.SetActive(true);
            rb.linearVelocity = Vector2.zero;
        }
        if (other.CompareTag("Red"))
        {
            gameOver = true;
            loseText.SetActive(true);
            restartButton.SetActive(true);
            rb.linearVelocity = Vector2.zero;
        }   
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
