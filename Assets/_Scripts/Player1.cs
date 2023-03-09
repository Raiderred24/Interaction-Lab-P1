using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public float jumpForce;
    float score;

    [SerializeField]
    bool isGrounded = false;
    bool isAlive = true;

    Rigidbody2D RB;

    public Text ScoreTxt;
    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
        score = 0;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (isGrounded == true)
            {
                RB.AddForce(Vector2.up * jumpForce);
                isGrounded = false;
            }
        }

            if(isAlive)
            {
                score += Time.deltaTime * 4;
                ScoreTxt.text = "SCORE  : " + score.ToString("F0");
            }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("ground"))
        {
            if(isGrounded == false)
            {
                isGrounded = true;
            }
        }
        if (collision.gameObject.CompareTag("spike"))
        {
            isAlive = false;
            Time.timeScale = 0;
        }
    }
}
