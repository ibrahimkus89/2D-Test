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
    public AudioSource[] sounds;
    public GameObject[] Buttons;


    void Start()
    {
        first_choice_value = 0;
    }

    public void Give_object(GameObject myobject)
    {
        button_itself = myobject;
        button_itself.GetComponent<Image>().sprite = button_itself.GetComponentInChildren<SpriteRenderer>().sprite;
        button_itself.GetComponent<Image>().raycastTarget = false;
        sounds[1].Play();
    }

     void Button_situation(bool situation)
    {
        foreach (var item in Buttons)
        {
            if (item!=null)
            {
                item.GetComponent<Image>().raycastTarget = situation;
            }

            
        }
    }

    public void ButtonClicked(int value)
    {
        Control(value);

       
    }
    
     void Control(int incoming_value)
    {
        if (first_choice_value == 0)
        {
            first_choice_value = incoming_value;
            selected_button = button_itself;
        }
        else
        {
            StartCoroutine(Check_it(incoming_value));
        }
    }

     
    IEnumerator Check_it(int incoming_value)
    {
        Button_situation(false);
        yield return new WaitForSeconds(1);

        if (first_choice_value == incoming_value)
        {
            Destroy(selected_button.gameObject);
            Destroy(button_itself.gameObject);
            first_choice_value = 0;
            selected_button = null;
            Button_situation(true);

        }
        else
        {
            sounds[2].Play();
            selected_button.GetComponent<Image>().sprite = default_sprite;
            button_itself.GetComponent<Image>().sprite = default_sprite;
            first_choice_value = 0;
            selected_button = null;
            Button_situation(true);

        }
    }
}
