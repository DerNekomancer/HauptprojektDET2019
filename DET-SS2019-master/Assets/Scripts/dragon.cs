using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragon : MonoBehaviour
{
    public Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        anim.SetBool("Fly", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
