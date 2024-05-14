using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoPlay : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Play()
    {
        SceneManager.LoadScene("PlayScene");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
