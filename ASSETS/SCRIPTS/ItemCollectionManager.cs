using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemCollectionManager : MonoBehaviour
{
    public static ItemCollectionManager Instance;

    public List<ItemData> collectibleItems = new List<ItemData>();

    public ItemsPanelView view;
    public PickUpInfoBoardController infoBoardController;

    public GameObject gameComplete;
    private bool isGameComplete = false;

    public void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void Update()
    {
        if(isGameComplete && Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(0);
        }
    }


    public void AddInteractableToCollectibles(BaseInteractableController interactableItemController)
    {
        isGameComplete = false;
        collectibleItems.Add(interactableItemController.itemData);

        interactableItemController.OnItemInteractedAction = () => OnItemCollectedAction(interactableItemController);

        view.CreateNewNamePlate(interactableItemController.itemData.itemName);
    }

    public void CheckIfGameIsComplete()
    {
        if (collectibleItems.Count == 0)
        {
            gameComplete.SetActive(true);
            isGameComplete = true;
        }
    }

    void OnItemCollectedAction(BaseInteractableController item)
    {
        view.RemoveNamePlate(item.itemData.itemName);
        infoBoardController.OnItemInteracted(item.itemData.itemName);

        int removeIdx = collectibleItems.FindIndex(x => x.itemName == item.itemData.itemName);
        collectibleItems.RemoveAt(removeIdx);
    }


}
