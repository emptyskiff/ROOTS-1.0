using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public enum ItemsType { cube, sphere, cylinder }

[CreateAssetMenu (fileName = "Inventory", menuName = "Simple Inventory" )]
public class Inventory : ScriptableObject
{

    [System.Serializable]
    public struct CollectableItems
    {
        public GameObject prefab;
        public string name;
    }
    public CollectableItems[] Items;

    public int inventorySize = 3;

    private Dictionary<string, GameObject> collection = new Dictionary<string, GameObject>();
    public List<string> savedItems = new List<string>();


    public void InitItems()
    {
        collection.Clear();
        savedItems.Clear();

        foreach(var item in Items)
        {
            if(collection.ContainsKey(item.name) == false)
            collection.Add(item.name, item.prefab);
        }
    }

    public void SaveItem(GameObject item)
    {
        if (savedItems.Count < inventorySize)
        {
            savedItems.Add(item.GetComponent<InventoryObj>().objectName);
        }
    }


    public void GiveBack(Vector3 transform, Quaternion rotation)
    {
        Debug.Log("Restore");
        string currentName;
        if (savedItems.Count > 0)
        {
            int last = savedItems.Count - 1;
            currentName = savedItems[last];
            var placed = Instantiate(collection[currentName], transform, rotation);
            if (placed.GetComponent<InventoryObj>() != null)
            {
                Destroy(placed.GetComponent<InventoryObj>());
            }
            savedItems.Remove(currentName);

        }
      
    }



}
