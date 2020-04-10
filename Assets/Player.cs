using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public float jumpForce = 10f;
    public Rigidbody2D rb;
    public string currentColor;
    public SpriteRenderer sr;
    public Color colorGreen;
    public Color colorYellow;
    public Color colorPurple;
    public Color colorPink;

    private void Start()
    {
        SetRandomColor();
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump")|| Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "colorChanger")
        {
            SetRandomColor();
            Destroy(collision.gameObject);
            return;

        }
        if(collision.tag != currentColor)
        {
            Debug.Log("Game Over!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void SetRandomColor()
    {
        int index = Random.Range(0, 4);
        switch (index)
        {
            case 0:
                currentColor = "green";
                sr.color = colorGreen;
                break;
            case 1:
                currentColor = "yellow";
                sr.color = colorYellow;
                break;
            case 2:
                currentColor = "purple";
                sr.color = colorPurple;
                break;
            case 3:
                currentColor = "Pink";
                sr.color = colorPink;
                break;
        }
    }
}
