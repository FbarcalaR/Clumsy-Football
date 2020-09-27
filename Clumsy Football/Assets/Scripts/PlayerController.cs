using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 40f;
    public string playerName = "Player1";
    public float boostForce = 1000f;
    public ParticleSystem boostEffect;

    private bool onBoostCooldown = false;
    private float boostCooldownTimer = 1f;

    private float horizontalMove = 0f;
    private float verticalMove = 0f;
    private Rigidbody2D m_Rigidbody2D;
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;
    private Vector3 m_Velocity = Vector3.zero;

    public void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal" + playerName) * speed;
        verticalMove = Input.GetAxisRaw("Vertical" + playerName) * speed;
    }

    public void FixedUpdate()
    {
        Move(horizontalMove * Time.fixedDeltaTime, verticalMove * Time.fixedDeltaTime);
        boostCooldownTimerControl();
    }

    private void boostCooldownTimerControl()
    {
        if (onBoostCooldown)
        {
            boostCooldownTimer -= Time.deltaTime;
            if (boostCooldownTimer <= 0)
            {
                boostCooldownTimer = 1f;
                onBoostCooldown = false;
            }
        }
    }


    public void Move(float moveX, float moveY)
    {
        if (Input.GetButtonDown("Boost" + playerName) && !onBoostCooldown)
        {
            var effect = Instantiate(boostEffect, transform.position, Quaternion.identity);
            effect.gameObject.transform.SetParent(transform);
            m_Rigidbody2D.AddForce(m_Rigidbody2D.velocity.normalized * boostForce);
            onBoostCooldown = true;
        }
        Vector3 targetVelocity = new Vector2(moveX * 10f, moveY * 10f);
        m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
    }
}
