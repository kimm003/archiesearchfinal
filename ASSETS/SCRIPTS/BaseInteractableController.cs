using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InteractableType
{
    Item,
    Character,
}

/// <summary>
/// Feel free to attach this to a gameObject you want the character to interact with.
/// </summary>
public class BaseInteractableController : MonoBehaviour
{
    public InteractableType type = InteractableType.Item;
    public ItemData itemData = new ItemData();

    public Action OnItemInteractedAction;

    public void Start()
    {
        if(type == InteractableType.Item)
        {
            ItemCollectionManager.Instance.AddInteractableToCollectibles(this);
        }
    }

    public void ItemInteracted()
    {
        OnItemInteractedAction?.Invoke();
    }
}
