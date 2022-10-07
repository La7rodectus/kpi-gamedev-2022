using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char : MonoBehaviour
{

    [SerializeField] private float hp = 100f;
    [SerializeField] private float jumpForce = 15f;
    [SerializeField] private float speed = 5f;

    private bool isGrounded = true;
    private Animator anim;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    void Awake()
    {
        hp = 100f;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }


    private bool isFalling()
    {
        return rb.velocity.y < 0 ? true : false;
    }
    private void CheckGround()
    {
        isGrounded = transform.Find("ground_check").GetComponent<ground_check>().isGrounded;
        
        if (!isGrounded && hp > 0) {
            State = isFalling() ? States.jumpFall : States.jump;
        }
    }

    private States State
    {
        get { return (States)anim.GetInteger("state"); }
        set { anim.SetInteger("state", (int)value); }
    }

    private void Run()
    {
        if (isGrounded) State = States.run;

        Vector3 dir = transform.right * Input.GetAxis("Horizontal"); //joystick.Horizontal;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
        sprite.flipX = dir.x < 0.0f;

    }
    private void FixedUpdate()
    {
        CheckGround();
    }
    private void Jump()
    {
        rb.velocity = Vector2.up * jumpForce;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded) {
            State = States.idle;
        }
        if (Input.GetButton("Horizontal")) Run();
        if (isGrounded && Input.GetButtonDown("Jump")) Jump();
    }
}

public enum States
{
    idle,
    run,
    jump,
    jumpFall
}

