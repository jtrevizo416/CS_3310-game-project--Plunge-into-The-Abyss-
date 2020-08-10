using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform doorModel;
    public GameObject colObject;//collider object

    public float openSpeed;//Speed door opens at

    private bool shouldOpen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldOpen == true && doorModel.position.z != 1)
        {
            doorModel.position = Vector3.MoveTowards(doorModel.position, new Vector3(doorModel.position.x, doorModel.position.y, 1f), openSpeed * Time.deltaTime);//open door

            if (doorModel.position.z == 1f)
            {
                colObject.SetActive(false);//disable collider for door
            }
        }
        else if (!shouldOpen && doorModel.position.z != 0f)
        {
            doorModel.position = Vector3.MoveTowards(doorModel.position, new Vector3(doorModel.position.x, doorModel.position.y, 0f), openSpeed * Time.deltaTime);//close door

            if (doorModel.position.z == 0f)
            {
                colObject.SetActive(true);//disable collider for door
            }
        }


    }

    private void OnTriggerEnter2D(Collider2D other)//when player enters area door should open
    {
        if (other.tag == "Player")
        {
            shouldOpen = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)//when player enters area door should close
    {
        if (other.tag == "Player")
        {
            shouldOpen = false;
        }
    }
}
