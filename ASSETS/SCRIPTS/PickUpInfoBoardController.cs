using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PickUpInfoBoardController : MonoBehaviour
{
    [Header("References")]
    public GameObject Content;
    public Image infoBoardImage;
    [Header("Item Sprites")]
    public List<Sprite> infoBoardSprites = new List<Sprite>();

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && Content.gameObject.activeInHierarchy)
        {
            Content.gameObject.SetActive(false);
        }
    }

    public void OnItemInteracted(string itemName)
    {
        Sprite itemInteractedSprite = infoBoardSprites.First(x => x.name == itemName);

        infoBoardImage.sprite = itemInteractedSprite;
        Content.gameObject.SetActive(true);
    }
}
