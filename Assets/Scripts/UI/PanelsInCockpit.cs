using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PanelsInCockpit : MonoBehaviour
{
    [SerializeField] Text scoreShower;
    public float score;
    int scoreToDisplay;
    [SerializeField] Image compass;
    [SerializeField] Image[] rooms;

    float br;
   
    //0: spacceship. 1: heart. 2: left organ. 3: right organ. 4: top organ.
    [SerializeField] Image[] healthBars;
    [SerializeField] OrganHealth[] organs;
    [SerializeField] float[] organHealths;

    public PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        br = 100;
        playerHealth = GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealths();
        //ALL FOR MIDDLE SCREEN

        scoreShower.text = PlayerPrefs.GetInt("score").ToString();
        //Score Gets Added In This Script!
        score += Time.deltaTime;
        scoreToDisplay = Convert.ToInt32(score);
        PlayerPrefs.SetInt("score", scoreToDisplay);

        //ALL FOR LEFT SCREEN

        //This is all done in the 2 voids at the bottom of the script.

        //ALL FOR RIGHT SCREEN

        //This is all done in the last void at the bottom of the script.

        //ALL FOR COMPASS

        compass.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, transform.rotation.y * 360));
    }
    /// <summary>
    /// 
    /// </summary>
    ///Call this function if you want to make the attacked room light up or stop it lighting up.
    /// <returns></returns>

    public void RoomAlarm(string name, bool active) {
        if (active)
        {
            if (name.ToLower() == "left")
            {
                rooms[0].color = new Color(0.86f, 0f, 0f);
            }
            else if (name.ToLower() == "right")
            {
                rooms[1].color = new Color(0.86f, 0f, 0f);
            }
            else if (name.ToLower() == "up")
            {
                rooms[2].color = new Color(0.86f, 0f, 0f);
            }
        }
        if (!active)
        {
            if (name.ToLower() == "left")
            {
                rooms[0].color = new Color(1f, 1f, 1f);
            }
            else if (name.ToLower() == "right")
            {
                rooms[1].color = new Color(1f, 1f, 1f);
            }
            else if (name.ToLower() == "up")
            {
                rooms[2].color = new Color(1f, 1f, 1f);
            }
        }
    }
    /// <summary>
    /// if a room dies, call this function.
    /// </summary>

    public void RoomDeath(string name)
    {
        if (name.ToLower() == "left")
        {
            rooms[0].color = new Color(0.2f, 0.2f, .2f);
        }
        else if (name.ToLower() == "right")
        {
            rooms[1].color = new Color(0.2f, 0.2f, .2f);
        }
        else if (name.ToLower() == "up")
        {
            rooms[2].color = new Color(0.2f, 0.2f, .2f);
        }
    }
    /// <summary>
    /// Float[] order: 0: Heart healthbar. 1: left room healthbar. 2: right room healthbar. 3: up room healthbar. 4: spaceship health. 
    /// Max Health Of Organ Is 100!
    /// </summary>
    public void Healthbar(float[] healths)
    {
        for(int i = 0; i < 5; i++)
        {

            healthBars[i].transform.localScale = new Vector3((healths[i] / 1000) * 10 , 1);

            // if (i != 4)
            // {
            //     healthBars[i].transform.localScale = new Vector3((healths[i] / 100) * 12, healthBars[i].transform.localScale.y, 1);
            // }
            // else if(i == 4)
            // {
            //     healthBars[i].transform.localScale = new Vector3((healths[i] / 50) * 12, healthBars[i].transform.localScale.y, 1);
            // }
        }
    }

    public void UpdateHealths()
    {
        for (int i = 0; i < 4; i++)
        {
            organHealths[i] = organs[i].currentLife;
        }

        organHealths[4] = playerHealth.currentLife * 25;
        Healthbar(organHealths);
        


    }
    
}


