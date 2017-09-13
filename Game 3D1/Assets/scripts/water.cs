using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class water : MonoBehaviour {
    private Transform player;
    private Transform enemy;
   


    

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

       

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(4);
            return;
        }

       
    }

       


} 