﻿/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Girl2Movement : MonoBehaviour
{
    GameObject anchorpoint;

    public Transform Player;
      public float moveSpeed = 0.2f;
    public float rotationspeed = 0.2f;
    public Animator anim;
    public Rigidbody rigid;
    public GameObject explosion;
    public bool VargirlIsAlive2 = true; 

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.transform.position.Set(anchorpoint.transform.position.x-1, anchorpoint.transform.position.y, anchorpoint.transform.position.z);
        anim.SetBool("laufen", false);
        anim.SetBool("death", false);
        anim.SetBool("girlIsAlive", true);

    }

    // Update is called once per frame
    void Update()
    {
        if (VargirlIsAlive)
        {
            if (anim.GetBool("death") == true)
            {
                //Destroy(gameObject);
            }
            if (anim.GetBool("attack") == true)
            {

                Explode2();
                anim.SetBool("attack", false);
                // WaitForSeconds wait = new WaitForSeconds(5);

                //anim.SetBool("death", true);
            }
            if (Vector3.Distance(transform.position, Player.position) < 3 && VargirlIsAlive)
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
                //Explode();
                //Vector3 girlPosi = new Vector3(rigid.velocity);
                //rigid.velocity = ( transform.forward * moveSpeed);
            }
            else
            {
                anim.SetBool("laufen", false);
            }
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

   // float blastRadius = 3.0f;

    private void Explode2()
    {

        //GameObject[] player = GameObject.FindGameObjectsWithTag("Player");
        //foreach (GameObject creature in player)
        //{

        if (blastRadius >= Vector3.Distance(transform.position, Player.position))
        {


            //Add Code for affected enemies here, example :
            //enemy.GetComponent(HealthScript).addDamage(100);
            GameObject.Instantiate(explosion, transform.position, Quaternion.identity, transform);
            Debug.Log("blast radius hits player");
            //creature.GetComponent<PlayerHealth2>().TakeDamage(10);#+
            Player.GetComponent<PlayerHealth2>().TakeDamage(10);
            anim.Play("FreeVoxelGirl-jump");
            Debug.Log("Jump");
            VargirlIsAlive = false;
            Debug.Log(VargirlIsAlive);
            anim.SetBool("girlIsAlive", false);
            anim.SetBool("laufen", false);
            //anim.Play("FreeVoxelGirl-idle");
            //Destroy(gameObject);
        }

        //}

    }
} */
