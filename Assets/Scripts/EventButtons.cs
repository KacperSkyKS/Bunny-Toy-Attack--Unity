using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventButtons : MonoBehaviour
{

    public void LoadScene(string name) {
        Kontroler.completedWaves = 0;
        SceneManager.LoadScene(name);
    }
    public void ExitGame() {
        Application.Quit();
    }

}
