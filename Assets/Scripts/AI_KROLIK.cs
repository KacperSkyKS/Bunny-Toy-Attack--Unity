using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AI_KROLIK : MonoBehaviour
{
    private Transform target;
    public Rigidbody rb;
    public GameObject healthBarUI;
    public Slider slider;
    public Vector3 movement;
    public Animator KROLIKAnimation;
    [SerializeField] private AudioSource soundSource;
    [SerializeField] private AudioClip impactSound;
    [SerializeField] private AudioClip walkSound;

    private float speed = 6.0f;
    public float obstacleRange = 5.0f;
    private bool _alive;
    private bool isAttacking = false;
    private bool isAngry=false;
    private bool isRaged = false;
    public const float baseSpeed = 6.0f;
    private int damage = 5;
    public float health;
    public float maxHealth;



    private void Start()
    {
        _alive = true;
        target = GameObject.Find("Player").transform;
        if (Kontroler.completedWaves != 0 && Kontroler.completedWaves % 2 == 0 || Kontroler.completedWaves > 2)
        {
            maxHealth *= (1 + 1f * Mathf.Floor((Kontroler.completedWaves) / 2));
            health = maxHealth;
            damage +=(Kontroler.completedWaves) / 2;
            speed += Mathf.Floor((Kontroler.completedWaves) / 2);
        }
        else
        {
            health = maxHealth;
        }
        slider.value = CurrentHealth();
    }
    void Awake()
    {
        Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }
    void Update()
    {
        slider.value = CurrentHealth();
        if (_alive)
        {
            transform.LookAt(new Vector3(target.position.x, this.transform.position.y, target.position.z));
            if (Vector3.Distance(transform.position, target.position) >= 3.75f && isAttacking == false)
            {
                transform.position += transform.forward * Time.deltaTime * speed;
            }
            else
            {
                isAttacking = true;
                makeAttack();
            }
            if (Vector3.Distance(transform.position, target.position) < 3.75f)
            {
                rb.velocity = Vector3.zero;
            }

        }
        else
        {
            transform.position += transform.forward * Time.deltaTime * 0f;
            KROLIKAnimation.SetBool("isDead", true);
        }
        if (health / maxHealth <= 0.5f && isAngry==false) {
            speed *= 2;
            isAngry = true;
            KROLIKAnimation.speed = 1.5f;
        }
        if (health / maxHealth <= 0.2f && isRaged==false)
        {
            speed *= 2;
            KROLIKAnimation.speed = 2.5f;
            isRaged = true;
        }
    }
    public void SetAlive(bool alive)
    {
        _alive = alive;
    }
    float CurrentHealth()
    {
        return health / maxHealth;
    }
    void OnDestroy()
    {
        Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }
    private void OnSpeedChanged(float value)
    {
        speed = baseSpeed * value;
        Debug.Log(speed);
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Managers.Player.hurtPlayer(damage);
        }
    }
    void makeAttack() {
        transform.position += transform.forward * Time.deltaTime * 0f;
        KROLIKAnimation.SetBool("isCloseToPlayer", true);

    }
    void AttackEnd() {
        isAttacking = false;
        KROLIKAnimation.SetBool("isCloseToPlayer", false);
        transform.position += transform.forward * Time.deltaTime * speed;
    }
    void PlayImpactSound() {
        soundSource.PlayOneShot(impactSound);
    }
    void PlayWalkSound()
    {
        soundSource.PlayOneShot(walkSound);
    }
}
