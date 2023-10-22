using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyController : MonoBehaviour
{
    private new Rigidbody2D rigidbody; // Usar "new" para ocultar el miembro heredado

    private Transform player;
    public float moveSpeed = 5f;
    public int lives = 1;
    public float detectionDistance = 5f;
    
    public AnimatedSpriteRenderer spriteRendererDeath;

    private bool isInvulnerable = false; // Variable para rastrear si el enemigo es invulnerable temporalmente
    private float invulnerabilityDuration = 5f; // Duración de la invulnerabilidad en segundos

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>(); // Corregido
        player = FindObjectOfType<MovementController>().transform; // Asume que hay un script "MovementController" en el jugador.
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

        // Si es invulnerable, reducir el tiempo de invulnerabilidad y restaurar las colisiones
        if (isInvulnerable)
        {
            invulnerabilityDuration -= Time.deltaTime;
            if (invulnerabilityDuration <= 0f)
            {
                isInvulnerable = false;
                // Restaurar las colisiones con explosiones
                Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Enemy"), LayerMask.NameToLayer("Explosion"), false);
            }
        }
    }

    private void MoveEnemy(Vector2 moveDirection)
    {
        Vector2 position = rigidbody.position;
        Vector2 translation = moveDirection * moveSpeed * Time.deltaTime;

        rigidbody.MovePosition(position + translation);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Explosion") && !isInvulnerable)
        {
            lives--;
            // Hacer que el enemigo sea invulnerable temporalmente
            isInvulnerable = true;
            invulnerabilityDuration = 5f;
            // Ignorar las colisiones con explosiones
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Enemy"), LayerMask.NameToLayer("Explosion"), true);
        }
    }

    private void DeathSequence()
    {
        enabled = false;
        GetComponent<BombController>().enabled = false;

        spriteRendererDeath.enabled = true;

        gameObject.SetActive(false); // Puedes cambiar esto según tu lógica
        // Opción: Destroy(gameObject) si prefieres destruir el objeto en lugar de desactivarlo


    }
}
