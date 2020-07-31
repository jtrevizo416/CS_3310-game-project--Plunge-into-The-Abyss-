using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{

    public Transform doorModel;
    public GameObject colObject;

    public float openSpeed;

    private bool shouldOpen;
    

    [SerializeField] private Key.KeyType keyType;

    private void Update()
    {
        openDoor();
    }

    public Key.KeyType getKeyType()
    {
        return keyType;
    }

    public void openDoor()
    {
        if (shouldOpen)
        {
            doorModel.position = Vector3.MoveTowards(doorModel.position, new Vector3(doorModel.position.x, doorModel.position.y, 1f), openSpeed * Time.deltaTime);

            if (doorModel.position.z == 1f)
            {
                colObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        KeyHolder key = collider.GetComponent<KeyHolder>();
        ///KeyDoor keyDoor = collider.GetComponent<KeyDoor>();
        if (collider.tag == "Player")
        {
            if (key.ContainsKey(getKeyType()))
            { 
                shouldOpen = true;
            }
        }
    }
}


