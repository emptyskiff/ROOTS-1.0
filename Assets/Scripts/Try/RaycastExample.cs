//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class RaycastExample : MonoBehaviour
//{

//    [SerializeField] private Material highlightMaterial;

//    private Camera sceneCamera;
//    private Ray ray;
//    private RaycastHit hit;

//    private RaySelectable current, previous;

//    [SerializeField] private Inventory data;
//    [SerializeField] private int levelIndex;
//    public static int GameLaunchCounter;



//    void Start()
//    {
//        sceneCamera = Camera.main;

//        if(GameLaunchCounter < 1)
//        data.InitItems();

//        GameLaunchCounter++;

//    }

//    // Update is called once per frame
//    void Update()
//    {

//        ray = sceneCamera.ScreenPointToRay(Input.mousePosition);
//        bool onHit = Physics.Raycast(ray, out hit, 20f);


//        if (onHit && hit.collider.TryGetComponent(out RaySelectable item))
//        {
//            previous = current;
//            current = item;

//            if (previous != current)
//            {
//                Select(item);
//            }

//            if (Input.GetMouseButtonDown(0))
//            {
//                data.SaveItem(item.Description);
//                Destroy(item.gameObject);

//            }

//        }

//        // когда луч не пересекает a:
//        else if (current != null)
//        {
//            Deselect(current);
//            current = null;
//        }


//        // в том случае если хит продолжается, но объекты стоят вплотную 
//        if(onHit && previous != null && previous != current)
//        {
//            Deselect(previous);
//            previous = null;
//        }


//        if (Input.GetKeyDown(KeyCode.R))
//        {
//            SceneManager.LoadScene(levelIndex);
//        }


//        if (Input.GetMouseButtonDown(1))
//        {
//            Debug.Log("Restore click");
//            data.GiveBack();
//        }



//    }

//    private void Select(RaySelectable cube)
//    {
//        cube.Highlight(highlightMaterial);
//    }

//    private void Deselect(RaySelectable cube)
//    {
//        cube.Deselect();
//    }

//}
