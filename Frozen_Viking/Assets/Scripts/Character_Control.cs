using UnityEngine;
using UnityEngine.UI;

public class Character_Control : MonoBehaviour
{
    public float move_speed;
    public float jump_force;
    public float double_force;

    public Animator animator;
    public Rigidbody2D rb2D;

    public Transform ground_check_position;
    public float ground_check_radius;
    public LayerMask ground_check_layer;
    public bool grounded;
    public bool mid_air;

    public Image filler;  // this will ajustthe fill amount value
    public float health;  // current healt
    public float prev_health;  // health before we took dmg
    public float max_health;  // what is the max val of health
    public float counter;  // from 0 to max counter, and starts again from 0 to max counter in seconds
    public float max_counter;  // how long it takes to animate the filler

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.OverlapCircle(ground_check_position.position, ground_check_radius, ground_check_layer);
        transform.Translate(Input.GetAxis("Horizontal") * move_speed * Time.deltaTime, 0, 0);
        if (Input.GetAxisRaw("Horizontal") != 0 )
        {
            // This means you either have a or d pressed
            transform.localScale = new Vector3(Input.GetAxisRaw("Horizontal"), 1, 1);
            animator.SetBool("Walk", true);
        }
        else
        {
            //Nothing is pressed
            animator.SetBool("Walk", false);
        }

        if (Input.GetButtonDown("Jump") && grounded == true)
        {
            rb2D.velocity = new Vector2(0, jump_force);
            animator.SetTrigger("Jump");
            mid_air = true;
        }
        else if (Input.GetButtonDown("Jump") && grounded == false && mid_air == true)
        {
            rb2D.velocity = new Vector2(0, double_force);
            animator.SetTrigger("Jump");
            mid_air = false;
        }

        // heath baar stuff
        if(counter > max_counter)
        {
            prev_health = health;
            counter = 0;
        }
        else
        {
            counter += Time.deltaTime;
        }


        filler.fillAmount = Mathf.Lerp(prev_health/max_health, health/max_health, counter/max_counter);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Take_Damage(15);
        }
    }

    public void Take_Damage(float damage)
    {
        prev_health = filler.fillAmount * max_health;
        counter = 0;
        health -= damage;
    }    
}
