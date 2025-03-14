using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{   
    
    public string GoToScene = "HomeScene";

    private void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(GoToScene);
        }
    }
}
