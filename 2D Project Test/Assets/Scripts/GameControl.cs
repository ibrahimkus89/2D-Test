using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    int first_choice_value;
    GameObject selected_button;
    GameObject button_itself;
    public Sprite default_sprite;


    void Start()
    {
        first_choice_value = 0;
    }

    public void Give_object(GameObject myobject)
    {
        button_itself = myobject;
        button_itself.GetComponent<Image>().sprite = button_itself.GetComponentInChildren<SpriteRenderer>().sprite;
    }

    public void ButtonClicked(int value)
    {
        //Debug.Log("Yes Clicked : incoming value : " +value);

        if (first_choice_value==0)
        {
            first_choice_value= value;
        }
        else
        {
            if (first_choice_value==value)
            {
                Debug.Log("Yes matched");
                first_choice_value = 0;
            }
            else
            {
                Debug.Log("didn't match");
                first_choice_value = 0;
            }
        }
    }
    
    void Update()
    {
        
    }
}
