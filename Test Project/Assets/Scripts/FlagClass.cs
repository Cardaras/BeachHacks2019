using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagClass : MonoBehaviour
{

    private string LEFT_HAND = "mixamorig:LeftHand";

    private FlagZone flagZone;

    public void SetZone(FlagZone zone)
    {
        flagZone = zone;
    }

    public FlagZone GetFlagZone()
    {
        return flagZone;
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject go = other.transform.gameObject;

        //Debug.Log("Something entered = "+go.tag);
        if (go.CompareTag(AllTags.PLAYER_TAG) && go.name.Equals("xbotwithcamera") && go.GetComponent<FlagHandler>().HasFlag() == false)
        {

            //Debug.Log("Player collided");
            this.transform.parent = GameObject.Find(LEFT_HAND).transform; //go.transform.FindChild(LEFT_HAND).transform;
            this.transform.localPosition = new Vector3(0,-0.05f,0);
            this.transform.eulerAngles = new Vector3(-110,100,45);
            this.transform.localScale = new Vector3(1f, 1f, 1f);

            go.GetComponent<FlagHandler>().SetFlag(true, this.gameObject);
        }
    }
}
