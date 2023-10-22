using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyController : MonoBehaviour
{
    private new Rigidbody2D rigidbody; // Usar "new" para ocultar el miembro heredado

    private Transform player;
    public float moveSpeed = 5f;
    public float detectionDistance = 5f;
    
    public AnimatedSpriteRenderer spriteRendererDeath;

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
    }

    private void MoveEnemy(Vector2 moveDirection)
    {
        Vector2 position = rigidbody.position;
        Vector2 translation = moveDirection * moveSpeed * Time.deltaTime;

        rigidbody.MovePosition(position + translation);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Explosion")) {
            DeathSequence();
        }
    }

    private void DeathSequence()
    {
        gameObject.SetActive(false); // Puedes cambiar esto según tu lógica
        // Opción: Destroy(gameObject) si prefieres destruir el objeto en lugar de desactivarlo

        spriteRendererDeath.enabled = true;
    }
}