using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SplashScreenStart : MonoBehaviour
{
    public Image splashImage;

    public List<Sprite> splashSprites = new List<Sprite>();
    public int curImageIdx = 0;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && curImageIdx == 0)
        {
            LoadGame();
        }
        else if(Input.GetKeyDown(KeyCode.Return) && curImageIdx == 1)
        {
            LoadGame();
        } 
        else if(Input.GetKeyDown(KeyCode.Space) && curImageIdx == 2)
        {
            LoadGame();
        }
    }

    void LoadGame()
    {
        curImageIdx++;


        if(curImageIdx >= splashSprites.Count)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            splashImage.sprite = splashSprites[curImageIdx];
        }
    }
}
