using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyController : MonoBehaviour
{
    private Rigidbody2D Enemyrigidbody;
    private Transform player;
    public float moveSpeed = 5f;
    public int lives = 1;
    public float detectionDistance = 5f;
    public AnimatedSpriteRenderer spriteRendererDeath;

    private float invulnerabilityDuration = 5f;
    private static bool isInvulnerable = false; // Variable estática compartida por todos los enemigos

    private void Awake()
    {
        Enemyrigidbody = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<MovementController>().transform;
    }

    private void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionDistance)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            MoveEnemy(direction);
        }
        if (lives <= 0)
        {
            DeathSequence();
        }

        if (isInvulnerable)
        {
            invulnerabilityDuration -= Time.deltaTime;
            if (invulnerabilityDuration <= 0f)
            {
                isInvulnerable = false;
                // Restaurar las colisiones con explosiones para todos los enemigos
                Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Enemy"), LayerMask.NameToLayer("Explosion"), false);
            }
        }
    }

    private void MoveEnemy(Vector2 moveDirection)
    {
        Vector2 position = Enemyrigidbody.position;
        Vector2 translation = moveDirection * moveSpeed * Time.deltaTime;

        Enemyrigidbody.MovePosition(position + translation);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Explosion") && !isInvulnerable)
        {
            lives--;
            // Hacer que todos los enemigos sean invulnerables temporalmente
            isInvulnerable = true;
            invulnerabilityDuration = 5f;
            // Ignorar las colisiones con explosiones para todos los enemigos
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Enemy"), LayerMask.NameToLayer("Explosion"), true);
        }
    }

    private void DeathSequence()
    {
        gameObject.SetActive(false);
        spriteRendererDeath.enabled = true;
    }
}