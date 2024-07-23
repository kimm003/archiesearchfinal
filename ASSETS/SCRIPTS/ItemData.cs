using System;
using System.Runtime.CompilerServices;

[Serializable]
public class ItemData
{
    public ItemData() { }

    public ItemData(ItemData data)
    {
        this.itemName = data.itemName;
    }

    public string itemName = "";
    //Note: You may add New Item Data
}
