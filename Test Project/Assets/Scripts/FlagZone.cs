using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagZone : MonoBehaviour
{

    private GameObject flag;
    private string LEFT_HAND = "mixamorig:LeftHand";

    // Start is called before the first frame update
    void Start()
    {

        GameObject[] flags = GameObject.FindGameObjectsWithTag(AllTags.FLAG_TAG);

        //Debug.Log("Number of flags = " + flags.Length);

        foreach(GameObject go in flags)
        {
            if (go.transform.parent.Equals(this.transform.parent))
            {
                //Debug.Log("Fount parent");
                flag = go;
            }
            //Debug.Log(go.transform.parent.name);
        }
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
            //Debug.Log("Player collided");
            flag.transform.parent = GameObject.Find(LEFT_HAND).transform; //go.transform.FindChild(LEFT_HAND).transform;
            flag.transform.localPosition = new Vector3(0,-0.05f,0);
            flag.transform.eulerAngles = new Vector3(0,125,0);
            flag.transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
