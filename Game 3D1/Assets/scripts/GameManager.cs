using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    static public GameManager instance;


    void Awake() {
        if (instance != null) {
            Destroy(gameObject);
        } else {
            instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start()
    {
    }

        // Update is called once per frame
        void Update () {
          

            if (Input.GetButtonDown("Cancel")) {
                ExitGame();
            }
        }

    public void LoadLevel(int levelID) {
        SceneManager.LoadScene(levelID);
    }

    public void ExitGame() {
        Application.Quit();
    }

}
