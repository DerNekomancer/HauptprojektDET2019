using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragon : MonoBehaviour
{
    public Transform Player;
    public Animator anim;
    float moveSpeed = 0.2f;
    int timePassed = 0;
    
    // Start is called before the first frame update
    void Start()
    {
       // anim.SetBool("Fly", true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, Player.position) < 20)
        {
            transform.LookAt(Player);
            if(anim.GetBool("isIdle") == false)             //flying
            {
                if (Vector3.Distance(transform.position, Player.position) < 6)
                {
                    anim.SetBool("flyAttack", true);
                }
                if (Vector3.Distance(transform.position, Player.position) <= 15 && Vector3.Distance(transform.position, Player.position) > 7)
                {
                    transform.Translate(0f, 0f, 5f * moveSpeed * Time.deltaTime);
                }
            }
            else                                             //on the ground
            {
                if(Vector3.Distance(transform.position, Player.position) < 8)
                {
                    anim.SetBool("standAttack", true);
                    anim.SetBool("walking", false);
                }
                if (Vector3.Distance(transform.position, Player.position) <= 15 && Vector3.Distance(transform.position, Player.position) > 7)
                {
                    anim.SetBool("walking", true);
                    transform.Translate(0f, 0f, 5f * moveSpeed * Time.deltaTime);
                }
            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                anim.SetBool("isIdle", false);
            }
            else if (Input.GetKeyDown(KeyCode.O))
            {
                anim.SetBool("isIdle", true);
            }
        }
    }
}
