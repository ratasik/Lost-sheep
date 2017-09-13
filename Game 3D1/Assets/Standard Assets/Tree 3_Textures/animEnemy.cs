using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animEnemy : MonoBehaviour {

    private Transform player;
    private Transform enemy;

    public Animator anim;

    public float predkoscObrotu = 4.0f;
    public float predkoscRuchu = 5.0f;
    public float zasieg = 30.0f;
    public float odstepOdGracza = 2f;

    // Use this for initialization
    void Start()
    {
        enemy = transform;
        GameObject go = GameObject.FindWithTag("Player");
        player = go.transform;

        anim = GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {

        //Pobranie dystansu dzielącego wroga od obiektu gracza.
        float dystans = Vector3.Distance(enemy.position, player.position);

        //Jeżeli dystans jaki dzieli obiekt wroga od obiektu gracza mieści się w zakresie widzenia wroga to 
        //obiekt wroga zaczyna poruszać się w kierunku gracza.
        //Obiekt wroga zatrzyma się przed graczem w zadanym odstępie.
        if (dystans < zasieg && dystans > odstepOdGracza)
        {
            anim.SetBool("isWalking", true);

        }
        else
        {
            anim.SetBool("isWalking", false);
        }

    }
    
   
}