using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemsType { cube, sphere, cylinder }

[CreateAssetMenu (fileName = "Inventory", menuName = "Simple Inventory" )]
public class Inventory : ScriptableObject
{

    [System.Serializable]
    public struct CollectableItems
    {
        public GameObject Prefab;
        public ItemsType Description;
    }
    public CollectableItems[] Items;



    private Dictionary<ItemsType, GameObject> collection = new Dictionary<ItemsType, GameObject>();
    public List<ItemsType> savedItems = new List<ItemsType>();


    public void InitItems()
    {
        collection.Clear();
        savedItems.Clear();

        foreach(var item in Items)
        {
            if(collection.ContainsKey(item.Description) == false)
            collection.Add(item.Description, item.Prefab);
        }
    }

    public void SaveItem(ItemsType type)
    {
        if(savedItems.Count < 3)
        savedItems.Add(type);
    }


    public void GiveBack()
    {
        Debug.Log("Restore");
        ItemsType current;
        if (savedItems.Count > 0)
        {
            int last = savedItems.Count - 1;
            current = savedItems[last];
            Instantiate(collection[current], Vector3.zero, Quaternion.identity);
            savedItems.Remove(current);

        }
      
    }



}
