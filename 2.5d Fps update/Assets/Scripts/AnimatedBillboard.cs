using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedBillboard : MonoBehaviour
{
    private SpriteRenderer theSR;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
        theSR.flipX = true;

        //theSR.flipY = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(PlayerController.instance.transform.position, -Vector3.forward);
        anim.SetBool("animate", true);
    }
}
