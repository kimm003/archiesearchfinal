using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreenStart : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            LoadGame();
        }
    }

    void LoadGame()
    {
        SceneManager.LoadScene(1);
    }
}
