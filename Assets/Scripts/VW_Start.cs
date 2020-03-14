using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class VW_Start : MonoBehaviour
{

    [SerializeField] GameObject titleFire;
    [SerializeField] Text titleText;
    [SerializeField] Button beginButton;
    [SerializeField] Text beginButtonText;
    [SerializeField] GameObject transitionPanel;

    private Music music;
    [SerializeField] YoutubePlayer ytPlayer;

    private DataService ds;

    // Start is called before the first frame update
    void Start()
    {
        // Preload the Masters if they are not loaded
        ds = StartupScript.ds;
        music = new Music();

        ytPlayer.Play(music.Music1);
        ytPlayer.GetComponent<AudioSource>().volume = 0.25f;
        Debug.Log("music supposed to be playing = " + music.Music1);
        Debug.Log("music actually playing = " + ytPlayer.videoPlayer.url);

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void PressBeginButton()
    {
        PlayerPrefs.SetInt("PrudenceKey", 50);
        PlayerPrefs.SetInt("TemperanceKey", 50);
        PlayerPrefs.SetInt("CourageKey", 50);
        PlayerPrefs.SetInt("JusticeKey", 50);
        PlayerPrefs.SetInt("FaithKey", 50);
        PlayerPrefs.SetInt("HopeKey", 50);
        PlayerPrefs.SetInt("CharityKey", 50);

        StartCoroutine(Transition());

    }

    private IEnumerator Transition()
    {
        transitionPanel.SetActive(true);
        titleText.gameObject.GetComponent<Animation>().Play("FallIntoInfernoFadeOut");
        beginButtonText.gameObject.GetComponent<Animation>().Play("FallIntoInfernoFadeOut");
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(0.5f);
            ytPlayer.GetComponent<AudioSource>().volume -= 0.025f;
            Debug.Log("timestep = " + i);

        }
       
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Gameloop");
    }

}
