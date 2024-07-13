using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    int playerHealth;
    int playerScore;
    int playerLives;
    int playerLevel;

    Vector2 checkpoint;

    void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
        //Damagezone.damageEvent += TakeDamage;
    }

    void Start()
    {
        playerHealth = 100;
        playerScore = 0;
        playerLives = 3;
        checkpoint = transform.position;
    }

    void FixedUpdate()
    {
        
    }

    void TakeDamage(int damage)
    {
        playerHealth -= damage;
        if (playerHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        playerLives--;
        if (playerLives <= 0)
        {
            GameOver();
        }
        else
        {
            PlayerRespawn();
        }
    }

    void GameOver()
    {
        Debug.Log("Game Over");
    }

    void PlayerRespawn()
    {
        transform.position = checkpoint;
        playerHealth = 100;
    }
}
