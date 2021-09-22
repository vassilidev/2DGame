using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Dropdown resolutionDropDown;
    
    private Resolution[] _resolutions;
    
    public void Start()
    {
        _resolutions = Screen.resolutions
            .Select(resolution => new Resolution {width = resolution.width, height = resolution.height})
            .Distinct()
            .ToArray();
        
        resolutionDropDown.ClearOptions();
        
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        
        for (int i = 0; i < _resolutions.Length; i++)
        {
            if (_resolutions[i].width == Screen.width && _resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
            
            string option = _resolutions[i].width + "x" + _resolutions[i].height;
            options.Add(option);
        }
        
        resolutionDropDown.AddOptions(options);
        resolutionDropDown.value = currentResolutionIndex;
        resolutionDropDown.RefreshShownValue();

        Screen.fullScreen = true;
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetScreenResolution(int resolutionIndex)
    {
        Resolution resolution = _resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
