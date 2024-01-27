using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameButton : MonoBehaviour
{
    
    public void OnButtonPush()
    {
        SceneManager.LoadScene(0);
    }

}
