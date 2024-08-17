using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectionManager : MonoBehaviour
{
    public static ItemCollectionManager Instance;

    public List<ItemData> collectibleItems = new List<ItemData>();

    public ItemsPanelView view;

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

        DontDestroyOnLoad(Instance);
    }


    public void AddInteractableToCollectibles(BaseInteractableController interactableItemController)
    {
        collectibleItems.Add(interactableItemController.itemData);

        interactableItemController.OnItemInteractedAction = () => OnItemCollectedAction(interactableItemController);

        view.CreateNewNamePlate(interactableItemController.itemData.itemName);
    }

    void OnItemCollectedAction(BaseInteractableController item)
    {
        view.RemoveNamePlate(item.itemData.itemName);
    }


}
