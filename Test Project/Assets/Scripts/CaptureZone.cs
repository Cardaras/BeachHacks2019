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
        if (go.CompareTag(AllTags.PLAYER_TAG))
        {
            Debug.Log("Player collided");
            int childCount = go.transform.childCount;
            for (int i = 0;i < childCount; i++)
            {
                if (go.transform.GetChild(i).CompareTag(AllTags.FLAG_TAG))
                {
                    Debug.Log("Flag captured");
                    Destroy(go.transform.GetChild(i).gameObject);
                    break;
                }
            }

           
        }
    }
}
