using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementController : MonoBehaviour
{
    private Rigidbody2D Enemyrigidbody;
    public bool sePuedeMover = true;
    [SerializeField] private Vector2 velocidadDeRebote;
    [SerializeField] private float tiempoPerdidaControl;
    private Vector2 direction = Vector2.down;
    public float speed = 5f;
    public int lives = 1;
    private float invulnerabilityDuration = 5f;
    private bool isInvulnerable = false;
    public MenuPausa menuPausa;

    [Header("Input")]
    public KeyCode inputUp = KeyCode.W;
    public KeyCode inputDown = KeyCode.S;
    public KeyCode inputLeft = KeyCode.A;
    public KeyCode inputRight = KeyCode.D;

    [Header("Sprites")]
    public AnimatedSpriteRenderer spriteRendererUp;
    public AnimatedSpriteRenderer spriteRendererDown;
    public AnimatedSpriteRenderer spriteRendererLeft;
    public AnimatedSpriteRenderer spriteRendererRight;
    public AnimatedSpriteRenderer spriteRendererDeath;
    private AnimatedSpriteRenderer activeSpriteRenderer;

    private void Awake()
    {
        Enemyrigidbody = GetComponent<Rigidbody2D>();
        activeSpriteRenderer = spriteRendererDown;
    }

    private void Update()
    {
        if (Input.GetKey(inputUp)) {
            SetDirection(Vector2.up, spriteRendererUp);
            FindObjectOfType<AudioManager>().PlaySound("caminata");
        } else if (Input.GetKey(inputDown)) {
            SetDirection(Vector2.down, spriteRendererDown);
            FindObjectOfType<AudioManager>().PlaySound("caminata");
        } else if (Input.GetKey(inputLeft)) {
            SetDirection(Vector2.left, spriteRendererLeft);
            FindObjectOfType<AudioManager>().PlaySound("caminata");
        } else if (Input.GetKey(inputRight)) {
            SetDirection(Vector2.right, spriteRendererRight);
            FindObjectOfType<AudioManager>().PlaySound("caminata");
        } else {
            SetDirection(Vector2.zero, activeSpriteRenderer);
            FindObjectOfType<AudioManager>().PlaySound("caminata");
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

    private void FixedUpdate()
    {
        Vector2 position = Enemyrigidbody.position;
        Vector2 translation = direction * speed * Time.fixedDeltaTime;
        if (sePuedeMover){
            Enemyrigidbody.MovePosition(position + translation);
        }
    }

    private void SetDirection(Vector2 newDirection, AnimatedSpriteRenderer spriteRenderer)
    {
        direction = newDirection;

        spriteRendererUp.enabled = spriteRenderer == spriteRendererUp;
        spriteRendererDown.enabled = spriteRenderer == spriteRendererDown;
        spriteRendererLeft.enabled = spriteRenderer == spriteRendererLeft;
        spriteRendererRight.enabled = spriteRenderer == spriteRendererRight;

        activeSpriteRenderer = spriteRenderer;
        activeSpriteRenderer.idle = direction == Vector2.zero;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Explosion") && !isInvulnerable) {
            FindObjectOfType<AudioManager>().PlaySound("Pato herido");
            
            string scene = SceneManager.GetActiveScene().name;
            if(scene == "Plumas"){
                PlumasManager.Instance.SumarPlumas(-2, this.gameObject.tag);
                isInvulnerable = true;
                invulnerabilityDuration = 5f;
            }
            else if(scene =="BabyDucks"){
                PlumasManager.Instance.DesobtenerBaby(this.gameObject.tag);
                isInvulnerable = true;
                invulnerabilityDuration = 5f;

                if(this.gameObject.tag == "WhiteDuck"){
                    PlumasManager.Instance.SuperActivacionWhite();
                }
                else if(this.gameObject.tag == "BlackDuck"){
                    PlumasManager.Instance.SuperActivacionBlack();
                }
            }
            else{
                isInvulnerable = true;
                invulnerabilityDuration = 5f;
                lives--;

                PlumasManager.Instance.PerderVidas(this.gameObject.tag);

            }
        }
    }

    private void DeathSequence()
    {
        enabled = false;
        GetComponent<BombController>().enabled = false;

        spriteRendererUp.enabled = false;
        spriteRendererDown.enabled = false;
        spriteRendererLeft.enabled = false;
        spriteRendererRight.enabled = false;
        spriteRendererDeath.enabled = true;

        Invoke(nameof(OnDeathSequenceEnded), 1.25f);
    }

    private void OnDeathSequenceEnded()
    {
        gameObject.SetActive(false);
        string sceneName = SceneManager.GetActiveScene().name;

        if(sceneName == "Granja" || sceneName =="Nieve" || sceneName == "Playa"){
            menuPausa.Derrota();
        }
        else{
            menuPausa.StatusWinnerVidas(this.gameObject.tag);
        }
        FindObjectOfType<AudioManager>().PlaySound("Game over");
    }

}