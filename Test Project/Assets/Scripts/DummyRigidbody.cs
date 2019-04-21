using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyRigidbody : MonoBehaviour
{

    public Animator stand_anim;
    public Rigidbody[] rbs;
    public GameObject ragdollRoot;
    private bool isRagdolled;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(AllTags.PLAYER_TAG))
        {

            toggleRagdoll(true);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(Entered(other));
    }

    private IEnumerator Entered(Collider other)
    {
        Debug.Log("Tag = " + other.tag);
        if (other.gameObject.CompareTag(AllTags.PLAYER_TAG))
        {
            //yield return new WaitForSeconds(tackleDelay);
            toggleRagdoll(true);
            Rigidbody rb = ragdollRoot.GetComponent<Rigidbody>();
            yield return new WaitForFixedUpdate();
            bool done = false;
            while (!done)
            {
                if (rb.velocity.magnitude < 0.1)
                {
                    done = true;
                }
                yield return null;
            }
            toggleRagdoll(false);
        }
    }


    private void toggleRagdoll(bool isRagdoll)
    {
        if (isRagdolled == isRagdoll)
            return;
        isRagdolled = isRagdoll;
        stand_anim.enabled = !isRagdoll;
        foreach (var item in rbs)
        {
            item.isKinematic = !isRagdoll;
        }
        if (!isRagdoll)
        {
            this.transform.position = ragdollRoot.transform.position;
            ragdollRoot.transform.localPosition = Vector3.zero;
        }

    }
}
