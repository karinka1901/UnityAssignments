using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AudioControl : MonoBehaviour
{
    public AudioSource audioS;
    public AudioClip backgroundMusic;
    public AudioClip SFXMusic;

    //slider music
    //slider volume     slider.value (0-1)

    public Slider musicSlider;
    public Slider sfxSlider;

    private float musicVol;
    private float sfxVol;

    public TextMeshProUGUI musicPercent;
    public TextMeshProUGUI sfxPercent;

    private void Update()
    {
        musicPercent.text = musicSlider.value.ToString();
        sfxPercent.text = sfxSlider.value.ToString();

        sfxVol = sfxSlider.value/100;
        musicVol = musicSlider.value/100;

        audioS.volume = musicVol;
    }



    private void Start()
    {
        audioS.clip = backgroundMusic;
        audioS.Play();

        musicSlider.value = 50f;
        sfxSlider.value = 80f;


    }

    public void CookieSound()
    {
        audioS.PlayOneShot(SFXMusic, sfxVol);
    }
}
 