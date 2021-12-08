using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public int target_success;
    int first_choice_value;
    int instant_success;
    //-------------------------
    GameObject selected_button;
    GameObject button_itself;
    //-----------------------
    public Sprite default_sprite;
    public AudioSource[] sounds;
    public GameObject[] Buttons;
    public TextMeshProUGUI counter;
    public GameObject[] gameoverpanels;
    public Slider TimeSlider;

    //Timer
   public float totalTime;
    float minute;
    float second;
    bool timer;
    float elapsedtime;



    void Start()
    {
        first_choice_value = 0;
        timer = true;
        elapsedtime = 0;
        TimeSlider.value = elapsedtime;
        TimeSlider.maxValue = totalTime;

    }


    void Update()
    {
        if (timer && elapsedtime!=totalTime)
        {
            elapsedtime += Time.deltaTime;
            TimeSlider.value = elapsedtime;

            if (TimeSlider.maxValue==TimeSlider.value)
            {
                timer = false;
                GameOver();
            }

            //minute = Mathf.FloorToInt(totalTime / 60);
            //second = Mathf.FloorToInt(totalTime % 60);

            //counter.text = Mathf.FloorToInt(totalTime).ToString();
            //counter.text = string.Format("{0:00}:{1:00}", minute, second);
        }
        

    }

    public void Pause()
    {
        gameoverpanels[2].SetActive(true);

        Time.timeScale = 0;
    }
    public void Continue()
    {
        gameoverpanels[2].SetActive(false);

        Time.timeScale = 1;
    }
    void GameOver()
    {
        gameoverpanels[0].SetActive(true);
    }

    void Win()
    {
        gameoverpanels[1].SetActive(true);

    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Give_object(GameObject myobject)
    {
        button_itself = myobject;
        button_itself.GetComponent<Image>().sprite = button_itself.GetComponentInChildren<SpriteRenderer>().sprite;
        button_itself.GetComponent<Image>().raycastTarget = false;
        sounds[0].Play();
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
            instant_success++;
            selected_button.GetComponent<Image>().enabled = false;
            button_itself.GetComponent<Image>().enabled = false;
            //selected_button.GetComponent<Button>().enabled = false;
            //button_itself.GetComponent<Button>().enabled = false;  
            first_choice_value = 0;
            selected_button = null;
            Button_situation(true);

            if (target_success==instant_success)
            {
                Win();
            }
        }
        else
        {
            sounds[1].Play();
            selected_button.GetComponent<Image>().sprite = default_sprite;
            button_itself.GetComponent<Image>().sprite = default_sprite;
            first_choice_value = 0;
            selected_button = null;
            Button_situation(true);

        }
    }
}
