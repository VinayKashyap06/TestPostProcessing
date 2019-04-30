using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.PostProcessing;
using UnityEngine;

public class MenuControl : MonoBehaviour
{
    private bool toggle;

    public GameObject[] settingsOptions;
    public GameObject[] homeOptions;
    public GameObject[] levels;
    public PostProcessingProfile postProcInst;
    void Start()
    {
        toggle = true;

        foreach (GameObject item in homeOptions)
        {
            item.SetActive(true);
        }

        var set = postProcInst.colorGrading.settings;
        set.basic.postExposure = 0;
        postProcInst.colorGrading.settings = set;
    }

    public void OnExit()
    {
        Application.Quit();
    }

    public void ShowSettingsMenu()
    {
        foreach (GameObject item in homeOptions)
        {
            item.SetActive(false);
        }

        foreach (GameObject item in settingsOptions)
        {
            item.SetActive(true);
        }
    }

    public void ShowHomeMenu()
    {
        foreach (GameObject item in settingsOptions)
        {
            item.SetActive(false);
        }

        foreach (GameObject item in levels)
        {
            item.SetActive(false);
        }

        foreach (GameObject item in homeOptions)
        {
            item.SetActive(true);
        }

    }

    public void OnToggleSound()
    {
        toggle = !toggle;

        if (toggle)
            gameObject.GetComponent<AudioSource>().UnPause();
        else
            gameObject.GetComponent<AudioSource>().Pause();
    }


    public void AdjustAmbientLight(float value)
    {
       
        var set = postProcInst.colorGrading.settings;
        set.basic.postExposure = value;
        postProcInst.colorGrading.settings = set;


    }

    public void AdjustVolume(float volume)
    {
        AudioListener.volume = volume;
    }

    public void OnPlayButtonClicked()
    {
        foreach(GameObject item in homeOptions)
        {
            item.SetActive(false);
        }

        foreach (GameObject item in levels)
        {
            item.SetActive(true);
        }
    }


    public void OnArenaSelected()
    {
        SceneManager.LoadScene(1);
    }

    public void OnForestSelected()
    {
        SceneManager.LoadScene(2);
    }
}
