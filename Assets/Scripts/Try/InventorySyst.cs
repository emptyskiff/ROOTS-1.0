using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySyst : MonoBehaviour
{

    [SerializeField] public Inventory data;
    [SerializeField] private int levelIndex;
    public static int GameLaunchCounter;




    // Start is called before the first frame update
    void Start()
    {
        if (GameLaunchCounter < 1)
            data.InitItems();

        GameLaunchCounter++;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
