using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControler : MonoBehaviour
{
    [Range(5f,20f)]
    public float JumpForce = 10;
    bool _canJumping = true;
    Rigidbody2D _playerRigidbody2D;
    CapsuleCollider2D _playerBoxCollider2D;



    void Start() 
    {
        _playerRigidbody2D = GetComponent<Rigidbody2D>();
        _playerBoxCollider2D = GetComponent<CapsuleCollider2D>();
    } 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1;
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && _canJumping)
        {
            _playerRigidbody2D.velocity = new Vector2(0,JumpForce);            
        }

        if (Input.GetKey(KeyCode.LeftControl) && Time.timeScale == 1)
        {
            _canJumping = false;
            _playerBoxCollider2D.size = new Vector2(1,2);
            transform.localScale = new Vector2(1 , 0.63f); 
        }

        if (Input.GetKeyUp(KeyCode.LeftControl) && Time.timeScale == 1)
        {
            _canJumping = true;
            _playerBoxCollider2D.size = new Vector2(1,2);
            transform.localScale = new Vector2(1 , 1.4f);
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Enemy"))
        {
            Time.timeScale = 0;
        }
    }
}