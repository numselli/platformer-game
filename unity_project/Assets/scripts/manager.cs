using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class manager : MonoBehaviour {

    public GameObject SettingsImg;
    public GameObject SettingsButton;
    public GameObject CreditsImg;
    public GameObject notgoingtowork;
    public GameObject shop;
    public bool canrespown = true;
public GameObject respownbtn;
    public void Nextlevel()
    {
        FindObjectOfType<player>().Level++;
        FindObjectOfType<SpawnPlatforms>().maxPlatforms += 5;
        //save
        PlayerPrefs.SetInt("level", FindObjectOfType<player>().Level);
        PlayerPrefs.SetInt("platfoms", FindObjectOfType<player>().Platforms);
        PlayerPrefs.SetInt("maxPlatforms", FindObjectOfType<SpawnPlatforms>().maxPlatforms);
        PlayerPrefs.SetInt("coins", FindObjectOfType<player>().coins);
        //reload scene
        SceneManager.LoadScene(0);
    }
    private void Start()
    {
        FindObjectOfType<player>().Platforms = PlayerPrefs.GetInt("platfoms", FindObjectOfType<player>().Platforms);
        FindObjectOfType<player>().Level = PlayerPrefs.GetInt("level", FindObjectOfType<player>().Level);
        FindObjectOfType<SpawnPlatforms>().maxPlatforms = PlayerPrefs.GetInt("maxPlatforms", FindObjectOfType<SpawnPlatforms>().maxPlatforms);
        FindObjectOfType<player>().coins = PlayerPrefs.GetInt("coins", FindObjectOfType<player>().coins);
        AudioListener.volume = (PlayerPrefs.HasKey("soundsOn") && (PlayerPrefs.GetInt("soundsOn") != 1)) ? 0f : 1f;
    }
    public void loss()
    {
        SceneManager.LoadScene(0);
    }
    public void SoundsClicked()
    {
        bool flag = !PlayerPrefs.HasKey("soundsOn") || (PlayerPrefs.GetInt("soundsOn") == 1);
        flag = !flag;
        PlayerPrefs.SetInt("soundsOn", !flag ? 0 : 1);
        AudioListener.volume = !flag ? 0f : 1f;
    }
    public void showSettings() 
    {
        SettingsImg.SetActive(true);
        SettingsButton.SetActive(false);
        notgoingtowork.SetActive(false);
    }
    public void dontshowSettings()
    {
        SettingsImg.SetActive(false);
        SettingsButton.SetActive(true);
        notgoingtowork.SetActive(true);
    }
    public void showCredits()
    {
        CreditsImg.SetActive(true);
        SettingsImg.SetActive(false);
    }
    public void dontshowCredits()
    {
        CreditsImg.SetActive(false);
        SettingsImg.SetActive(true);
    }
    public void showshop()
    {
        shop.SetActive(true);
        SettingsImg.SetActive(false);
    }
    public void dontshowshop() 
    {
        shop.SetActive(false);
        SettingsImg.SetActive(true);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Levelup01soundfx() 
    {
        Application.OpenURL("https://freesound.org/people/shinephoenixstormcrow/sounds/337049/");
    }
    public void Electrowinsound()
    {
        Application.OpenURL("https://freesound.org/people/Mativve/sounds/391539/");
    }
    public void reset()
    {
        FindObjectOfType<player>().Level = 1;
        FindObjectOfType<SpawnPlatforms>().maxPlatforms = 5;
        FindObjectOfType<player>().coins = 0;
        FindObjectOfType<player>().Platforms = 0;
        PlayerPrefs.SetInt("level", FindObjectOfType<player>().Level);
        PlayerPrefs.SetInt("maxPlatforms", FindObjectOfType<SpawnPlatforms>().maxPlatforms);
        PlayerPrefs.SetInt("coins", FindObjectOfType<player>().coins);
        PlayerPrefs.SetInt("platfoms", FindObjectOfType<player>().Platforms);
        SceneManager.LoadScene(0);
    }
    public void notpossable()
    {
        PlayerPrefs.SetInt("platfoms", FindObjectOfType<player>().Platforms);
        SceneManager.LoadScene(0);
    }
    public void off()
    {
        print("hey");
        if (canrespown = false)
        {
            respownbtn.SetActive(false);
        }
    }
}