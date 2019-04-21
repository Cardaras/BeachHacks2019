using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagHandler : MonoBehaviour
{
    private bool hasFlag = false;
    private GameObject flag;
    private FlagZone flagZone;

   
    public void SetFlagZone(FlagZone cap)
    {
        flagZone = cap;
    }
    public bool HasFlag()
    {
        return hasFlag;
    }

    public void SetFlag(bool b, GameObject go)
    {
        hasFlag = b;

        if(go != null)
            flag = go;
    }

    public void DestroyFlag()
    {
        flag.GetComponent<FlagClass>().GetFlagZone().OnFlagDestroy();
        Destroy(flag);
    }

}
