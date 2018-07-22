using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    public void GotoScene(int i)
    {
        switch (i)
        {
            default:
            case (0):
                SceneManager.LoadScene("Menu");                
                break;
            case (1):
                GameObject loadingScreen = Resources.Load("prefabs/LoadingScreen") as GameObject;
                GameObject parent = GameObject.Find("Canvas");
                Instantiate(loadingScreen, parent.transform);
                SceneManager.LoadScene("Belajar");                
                break;
            case (2):
                SceneManager.LoadScene("Game");
                break;
            case (3):
                SceneManager.LoadScene("Bantuan");
                break;
            case (4):
                SceneManager.LoadScene("Tentang");
                break;
        }            
    }
}
