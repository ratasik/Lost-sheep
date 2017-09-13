using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{

    private Transform player;
    private Transform enemy;



    public float predkoscObrotu = 4.0f;
    public float predkoscRuchu = 5.0f;
    public float zasieg = 30.0f;
    public float odstepOdGracza = 2f;
    private Vector3 moveDirection = Vector3.zero;
    public CharacterController controller;
    private float gravity = 40f;
    private bool isChasing = false;
    // Use this for initialization
    void Start()
    {
        enemy = transform;
        GameObject go = GameObject.FindWithTag("Player");
        player = go.transform;




    }

    // Update is called once per frame
    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        Vector3 forward = transform.TransformDirection(Vector3.zero);
        float curSpeed = predkoscRuchu;
        controller.SimpleMove(forward * curSpeed);


        controller.SimpleMove(Vector3.zero);

     
        float dystans = Vector3.Distance(enemy.position, player.position);

      
        if (dystans < zasieg && dystans > odstepOdGracza)
        {
            isChasing = true;
         
            enemy.rotation = Quaternion.Slerp(enemy.rotation, Quaternion.LookRotation(player.position - enemy.position), predkoscRuchu * Time.deltaTime);

      
            enemy.position += enemy.forward * predkoscRuchu * Time.deltaTime;
            moveDirection.y -= gravity * Time.deltaTime;
            controller.Move(moveDirection * Time.deltaTime);


        }
      
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(2);
            return;
        }
        if (other.tag == "water")
        {
            Destroy(gameObject);
        }
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (controller.isGrounded && hit.normal.y < 0.7f)
        {
            isChasing = false;
        }
    }
}