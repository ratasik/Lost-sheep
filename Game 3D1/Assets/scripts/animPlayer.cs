using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animPlayer : MonoBehaviour {
    public Animator anim;
    private float vert;
   
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Jump"))
        {
            anim.SetBool("isJumping", true);
        }
        else
        {
            anim.SetBool("isJumping", false);

        }
        vert = Input.GetAxis("Vertical");
        anim.SetFloat("isWalking", vert);


    }
}
