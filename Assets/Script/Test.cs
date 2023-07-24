using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Test : MonoBehaviour
{
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.nowScene = 1;
            Debug.Log(GameManager.nowScene);

            SceneManager.LoadScene(1);
        }
    }
}
