using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollController : MonoBehaviour
{
    public Animator anim;
    public Rigidbody[] rbs;

    private bool is_sprinting = false;

    private float tackleDelay = 0.3f;
    private float ragdollDelay = 0.4f;

    private float forwardForce = 500f;

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
        /*
        if(Input.GetKeyDown(KeyCode.Space) && 
            GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter>().IsMaxSprint())
        {
            StartCoroutine(Tackle());
            StartCoroutine(Ragdoll());
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            StartCoroutine(Tackle());
        }
        */
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
        yield return new WaitForSeconds(tackleDelay);
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.forward * forwardForce);

    }

    private IEnumerator Ragdoll()
    {
        yield return new WaitForSeconds(ragdollDelay);
        toggleRagdoll(true);
    }

    private void toggleRagdoll(bool isRagdoll)
    {
        anim.enabled = !isRagdoll;
        foreach (var item in rbs)
        {
            item.isKinematic = !isRagdoll;
        }
        //void HandleAirborneMovement()

    }

    private void ToggleSprint(bool s)
    {
        this.is_sprinting = s;
        GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter>().SetIsSprinting(is_sprinting);
    }

}
