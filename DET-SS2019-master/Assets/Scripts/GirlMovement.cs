using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlMovement : MonoBehaviour
{
    public Transform Player;
    public float moveSpeed = 0.2f;
    public float rotationspeed = 0.2f;
    public Animator anim;
    public Rigidbody rigid;
    // Start is called before the first frame update
    void Start()
    {
        anim.SetBool("laufen", false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, Player.position) < 3)
        {
            anim.SetBool("attack", true);
        }
        if (Vector3.Distance(transform.position, Player.position) < 20 && anim.GetBool("attack") == false)
        {
            transform.LookAt(Player);
        }
        if (Vector3.Distance(transform.position, Player.position) <= 15 && anim.GetBool("attack") == false)
        {
            anim.SetBool("laufen", true);
            transform.Translate(0f, 0f, 5f * moveSpeed * Time.deltaTime);
            //Vector3 girlPosi = new Vector3(rigid.velocity);
            //rigid.velocity = ( transform.forward * moveSpeed);
        }
        else
        {
            anim.SetBool("laufen", false);
        }

    }

    private void FixedUpdate()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        //if (collision
        //rigid.velocity = new Vector3(0, 3, 0);
    }

    float blastRadius = 10.0f;
 
    private void Explode()
    {

        GameObject[] player = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject creature in player)
        {

            if (blastRadius >= Vector3.Distance(transform.position, Player.position))
            {

                //Add Code for affected enemies here, example :
                //enemy.GetComponent(HealthScript).addDamage(100);

               creature.GetComponent<PlayerHealth2>().TakeDamage(10);
            }

        }

    }
}
