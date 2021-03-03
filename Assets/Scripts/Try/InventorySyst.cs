using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class InventorySyst : MonoBehaviour
{

    [SerializeField] public Inventory data;
    [SerializeField] private int levelIndex;
    public static int GameLaunchCounter;
    public PostProcessVolume volume;



    // Start is called before the first frame update
    void Start()
    {
        volume.gameObject.SetActive(false);

        if (GameLaunchCounter < 1)
            data.InitItems();

        GameLaunchCounter++;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
