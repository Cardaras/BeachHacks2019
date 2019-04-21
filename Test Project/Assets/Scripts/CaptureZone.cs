using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureZone : MonoBehaviour
{
    private GameObject flagPrefab;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject go = other.transform.gameObject;

        //Debug.Log("Something entered = "+go.tag);
        if (go.CompareTag(AllTags.PLAYER_TAG) && go.name.Equals("xbotwithcamera"))
        {
            Debug.Log("Player in capture zone");
            if (go.GetComponent<FlagHandler>().HasFlag())
            {
                Debug.Log("Capture");
                go.GetComponent<FlagHandler>().DestroyFlag();
                go.GetComponent<FlagHandler>().SetFlag(false, null);

            }

           
        }
    }
}
