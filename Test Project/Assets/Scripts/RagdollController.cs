using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollController : MonoBehaviour
{
    public Animator anim;
    public Rigidbody[] rbs;

    // Start is called before the first frame update
    void Awake()
    {
        toggleRagdoll(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Ragdoll");
            toggleRagdoll(true);
        }
    }

    private void toggleRagdoll(bool isRagdoll)
    {
        anim.enabled = !isRagdoll;
        foreach (var item in rbs)
        {
            item.isKinematic = !isRagdoll;
        }
    }
}
