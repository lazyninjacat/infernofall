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

    private DataService ds;

    // Start is called before the first frame update
    void Start()
    {
        // Preload the Masters if they are not loaded
        ds = StartupScript.ds; 

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
        yield return new WaitForSeconds(3);
        titleText.gameObject.GetComponent<Animation>().Play("FallIntoInfernoFadeOut");
        beginButtonText.gameObject.GetComponent<Animation>().Play("FallIntoInfernoFadeOut");
        yield return new WaitForSeconds(6);
        SceneManager.LoadScene("Gameloop");
    }

}
