using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonHandler : MonoBehaviour {

	public void StartGame(string sceneName)
    {
        Application.LoadLevel(sceneName);
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }
}
