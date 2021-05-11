using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject Panel;
    [SerializeField] private GameObject SkillPanel;
    private bool Ispause=false;
    private bool IsSkill=false;
    void Awake()
    {
        SkillPanel.SetActive(false) ;
        Panel.SetActive(false);
        Time.timeScale = 1;
    }
    void Update()
    {
        if (Ispause)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Panel.SetActive(false);
                Time.timeScale = 1;
                Ispause = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Panel.SetActive(true);
            Ispause = true;
            Time.timeScale = 0;
        }
        if (IsSkill)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                SkillPanel.SetActive(false);
                Time.timeScale = 1;
                IsSkill = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Tab))
        {
            SkillPanel.SetActive(true);
            IsSkill = true;
            Time.timeScale = 0.3f;
        }

    }
}
