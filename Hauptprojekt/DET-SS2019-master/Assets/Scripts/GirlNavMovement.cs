using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GirlNavMovement : MonoBehaviour
{
    public Transform Player;
    public float moveSpeed = 0.2f;
    public float rotationspeed = 0.2f;
    public Animator anim;
    public Rigidbody rigid;
    public bool VargirlIsAlive = true;
    public int hp = 10;
    public GameObject Iceshot;
    float fireRate = 3.0f;
    float nextFire = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        anim.SetBool("laufen", false);
        anim.SetBool("death", false);
        anim.SetBool("girlIsAlive", true);
        anim.SetBool("sidewalk", false);

    }

    // Update is called once per frame
    void Update()
    {
        if (VargirlIsAlive)
        {
            if (Vector3.Distance(transform.position, Player.position) < 20)
            {
                transform.LookAt(Player);
            }
            if (Vector3.Distance(transform.position, Player.position) <= 15 && Vector3.Distance(transform.position, Player.position) >= 5)
            {
                //anim.SetBool("sidewalk", false);
                anim.SetBool("laufen", true);
                transform.Translate(0f, 0f, 5f * moveSpeed * Time.deltaTime); //auf uns zu laufen
            }
            if (Vector3.Distance(transform.position, Player.position) < 3)
            {
                anim.SetBool("laufen", true);
                //anim.SetBool("sidewalk", false);
                transform.Translate(0f, 0f, -5f * moveSpeed * Time.deltaTime);
            }
            if (Vector3.Distance(transform.position, Player.position) >= 3 && Vector3.Distance(transform.position, Player.position) < 5)
            {
                //anim.SetBool("laufen", false);
                anim.SetBool("sidewalk", true);
                transform.Translate(5f * moveSpeed * Time.deltaTime, 0f, 0f);
                if (Time.time > nextFire)
                {
                    nextFire = Time.time + fireRate;
                    //GameObject.Instantiate(Iceshot, transform.position, Quaternion.identity, transform);
                }
            }
        }

    }

    private void OnParticleCollision(GameObject other)
    {
        this.hp -= 1;
        Debug.Log(hp);
        if (hp <= 0)
        {
            VargirlIsAlive = false;
            anim.SetBool("girlIsAlive", false);
        }
    }
}
