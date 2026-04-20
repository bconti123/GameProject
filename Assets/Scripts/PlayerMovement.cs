using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    public GameObject winText;
    public GameObject loseText;
    public GameObject restartButton;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(x, y);

        rb.linearVelocity = move * speed;
    }
    void OnTriggerEnter2D(Collider2D other)
    {


        // if (other.CompareTag("Green"))
        // {
        //     winText.SetActive(true);
        //     rb.linearVelocity = Vector2.zero;
        // }
        if (other.CompareTag("Red"))
        {
            FindAnyObjectByType<GameTimer>().LoseGame();
            rb.linearVelocity = Vector2.zero;

        }   
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
