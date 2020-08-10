using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP_TEXT1 : MonoBehaviour
{
    public int maxHealth = 100;
    public Text changingText;
    public GameObject updateText;


    public void SetMaxHealthHP(int health)
    {

        changingText.text = health.ToString();
        updateText.GetComponent<Text>().text = health.ToString();



    }
    public void SetHealthHP(int health)
    {

        changingText.text = health.ToString();
        updateText.GetComponent<Text>().text = health.ToString();
    }

}
