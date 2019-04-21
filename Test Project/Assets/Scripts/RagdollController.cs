using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollController : MonoBehaviour
{
    public Animator run_anim;
    public Rigidbody[] rbs;

    public GameObject test;

    public GameObject ragdollRoot;

    private bool is_sprinting = false;

    private float tackleDelay = 1f;
    private float ragdollDelay = 0.1f;

    private float forwardForce = 100f;


    private bool isRagdolled = false;

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
            //Debug.Log("Ragdoll");
            toggleRagdoll(true);
        }

        if(Input.GetKeyDown(KeyCode.Space) && 
            GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter>().IsMaxSprint())
        {

            //StartCoroutine(Tackle());
            //StartCoroutine(Ragdoll());
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Tackle());
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            toggleRagdoll(false);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            StartCoroutine(Tackle());
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && !is_sprinting)
        {
            //Debug.Log("Sprint on");
            ToggleSprint(true);
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            //Debug.Log("Sprint off");
            ToggleSprint(false);
        }
    }

    private IEnumerator Tackle()
    {
        //yield return new WaitForSeconds(tackleDelay);
        toggleRagdoll(true);
        Rigidbody rb = ragdollRoot.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward*forwardForce+ transform.up*forwardForce, ForceMode.Impulse);
        yield return new WaitForFixedUpdate();
        bool done = false;
        while(!done)
        {
            if(rb.velocity.magnitude < 0.1)
            {
                done = true;
            }
            yield return null;
        }
        toggleRagdoll(false);
    }

    private IEnumerator Ragdoll()
    {
        yield return new WaitForSeconds(ragdollDelay);
        toggleRagdoll(true);
    }

    private void toggleRagdoll(bool isRagdoll)
    {
        if (isRagdolled == isRagdoll)
            return;
        isRagdolled = isRagdoll;
        run_anim.enabled = !isRagdoll; 
        foreach (var item in rbs)
        {
            item.isKinematic = !isRagdoll;
        }
        if(!isRagdoll)
        {
            this.transform.position = ragdollRoot.transform.position;
            ragdollRoot.transform.localPosition = Vector3.zero;
        }

    }

    private void ToggleSprint(bool s)
    {
        this.is_sprinting = s;
        GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter>().SetIsSprinting(is_sprinting);
    }

}
