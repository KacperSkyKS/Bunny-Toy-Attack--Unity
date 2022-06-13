using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// Skrypt zarządzający Menu gry
public class MainMenu : MonoBehaviour
{
    // nazwa sceny
    public string sceneToLoad="Arena";
    // element zawierający komunikat Wczytywanie...
    public RectTransform loadingOverlay;
    // wczytywanie w tle
    AsyncOperation sceneLoadingOperation;
    public void Start()
    {
        Cursor.visible = true;
        // zapewnienie, że nakładka 'Wczytywanie...' będzie widoczna
        loadingOverlay.gameObject.SetActive(false);
        // rozpoczynamy wczytywanie w tle
        sceneLoadingOperation = SceneManager.LoadSceneAsync(sceneToLoad);
        // nie wyświetlamy sceny, aż nie zostanie wczytana
        sceneLoadingOperation.allowSceneActivation = false;
    }
    public void LoadScene()
    {
        //wyświetlamy nakładkę
        loadingOverlay.gameObject.SetActive(true);
        // przełączamy sceny
        sceneLoadingOperation.allowSceneActivation = true;
    }
    public void ExitGame() {
        Application.Quit();
    }
}
