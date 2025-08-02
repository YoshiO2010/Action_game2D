using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Game_mane : MonoBehaviour
{
    [SerializeField]
    GameObject Game_clearUI;
    // Start is called before the first frame update
    float End_time;
    float start_time;
    float Clear_time;
    [SerializeField]
     TextMeshProUGUI Clear_timeUI;
    bool Pause_Flag;
    [SerializeField]
    GameObject Pause_panel;
    void Start()
    {
        Game_clearUI.SetActive(false);
        start_time = Time.time;
        Pause_panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause_Flag = !Pause_Flag;
        }
        if (Pause_Flag)
        {
            Time.timeScale = 0;
            Pause_panel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            Pause_panel.SetActive(false);
        }
    }
    public void Game_clear()
    {
        End_time = Time.time;
        Clear_time = End_time - start_time;
        int minutes = Mathf.FloorToInt(Clear_time / 60f);
        float seconds = Clear_time % 60f;

        Clear_timeUI.text = $"{minutes}:{seconds:0.00}";
        Game_clearUI.SetActive(true);
        
    }
    public void Load_scene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
   
}
