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
        Control(value,button_itself);

       
    }
    
     void Control(int incoming_value,GameObject incoming_object)
    {
        if (first_choice_value == 0)
        {
            first_choice_value = incoming_value;
            selected_button = incoming_object;
        }
        else
        {
            if (first_choice_value == incoming_value)
            {
                Destroy(selected_button.gameObject);
                Destroy(incoming_object.gameObject);
                first_choice_value = 0;
                selected_button = null;
            }
            else
            {
                selected_button.GetComponent<Image>().sprite = default_sprite;
                incoming_object.GetComponent<Image>().sprite = default_sprite;
                first_choice_value = 0;
                selected_button = null;
            }
        }
    }
}
