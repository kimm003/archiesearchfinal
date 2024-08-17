using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ItemsPanelView : MonoBehaviour
{
    public GridLayoutGroup layoutGroup;
    [Header("Reference")]
    public Transform collectibleParent;
    public GameObject CollectibleItemPrefab;

    public List<ItemCollectibleNamePlateView> collectibleNamePlateList = new List<ItemCollectibleNamePlateView>();

    private float delayLayoutDisableCount = 1.0f;
    private float curCount = 0.0f;


    private void Update()
    {
        if (layoutGroup.enabled)
        {
            curCount += Time.deltaTime;

            if (curCount > delayLayoutDisableCount)
            {
                curCount = 0.0f;
                layoutGroup.enabled = false;
            }
        }
    }

    public void CreateNewNamePlate(string itemName)
    {
        layoutGroup.enabled = true;
        
        ItemCollectibleNamePlateView tmp = Instantiate(CollectibleItemPrefab, collectibleParent).GetComponent<ItemCollectibleNamePlateView>();
        tmp.collectibleName = itemName;
        tmp.collectibleNameText.text = itemName;

        collectibleNamePlateList.Add(tmp);
    }


    public void RemoveNamePlate(string name)
    {
        ItemCollectibleNamePlateView itemNamePlate = collectibleNamePlateList.FirstOrDefault(x => x.collectibleName == name);

        collectibleNamePlateList.Remove(itemNamePlate);

        Destroy(itemNamePlate.gameObject);
    }

}
