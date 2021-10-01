using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsForSceneControl : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void LoadStartScene()
    {
        SceneManager.LoadScene("Start");
    }
    public void LoadMainScene()
    {
        SceneManager.LoadScene("Main");
    }
    public void LoadSceneTwo()
    {
        SceneManager.LoadScene("SceneTwo");
    }

}
