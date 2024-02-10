using System.Collections;
using UnityEngine;
public class DosPatas : Enemigos
{
    public float checkRadius;
    public float attackRadius;

    public bool shouldRotate;
    public LayerMask whatIsPlayer;
    public float distance;
    public float parrar;
    public float atacar;

    public Transform target;
    private Animator anim;
    private Vector2 movement;
    public Vector3 dir;

    public bool isInChaseRange;
    public bool isInAttackRange;
    //public BarraDeVida vidaSoldado;
    public bool estaMuerto = false;

    public Transform attackPos;
    public LayerMask whatIsPlayerTo;
    public float attackRange;
    [Header("Misiones Settings")]
    public int _id;
    public static QuestManager _questManager;

    void Start()
    {
        _questManager = GameObject.FindObjectOfType<QuestManager>();
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && estaMuerto==false)
        {
            MovementCharacter(movement);
            Move();
            shouldRotate = true;
            if (Vector3.Distance(target.transform.position, transform.position) < atacar)
            {
                anim.SetBool("IsAtacking", true);
                anim.SetFloat("x", dir.x);
                anim.SetFloat("y", dir.y);
            }
            else
            {
                anim.SetBool("IsAtacking", false);
            }
        }
    }
    private void FixedUpdate()
    {
     //   isInChaseRange = Physics2D.OverlapCircle(transform.position, checkRadius, whatIsPlayer);
       // isInAttackRange = Physics2D.OverlapCircle(transform.position, attackRadius, whatIsPlayer);
    
       // if (Vector3.Distance(target.transform.position, transform.position) < atacar && estaMuerto == false)
      /*  {
            shouldRotate = true;
            anim.SetBool("IsAtacking", true);
            anim.SetFloat("x", dir.x);
            anim.SetFloat("y", dir.y);

            Collider2D[] playerToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsPlayerTo);
            for (int i = 0; i < playerToDamage.Length; i++)
            {
                playerToDamage[i].GetComponent<Vida_Player>().takeDamage();
            }

        }
        else
        {
            anim.SetBool("IsAtacking", false);
        }
        //moverse
        if ((Vector3.Distance(target.transform.position, transform.position) < distance) && Vector3.Distance(target.transform.position, transform.position) > parrar && vidaActual > 0)
        {
            MovementCharacter(movement);
        }*/
        //MUERTE
        if (vidaActual <= 0)
        {      
            Muerte();
        }
    }

    private void MovementCharacter(Vector2 dir)
    {
        rb.MovePosition((Vector2)transform.position + (dir * speed * Time.deltaTime));
    }
    void Muerte()
    {
        anim.SetBool("Muerto", true);
        Destroy(this.GetComponent<BoxCollider2D>());
        estaMuerto = true;
        StartCoroutine(Espera());
    }
    IEnumerator Espera()
    {
        yield return new WaitForSeconds(7f);
        _questManager.SumarTarea(_id);
        Destroy(this.gameObject);
    }
    private void Move()
    {
        isInChaseRange = Physics2D.OverlapCircle(transform.position, checkRadius, whatIsPlayer);
        isInAttackRange = Physics2D.OverlapCircle(transform.position, attackRadius, whatIsPlayer);

        dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        dir.Normalize();
        movement = dir;

        if (shouldRotate)
        {
            anim.SetFloat("x", dir.x);
            anim.SetFloat("y", dir.y);
        }
        if (isInAttackRange)
        {
            rb.velocity = Vector2.zero;
        }
    }
}
