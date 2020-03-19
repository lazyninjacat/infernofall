using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System;
using BestHTTP;
using TMPro;
using UnityEngine.UI;


public class VW_Gameloop : MonoBehaviour
{
    #region Variables

    // Database
    private DataService ds = StartupScript.ds;

    // Youtube player
    [SerializeField] YoutubePlayer ytplayer1;
    [SerializeField] YoutubePlayer ytplayer2;
    public int activeYTPlayer = -1;


    // Transition Panel
    [SerializeField] GameObject TransitionFadeOutPanel;

    // Map Panel
    [SerializeField] GameObject MapPanel;

    // End of game panel and elements
    [SerializeField] GameObject endPanel;
    [SerializeField] TextMeshProUGUI endScoreTextGUI;

    // Text Objects
    [SerializeField] TextMeshProUGUI sourceTextGUI;
    [SerializeField] GameObject sourceTextPanel;
    [SerializeField] TextMeshProUGUI descriptionTextGUI;
    [SerializeField] GameObject descriptionPanel;
    [SerializeField] TextMeshProUGUI rollOutcomeTextGUI;
    [SerializeField] TextMeshProUGUI promptTextGUI;
    [SerializeField] TextMeshProUGUI charityText;
    [SerializeField] TextMeshProUGUI charityAmountText;
    [SerializeField] TextMeshProUGUI faithText;
    [SerializeField] TextMeshProUGUI faithAmountText;
    [SerializeField] TextMeshProUGUI hopeText;
    [SerializeField] TextMeshProUGUI hopeAmountText;
    [SerializeField] TextMeshProUGUI courageText;
    [SerializeField] TextMeshProUGUI courageAmountText;
    [SerializeField] TextMeshProUGUI justiceText;
    [SerializeField] TextMeshProUGUI justiceAmountText;
    [SerializeField] TextMeshProUGUI prudenceText;
    [SerializeField] TextMeshProUGUI prudenceAmountText;
    [SerializeField] TextMeshProUGUI temperanceText;
    [SerializeField] TextMeshProUGUI temperanceAmountText;

    [SerializeField] TextMeshProUGUI Option1Text;
    [SerializeField] TextMeshProUGUI Option2Text;
    [SerializeField] TextMeshProUGUI Option3Text;
    [SerializeField] GameObject optionsTextPanel;


    // Virtue Progress Bars and Percent Texts
    [SerializeField] GameObject virtuesPanel;
    [SerializeField] Image PrudenceBar;
    [SerializeField] Image TemperanceBar;
    [SerializeField] Image JusticeBar;
    [SerializeField] Image FaithBar;
    [SerializeField] Image HopeBar;
    [SerializeField] Image CharityBar;
    [SerializeField] Image CourageBar;
    [SerializeField] TextMeshProUGUI CouragePercentText;
    [SerializeField] TextMeshProUGUI PrudencePercentText;
    [SerializeField] TextMeshProUGUI JusticePercentText;
    [SerializeField] TextMeshProUGUI TemperancePercentText;
    [SerializeField] TextMeshProUGUI FaithPercentText;
    [SerializeField] TextMeshProUGUI HopePercentText;
    [SerializeField] TextMeshProUGUI CharityPercentText;



    // Buttons
    [SerializeField] GameObject optionButtonsPanel;
    [SerializeField] Button option1Button;
    [SerializeField] Button option2Button;
    [SerializeField] Button option3Button;
    [SerializeField] Button continueButton;
    //[SerializeField] Button readSourceTextButton;
    [SerializeField] Button mapButton;
    [SerializeField] Button virtuesButton;

    // Scrollers
    [SerializeField] TextScroller sourceTextScroller;
    [SerializeField] TextScroller descriptionTextScroller;

    // Backgrounds.
    [SerializeField] RawImage backgroundImgA;
    [SerializeField] RawImage backgroundImgB;
    private bool backgroundA;

    // Virtue ints
    public int Prudence = 50;
    public int Temperance = 50;
    public int Courage = 50;
    public int Justice = 50;
    public int Faith = 50;
    public int Hope = 50;
    public int Charity = 50;

    // Room Data. Changes whenever a room method is invoked, e.g. _1_1()    
    private string option1BadOutcomeText = "";
    private string option2BadOutcomeText = "";
    private string option3BadOutcomeText = "";
    private string option1GoodOutcomeText = "";
    private string option2GoodOutcomeText = "";
    private string option3GoodOutcomeText = "";
    private string option1NeutralOutcomeText = "";
    private string option2NeutralOutcomeText = "";
    private string option3NeutralOutcomeText = "";

    public int currentRoomId = 1;
    private bool firstRunDone;

    private string nextBackgroundURI;

    // Database RoomData
    private int canto;
    private string source_text;
    private string description_text;
    private string area;
    private string background_img;
    private int music = 1;
    private string room_sound_effect;
    private string option1_sound_effect;
    private string option2_sound_effect;
    private string option3_sound_effect;
    private int number_options;
    private string background_animation;
    private string source_audio;
    private string prompt_text;
    private string option1_text;
    private string option2_text;
    private string option3_text;
    private string option1_good_outcome_text;
    private string option1_neutral_outcome_text;
    private string option1_bad_outcome_text;
    private string option2_good_outcome_text;
    private string option2_neutral_outcome_text;
    private string option2_bad_outcome_text;
    private string option3_good_outcome_text;
    private string option3_neutral_outcome_text;
    private string option3_bad_outcome_text;
    private int option1_good_courage;
    private int option1_good_prudence;
    private int option1_good_temperance;
    private int option1_good_justice;
    private int option1_good_faith;
    private int option1_good_hope;
    private int option1_good_charity;
    private int option1_neutral_courage;
    private int option1_neutral_prudence;
    private int option1_neutral_temperance;
    private int option1_neutral_justice;
    private int option1_neutral_faith;
    private int option1_neutral_hope;
    private int option1_neutral_charity;
    private int option1_bad_courage;
    private int option1_bad_prudence;
    private int option1_bad_temperance;
    private int option1_bad_justice;
    private int option1_bad_faith;
    private int option1_bad_hope;
    private int option1_bad_charity;
    private int option2_good_courage;
    private int option2_good_prudence;
    private int option2_good_temperance;
    private int option2_good_justice;
    private int option2_good_faith;
    private int option2_good_hope;
    private int option2_good_charity;
    private int option2_neutral_courage;
    private int option2_neutral_prudence;
    private int option2_neutral_temperance;
    private int option2_neutral_justice;
    private int option2_neutral_faith;
    private int option2_neutral_hope;
    private int option2_neutral_charity;
    private int option2_bad_courage;
    private int option2_bad_prudence;
    private int option2_bad_temperance;
    private int option2_bad_justice;
    private int option2_bad_faith;
    private int option2_bad_hope;
    private int option2_bad_charity;
    private int option3_good_courage;
    private int option3_good_prudence;
    private int option3_good_temperance;
    private int option3_good_justice;
    private int option3_good_faith;
    private int option3_good_hope;
    private int option3_good_charity;
    private int option3_neutral_courage;
    private int option3_neutral_prudence;
    private int option3_neutral_temperance;
    private int option3_neutral_justice;
    private int option3_neutral_faith;
    private int option3_neutral_hope;
    private int option3_neutral_charity;
    private int option3_bad_courage;
    private int option3_bad_prudence;
    private int option3_bad_temperance;
    private int option3_bad_justice;
    private int option3_bad_faith;
    private int option3_bad_hope;
    private int option3_bad_charity;

    private Music musicList;



    #endregion

    #region Initialize Gameloop

    void Start()
    {
        musicList = new Music();

        Debug.Log("Begin Start method");
        //Prudence = PlayerPrefs.GetInt("PrudenceKey");
        //Temperance = PlayerPrefs.GetInt("TemperanceKey");
        //Courage = PlayerPrefs.GetInt("CourageKey");
        //Justice = PlayerPrefs.GetInt("JusticeKey");
        //Faith = PlayerPrefs.GetInt("FaithKey");
        //Hope = PlayerPrefs.GetInt("HopeKey");
        //Charity = PlayerPrefs.GetInt("CharityKey");
        backgroundA = true;
        currentRoomId = 1;
        ChangeRoom();
        backgroundImgA.texture = Resources.Load<Texture2D>("SourceMaterial/Images/1_1");
        StartCoroutine(StartFadeIn());
        Debug.Log("End Start method");


    }

    #endregion

    #region Gameplay Methods

    private void PreloadNextBackgroundImage(string URI)
    {
        nextBackgroundURI = URI;
        HTTPRequest request = new HTTPRequest(new Uri(URI), OnRequestFinished);
        request.Send();

    }

    void OnRequestFinished(HTTPRequest req, HTTPResponse resp)
    {
        switch (req.State)
        {
            // The request finished without any problem.
            case HTTPRequestStates.Finished:
                if (resp.IsSuccess)
                {
                    // Everything went as expected!
                }
                else
                {
                    Debug.LogWarning(string.Format("Request finished Successfully, but the server sent an error. Status Code: {0}-{1} Message: {2}",
                                                    resp.StatusCode,
                                                    resp.Message,
                                                    resp.DataAsText));
                }
                break;

            // The request finished with an unexpected error. The request's Exception property may contain more info about the error.
            case HTTPRequestStates.Error:
                Debug.LogError("Request Finished with Error! " + (req.Exception != null ? (req.Exception.Message + "\n" + req.Exception.StackTrace) : "No Exception"));
                Debug.Log("Trying Again");
                PreloadNextBackgroundImage(nextBackgroundURI);
                break;

            // The request aborted, initiated by the user.
            case HTTPRequestStates.Aborted:
                Debug.LogWarning("Request Aborted!");
                Debug.Log("Trying Again");
                PreloadNextBackgroundImage(nextBackgroundURI);
                break;

            // Connecting to the server is timed out.
            case HTTPRequestStates.ConnectionTimedOut:
                Debug.LogError("Connection Timed Out!");
                Debug.Log("Trying Again");
                PreloadNextBackgroundImage(nextBackgroundURI);
                break;

            // The request didn't finished in the given time.
            case HTTPRequestStates.TimedOut:
                Debug.LogError("Processing the request Timed Out!");
                Debug.Log("Trying Again");
                PreloadNextBackgroundImage(nextBackgroundURI);
                break;
        }

        //////////////////////////// Add downloaded image to backgroundA or B
        Debug.Log("Request Finished! Image received.");

        var tex = new Texture2D(0, 0);
        tex.LoadImage(resp.Data);

        if (backgroundA == true)
        {
            backgroundImgB.texture = tex;
            Debug.Log("Downloading background image. Applying to backgroundB");
        }
        else
        {
            backgroundImgA.texture = tex;
            Debug.Log("Downloading background image. Applying to backgroundA");

        }

        if (backgroundA == true)
        {
            backgroundImgA.GetComponent<Animation>().Play();
        }
        else
        {
            backgroundImgB.GetComponent<Animation>().Play();
        }

    }


    void Update()
    {

    }

    public void StartSoundtrack()
    {

        StartCoroutine(GradualVolumeIncrease());


    }

    private string SelectMusicString(int musicNumber)
    {
        if (musicNumber == 1)
        {
            return musicList.Music1;
        }
        else if (musicNumber == 2)
        {
            return musicList.Music2;
        }
        else if (musicNumber == 3)
        {
            return musicList.Music3;
        }
        else if (musicNumber == 4)
        {
            return musicList.Music4;
        }
        else if (musicNumber == 5)
        {
            return musicList.Music5;
        }
        else if (musicNumber == 6)
        {
            return musicList.Music6;
        }
        else if (musicNumber == 7)
        {
            return musicList.Music7;
        }
        else if (musicNumber == 8)
        {
            return musicList.Music8;
        }
        else
        {
            Debug.Log("Error. musicNumber = " + musicNumber + " is not valid");
            return "";
        }
    }

    private IEnumerator GradualVolumeIncrease()
    {
        if (ytplayer1.videoPlayer.isPlaying)
        {
            activeYTPlayer = 1;
        }
        else if (ytplayer2.videoPlayer.isPlaying)
        {
            activeYTPlayer = 2;
        }
        else
        {
            activeYTPlayer = -1;
        }

        Debug.Log("activeTYPlayer = " + activeYTPlayer);

        if (activeYTPlayer == -1)
        {
            ytplayer1.Play(SelectMusicString(music));
            ytplayer1.GetComponent<AudioSource>().volume = 0;

            for (int i = 0; i < 20; i++)
            {
                yield return new WaitForSeconds(0.5f);
                ytplayer1.GetComponent<AudioSource>().volume += 0.0125f;
                Debug.Log("timestep = " + i);

            }
        }
        else if (activeYTPlayer == 2)
        {
            ytplayer1.Play(SelectMusicString(music));
            ytplayer1.GetComponent<AudioSource>().volume = 0;
            ytplayer2.GetComponent<AudioSource>().volume = 0.25f;

            for (int i = 0; i < 20; i++)
            {
                yield return new WaitForSeconds(0.5f);
                ytplayer1.GetComponent<AudioSource>().volume += 0.0125f;
                ytplayer2.GetComponent<AudioSource>().volume -= 0.0125f;
                Debug.Log("timestep = " + i);

            }
            Debug.Log("Stopping ytPlayer1");
            ytplayer2.Stop();

        }
        else if (activeYTPlayer == 1)
        {
            ytplayer2.Play(SelectMusicString(music));
            ytplayer2.GetComponent<AudioSource>().volume = 0;
            ytplayer1.GetComponent<AudioSource>().volume = 0.25f;

            for (int i = 0; i < 20; i++)
            {
                yield return new WaitForSeconds(0.5f);
                ytplayer2.GetComponent<AudioSource>().volume += 0.0125f;
                ytplayer1.GetComponent<AudioSource>().volume -= 0.0125f;
                Debug.Log("timestep = " + i);


            }
            Debug.Log("Stopping ytPlayer2");

            ytplayer1.Stop();

        }
        else
        {
            Debug.Log("Something went wrong. activeYTPlayer = " + activeYTPlayer);
        }

    }



    //public void PressAudioButton()
    //{
    //    StartCoroutine(YoutubePlayer(audioStartTime, audioStopTime));
    //}

    //private IEnumerator YoutubePlayer(int startTime, int endTime)
    //{
    //    ytplayer.Play(audioURL + "?t=" + startTime.ToString());

    //    ytplayer.GetComponent<AudioSource>().volume = 0;

    //    for (int i = 0; i < 40; i++)
    //    {
    //        yield return new WaitForSeconds(0.25f);
    //        ytplayer.GetComponent<AudioSource>().volume = ((ytplayer.GetComponent<AudioSource>().volume) + 0.025f);
    //    }
    //    Debug.Log("************************************* Done raising volume");

    //    yield return new WaitForSeconds((endTime - startTime) - 20);

    //    Debug.Log("************ And now starting to lower volume");
    //    for (int i = 0; i < 40; i++)
    //    {
    //        yield return new WaitForSeconds(0.5f);
    //        ytplayer.GetComponent<AudioSource>().volume = ((ytplayer.GetComponent<AudioSource>().volume) - 0.025f);
    //    }
    //    Debug.Log("Done lowering volume");
    //    ytplayer.Stop();
    //    Debug.Log("youtube player stopped");
    //}

    public void PressVirtuesButton()
    {
        if (virtuesPanel.activeSelf == false)
        {
            virtuesPanel.SetActive(true);

        }
        else
        {
            virtuesPanel.SetActive(false);
        }
    }

    public void PressMapButton()
    {
        if (MapPanel.activeSelf == false)
        {
            MapPanel.SetActive(true);
        }
        else
        {
            MapPanel.SetActive(false);
        }
    }

    private IEnumerator StartFadeIn()
    {
        Debug.Log("Begin StartFadeIn coroutine");

        TransitionFadeOutPanel.SetActive(true);
        virtuesPanel.SetActive(true);
        SetVirtueBars();
        virtuesPanel.SetActive(false);
        TransitionFadeOutPanel.GetComponent<Animation>().Play("TransitionPanelFadeIn");

        yield return new WaitForSeconds(2);
        virtuesButton.gameObject.SetActive(true);
        mapButton.gameObject.SetActive(true);
        TransitionFadeOutPanel.SetActive(false);
        StartCoroutine(BeginDescriptionTextScroll());
        Debug.Log("End StartFadeIn coroutine");
    }


    private IEnumerator BeginDescriptionTextScroll()
    {
        Debug.Log("Begin descriptionscroll coroutine");
        descriptionTextScroller.ResetPosition();
        descriptionPanel.SetActive(true);
        descriptionTextScroller.scrolling = true;
        yield return new WaitUntil(() => descriptionTextScroller.scrolling == false);
        promptTextGUI.gameObject.SetActive(true);
        //promptTextGUI.gameObject.GetComponent<Animation>().Play("RollOutcomeTextFadeIn");
        optionButtonsPanel.SetActive(true);
        optionsTextPanel.SetActive(true);

        if (number_options == 1)
        {
            option1Button.gameObject.SetActive(true);
            Option1Text.gameObject.SetActive(true);

            option2Button.gameObject.SetActive(false);
            Option2Text.gameObject.SetActive(false);

            option3Button.gameObject.SetActive(false);
            Option3Text.gameObject.SetActive(false);

        }
        if (number_options == 2)
        {
            option1Button.gameObject.SetActive(true);
            Option1Text.gameObject.SetActive(true);

            option2Button.gameObject.SetActive(true);
            Option2Text.gameObject.SetActive(true);

            option3Button.gameObject.SetActive(false);
            Option3Text.gameObject.SetActive(false);

        }
        if (number_options == 3)
        {
            option1Button.gameObject.SetActive(true);
            Option1Text.gameObject.SetActive(true);

            option2Button.gameObject.SetActive(true);
            Option2Text.gameObject.SetActive(true);

            option3Button.gameObject.SetActive(true);
            Option3Text.gameObject.SetActive(true);

        }

        //readSourceTextButton.gameObject.SetActive(true);
        Debug.Log("End descriptionscroll coroutine");
    }


    public void PressContinueButton()
    {
        Debug.Log("Begin PressContinueButton method");

        charityText.gameObject.SetActive(false);
        charityAmountText.gameObject.SetActive(false);

        courageText.gameObject.SetActive(false);
        courageAmountText.gameObject.SetActive(false);

        justiceText.gameObject.SetActive(false);
        justiceAmountText.gameObject.SetActive(false);

        prudenceText.gameObject.SetActive(false);
        prudenceAmountText.gameObject.SetActive(false);

        temperanceText.gameObject.SetActive(false);
        temperanceAmountText.gameObject.SetActive(false);

        faithText.gameObject.SetActive(false);
        faithAmountText.gameObject.SetActive(false);

        hopeText.gameObject.SetActive(false);
        hopeAmountText.gameObject.SetActive(false);

        continueButton.gameObject.SetActive(false);
        promptTextGUI.gameObject.SetActive(false);
        optionButtonsPanel.SetActive(false);
        rollOutcomeTextGUI.gameObject.SetActive(false);
        descriptionTextScroller.ResetPosition();
        sourceTextScroller.ResetPosition();
        descriptionPanel.SetActive(false);
        sourceTextPanel.SetActive(false);

        currentRoomId++;

        StartCoroutine(RoomTransition());

        Debug.Log("End PressContinueButton method");

        /////// TODO: Complete this section
    }


    public void PressSourceTextButton()
    {


        Debug.Log("Begin PressSourceTextButton method");
        descriptionPanel.SetActive(false);


        //PressAudioButton();
        sourceTextPanel.SetActive(true);
        sourceTextScroller.ResetPosition();
        //readSourceTextButton.gameObject.SetActive(false);
        //closeSourceTextButton.gameObject.SetActive(true);
        promptTextGUI.gameObject.SetActive(false);
        StartCoroutine(WaitForSourceTextScroll());

        if (firstRunDone == false)
        {
            firstRunDone = true;
            StartCoroutine(SourceTextHelper());
        }
        else
        {
            optionButtonsPanel.SetActive(false);
            //virtuesPanel.SetActive(false);
            firstRunDone = false;
        }

        //firstRunDone = false;
        Debug.Log("End PressSourceTextButton method");

    }

    private IEnumerator SourceTextHelper()
    {
        yield return new WaitForSeconds(0.1f);
        //PressCloseSourceTextButton();
    }

    private IEnumerator CloseSourceTextHelper()
    {
        yield return new WaitForSeconds(0.1f);
        PressSourceTextButton();
    }

    private IEnumerator WaitForSourceTextScroll()
    {
        Debug.Log("Begin WaitForSourceTextScroll coroutine");
        sourceTextScroller.ResetPosition();
        sourceTextScroller.scrolling = true;
        yield return new WaitUntil(() => sourceTextScroller.scrolling == false);
        sourceTextPanel.SetActive(false);
        descriptionPanel.SetActive(true);
        //virtuesPanel.SetActive(true);
        optionButtonsPanel.SetActive(true);
        //readSourceTextButton.gameObject.SetActive(true);
        //closeSourceTextButton.gameObject.SetActive(false);
        promptTextGUI.gameObject.SetActive(true);
        Debug.Log("End WaitForSourceTextScroll coroutine");
    }

    private int RollOutcomeGoodBadNuetral()
    {
        Debug.Log("Begin RollOutcomeGoodBadNuetral int method");
        return UnityEngine.Random.Range(1, 3);
    }

    private int RollForGainedLostAmount()
    {
        Debug.Log("Begin RollForGainedLostAmount int method");
        return UnityEngine.Random.Range(1, 7);
    }

    private void SetVirtueBars()
    {
        CourageBar.fillAmount = Courage * 0.01f;
        CouragePercentText.text = Courage.ToString() + "%";

        TemperanceBar.fillAmount = Temperance * 0.01f;
        TemperancePercentText.text = Temperance.ToString() + "%";

        JusticeBar.fillAmount = Justice * 0.01f;
        JusticePercentText.text = Justice.ToString() + "%";

        PrudenceBar.fillAmount = Prudence * 0.01f;
        PrudencePercentText.text = Prudence.ToString() + "%";

        FaithBar.fillAmount = Faith * 0.01f;
        FaithPercentText.text = Faith.ToString() + "%";

        HopeBar.fillAmount = Hope * 0.01f;
        HopePercentText.text = Hope.ToString() + "%";

        CharityBar.fillAmount = Charity * 0.01f;
        CharityPercentText.text = Charity.ToString() + "%";



    }

    #endregion

    #region Option Button Methods

    private void GoodOutcome(string goodOutcomeText, int pru, int cou, int jus, int tem, int fai, int hop, int cha)
    {

        rollOutcomeTextGUI.text = goodOutcomeText;
        if (cha != 0)
        {
            charityText.gameObject.SetActive(true);
            charityAmountText.gameObject.SetActive(true);
            charityAmountText.text = "+ " + cha.ToString();
        }
        if (fai != 0)
        {
            faithText.gameObject.SetActive(true);
            faithAmountText.gameObject.SetActive(true);
            faithAmountText.text = "+ " + fai.ToString();
        }
        if (hop != 0)
        {
            hopeText.gameObject.SetActive(true);
            hopeAmountText.gameObject.SetActive(true);
            hopeAmountText.text = "+ " + hop.ToString();
        }
        if (cou != 0)
        {
            courageText.gameObject.SetActive(true);
            courageAmountText.gameObject.SetActive(true);
            courageAmountText.text = "+ " + cou.ToString();
        }
        if (jus != 0)
        {
            justiceText.gameObject.SetActive(true);
            justiceAmountText.gameObject.SetActive(true);
            justiceAmountText.text = "+ " + jus.ToString();
        }
        if (pru != 0)
        {
            prudenceText.gameObject.SetActive(true);
            prudenceAmountText.gameObject.SetActive(true);
            prudenceAmountText.text = "+ " + pru.ToString();
        }
        if (tem != 0)
        {
            temperanceText.gameObject.SetActive(true);
            temperanceAmountText.gameObject.SetActive(true);
            temperanceAmountText.text = "+ " + tem.ToString();
        }

        Courage = Courage + cou;
        Justice = Justice + jus;
        Prudence = Prudence + pru;
        Temperance = Temperance + tem;
        Faith = Faith + fai;
        Hope = Hope + hop;
        Charity = Charity + cha;

        optionButtonsPanel.SetActive(false);

        promptTextGUI.gameObject.SetActive(false);
    }

    private void BadOutcome(string badOutcomeText, int pru, int cou, int jus, int tem, int fai, int hop, int cha)
    {

        rollOutcomeTextGUI.text = badOutcomeText;
        if (cha != 0)
        {
            charityText.gameObject.SetActive(true);
            charityAmountText.gameObject.SetActive(true);
            charityAmountText.text = cha.ToString();
        }
        if (fai != 0)
        {
            faithText.gameObject.SetActive(true);
            faithAmountText.gameObject.SetActive(true);
            faithAmountText.text = fai.ToString();
        }
        if (hop != 0)
        {
            hopeText.gameObject.SetActive(true);
            hopeAmountText.gameObject.SetActive(true);
            hopeAmountText.text = hop.ToString();
        }
        if (cou != 0)
        {
            courageText.gameObject.SetActive(true);
            courageAmountText.gameObject.SetActive(true);
            courageAmountText.text = cou.ToString();
        }
        if (jus != 0)
        {
            justiceText.gameObject.SetActive(true);
            justiceAmountText.gameObject.SetActive(true);
            justiceAmountText.text = jus.ToString();
        }
        if (pru != 0)
        {
            prudenceText.gameObject.SetActive(true);
            prudenceAmountText.gameObject.SetActive(true);
            prudenceAmountText.text = pru.ToString();
        }
        if (tem != 0)
        {
            temperanceText.gameObject.SetActive(true);
            temperanceAmountText.gameObject.SetActive(true);
            temperanceAmountText.text = tem.ToString();
        }

        Courage = Courage + cou;
        Justice = Justice + jus;
        Prudence = Prudence + pru;
        Temperance = Temperance + tem;
        Faith = Faith + fai;
        Hope = Hope + hop;
        Charity = Charity + cha;

        optionButtonsPanel.SetActive(false);

        promptTextGUI.gameObject.SetActive(false);
    }

    private void NeutralOutcome(string neutralOutcomeText, int pru, int cou, int jus, int tem, int fai, int hop, int cha)
    {
        rollOutcomeTextGUI.text = neutralOutcomeText;
        if (cha != 0)
        {
            charityText.gameObject.SetActive(true);
            charityAmountText.gameObject.SetActive(true);

            if (cha > 0)
            {
                charityAmountText.text = "+ " + cha.ToString();
            }
            else
            {
                charityAmountText.text = cha.ToString();

            }

        }
        if (fai != 0)
        {
            faithText.gameObject.SetActive(true);
            faithAmountText.gameObject.SetActive(true);
            if (fai > 0)
            {
                faithAmountText.text = "+ " + fai.ToString();
            }
            else
            {
                faithAmountText.text = fai.ToString();

            }
        }
        if (hop != 0)
        {
            hopeText.gameObject.SetActive(true);
            hopeAmountText.gameObject.SetActive(true);
            if (hop > 0)
            {
                hopeAmountText.text = "+ " + hop.ToString();
            }
            else
            {
                hopeAmountText.text = hop.ToString();
            }
        }
        if (cou != 0)
        {
            courageText.gameObject.SetActive(true);
            courageAmountText.gameObject.SetActive(true);
            if (cou > 0)
            {
                courageAmountText.text = "+ " + cou.ToString();
            }
            else
            {
                courageAmountText.text = cou.ToString();
            }
        }
        if (jus != 0)
        {
            justiceText.gameObject.SetActive(true);
            justiceAmountText.gameObject.SetActive(true);
            if (jus > 0)
            {
                justiceAmountText.text = "+ " + jus.ToString();
            }
            else
            {
                justiceAmountText.text = jus.ToString();
            }
        }
        if (pru != 0)
        {
            prudenceText.gameObject.SetActive(true);
            prudenceAmountText.gameObject.SetActive(true);
            if (pru > 0)
            {
                prudenceAmountText.text = "+ " + pru.ToString();
            }
            else
            {
                prudenceAmountText.text = pru.ToString();
            }
        }
        if (tem != 0)
        {
            temperanceText.gameObject.SetActive(true);
            temperanceAmountText.gameObject.SetActive(true);
            if (tem > 0)
            {
                temperanceAmountText.text = "+ " + tem.ToString();
            }
            else
            {
                temperanceAmountText.text = tem.ToString();
            }
        }

        Courage = Courage + cou;
        Justice = Justice + jus;
        Prudence = Prudence + pru;
        Temperance = Temperance + tem;
        Faith = Faith + fai;
        Hope = Hope + hop;
        Charity = Charity + cha;

        optionButtonsPanel.SetActive(false);

        promptTextGUI.gameObject.SetActive(false);
    }

    public void PressOption1Button()
    {
        Debug.Log("Begin PressOption1Button method");
        rollOutcomeTextGUI.gameObject.SetActive(true);
        continueButton.gameObject.SetActive(true);
        descriptionPanel.SetActive(false);
        optionsTextPanel.SetActive(false);
        int gbn = RollOutcomeGoodBadNuetral();

        if (gbn == 1)
        {
            GoodOutcome(option1_good_outcome_text, option1_good_prudence, option1_good_courage, option1_good_justice, option1_good_temperance, option1_good_faith, option1_good_hope, option1_good_charity);
        }
        else if (gbn == 2)
        {
            NeutralOutcome(option1_neutral_outcome_text, option1_neutral_prudence, option1_neutral_courage, option1_neutral_justice, option1_neutral_temperance, option1_neutral_faith, option1_neutral_hope, option1_neutral_charity);
        }
        else if (gbn == 3)
        {
            BadOutcome(option1_bad_outcome_text, option1_bad_prudence, option1_bad_courage, option1_bad_justice, option1_bad_temperance, option1_bad_faith, option1_bad_hope, option1_bad_charity);
        }
        else
        {
            Debug.Log("error on roll random outcome gbn");
        }

        optionButtonsPanel.SetActive(false);
        promptTextGUI.gameObject.SetActive(false);
        optionsTextPanel.SetActive(false);

        SetVirtueBars();
        Debug.Log("End PressOption1Button method");
    }


    public void PressOption2Button()
    {
        Debug.Log("Begin PressOption2Button method");
        rollOutcomeTextGUI.gameObject.SetActive(true);
        continueButton.gameObject.SetActive(true);
        descriptionPanel.SetActive(false);
        optionsTextPanel.SetActive(false);

        int gbn = RollOutcomeGoodBadNuetral();

        if (gbn == 1)
        {
            GoodOutcome(option2_good_outcome_text, option2_good_prudence, option2_good_courage, option2_good_justice, option2_good_temperance, option2_good_faith, option2_good_hope, option2_good_charity);
        }
        else if (gbn == 2)
        {
            NeutralOutcome(option2_neutral_outcome_text, option2_neutral_prudence, option2_neutral_courage, option2_neutral_justice, option2_neutral_temperance, option2_neutral_faith, option2_neutral_hope, option2_neutral_charity);
        }
        else if (gbn == 3)
        {
            BadOutcome(option2_bad_outcome_text, option2_bad_prudence, option2_bad_courage, option2_bad_justice, option2_bad_temperance, option2_bad_faith, option2_bad_hope, option2_bad_charity);
        }
        else
        {
            Debug.Log("error on roll random outcome gbn");
        }

        optionButtonsPanel.SetActive(false);
        promptTextGUI.gameObject.SetActive(false);

        SetVirtueBars();

        Debug.Log("End PressOption2Button method");
    }


    public void PressOption3Button()
    {
        Debug.Log("Begin PressOption3Button method");
        rollOutcomeTextGUI.gameObject.SetActive(true);
        continueButton.gameObject.SetActive(true);
        descriptionPanel.SetActive(false);
        optionsTextPanel.SetActive(false);

        int gbn = RollOutcomeGoodBadNuetral();

        if (gbn == 1)
        {
            GoodOutcome(option3_good_outcome_text, option3_good_prudence, option3_good_courage, option3_good_justice, option3_good_temperance, option3_good_faith, option3_good_hope, option3_good_charity);
        }
        else if (gbn == 2)
        {
            NeutralOutcome(option3_neutral_outcome_text, option3_neutral_prudence, option3_neutral_courage, option3_neutral_justice, option3_neutral_temperance, option3_neutral_faith, option3_neutral_hope, option3_neutral_charity);
        }
        else if (gbn == 3)
        {
            BadOutcome(option3_bad_outcome_text, option3_bad_prudence, option3_bad_courage, option3_bad_justice, option3_bad_temperance, option3_bad_faith, option3_bad_hope, option3_bad_charity);
        }
        else
        {
            Debug.Log("error on roll random outcome gbn");
        }

        optionButtonsPanel.SetActive(false);
        promptTextGUI.gameObject.SetActive(false);

        SetVirtueBars();

        Debug.Log("End PressOption3Button method");
    }

    #endregion

    #region Room Transition

    private IEnumerator RoomTransition()
    {
        Debug.Log("Begin RoomTransition coroutine");

        TransitionFadeOutPanel.SetActive(true);
        TransitionFadeOutPanel.GetComponent<Animation>().Play("TransitionPanelFadeOut");
        yield return new WaitForSeconds(3);
        //PressSourceTextButton();
        //yield return new WaitForSeconds(0.5f);
        //PressCloseSourceTextButton();
        //yield return new WaitForSeconds(0.5f);
        promptTextGUI.gameObject.SetActive(false);
        optionButtonsPanel.SetActive(false);
        if (backgroundA == true)
        {
            backgroundImgB.gameObject.SetActive(true);
            backgroundImgA.gameObject.SetActive(false);
            backgroundA = false;
        }
        else if (backgroundA == false)
        {
            backgroundImgB.gameObject.SetActive(false);
            backgroundImgA.gameObject.SetActive(true);
            backgroundA = true;
        }
        ChangeRoom();
        TransitionFadeOutPanel.GetComponent<Animation>().Play("TransitionPanelFadeIn");
        yield return new WaitForSeconds(3);
        TransitionFadeOutPanel.SetActive(false);
        StartCoroutine(BeginDescriptionTextScroll());
        Debug.Log("End RoomTransition coroutine");
    }

    private void ChangeRoom()
    {
        Debug.Log("Changing Room");
        GetRoomData(currentRoomId);
        StartSoundtrack();
        PreloadNextBackgroundImage(ds.GetRoomDataString(currentRoomId + 1, "background_img"));
        //TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/" + source_text);
        //TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/" + description_text);
        //sourceTextGUI.text = sourceTextFileContents.text;
        descriptionTextGUI.text = description_text;
        promptTextGUI.text = prompt_text;

        //Option Texts
        Option1Text.text = "1) " + option1_text;
        Option2Text.text = "2) " + option2_text;
        Option3Text.text = "3) " + option3_text;


        //option1
        option1GoodOutcomeText = option1_good_outcome_text;
        option1NeutralOutcomeText = option1_neutral_outcome_text;
        option1BadOutcomeText = option1_bad_outcome_text;

        //option2
        option2GoodOutcomeText = option2_good_outcome_text;
        option2NeutralOutcomeText = option2_neutral_outcome_text;
        option2BadOutcomeText = option2_bad_outcome_text;

        //option3
        option3GoodOutcomeText = option3_good_outcome_text;
        option3NeutralOutcomeText = option3_neutral_outcome_text;
        option3BadOutcomeText = option3_bad_outcome_text;

        //if (currentRoomId == 75) { End(); }
        Debug.Log("End ChangeRoom method");


        //Debug.Log("Begin ChangeRoom method");
        //if (currentRoomId == 1) { _1_1(); }
        //if (currentRoomId == 2) { _1_2(); }
        //if (currentRoomId == 3) { _1_3(); }
        //if (currentRoomId == 4) { _1_4(); }
        //if (currentRoomId == 5) { _2_1(); }
        //if (currentRoomId == 6) { _2_2(); }
        //if (currentRoomId == 7) { _3_1(); }
        //if (currentRoomId == 8) { _3_2(); }
        //if (currentRoomId == 9) { _3_3(); }
        //if (currentRoomId == 10) { _4_1(); }
        //if (currentRoomId == 11) { _4_2(); }
        //if (currentRoomId == 12) { _5_1(); }
        //if (currentRoomId == 13) { _5_2(); }
        //if (currentRoomId == 14) { _5_3(); }
        //if (currentRoomId == 15) { _5_4(); }
        //if (currentRoomId == 16) { _5_5(); }
        //if (currentRoomId == 17) { _6_1(); }
        //if (currentRoomId == 18) { _6_2(); }
        //if (currentRoomId == 19) { _7_1(); }
        //if (currentRoomId == 20) { _7_2(); }
        //if (currentRoomId == 21) { _7_3(); }
        //if (currentRoomId == 22) { _8_1(); }
        //if (currentRoomId == 23) { _8_2(); }
        //if (currentRoomId == 24) { _8_3(); }
        //if (currentRoomId == 25) { _9_1(); }
        //if (currentRoomId == 26) { _9_2(); }
        //if (currentRoomId == 27) { _9_3(); }
        //if (currentRoomId == 28) { _10_1(); }
        //if (currentRoomId == 29) { _11_1(); }
        //if (currentRoomId == 30) { _12_1(); }
        //if (currentRoomId == 31) { _12_2(); }
        //if (currentRoomId == 32) { _12_3(); }
        //if (currentRoomId == 33) { _13_1(); }
        //if (currentRoomId == 34) { _13_2(); }
        //if (currentRoomId == 35) { _13_3(); }
        //if (currentRoomId == 36) { _14_1(); }
        //if (currentRoomId == 37) { _15_1(); }
        //if (currentRoomId == 38) { _17_1(); }
        //if (currentRoomId == 39) { _17_2(); }
        //if (currentRoomId == 40) { _18_1(); }
        //if (currentRoomId == 41) { _18_2(); }
        //if (currentRoomId == 42) { _18_3(); }
        //if (currentRoomId == 43) { _19_1(); }
        //if (currentRoomId == 44) { _20_1(); }
        //if (currentRoomId == 45) { _21_1(); }
        //if (currentRoomId == 46) { _21_2(); }
        //if (currentRoomId == 47) { _22_1(); }
        //if (currentRoomId == 48) { _22_2(); }
        //if (currentRoomId == 49) { _23_1(); }
        //if (currentRoomId == 50) { _23_2(); }
        //if (currentRoomId == 51) { _23_3(); }
        //if (currentRoomId == 52) { _24_1(); }
        //if (currentRoomId == 53) { _25_1(); }
        //if (currentRoomId == 54) { _26_1(); }
        //if (currentRoomId == 55) { _28_1(); }
        //if (currentRoomId == 56) { _28_2(); }
        //if (currentRoomId == 57) { _28_3(); }
        //if (currentRoomId == 58) { _29_1(); }
        //if (currentRoomId == 59) { _29_2(); }
        //if (currentRoomId == 60) { _29_3(); }
        //if (currentRoomId == 61) { _30_1(); }
        //if (currentRoomId == 62) { _30_2(); }
        //if (currentRoomId == 63) { _31_1(); }
        //if (currentRoomId == 64) { _31_2(); }
        //if (currentRoomId == 65) { _31_3(); }
        //if (currentRoomId == 66) { _32_1(); }
        //if (currentRoomId == 67) { _32_2(); }
        //if (currentRoomId == 68) { _32_3(); }
        //if (currentRoomId == 69) { _33_1(); }
        //if (currentRoomId == 70) { _33_2(); }
        //if (currentRoomId == 71) { _33_3(); }
        //if (currentRoomId == 72) { _34_1(); }
        //if (currentRoomId == 73) { _34_2(); }
        //if (currentRoomId == 74) { _34_3(); }

    }

    /// <summary>
    /// Gets all of the data for the passed roomId from the databse via the COM_Director dataservice
    /// </summary>
    /// <param name="roomId"></param>
    private void GetRoomData(int roomId)
    {
        Debug.Log("Getting Room Data");
        canto = ds.GetRoomDataInt(roomId, "canto");
        area = ds.GetRoomDataString(roomId, "area");
        background_img = ds.GetRoomDataString(roomId, "background_img");
        music = ds.GetRoomDataInt(roomId, "music");
        room_sound_effect = ds.GetRoomDataString(roomId, "room_sound_effect");
        option1_sound_effect = ds.GetRoomDataString(roomId, "option1_sound_effect");
        option2_sound_effect = ds.GetRoomDataString(roomId, "option2_sound_effect");
        option3_sound_effect = ds.GetRoomDataString(roomId, "option3_sound_effect");
        option3_sound_effect = ds.GetRoomDataString(roomId, "option3_sound_effect");
        number_options = ds.GetRoomDataInt(roomId, "number_options");
        source_text = ds.GetRoomDataString(roomId, "source_text");
        source_audio = ds.GetRoomDataString(roomId, "source_audio");
        description_text = ds.GetRoomDataString(roomId, "description_text");
        prompt_text = ds.GetRoomDataString(roomId, "prompt_text");
        option1_text = ds.GetRoomDataString(roomId, "option1_text");
        option2_text = ds.GetRoomDataString(roomId, "option2_text");
        option3_text = ds.GetRoomDataString(roomId, "option3_text");
        option1_good_outcome_text = ds.GetRoomDataString(roomId, "option1_good_outcome_text");
        option1_neutral_outcome_text = ds.GetRoomDataString(roomId, "option1_neutral_outcome_text");
        option1_bad_outcome_text = ds.GetRoomDataString(roomId, "option1_bad_outcome_text");
        option2_good_outcome_text = ds.GetRoomDataString(roomId, "option2_good_outcome_text");
        option2_neutral_outcome_text = ds.GetRoomDataString(roomId, "option2_neutral_outcome_text");
        option2_bad_outcome_text = ds.GetRoomDataString(roomId, "option2_bad_outcome_text");
        option3_good_outcome_text = ds.GetRoomDataString(roomId, "option3_good_outcome_text");
        option3_neutral_outcome_text = ds.GetRoomDataString(roomId, "option3_neutral_outcome_text");
        option3_bad_outcome_text = ds.GetRoomDataString(roomId, "option3_bad_outcome_text");
        option1_good_courage = ds.GetRoomDataInt(roomId, "option1_good_courage");
        option1_good_prudence = ds.GetRoomDataInt(roomId, "option1_good_prudence");
        option1_good_temperance = ds.GetRoomDataInt(roomId, "option1_good_temperance");
        option1_good_justice = ds.GetRoomDataInt(roomId, "option1_good_justice");
        option1_good_faith = ds.GetRoomDataInt(roomId, "option1_good_faith");
        option1_good_hope = ds.GetRoomDataInt(roomId, "option1_good_hope");
        option1_good_charity = ds.GetRoomDataInt(roomId, "option1_good_charity");
        option1_neutral_courage = ds.GetRoomDataInt(roomId, "option1_neutral_courage");
        option1_neutral_prudence = ds.GetRoomDataInt(roomId, "option1_neutral_prudence");
        option1_neutral_temperance = ds.GetRoomDataInt(roomId, "option1_neutral_temperance");
        option1_neutral_justice = ds.GetRoomDataInt(roomId, "option1_neutral_justice");
        option1_neutral_faith = ds.GetRoomDataInt(roomId, "option1_neutral_faith");
        option1_neutral_hope = ds.GetRoomDataInt(roomId, "option1_neutral_hope");
        option1_neutral_charity = ds.GetRoomDataInt(roomId, "option1_neutral_charity");
        option1_bad_courage = ds.GetRoomDataInt(roomId, "option1_bad_courage");
        option1_bad_prudence = ds.GetRoomDataInt(roomId, "option1_bad_prudence");
        option1_bad_temperance = ds.GetRoomDataInt(roomId, "option1_bad_temperance");
        option1_bad_justice = ds.GetRoomDataInt(roomId, "option1_bad_justice");
        option1_bad_faith = ds.GetRoomDataInt(roomId, "option1_bad_faith");
        option1_bad_hope = ds.GetRoomDataInt(roomId, "option1_bad_hope");
        option1_bad_charity = ds.GetRoomDataInt(roomId, "option1_bad_charity");
        option2_good_courage = ds.GetRoomDataInt(roomId, "option2_good_courage");
        option2_good_prudence = ds.GetRoomDataInt(roomId, "option2_good_prudence");
        option2_good_temperance = ds.GetRoomDataInt(roomId, "option2_good_temperance");
        option2_good_justice = ds.GetRoomDataInt(roomId, "option2_good_justice");
        option2_good_faith = ds.GetRoomDataInt(roomId, "option2_good_faith");
        option2_good_hope = ds.GetRoomDataInt(roomId, "option2_good_hope");
        option2_good_charity = ds.GetRoomDataInt(roomId, "option2_good_charity");
        option2_neutral_courage = ds.GetRoomDataInt(roomId, "option2_neutral_courage");
        option2_neutral_prudence = ds.GetRoomDataInt(roomId, "option2_neutral_prudence");
        option2_neutral_temperance = ds.GetRoomDataInt(roomId, "option2_neutral_temperance");
        option2_neutral_justice = ds.GetRoomDataInt(roomId, "option2_neutral_justice");
        option2_neutral_faith = ds.GetRoomDataInt(roomId, "option2_neutral_faith");
        option2_neutral_hope = ds.GetRoomDataInt(roomId, "option2_neutral_hope");
        option2_neutral_charity = ds.GetRoomDataInt(roomId, "option2_neutral_charity");
        option2_bad_courage = ds.GetRoomDataInt(roomId, "option2_bad_courage");
        option2_bad_prudence = ds.GetRoomDataInt(roomId, "option2_bad_prudence");
        option2_bad_temperance = ds.GetRoomDataInt(roomId, "option2_bad_temperance");
        option2_bad_justice = ds.GetRoomDataInt(roomId, "option2_bad_justice");
        option2_bad_faith = ds.GetRoomDataInt(roomId, "option2_bad_faith");
        option2_bad_hope = ds.GetRoomDataInt(roomId, "option2_bad_hope");
        option2_bad_charity = ds.GetRoomDataInt(roomId, "option2_bad_charity");
        option3_good_courage = ds.GetRoomDataInt(roomId, "option3_good_courage");
        option3_good_prudence = ds.GetRoomDataInt(roomId, "option3_good_prudence");
        option3_good_temperance = ds.GetRoomDataInt(roomId, "option3_good_temperance");
        option3_good_justice = ds.GetRoomDataInt(roomId, "option3_good_justice");
        option3_good_faith = ds.GetRoomDataInt(roomId, "option3_good_faith");
        option3_good_hope = ds.GetRoomDataInt(roomId, "option3_good_hope");
        option3_good_charity = ds.GetRoomDataInt(roomId, "option3_good_charity");
        option3_neutral_courage = ds.GetRoomDataInt(roomId, "option3_neutral_courage");
        option3_neutral_prudence = ds.GetRoomDataInt(roomId, "option3_neutral_prudence");
        option3_neutral_temperance = ds.GetRoomDataInt(roomId, "option3_neutral_temperance");
        option3_neutral_justice = ds.GetRoomDataInt(roomId, "option3_neutral_justice");
        option3_neutral_faith = ds.GetRoomDataInt(roomId, "option3_neutral_faith");
        option3_neutral_hope = ds.GetRoomDataInt(roomId, "option3_neutral_hope");
        option3_neutral_charity = ds.GetRoomDataInt(roomId, "option3_neutral_charity");
        option3_bad_courage = ds.GetRoomDataInt(roomId, "option3_bad_courage");
        option3_bad_prudence = ds.GetRoomDataInt(roomId, "option3_bad_prudence");
        option3_bad_temperance = ds.GetRoomDataInt(roomId, "option3_bad_temperance");
        option3_bad_justice = ds.GetRoomDataInt(roomId, "option3_bad_justice");
        option3_bad_faith = ds.GetRoomDataInt(roomId, "option3_bad_faith");
        option3_bad_hope = ds.GetRoomDataInt(roomId, "option3_bad_hope");
        option3_bad_charity = ds.GetRoomDataInt(roomId, "option3_bad_charity");
        Debug.Log("Done getting room data");
    }

    #endregion

    //#region Room Methods



    //private void _1_1()
    //{
    //    audioStartTime = 67;
    //    audioStopTime = 155;
    //    audioURL = "https://www.youtube.com/watch?v=lEEyuEL7dt0";

    //    backgroundImgA.texture = Resources.Load<Texture2D>("SourceMaterial/Images/1_1");

    //    PreloadNextBackgroundImage("http://www.gutenberg.org/files/8789/8789-h/images/01-005.jpg");
    //    TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/1_1");
    //    TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/1_1");
    //    sourceTextGUI.text = sourceTextFileContents.text;
    //    descriptionTextGUI.text = descriptionTextFileContents.text;

    //    promptTextGUI.text = "You have only one option. You must follow Dante...";

    //    numberOfOptions = 1;

    //    //option1
    //    option1BadOutcomeText = "You foolishly follow Dante.";
    //    option1NeutralOutcomeText = "You find Courage and resolve to follow Dante, but in your heart you know this is probably not a good idea.";
    //    option1GoodOutcomeText = "You find your Courage and resolve to follow Dante.";
    //    virtueGained1 = "Courage";
    //    virtueLost1 = "Prudence";
    //}


    //private void _1_2()
    //{
    //    audioStartTime = 160;
    //    audioStopTime = 205;
    //    audioURL = "https://www.youtube.com/watch?v=lEEyuEL7dt0";

    //    PreloadNextBackgroundImage("http://www.gutenberg.org/files/8789/8789-h/images/01-007.jpg");

    //    //backgroundImg.GetComponent<Animation>().Play();
    //    TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/1_2");
    //    TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/1_2");
    //    sourceTextGUI.text = sourceTextFileContents.text;
    //    descriptionTextGUI.text = descriptionTextFileContents.text;

    //    promptTextGUI.text = "What will you do? \n \n 1) Confront the panther \n 2) Follow Dante \n 3) Run away";

    //    numberOfOptions = 3;

    //    //option1
    //    option1GoodOutcomeText = "You bravely confront the panther, standing tall and fearless before it. The beast slinks away and allows you to pass.";
    //    option1NeutralOutcomeText = "neutral1";
    //    option1BadOutcomeText = "bad1";
    //    virtueGained1 = "Courage";
    //    virtueLost1 = "Prudence";

    //    //option2
    //    option2GoodOutcomeText = "good2";
    //    option2NeutralOutcomeText = "You wisely decide to follow Dante and keep your distance from the panther, but in your heart you feel like a coward.";
    //    option2BadOutcomeText = "bad2";
    //    virtueGained2 = "Prudence";
    //    virtueLost2 = "Courage";

    //    //option3
    //    option3GoodOutcomeText = "good2";
    //    option3NeutralOutcomeText = "neutral3";
    //    option3BadOutcomeText = "At the sight of the panther you flee, running blindly into the forest away from the beast. After some time blindly stumbling around you spot Dante in the distance. You feel ashamed of your cowardice.";
    //    virtueGained3 = "Prudence";
    //    virtueLost3 = "Courage";
    //}


    //private void _1_3()
    //{
    //    audioStartTime = 200;
    //    audioStopTime = 340;
    //    audioURL = "https://www.youtube.com/watch?v=lEEyuEL7dt0";

    //    PreloadNextBackgroundImage("http://www.gutenberg.org/files/8789/8789-h/images/01-011.jpg");
    //    //backgroundImg.GetComponent<Animation>().Play();
    //    TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/1_3");
    //    TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/1_3");
    //    sourceTextGUI.text = sourceTextFileContents.text;
    //    descriptionTextGUI.text = descriptionTextFileContents.text;
    //    promptTextGUI.text = "You can confront the lion and the wolf, potentially increasing your Courage, but you risk having your Courage fail as well if you are overwhelmed and are forced to flee. \n \n 1) Confront the lion and wolf \n 2) Keep your distance";

    //    numberOfOptions = 2;

    //    //option1
    //    option1GoodOutcomeText = "You bravely confront the lion and the wolf. They submit to your dominance and allow you to pass unhindered.";
    //    option1NeutralOutcomeText = "You bravely confront the lion and the wolf.";
    //    option1BadOutcomeText = "You confront the lion and the wolf but are quickly overwhelmed with fear and turn and flee. You are ashamed of your cowardice.";
    //    virtueGained1 = "Courage";
    //    virtueLost1 = "Faith";

    //    //option2
    //    option2GoodOutcomeText = "good2";
    //    option2NeutralOutcomeText = "You wisely decide to follow Dante and keep your distance from the panther, but in your heart you feel like a coward.";
    //    option2BadOutcomeText = "bad2";
    //    virtueGained2 = "Prudence";
    //    virtueLost2 = "Courage";
    //}


    //private void _1_4()
    //{
    //    PreloadNextBackgroundImage("http://www.gutenberg.org/files/8789/8789-h/images/01-015.jpg");
    //    //backgroundImg.GetComponent<Animation>().Play();
    //    TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/1_4");
    //    TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/1_4");
    //    sourceTextGUI.text = sourceTextFileContents.text;
    //    descriptionTextGUI.text = descriptionTextFileContents.text;
    //    promptTextGUI.text = "prompt";

    //    numberOfOptions = 3;

    //    //option1
    //    option1GoodOutcomeText = "good1";
    //    option1NeutralOutcomeText = "neutral1";
    //    option1BadOutcomeText = "bad1";
    //    virtueGained1 = "Hope";
    //    virtueLost1 = "Faith";

    //    //option2
    //    option2GoodOutcomeText = "good2";
    //    option2NeutralOutcomeText = "neutral2";
    //    option2BadOutcomeText = "bad2";
    //    virtueGained2 = "Courage";
    //    virtueLost2 = "Temperance";

    //    //option3
    //    option3GoodOutcomeText = "good3";
    //    option3NeutralOutcomeText = "neutral3";
    //    option3BadOutcomeText = "bad3";
    //    virtueGained3 = "Temperance";
    //    virtueLost3 = "Justice";
    //}


    //private void _1_5()
    //{
    //    PreloadNextBackgroundImage("http://www.gutenberg.org/files/8789/8789-h/images/02-017.jpg");
    //    //backgroundImg.GetComponent<Animation>().Play();
    //    TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/1_5");
    //    TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/1_5");
    //    sourceTextGUI.text = sourceTextFileContents.text;
    //    descriptionTextGUI.text = descriptionTextFileContents.text;
    //    promptTextGUI.text = "prompt";

    //    numberOfOptions = 3;

    //    //option1
    //    option1GoodOutcomeText = "good1";
    //    option1NeutralOutcomeText = "neutral1";
    //    option1BadOutcomeText = "bad1";
    //    virtueGained1 = "Hope";
    //    virtueLost1 = "Faith";

    //    //option2
    //    option2GoodOutcomeText = "good2";
    //    option2NeutralOutcomeText = "neutral2";
    //    option2BadOutcomeText = "bad2";
    //    virtueGained2 = "Courage";
    //    virtueLost2 = "Temperance";

    //    //option3
    //    option3GoodOutcomeText = "good3";
    //    option3NeutralOutcomeText = "neutral3";
    //    option3BadOutcomeText = "bad3";
    //    virtueGained3 = "Temperance";
    //    virtueLost3 = "Justice";
    //}


    //private void _2_1()
    //{
    //    PreloadNextBackgroundImage("http://www.gutenberg.org/files/8789/8789-h/images/02-021.jpg");
    //    //backgroundImg.GetComponent<Animation>().Play();
    //    TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/2_1");
    //    TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/2_1");
    //    sourceTextGUI.text = sourceTextFileContents.text;
    //    descriptionTextGUI.text = descriptionTextFileContents.text;
    //    promptTextGUI.text = "prompt";

    //    numberOfOptions = 3;

    //    //option1
    //    option1GoodOutcomeText = "good1";
    //    option1NeutralOutcomeText = "neutral1";
    //    option1BadOutcomeText = "bad1";
    //    virtueGained1 = "Hope";
    //    virtueLost1 = "Faith";

    //    //option2
    //    option2GoodOutcomeText = "good2";
    //    option2NeutralOutcomeText = "neutral2";
    //    option2BadOutcomeText = "bad2";
    //    virtueGained2 = "Courage";
    //    virtueLost2 = "Temperance";

    //    //option3
    //    option3GoodOutcomeText = "good3";
    //    option3NeutralOutcomeText = "neutral3";
    //    option3BadOutcomeText = "bad3";
    //    virtueGained3 = "Temperance";
    //    virtueLost3 = "Justice";
    //}


    //private void _2_2()
    //{
    //    PreloadNextBackgroundImage("http://www.gutenberg.org/files/8789/8789-h/images/03-027.jpg");
    //    //backgroundImg.GetComponent<Animation>().Play();
    //    TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/2_2");
    //    TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/2_2");
    //    sourceTextGUI.text = sourceTextFileContents.text;
    //    descriptionTextGUI.text = descriptionTextFileContents.text;
    //    promptTextGUI.text = "prompt";

    //    numberOfOptions = 3;

    //    //option1
    //    option1GoodOutcomeText = "good1";
    //    option1NeutralOutcomeText = "neutral1";
    //    option1BadOutcomeText = "bad1";
    //    virtueGained1 = "Hope";
    //    virtueLost1 = "Faith";

    //    //option2
    //    option2GoodOutcomeText = "good2";
    //    option2NeutralOutcomeText = "neutral2";
    //    option2BadOutcomeText = "bad2";
    //    virtueGained2 = "Courage";
    //    virtueLost2 = "Temperance";

    //    //option3
    //    option3GoodOutcomeText = "good3";
    //    option3NeutralOutcomeText = "neutral3";
    //    option3BadOutcomeText = "bad3";
    //    virtueGained3 = "Temperance";
    //    virtueLost3 = "Justice";
    //}


    //private void _3_1()
    //{
    //    PreloadNextBackgroundImage("http://www.gutenberg.org/files/8789/8789-h/images/03-031.jpg");

    //    //backgroundImg.GetComponent<Animation>().Play();
    //    TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/3_1");
    //    TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/3_1");
    //    sourceTextGUI.text = sourceTextFileContents.text;
    //    descriptionTextGUI.text = descriptionTextFileContents.text;
    //    promptTextGUI.text =
    //        "prompt";

    //    numberOfOptions = 1;

    //    //option1
    //    option1GoodOutcomeText = "Despite the foreboding of the black entrance of the cave, you feel your Faith increasing.";
    //    option1NeutralOutcomeText = "Despite the foreboding of the black entrance of the cave, you feel your Faith increasing, but a thought nags in your mind that following them into the dark abyss is probably a bad idea. ";
    //    option1BadOutcomeText = "You follow them into the cave, and a thought nags in your mind that following them into the dark abyss is probably a bad idea.";
    //    virtueGained1 = "Faith";
    //    virtueLost1 = "Prudence";

    //    //option2
    //    option2GoodOutcomeText = "good2";
    //    option2NeutralOutcomeText = "neutral2";
    //    option2BadOutcomeText = "bad2";
    //    virtueGained2 = "Courage";
    //    virtueLost2 = "Temperance";

    //    //option3
    //    option3GoodOutcomeText = "good2";
    //    option3NeutralOutcomeText = "neutral3";
    //    option3BadOutcomeText = "bad3";
    //    virtueGained3 = "Temperance";
    //    virtueLost3 = "Justice";

    //}


    //private void _3_2()
    //{
    //    PreloadNextBackgroundImage("http://www.gutenberg.org/files/8789/8789-h/images/03-035.jpg");
    //    //backgroundImg.GetComponent<Animation>().Play();
    //    TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/3_2");
    //    TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/3_2");
    //    sourceTextGUI.text = sourceTextFileContents.text;
    //    descriptionTextGUI.text = descriptionTextFileContents.text;
    //    promptTextGUI.text = "prompt";

    //    numberOfOptions = 3;

    //    //option1
    //    option1GoodOutcomeText = "good1";
    //    option1NeutralOutcomeText = "neutral1";
    //    option1BadOutcomeText = "bad1";
    //    virtueGained1 = "Hope";
    //    virtueLost1 = "Faith";

    //    //option2
    //    option2GoodOutcomeText = "good2";
    //    option2NeutralOutcomeText = "neutral2";
    //    option2BadOutcomeText = "bad2";
    //    virtueGained2 = "Courage";
    //    virtueLost2 = "Temperance";

    //    //option3
    //    option3GoodOutcomeText = "good3";
    //    option3NeutralOutcomeText = "neutral3";
    //    option3BadOutcomeText = "bad3";
    //    virtueGained3 = "Temperance";
    //    virtueLost3 = "Justice";

    //}


    //private void _3_3()
    //{
    //    PreloadNextBackgroundImage("http://www.gutenberg.org/files/8789/8789-h/images/04-039.jpg");
    //    TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/3_3");
    //    TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/3_3");
    //    sourceTextGUI.text = sourceTextFileContents.text;
    //    descriptionTextGUI.text = descriptionTextFileContents.text;
    //    promptTextGUI.text = "prompt";

    //    numberOfOptions = 3;

    //    //option1
    //    option1GoodOutcomeText = "good1";
    //    option1NeutralOutcomeText = "neutral1";
    //    option1BadOutcomeText = "bad1";
    //    virtueGained1 = "Hope";
    //    virtueLost1 = "Faith";

    //    //option2
    //    option2GoodOutcomeText = "good2";
    //    option2NeutralOutcomeText = "neutral2";
    //    option2BadOutcomeText = "bad2";
    //    virtueGained2 = "Courage";
    //    virtueLost2 = "Temperance";

    //    //option3
    //    option3GoodOutcomeText = "good3";
    //    option3NeutralOutcomeText = "neutral3";
    //    option3BadOutcomeText = "bad3";
    //    virtueGained3 = "Temperance";
    //    virtueLost3 = "Justice";
    //}


    //private void _4_1()
    //{
    //    PreloadNextBackgroundImage("http://www.gutenberg.org/files/8789/8789-h/images/04-043.jpg");

    //    TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/4_1");
    //    TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/4_1");
    //    sourceTextGUI.text = sourceTextFileContents.text;
    //    descriptionTextGUI.text = descriptionTextFileContents.text;
    //    promptTextGUI.text = "prompt";

    //    numberOfOptions = 3;

    //    //option1
    //    option1GoodOutcomeText = "good1";
    //    option1NeutralOutcomeText = "neutral1";
    //    option1BadOutcomeText = "bad1";
    //    virtueGained1 = "Hope";
    //    virtueLost1 = "Faith";

    //    //option2
    //    option2GoodOutcomeText = "good2";
    //    option2NeutralOutcomeText = "neutral2";
    //    option2BadOutcomeText = "bad2";
    //    virtueGained2 = "Courage";
    //    virtueLost2 = "Temperance";

    //    //option3
    //    option3GoodOutcomeText = "good3";
    //    option3NeutralOutcomeText = "neutral3";
    //    option3BadOutcomeText = "bad3";
    //    virtueGained3 = "Temperance";
    //    virtueLost3 = "Justice";

    //}


    //private void _4_2()
    //{
    //    PreloadNextBackgroundImage("http://www.gutenberg.org/files/8789/8789-h/images/05-047.jpg");

    //    TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/4_2");
    //    TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/4_2");
    //    sourceTextGUI.text = sourceTextFileContents.text;
    //    descriptionTextGUI.text = descriptionTextFileContents.text;
    //    promptTextGUI.text = "prompt";

    //    numberOfOptions = 3;

    //    //option1
    //    option1GoodOutcomeText = "good1";
    //    option1NeutralOutcomeText = "neutral1";
    //    option1BadOutcomeText = "bad1";
    //    virtueGained1 = "Hope";
    //    virtueLost1 = "Faith";

    //    //option2
    //    option2GoodOutcomeText = "good2";
    //    option2NeutralOutcomeText = "neutral2";
    //    option2BadOutcomeText = "bad2";
    //    virtueGained2 = "Courage";
    //    virtueLost2 = "Temperance";

    //    //option3
    //    option3GoodOutcomeText = "good3";
    //    option3NeutralOutcomeText = "neutral3";
    //    option3BadOutcomeText = "bad3";
    //    virtueGained3 = "Temperance";
    //    virtueLost3 = "Justice";
    //}


    //private void _5_1()
    //{
    //    PreloadNextBackgroundImage("http://www.gutenberg.org/files/8789/8789-h/images/05-051.jpg");

    //    TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/5_1");
    //    TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/5_1");
    //    sourceTextGUI.text = sourceTextFileContents.text;
    //    descriptionTextGUI.text = descriptionTextFileContents.text;
    //    promptTextGUI.text = "prompt";

    //    numberOfOptions = 3;

    //    //option1
    //    option1GoodOutcomeText = "good1";
    //    option1NeutralOutcomeText = "neutral1";
    //    option1BadOutcomeText = "bad1";
    //    virtueGained1 = "Hope";
    //    virtueLost1 = "Faith";

    //    //option2
    //    option2GoodOutcomeText = "good2";
    //    option2NeutralOutcomeText = "neutral2";
    //    option2BadOutcomeText = "bad2";
    //    virtueGained2 = "Courage";
    //    virtueLost2 = "Temperance";

    //    //option3
    //    option3GoodOutcomeText = "good3";
    //    option3NeutralOutcomeText = "neutral3";
    //    option3BadOutcomeText = "bad3";
    //    virtueGained3 = "Temperance";
    //    virtueLost3 = "Justice";
    //}


    //private void _5_2()
    //{
    //    PreloadNextBackgroundImage("http://www.gutenberg.org/files/8789/8789-h/images/05-053.jpg");

    //    TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/5_2");
    //    TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/5_2");
    //    sourceTextGUI.text = sourceTextFileContents.text;
    //    descriptionTextGUI.text = descriptionTextFileContents.text;
    //    promptTextGUI.text = "prompt";

    //    numberOfOptions = 3;

    //    //option1
    //    option1GoodOutcomeText = "good1";
    //    option1NeutralOutcomeText = "neutral1";
    //    option1BadOutcomeText = "bad1";
    //    virtueGained1 = "Hope";
    //    virtueLost1 = "Faith";

    //    //option2
    //    option2GoodOutcomeText = "good2";
    //    option2NeutralOutcomeText = "neutral2";
    //    option2BadOutcomeText = "bad2";
    //    virtueGained2 = "Courage";
    //    virtueLost2 = "Temperance";

    //    //option3
    //    option3GoodOutcomeText = "good3";
    //    option3NeutralOutcomeText = "neutral3";
    //    option3BadOutcomeText = "bad3";
    //    virtueGained3 = "Temperance";
    //    virtueLost3 = "Justice";
    //}


    //private void _5_3()
    //{
    //    PreloadNextBackgroundImage("http://www.gutenberg.org/files/8789/8789-h/images/05-057.jpg");

    //    TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/5_3");
    //    TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/5_3");
    //    sourceTextGUI.text = sourceTextFileContents.text;
    //    descriptionTextGUI.text = descriptionTextFileContents.text;
    //    promptTextGUI.text = "prompt";

    //    numberOfOptions = 3;

    //    //option1
    //    option1GoodOutcomeText = "good1";
    //    option1NeutralOutcomeText = "neutral1";
    //    option1BadOutcomeText = "bad1";
    //    virtueGained1 = "Hope";
    //    virtueLost1 = "Faith";

    //    //option2
    //    option2GoodOutcomeText = "good2";
    //    option2NeutralOutcomeText = "neutral2";
    //    option2BadOutcomeText = "bad2";
    //    virtueGained2 = "Courage";
    //    virtueLost2 = "Temperance";

    //    //option3
    //    option3GoodOutcomeText = "good3";
    //    option3NeutralOutcomeText = "neutral3";
    //    option3BadOutcomeText = "bad3";
    //    virtueGained3 = "Temperance";
    //    virtueLost3 = "Justice";
    //}


    //private void _5_4()
    //{
    //    PreloadNextBackgroundImage("http://www.gutenberg.org/files/8789/8789-h/images/05-061.jpg");

    //    TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/5_4");
    //    TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/5_4");
    //    sourceTextGUI.text = sourceTextFileContents.text;
    //    descriptionTextGUI.text = descriptionTextFileContents.text;
    //    promptTextGUI.text = "prompt";

    //    numberOfOptions = 3;

    //    //option1
    //    option1GoodOutcomeText = "good1";
    //    option1NeutralOutcomeText = "neutral1";
    //    option1BadOutcomeText = "bad1";
    //    virtueGained1 = "Hope";
    //    virtueLost1 = "Faith";

    //    //option2
    //    option2GoodOutcomeText = "good2";
    //    option2NeutralOutcomeText = "neutral2";
    //    option2BadOutcomeText = "bad2";
    //    virtueGained2 = "Courage";
    //    virtueLost2 = "Temperance";

    //    //option3
    //    option3GoodOutcomeText = "good3";
    //    option3NeutralOutcomeText = "neutral3";
    //    option3BadOutcomeText = "bad3";
    //    virtueGained3 = "Temperance";
    //    virtueLost3 = "Justice";
    //}


    //private void _5_5()
    //{
    //    PreloadNextBackgroundImage("http://www.gutenberg.org/files/8789/8789-h/images/05-063.jpg");

    //    TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/5_5");
    //    TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/5_5");
    //    sourceTextGUI.text = sourceTextFileContents.text;
    //    descriptionTextGUI.text = descriptionTextFileContents.text;
    //    promptTextGUI.text = "prompt";

    //    numberOfOptions = 3;

    //    //option1
    //    option1GoodOutcomeText = "good1";
    //    option1NeutralOutcomeText = "neutral1";
    //    option1BadOutcomeText = "bad1";
    //    virtueGained1 = "Hope";
    //    virtueLost1 = "Faith";

    //    //option2
    //    option2GoodOutcomeText = "good2";
    //    option2NeutralOutcomeText = "neutral2";
    //    option2BadOutcomeText = "bad2";
    //    virtueGained2 = "Courage";
    //    virtueLost2 = "Temperance";

    //    //option3
    //    option3GoodOutcomeText = "good3";
    //    option3NeutralOutcomeText = "neutral3";
    //    option3BadOutcomeText = "bad3";
    //    virtueGained3 = "Temperance";
    //    virtueLost3 = "Justice";
    //}


    //private void _5_6()
    //{
    //    PreloadNextBackgroundImage("http://www.gutenberg.org/files/8789/8789-h/images/06-067.jpg");

    //    TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/5_6");
    //    TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/5_6");
    //    sourceTextGUI.text = sourceTextFileContents.text;
    //    descriptionTextGUI.text = descriptionTextFileContents.text;
    //    promptTextGUI.text = "prompt";

    //    numberOfOptions = 3;

    //    //option1
    //    option1GoodOutcomeText = "good1";
    //    option1NeutralOutcomeText = "neutral1";
    //    option1BadOutcomeText = "bad1";
    //    virtueGained1 = "Hope";
    //    virtueLost1 = "Faith";

    //    //option2
    //    option2GoodOutcomeText = "good2";
    //    option2NeutralOutcomeText = "neutral2";
    //    option2BadOutcomeText = "bad2";
    //    virtueGained2 = "Courage";
    //    virtueLost2 = "Temperance";

    //    //option3
    //    option3GoodOutcomeText = "good3";
    //    option3NeutralOutcomeText = "neutral3";
    //    option3BadOutcomeText = "bad3";
    //    virtueGained3 = "Temperance";
    //    virtueLost3 = "Justice";
    //}


    //private void _6_1()
    //{
    //    PreloadNextBackgroundImage("http://www.gutenberg.org/files/8789/8789-h/images/06-069.jpg");

    //    TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/6_1");
    //    TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/6_1");
    //    sourceTextGUI.text = sourceTextFileContents.text;
    //    descriptionTextGUI.text = descriptionTextFileContents.text;
    //    promptTextGUI.text = "prompt";

    //    numberOfOptions = 3;

    //    //option1
    //    option1GoodOutcomeText = "good1";
    //    option1NeutralOutcomeText = "neutral1";
    //    option1BadOutcomeText = "bad1";
    //    virtueGained1 = "Hope";
    //    virtueLost1 = "Faith";

    //    //option2
    //    option2GoodOutcomeText = "good2";
    //    option2NeutralOutcomeText = "neutral2";
    //    option2BadOutcomeText = "bad2";
    //    virtueGained2 = "Courage";
    //    virtueLost2 = "Temperance";

    //    //option3
    //    option3GoodOutcomeText = "good3";
    //    option3NeutralOutcomeText = "neutral3";
    //    option3BadOutcomeText = "bad3";
    //    virtueGained3 = "Temperance";
    //    virtueLost3 = "Justice";
    //}


    //private void _6_2()
    //{
    //    PreloadNextBackgroundImage("http://www.gutenberg.org/files/8789/8789-h/images/07-075.jpg");

    //    TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/6_2");
    //    TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/6_2");
    //    sourceTextGUI.text = sourceTextFileContents.text;
    //    descriptionTextGUI.text = descriptionTextFileContents.text;
    //    promptTextGUI.text = "prompt";

    //    numberOfOptions = 3;

    //    //option1
    //    option1GoodOutcomeText = "good1";
    //    option1NeutralOutcomeText = "neutral1";
    //    option1BadOutcomeText = "bad1";
    //    virtueGained1 = "Hope";
    //    virtueLost1 = "Faith";

    //    //option2
    //    option2GoodOutcomeText = "good2";
    //    option2NeutralOutcomeText = "neutral2";
    //    option2BadOutcomeText = "bad2";
    //    virtueGained2 = "Courage";
    //    virtueLost2 = "Temperance";

    //    //option3
    //    option3GoodOutcomeText = "good3";
    //    option3NeutralOutcomeText = "neutral3";
    //    option3BadOutcomeText = "bad3";
    //    virtueGained3 = "Temperance";
    //    virtueLost3 = "Justice";
    //}


    //private void _7_1()
    //{
    //    PreloadNextBackgroundImage("http://www.gutenberg.org/files/8789/8789-h/images/07-079.jpg");

    //    TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/7_1");
    //    TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/7_1");
    //    sourceTextGUI.text = sourceTextFileContents.text;
    //    descriptionTextGUI.text = descriptionTextFileContents.text;
    //    promptTextGUI.text = "prompt";

    //    numberOfOptions = 3;

    //    //option1
    //    option1GoodOutcomeText = "good1";
    //    option1NeutralOutcomeText = "neutral1";
    //    option1BadOutcomeText = "bad1";
    //    virtueGained1 = "Hope";
    //    virtueLost1 = "Faith";

    //    //option2
    //    option2GoodOutcomeText = "good2";
    //    option2NeutralOutcomeText = "neutral2";
    //    option2BadOutcomeText = "bad2";
    //    virtueGained2 = "Courage";
    //    virtueLost2 = "Temperance";

    //    //option3
    //    option3GoodOutcomeText = "good3";
    //    option3NeutralOutcomeText = "neutral3";
    //    option3BadOutcomeText = "bad3";
    //    virtueGained3 = "Temperance";
    //    virtueLost3 = "Justice";
    //}


    //private void _7_2()
    //{
    //    PreloadNextBackgroundImage("http://www.gutenberg.org/files/8789/8789-h/images/07-083.jpg");

    //    TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/7_2");
    //    TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/7_2");
    //    sourceTextGUI.text = sourceTextFileContents.text;
    //    descriptionTextGUI.text = descriptionTextFileContents.text;
    //    promptTextGUI.text = "prompt";

    //    numberOfOptions = 3;

    //    //option1
    //    option1GoodOutcomeText = "good1";
    //    option1NeutralOutcomeText = "neutral1";
    //    option1BadOutcomeText = "bad1";
    //    virtueGained1 = "Hope";
    //    virtueLost1 = "Faith";

    //    //option2
    //    option2GoodOutcomeText = "good2";
    //    option2NeutralOutcomeText = "neutral2";
    //    option2BadOutcomeText = "bad2";
    //    virtueGained2 = "Courage";
    //    virtueLost2 = "Temperance";

    //    //option3
    //    option3GoodOutcomeText = "good3";
    //    option3NeutralOutcomeText = "neutral3";
    //    option3BadOutcomeText = "bad3";
    //    virtueGained3 = "Temperance";
    //    virtueLost3 = "Justice";
    //}


    //private void _7_3()
    //{
    //    PreloadNextBackgroundImage("http://www.gutenberg.org/files/8789/8789-h/images/08-087.jpg");

    //    TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/7_3");
    //    TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/7_3");
    //    sourceTextGUI.text = sourceTextFileContents.text;
    //    descriptionTextGUI.text = descriptionTextFileContents.text;
    //    promptTextGUI.text = "prompt";

    //    numberOfOptions = 3;

    //    //option1
    //    option1GoodOutcomeText = "good1";
    //    option1NeutralOutcomeText = "neutral1";
    //    option1BadOutcomeText = "bad1";
    //    virtueGained1 = "Hope";
    //    virtueLost1 = "Faith";

    //    //option2
    //    option2GoodOutcomeText = "good2";
    //    option2NeutralOutcomeText = "neutral2";
    //    option2BadOutcomeText = "bad2";
    //    virtueGained2 = "Courage";
    //    virtueLost2 = "Temperance";

    //    //option3
    //    option3GoodOutcomeText = "good3";
    //    option3NeutralOutcomeText = "neutral3";
    //    option3BadOutcomeText = "bad3";
    //    virtueGained3 = "Temperance";
    //    virtueLost3 = "Justice";
    //}


    //private void _8_1()
    //{
    //    PreloadNextBackgroundImage("http://www.gutenberg.org/files/8789/8789-h/images/08-089.jpg");

    //    TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/8_1");
    //    TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/8_1");
    //    sourceTextGUI.text = sourceTextFileContents.text;
    //    descriptionTextGUI.text = descriptionTextFileContents.text;
    //    promptTextGUI.text = "prompt";

    //    numberOfOptions = 3;

    //    //option1
    //    option1GoodOutcomeText = "good1";
    //    option1NeutralOutcomeText = "neutral1";
    //    option1BadOutcomeText = "bad1";
    //    virtueGained1 = "Hope";
    //    virtueLost1 = "Faith";

    //    //option2
    //    option2GoodOutcomeText = "good2";
    //    option2NeutralOutcomeText = "neutral2";
    //    option2BadOutcomeText = "bad2";
    //    virtueGained2 = "Courage";
    //    virtueLost2 = "Temperance";

    //    //option3
    //    option3GoodOutcomeText = "good3";
    //    option3NeutralOutcomeText = "neutral3";
    //    option3BadOutcomeText = "bad3";
    //    virtueGained3 = "Temperance";
    //    virtueLost3 = "Justice";
    //}


    //private void _8_2()
    //{
    //    PreloadNextBackgroundImage("http://www.gutenberg.org/files/8789/8789-h/images/08-093.jpg");

    //    TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/8_2");
    //    TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/8_2");
    //    sourceTextGUI.text = sourceTextFileContents.text;
    //    descriptionTextGUI.text = descriptionTextFileContents.text;
    //    promptTextGUI.text = "prompt";

    //    numberOfOptions = 3;

    //    //option1
    //    option1GoodOutcomeText = "good1";
    //    option1NeutralOutcomeText = "neutral1";
    //    option1BadOutcomeText = "bad1";
    //    virtueGained1 = "Hope";
    //    virtueLost1 = "Faith";

    //    //option2
    //    option2GoodOutcomeText = "good2";
    //    option2NeutralOutcomeText = "neutral2";
    //    option2BadOutcomeText = "bad2";
    //    virtueGained2 = "Courage";
    //    virtueLost2 = "Temperance";

    //    //option3
    //    option3GoodOutcomeText = "good3";
    //    option3NeutralOutcomeText = "neutral3";
    //    option3BadOutcomeText = "bad3";
    //    virtueGained3 = "Temperance";
    //    virtueLost3 = "Justice";
    //}


    //private void _8_3()
    //{
    //    PreloadNextBackgroundImage("http://www.gutenberg.org/files/8789/8789-h/images/09-097.jpg");

    //    TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/8_3");
    //    TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/8_3");
    //    sourceTextGUI.text = sourceTextFileContents.text;
    //    descriptionTextGUI.text = descriptionTextFileContents.text;
    //    promptTextGUI.text = "prompt";

    //    numberOfOptions = 3;

    //    //option1
    //    option1GoodOutcomeText = "good1";
    //    option1NeutralOutcomeText = "neutral1";
    //    option1BadOutcomeText = "bad1";
    //    virtueGained1 = "Hope";
    //    virtueLost1 = "Faith";

    //    //option2
    //    option2GoodOutcomeText = "good2";
    //    option2NeutralOutcomeText = "neutral2";
    //    option2BadOutcomeText = "bad2";
    //    virtueGained2 = "Courage";
    //    virtueLost2 = "Temperance";

    //    //option3
    //    option3GoodOutcomeText = "good3";
    //    option3NeutralOutcomeText = "neutral3";
    //    option3BadOutcomeText = "bad3";
    //    virtueGained3 = "Temperance";
    //    virtueLost3 = "Justice";
    //}


    //private void _9_1()
    //{
    //    PreloadNextBackgroundImage("http://www.gutenberg.org/files/8789/8789-h/images/09-101.jpg");

    //    TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/9_1");
    //    TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/9_1");
    //    sourceTextGUI.text = sourceTextFileContents.text;
    //    descriptionTextGUI.text = descriptionTextFileContents.text;
    //    promptTextGUI.text = "prompt";

    //    numberOfOptions = 3;

    //    //option1
    //    option1GoodOutcomeText = "good1";
    //    option1NeutralOutcomeText = "neutral1";
    //    option1BadOutcomeText = "bad1";
    //    virtueGained1 = "Hope";
    //    virtueLost1 = "Faith";

    //    //option2
    //    option2GoodOutcomeText = "good2";
    //    option2NeutralOutcomeText = "neutral2";
    //    option2BadOutcomeText = "bad2";
    //    virtueGained2 = "Courage";
    //    virtueLost2 = "Temperance";

    //    //option3
    //    option3GoodOutcomeText = "good3";
    //    option3NeutralOutcomeText = "neutral3";
    //    option3BadOutcomeText = "bad3";
    //    virtueGained3 = "Temperance";
    //    virtueLost3 = "Justice";
    //}


    //private void _9_2()
    //{
    //    PreloadNextBackgroundImage("http://www.gutenberg.org/files/8789/8789-h/images/09-105.jpg");

    //    TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/9_2");
    //    TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/9_2");
    //    sourceTextGUI.text = sourceTextFileContents.text;
    //    descriptionTextGUI.text = descriptionTextFileContents.text;
    //    promptTextGUI.text = "prompt";

    //    numberOfOptions = 3;

    //    //option1
    //    option1GoodOutcomeText = "good1";
    //    option1NeutralOutcomeText = "neutral1";
    //    option1BadOutcomeText = "bad1";
    //    virtueGained1 = "Hope";
    //    virtueLost1 = "Faith";

    //    //option2
    //    option2GoodOutcomeText = "good2";
    //    option2NeutralOutcomeText = "neutral2";
    //    option2BadOutcomeText = "bad2";
    //    virtueGained2 = "Courage";
    //    virtueLost2 = "Temperance";

    //    //option3
    //    option3GoodOutcomeText = "good3";
    //    option3NeutralOutcomeText = "neutral3";
    //    option3BadOutcomeText = "bad3";
    //    virtueGained3 = "Temperance";
    //    virtueLost3 = "Justice";
    //}


    //private void _9_3()
    //{
    //    PreloadNextBackgroundImage("http://www.gutenberg.org/files/8789/8789-h/images/10-109.jpg");

    //    TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/9_3");
    //    TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/9_3");
    //    sourceTextGUI.text = sourceTextFileContents.text;
    //    descriptionTextGUI.text = descriptionTextFileContents.text;
    //    promptTextGUI.text = "prompt";

    //    numberOfOptions = 3;

    //    //option1
    //    option1GoodOutcomeText = "good1";
    //    option1NeutralOutcomeText = "neutral1";
    //    option1BadOutcomeText = "bad1";
    //    virtueGained1 = "Hope";
    //    virtueLost1 = "Faith";

    //    //option2
    //    option2GoodOutcomeText = "good2";
    //    option2NeutralOutcomeText = "neutral2";
    //    option2BadOutcomeText = "bad2";
    //    virtueGained2 = "Courage";
    //    virtueLost2 = "Temperance";

    //    //option3
    //    option3GoodOutcomeText = "good3";
    //    option3NeutralOutcomeText = "neutral3";
    //    option3BadOutcomeText = "bad3";
    //    virtueGained3 = "Temperance";
    //    virtueLost3 = "Justice";
    //}


    //private void _10_1()
    //{
    //    PreloadNextBackgroundImage("http://www.gutenberg.org/files/8789/8789-h/images/11-115.jpg");

    //    TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/10_1");
    //    TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/10_1");
    //    sourceTextGUI.text = sourceTextFileContents.text;
    //    descriptionTextGUI.text = descriptionTextFileContents.text;
    //    promptTextGUI.text = "prompt";

    //    numberOfOptions = 3;

    //    //option1
    //    option1GoodOutcomeText = "good1";
    //    option1NeutralOutcomeText = "neutral1";
    //    option1BadOutcomeText = "bad1";
    //    virtueGained1 = "Hope";
    //    virtueLost1 = "Faith";

    //    //option2
    //    option2GoodOutcomeText = "good2";
    //    option2NeutralOutcomeText = "neutral2";
    //    option2BadOutcomeText = "bad2";
    //    virtueGained2 = "Courage";
    //    virtueLost2 = "Temperance";

    //    //option3
    //    option3GoodOutcomeText = "good3";
    //    option3NeutralOutcomeText = "neutral3";
    //    option3BadOutcomeText = "bad3";
    //    virtueGained3 = "Temperance";
    //    virtueLost3 = "Justice";
    //}


    //private void _11_1()
    //{
    //    PreloadNextBackgroundImage("http://www.gutenberg.org/files/8789/8789-h/images/12-123.jpg");

    //    TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/11_1");
    //    TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/11_1");
    //    sourceTextGUI.text = sourceTextFileContents.text;
    //    descriptionTextGUI.text = descriptionTextFileContents.text;
    //    promptTextGUI.text = "prompt";

    //    numberOfOptions = 3;

    //    //option1
    //    option1GoodOutcomeText = "good1";
    //    option1NeutralOutcomeText = "neutral1";
    //    option1BadOutcomeText = "bad1";
    //    virtueGained1 = "Hope";
    //    virtueLost1 = "Faith";

    //    //option2
    //    option2GoodOutcomeText = "good2";
    //    option2NeutralOutcomeText = "neutral2";
    //    option2BadOutcomeText = "bad2";
    //    virtueGained2 = "Courage";
    //    virtueLost2 = "Temperance";

    //    //option3
    //    option3GoodOutcomeText = "good3";
    //    option3NeutralOutcomeText = "neutral3";
    //    option3BadOutcomeText = "bad3";
    //    virtueGained3 = "Temperance";
    //    virtueLost3 = "Justice";
    //}


    //private void _12_1()
    //{
    //    PreloadNextBackgroundImage("http://www.gutenberg.org/files/8789/8789-h/images/12-127.jpg");

    //    TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/12_1");
    //    TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/12_1");
    //    sourceTextGUI.text = sourceTextFileContents.text;
    //    descriptionTextGUI.text = descriptionTextFileContents.text;
    //    promptTextGUI.text = "prompt";

    //    numberOfOptions = 3;

    //    //option1
    //    option1GoodOutcomeText = "good1";
    //    option1NeutralOutcomeText = "neutral1";
    //    option1BadOutcomeText = "bad1";
    //    virtueGained1 = "Hope";
    //    virtueLost1 = "Faith";

    //    //option2
    //    option2GoodOutcomeText = "good2";
    //    option2NeutralOutcomeText = "neutral2";
    //    option2BadOutcomeText = "bad2";
    //    virtueGained2 = "Courage";
    //    virtueLost2 = "Temperance";

    //    //option3
    //    option3GoodOutcomeText = "good3";
    //    option3NeutralOutcomeText = "neutral3";
    //    option3BadOutcomeText = "bad3";
    //    virtueGained3 = "Temperance";
    //    virtueLost3 = "Justice";
    //}


    //private void _12_2()
    //{
    //    PreloadNextBackgroundImage("http://www.gutenberg.org/files/8789/8789-h/images/12-129.jpg");

    //    TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/12_2");
    //    TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/12_2");
    //    sourceTextGUI.text = sourceTextFileContents.text;
    //    descriptionTextGUI.text = descriptionTextFileContents.text;
    //    promptTextGUI.text = "prompt";

    //    numberOfOptions = 3;

    //    //option1
    //    option1GoodOutcomeText = "good1";
    //    option1NeutralOutcomeText = "neutral1";
    //    option1BadOutcomeText = "bad1";
    //    virtueGained1 = "Hope";
    //    virtueLost1 = "Faith";

    //    //option2
    //    option2GoodOutcomeText = "good2";
    //    option2NeutralOutcomeText = "neutral2";
    //    option2BadOutcomeText = "bad2";
    //    virtueGained2 = "Courage";
    //    virtueLost2 = "Temperance";

    //    //option3
    //    option3GoodOutcomeText = "good3";
    //    option3NeutralOutcomeText = "neutral3";
    //    option3BadOutcomeText = "bad3";
    //    virtueGained3 = "Temperance";
    //    virtueLost3 = "Justice";
    //}


    //private void _12_3()
    //{
    //    PreloadNextBackgroundImage("http://www.gutenberg.org/files/8789/8789-h/images/13-135.jpg");

    //    TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/12_3");
    //    TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/12_3");
    //    sourceTextGUI.text = sourceTextFileContents.text;
    //    descriptionTextGUI.text = descriptionTextFileContents.text;
    //    promptTextGUI.text = "prompt";

    //    numberOfOptions = 3;

    //    //option1
    //    option1GoodOutcomeText = "good1";
    //    option1NeutralOutcomeText = "neutral1";
    //    option1BadOutcomeText = "bad1";
    //    virtueGained1 = "Hope";
    //    virtueLost1 = "Faith";

    //    //option2
    //    option2GoodOutcomeText = "good2";
    //    option2NeutralOutcomeText = "neutral2";
    //    option2BadOutcomeText = "bad2";
    //    virtueGained2 = "Courage";
    //    virtueLost2 = "Temperance";

    //    //option3
    //    option3GoodOutcomeText = "good3";
    //    option3NeutralOutcomeText = "neutral3";
    //    option3BadOutcomeText = "bad3";
    //    virtueGained3 = "Temperance";
    //    virtueLost3 = "Justice";
    //}


    //private void _13_1()
    //{
    //    PreloadNextBackgroundImage("http://www.gutenberg.org/files/8789/8789-h/images/13-137.jpg");

    //    TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/13_1");
    //    TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/13_1");
    //    sourceTextGUI.text = sourceTextFileContents.text;
    //    descriptionTextGUI.text = descriptionTextFileContents.text;
    //    promptTextGUI.text = "prompt";

    //    numberOfOptions = 3;

    //    //option1
    //    option1GoodOutcomeText = "good1";
    //    option1NeutralOutcomeText = "neutral1";
    //    option1BadOutcomeText = "bad1";
    //    virtueGained1 = "Hope";
    //    virtueLost1 = "Faith";

    //    //option2
    //    option2GoodOutcomeText = "good2";
    //    option2NeutralOutcomeText = "neutral2";
    //    option2BadOutcomeText = "bad2";
    //    virtueGained2 = "Courage";
    //    virtueLost2 = "Temperance";

    //    //option3
    //    option3GoodOutcomeText = "good3";
    //    option3NeutralOutcomeText = "neutral3";
    //    option3BadOutcomeText = "bad3";
    //    virtueGained3 = "Temperance";
    //    virtueLost3 = "Justice";
    //}


    //private void _13_2()
    //{
    //    PreloadNextBackgroundImage("http://www.gutenberg.org/files/8789/8789-h/images/13-143.jpg");

    //    TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/13_2");
    //    TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/13_2");
    //    sourceTextGUI.text = sourceTextFileContents.text;
    //    descriptionTextGUI.text = descriptionTextFileContents.text;
    //    promptTextGUI.text = "prompt";

    //    numberOfOptions = 3;

    //    //option1
    //    option1GoodOutcomeText = "good1";
    //    option1NeutralOutcomeText = "neutral1";
    //    option1BadOutcomeText = "bad1";
    //    virtueGained1 = "Hope";
    //    virtueLost1 = "Faith";

    //    //option2
    //    option2GoodOutcomeText = "good2";
    //    option2NeutralOutcomeText = "neutral2";
    //    option2BadOutcomeText = "bad2";
    //    virtueGained2 = "Courage";
    //    virtueLost2 = "Temperance";

    //    //option3
    //    option3GoodOutcomeText = "good3";
    //    option3NeutralOutcomeText = "neutral3";
    //    option3BadOutcomeText = "bad3";
    //    virtueGained3 = "Temperance";
    //    virtueLost3 = "Justice";
    //}


    //private void _13_3()
    //{
    //    PreloadNextBackgroundImage("http://www.gutenberg.org/files/8789/8789-h/images/14-147.jpg");

    //    TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/13_3");
    //    TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/13_3");
    //    sourceTextGUI.text = sourceTextFileContents.text;
    //    descriptionTextGUI.text = descriptionTextFileContents.text;
    //    promptTextGUI.text = "prompt";

    //    numberOfOptions = 3;

    //    //option1
    //    option1GoodOutcomeText = "good1";
    //    option1NeutralOutcomeText = "neutral1";
    //    option1BadOutcomeText = "bad1";
    //    virtueGained1 = "Hope";
    //    virtueLost1 = "Faith";

    //    //option2
    //    option2GoodOutcomeText = "good2";
    //    option2NeutralOutcomeText = "neutral2";
    //    option2BadOutcomeText = "bad2";
    //    virtueGained2 = "Courage";
    //    virtueLost2 = "Temperance";

    //    //option3
    //    option3GoodOutcomeText = "good3";
    //    option3NeutralOutcomeText = "neutral3";
    //    option3BadOutcomeText = "bad3";
    //    virtueGained3 = "Temperance";
    //    virtueLost3 = "Justice";
    //}


    //private void _14_1()
    //{
    //    PreloadNextBackgroundImage("http://www.gutenberg.org/files/8789/8789-h/images/15-155.jpg");

    //    TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/14_1");
    //    TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/14_1");
    //    sourceTextGUI.text = sourceTextFileContents.text;
    //    descriptionTextGUI.text = descriptionTextFileContents.text;
    //    promptTextGUI.text = "prompt";

    //    numberOfOptions = 3;

    //    //option1
    //    option1GoodOutcomeText = "good1";
    //    option1NeutralOutcomeText = "neutral1";
    //    option1BadOutcomeText = "bad1";
    //    virtueGained1 = "Hope";
    //    virtueLost1 = "Faith";

    //    //option2
    //    option2GoodOutcomeText = "good2";
    //    option2NeutralOutcomeText = "neutral2";
    //    option2BadOutcomeText = "bad2";
    //    virtueGained2 = "Courage";
    //    virtueLost2 = "Temperance";

    //    //option3
    //    option3GoodOutcomeText = "good3";
    //    option3NeutralOutcomeText = "neutral3";
    //    option3BadOutcomeText = "bad3";
    //    virtueGained3 = "Temperance";
    //    virtueLost3 = "Justice";
    //}


    //private void _15_1()
    //{
    //    PreloadNextBackgroundImage("http://www.gutenberg.org/files/8789/8789-h/images/17-167.jpg");

    //    TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/15_1");
    //    TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/15_1");
    //    sourceTextGUI.text = sourceTextFileContents.text;
    //    descriptionTextGUI.text = descriptionTextFileContents.text;
    //    promptTextGUI.text = "prompt";

    //    numberOfOptions = 3;

    //    //option1
    //    option1GoodOutcomeText = "good1";
    //    option1NeutralOutcomeText = "neutral1";
    //    option1BadOutcomeText = "bad1";
    //    virtueGained1 = "Hope";
    //    virtueLost1 = "Faith";

    //    //option2
    //    option2GoodOutcomeText = "good2";
    //    option2NeutralOutcomeText = "neutral2";
    //    option2BadOutcomeText = "bad2";
    //    virtueGained2 = "Courage";
    //    virtueLost2 = "Temperance";

    //    //option3
    //    option3GoodOutcomeText = "good3";
    //    option3NeutralOutcomeText = "neutral3";
    //    option3BadOutcomeText = "bad3";
    //    virtueGained3 = "Temperance";
    //    virtueLost3 = "Justice";
    //}


    //private void _17_1()
    //{
    //    PreloadNextBackgroundImage("http://www.gutenberg.org/files/8789/8789-h/images/17-171.jpg");

    //    TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/17_1");
    //    TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/17_1");
    //    sourceTextGUI.text = sourceTextFileContents.text;
    //    descriptionTextGUI.text = descriptionTextFileContents.text;
    //    promptTextGUI.text = "prompt";

    //    numberOfOptions = 3;

    //    //option1
    //    option1GoodOutcomeText = "good1";
    //    option1NeutralOutcomeText = "neutral1";
    //    option1BadOutcomeText = "bad1";
    //    virtueGained1 = "Hope";
    //    virtueLost1 = "Faith";

    //    //option2
    //    option2GoodOutcomeText = "good2";
    //    option2NeutralOutcomeText = "neutral2";
    //    option2BadOutcomeText = "bad2";
    //    virtueGained2 = "Courage";
    //    virtueLost2 = "Temperance";

    //    //option3
    //    option3GoodOutcomeText = "good3";
    //    option3NeutralOutcomeText = "neutral3";
    //    option3BadOutcomeText = "bad3";
    //    virtueGained3 = "Temperance";
    //    virtueLost3 = "Justice";
    //}


    //private void _17_2()
    //{
    //    PreloadNextBackgroundImage("http://www.gutenberg.org/files/8789/8789-h/images/18-177.jpg");

    //    TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/17_2");
    //    TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/17_2");
    //    sourceTextGUI.text = sourceTextFileContents.text;
    //    descriptionTextGUI.text = descriptionTextFileContents.text;
    //    promptTextGUI.text = "prompt";

    //    numberOfOptions = 3;

    //    //option1
    //    option1GoodOutcomeText = "good1";
    //    option1NeutralOutcomeText = "neutral1";
    //    option1BadOutcomeText = "bad1";
    //    virtueGained1 = "Hope";
    //    virtueLost1 = "Faith";

    //    //option2
    //    option2GoodOutcomeText = "good2";
    //    option2NeutralOutcomeText = "neutral2";
    //    option2BadOutcomeText = "bad2";
    //    virtueGained2 = "Courage";
    //    virtueLost2 = "Temperance";

    //    //option3
    //    option3GoodOutcomeText = "good3";
    //    option3NeutralOutcomeText = "neutral3";
    //    option3BadOutcomeText = "bad3";
    //    virtueGained3 = "Temperance";
    //    virtueLost3 = "Justice";
    //}


    //private void _18_1()
    //{
    //    PreloadNextBackgroundImage("http://www.gutenberg.org/files/8789/8789-h/images/18-181.jpg");

    //    TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/18_1");
    //    TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/18_1");
    //    sourceTextGUI.text = sourceTextFileContents.text;
    //    descriptionTextGUI.text = descriptionTextFileContents.text;
    //    promptTextGUI.text = "prompt";

    //    numberOfOptions = 3;

    //    //option1
    //    option1GoodOutcomeText = "good1";
    //    option1NeutralOutcomeText = "neutral1";
    //    option1BadOutcomeText = "bad1";
    //    virtueGained1 = "Hope";
    //    virtueLost1 = "Faith";

    //    //option2
    //    option2GoodOutcomeText = "good2";
    //    option2NeutralOutcomeText = "neutral2";
    //    option2BadOutcomeText = "bad2";
    //    virtueGained2 = "Courage";
    //    virtueLost2 = "Temperance";

    //    //option3
    //    option3GoodOutcomeText = "good3";
    //    option3NeutralOutcomeText = "neutral3";
    //    option3BadOutcomeText = "bad3";
    //    virtueGained3 = "Temperance";
    //    virtueLost3 = "Justice";
    //}


    //private void _18_2()
    //{
    //    PreloadNextBackgroundImage("http://www.gutenberg.org/files/8789/8789-h/images/18-183.jpg");

    //    TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/18_2");
    //    TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/18_2");
    //    sourceTextGUI.text = sourceTextFileContents.text;
    //    descriptionTextGUI.text = descriptionTextFileContents.text;
    //    promptTextGUI.text = "prompt";

    //    numberOfOptions = 3;

    //    //option1
    //    option1GoodOutcomeText = "good1";
    //    option1NeutralOutcomeText = "neutral1";
    //    option1BadOutcomeText = "bad1";
    //    virtueGained1 = "Hope";
    //    virtueLost1 = "Faith";

    //    //option2
    //    option2GoodOutcomeText = "good2";
    //    option2NeutralOutcomeText = "neutral2";
    //    option2BadOutcomeText = "bad2";
    //    virtueGained2 = "Courage";
    //    virtueLost2 = "Temperance";

    //    //option3
    //    option3GoodOutcomeText = "good3";
    //    option3NeutralOutcomeText = "neutral3";
    //    option3BadOutcomeText = "bad3";
    //    virtueGained3 = "Temperance";
    //    virtueLost3 = "Justice";
    //}


    //private void _18_3()
    //{
    //    PreloadNextBackgroundImage("http://www.gutenberg.org/files/8789/8789-h/images/19-187.jpg");

    //    TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/18_3");
    //    TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/18_3");
    //    sourceTextGUI.text = sourceTextFileContents.text;
    //    descriptionTextGUI.text = descriptionTextFileContents.text;
    //    promptTextGUI.text = "prompt";

    //    numberOfOptions = 3;

    //    //option1
    //    option1GoodOutcomeText = "good1";
    //    option1NeutralOutcomeText = "neutral1";
    //    option1BadOutcomeText = "bad1";
    //    virtueGained1 = "Hope";
    //    virtueLost1 = "Faith";

    //    //option2
    //    option2GoodOutcomeText = "good2";
    //    option2NeutralOutcomeText = "neutral2";
    //    option2BadOutcomeText = "bad2";
    //    virtueGained2 = "Courage";
    //    virtueLost2 = "Temperance";

    //    //option3
    //    option3GoodOutcomeText = "good3";
    //    option3NeutralOutcomeText = "neutral3";
    //    option3BadOutcomeText = "bad3";
    //    virtueGained3 = "Temperance";
    //    virtueLost3 = "Justice";
    //}


    //private void _19_1()
    //{
    //    PreloadNextBackgroundImage("http://www.gutenberg.org/files/8789/8789-h/images/21-201.jpg");

    //    TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/19_1");
    //    TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/19_1");
    //    sourceTextGUI.text = sourceTextFileContents.text;
    //    descriptionTextGUI.text = descriptionTextFileContents.text;
    //    promptTextGUI.text = "prompt";

    //    numberOfOptions = 3;

    //    //option1
    //    option1GoodOutcomeText = "good1";
    //    option1NeutralOutcomeText = "neutral1";
    //    option1BadOutcomeText = "bad1";
    //    virtueGained1 = "Hope";
    //    virtueLost1 = "Faith";

    //    //option2
    //    option2GoodOutcomeText = "good2";
    //    option2NeutralOutcomeText = "neutral2";
    //    option2BadOutcomeText = "bad2";
    //    virtueGained2 = "Courage";
    //    virtueLost2 = "Temperance";

    //    //option3
    //    option3GoodOutcomeText = "good3";
    //    option3NeutralOutcomeText = "neutral3";
    //    option3BadOutcomeText = "bad3";
    //    virtueGained3 = "Temperance";
    //    virtueLost3 = "Justice";
    //}


    //private void _20_1()
    //{
    //    PreloadNextBackgroundImage("http://www.gutenberg.org/files/8789/8789-h/images/21-201.jpg");

    //    TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/20_1");
    //    TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/20_1");
    //    sourceTextGUI.text = sourceTextFileContents.text;
    //    descriptionTextGUI.text = descriptionTextFileContents.text;
    //    promptTextGUI.text = "prompt";

    //    numberOfOptions = 3;

    //    //option1
    //    option1GoodOutcomeText = "good1";
    //    option1NeutralOutcomeText = "neutral1";
    //    option1BadOutcomeText = "bad1";
    //    virtueGained1 = "Hope";
    //    virtueLost1 = "Faith";

    //    //option2
    //    option2GoodOutcomeText = "good2";
    //    option2NeutralOutcomeText = "neutral2";
    //    option2BadOutcomeText = "bad2";
    //    virtueGained2 = "Courage";
    //    virtueLost2 = "Temperance";

    //    //option3
    //    option3GoodOutcomeText = "good3";
    //    option3NeutralOutcomeText = "neutral3";
    //    option3BadOutcomeText = "bad3";
    //    virtueGained3 = "Temperance";
    //    virtueLost3 = "Justice";
    //}


    //private void _21_1()
    //{
    //    PreloadNextBackgroundImage("http://www.gutenberg.org/files/8789/8789-h/images/21-205.jpg");

    //    TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/21_1");
    //    TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/21_1");
    //    sourceTextGUI.text = sourceTextFileContents.text;
    //    descriptionTextGUI.text = descriptionTextFileContents.text;
    //    promptTextGUI.text = "prompt";

    //    numberOfOptions = 3;

    //    //option1
    //    option1GoodOutcomeText = "good1";
    //    option1NeutralOutcomeText = "neutral1";
    //    option1BadOutcomeText = "bad1";
    //    virtueGained1 = "Hope";
    //    virtueLost1 = "Faith";

    //    //option2
    //    option2GoodOutcomeText = "good2";
    //    option2NeutralOutcomeText = "neutral2";
    //    option2BadOutcomeText = "bad2";
    //    virtueGained2 = "Courage";
    //    virtueLost2 = "Temperance";

    //    //option3
    //    option3GoodOutcomeText = "good3";
    //    option3NeutralOutcomeText = "neutral3";
    //    option3BadOutcomeText = "bad3";
    //    virtueGained3 = "Temperance";
    //    virtueLost3 = "Justice";
    //}


    //private void _21_2()
    //{
    //    PreloadNextBackgroundImage("http://www.gutenberg.org/files/8789/8789-h/images/22-213.jpg");

    //    TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/21_2");
    //    TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/21_2");
    //    sourceTextGUI.text = sourceTextFileContents.text;
    //    descriptionTextGUI.text = descriptionTextFileContents.text;
    //    promptTextGUI.text = "prompt";

    //    numberOfOptions = 3;

    //    //option1
    //    option1GoodOutcomeText = "good1";
    //    option1NeutralOutcomeText = "neutral1";
    //    option1BadOutcomeText = "bad1";
    //    virtueGained1 = "Hope";
    //    virtueLost1 = "Faith";

    //    //option2
    //    option2GoodOutcomeText = "good2";
    //    option2NeutralOutcomeText = "neutral2";
    //    option2BadOutcomeText = "bad2";
    //    virtueGained2 = "Courage";
    //    virtueLost2 = "Temperance";

    //    //option3
    //    option3GoodOutcomeText = "good3";
    //    option3NeutralOutcomeText = "neutral3";
    //    option3BadOutcomeText = "bad3";
    //    virtueGained3 = "Temperance";
    //    virtueLost3 = "Justice";
    //}


    //private void _22_1()
    //{
    //    PreloadNextBackgroundImage("http://www.gutenberg.org/files/8789/8789-h/images/22-215.jpg");

    //    TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/22_1");
    //    TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/22_1");
    //    sourceTextGUI.text = sourceTextFileContents.text;
    //    descriptionTextGUI.text = descriptionTextFileContents.text;
    //    promptTextGUI.text = "prompt";

    //    numberOfOptions = 3;

    //    //option1
    //    option1GoodOutcomeText = "good1";
    //    option1NeutralOutcomeText = "neutral1";
    //    option1BadOutcomeText = "bad1";
    //    virtueGained1 = "Hope";
    //    virtueLost1 = "Faith";

    //    //option2
    //    option2GoodOutcomeText = "good2";
    //    option2NeutralOutcomeText = "neutral2";
    //    option2BadOutcomeText = "bad2";
    //    virtueGained2 = "Courage";
    //    virtueLost2 = "Temperance";

    //    //option3
    //    option3GoodOutcomeText = "good3";
    //    option3NeutralOutcomeText = "neutral3";
    //    option3BadOutcomeText = "bad3";
    //    virtueGained3 = "Temperance";
    //    virtueLost3 = "Justice";
    //}


    //private void _22_2()
    //{
    //    PreloadNextBackgroundImage("http://www.gutenberg.org/files/8789/8789-h/images/23-219.jpg");

    //    TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/22_2");
    //    TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/22_2");
    //    sourceTextGUI.text = sourceTextFileContents.text;
    //    descriptionTextGUI.text = descriptionTextFileContents.text;
    //    promptTextGUI.text = "prompt";

    //    numberOfOptions = 3;

    //    //option1
    //    option1GoodOutcomeText = "good1";
    //    option1NeutralOutcomeText = "neutral1";
    //    option1BadOutcomeText = "bad1";
    //    virtueGained1 = "Hope";
    //    virtueLost1 = "Faith";

    //    //option2
    //    option2GoodOutcomeText = "good2";
    //    option2NeutralOutcomeText = "neutral2";
    //    option2BadOutcomeText = "bad2";
    //    virtueGained2 = "Courage";
    //    virtueLost2 = "Temperance";

    //    //option3
    //    option3GoodOutcomeText = "good3";
    //    option3NeutralOutcomeText = "neutral3";
    //    option3BadOutcomeText = "bad3";
    //    virtueGained3 = "Temperance";
    //    virtueLost3 = "Justice";
    //}


    //private void _23_1()
    //{
    //    PreloadNextBackgroundImage("http://www.gutenberg.org/files/8789/8789-h/images/23-223.jpg");

    //    TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/23_1");
    //    TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/23_1");
    //    sourceTextGUI.text = sourceTextFileContents.text;
    //    descriptionTextGUI.text = descriptionTextFileContents.text;
    //    promptTextGUI.text = "prompt";

    //    numberOfOptions = 3;

    //    //option1
    //    option1GoodOutcomeText = "good1";
    //    option1NeutralOutcomeText = "neutral1";
    //    option1BadOutcomeText = "bad1";
    //    virtueGained1 = "Hope";
    //    virtueLost1 = "Faith";

    //    //option2
    //    option2GoodOutcomeText = "good2";
    //    option2NeutralOutcomeText = "neutral2";
    //    option2BadOutcomeText = "bad2";
    //    virtueGained2 = "Courage";
    //    virtueLost2 = "Temperance";

    //    //option3
    //    option3GoodOutcomeText = "good3";
    //    option3NeutralOutcomeText = "neutral3";
    //    option3BadOutcomeText = "bad3";
    //    virtueGained3 = "Temperance";
    //    virtueLost3 = "Justice";
    //}


    //private void _23_2()
    //{
    //    PreloadNextBackgroundImage("http://www.gutenberg.org/files/8789/8789-h/images/23-225.jpg");

    //    TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/23_2");
    //    TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/23_2");
    //    sourceTextGUI.text = sourceTextFileContents.text;
    //    descriptionTextGUI.text = descriptionTextFileContents.text;
    //    promptTextGUI.text = "prompt";

    //    numberOfOptions = 3;

    //    //option1
    //    option1GoodOutcomeText = "good1";
    //    option1NeutralOutcomeText = "neutral1";
    //    option1BadOutcomeText = "bad1";
    //    virtueGained1 = "Hope";
    //    virtueLost1 = "Faith";

    //    //option2
    //    option2GoodOutcomeText = "good2";
    //    option2NeutralOutcomeText = "neutral2";
    //    option2BadOutcomeText = "bad2";
    //    virtueGained2 = "Courage";
    //    virtueLost2 = "Temperance";

    //    //option3
    //    option3GoodOutcomeText = "good3";
    //    option3NeutralOutcomeText = "neutral3";
    //    option3BadOutcomeText = "bad3";
    //    virtueGained3 = "Temperance";
    //    virtueLost3 = "Justice";
    //}


    //private void _23_3()
    //{
    //    PreloadNextBackgroundImage("http://www.gutenberg.org/files/8789/8789-h/images/24-233.jpg");

    //    TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/23_3");
    //    TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/23_3");
    //    sourceTextGUI.text = sourceTextFileContents.text;
    //    descriptionTextGUI.text = descriptionTextFileContents.text;
    //    promptTextGUI.text = "prompt";

    //    numberOfOptions = 3;

    //    //option1
    //    option1GoodOutcomeText = "good1";
    //    option1NeutralOutcomeText = "neutral1";
    //    option1BadOutcomeText = "bad1";
    //    virtueGained1 = "Hope";
    //    virtueLost1 = "Faith";

    //    //option2
    //    option2GoodOutcomeText = "good2";
    //    option2NeutralOutcomeText = "neutral2";
    //    option2BadOutcomeText = "bad2";
    //    virtueGained2 = "Courage";
    //    virtueLost2 = "Temperance";

    //    //option3
    //    option3GoodOutcomeText = "good3";
    //    option3NeutralOutcomeText = "neutral3";
    //    option3BadOutcomeText = "bad3";
    //    virtueGained3 = "Temperance";
    //    virtueLost3 = "Justice";
    //}


    //private void _24_1()
    //{
    //    PreloadNextBackgroundImage("http://www.gutenberg.org/files/8789/8789-h/images/25-239.jpg");

    //    TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/24_1");
    //    TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/24_1");
    //    sourceTextGUI.text = sourceTextFileContents.text;
    //    descriptionTextGUI.text = descriptionTextFileContents.text;
    //    promptTextGUI.text = "prompt";

    //    numberOfOptions = 3;

    //    //option1
    //    option1GoodOutcomeText = "good1";
    //    option1NeutralOutcomeText = "neutral1";
    //    option1BadOutcomeText = "bad1";
    //    virtueGained1 = "Hope";
    //    virtueLost1 = "Faith";

    //    //option2
    //    option2GoodOutcomeText = "good2";
    //    option2NeutralOutcomeText = "neutral2";
    //    option2BadOutcomeText = "bad2";
    //    virtueGained2 = "Courage";
    //    virtueLost2 = "Temperance";

    //    //option3
    //    option3GoodOutcomeText = "good3";
    //    option3NeutralOutcomeText = "neutral3";
    //    option3BadOutcomeText = "bad3";
    //    virtueGained3 = "Temperance";
    //    virtueLost3 = "Justice";
    //}


    //private void _25_1()
    //{
    //    PreloadNextBackgroundImage("http://www.gutenberg.org/files/8789/8789-h/images/26-245.jpg");

    //    TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/25_1");
    //    TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/25_1");
    //    sourceTextGUI.text = sourceTextFileContents.text;
    //    descriptionTextGUI.text = descriptionTextFileContents.text;
    //    promptTextGUI.text = "prompt";

    //    numberOfOptions = 3;

    //    //option1
    //    option1GoodOutcomeText = "good1";
    //    option1NeutralOutcomeText = "neutral1";
    //    option1BadOutcomeText = "bad1";
    //    virtueGained1 = "Hope";
    //    virtueLost1 = "Faith";

    //    //option2
    //    option2GoodOutcomeText = "good2";
    //    option2NeutralOutcomeText = "neutral2";
    //    option2BadOutcomeText = "bad2";
    //    virtueGained2 = "Courage";
    //    virtueLost2 = "Temperance";

    //    //option3
    //    option3GoodOutcomeText = "good3";
    //    option3NeutralOutcomeText = "neutral3";
    //    option3BadOutcomeText = "bad3";
    //    virtueGained3 = "Temperance";
    //    virtueLost3 = "Justice";
    //}


    //private void _26_1()
    //{
    //    PreloadNextBackgroundImage("http://www.gutenberg.org/files/8789/8789-h/images/28-259.jpg");

    //    TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/26_1");
    //    TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/26_1");
    //    sourceTextGUI.text = sourceTextFileContents.text;
    //    descriptionTextGUI.text = descriptionTextFileContents.text;
    //    promptTextGUI.text = "prompt";

    //    numberOfOptions = 3;

    //    //option1
    //    option1GoodOutcomeText = "good1";
    //    option1NeutralOutcomeText = "neutral1";
    //    option1BadOutcomeText = "bad1";
    //    virtueGained1 = "Hope";
    //    virtueLost1 = "Faith";

    //    //option2
    //    option2GoodOutcomeText = "good2";
    //    option2NeutralOutcomeText = "neutral2";
    //    option2BadOutcomeText = "bad2";
    //    virtueGained2 = "Courage";
    //    virtueLost2 = "Temperance";

    //    //option3
    //    option3GoodOutcomeText = "good3";
    //    option3NeutralOutcomeText = "neutral3";
    //    option3BadOutcomeText = "bad3";
    //    virtueGained3 = "Temperance";
    //    virtueLost3 = "Justice";
    //}


    //private void _28_1()
    //{
    //    PreloadNextBackgroundImage("http://www.gutenberg.org/files/8789/8789-h/images/28-261.jpg");

    //    TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/28_1");
    //    TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/28_1");
    //    sourceTextGUI.text = sourceTextFileContents.text;
    //    descriptionTextGUI.text = descriptionTextFileContents.text;
    //    promptTextGUI.text = "prompt";

    //    numberOfOptions = 3;

    //    //option1
    //    option1GoodOutcomeText = "good1";
    //    option1NeutralOutcomeText = "neutral1";
    //    option1BadOutcomeText = "bad1";
    //    virtueGained1 = "Hope";
    //    virtueLost1 = "Faith";

    //    //option2
    //    option2GoodOutcomeText = "good2";
    //    option2NeutralOutcomeText = "neutral2";
    //    option2BadOutcomeText = "bad2";
    //    virtueGained2 = "Courage";
    //    virtueLost2 = "Temperance";

    //    //option3
    //    option3GoodOutcomeText = "good3";
    //    option3NeutralOutcomeText = "neutral3";
    //    option3BadOutcomeText = "bad3";
    //    virtueGained3 = "Temperance";
    //    virtueLost3 = "Justice";
    //}


    //private void _28_2()
    //{
    //    PreloadNextBackgroundImage("http://www.gutenberg.org/files/8789/8789-h/images/28-265.jpg");

    //    TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/28_2");
    //    TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/28_2");
    //    sourceTextGUI.text = sourceTextFileContents.text;
    //    descriptionTextGUI.text = descriptionTextFileContents.text;
    //    promptTextGUI.text = "prompt";

    //    numberOfOptions = 3;

    //    //option1
    //    option1GoodOutcomeText = "good1";
    //    option1NeutralOutcomeText = "neutral1";
    //    option1BadOutcomeText = "bad1";
    //    virtueGained1 = "Hope";
    //    virtueLost1 = "Faith";

    //    //option2
    //    option2GoodOutcomeText = "good2";
    //    option2NeutralOutcomeText = "neutral2";
    //    option2BadOutcomeText = "bad2";
    //    virtueGained2 = "Courage";
    //    virtueLost2 = "Temperance";

    //    //option3
    //    option3GoodOutcomeText = "good3";
    //    option3NeutralOutcomeText = "neutral3";
    //    option3BadOutcomeText = "bad3";
    //    virtueGained3 = "Temperance";
    //    virtueLost3 = "Justice";
    //}


    //private void _28_3()
    //{
    //    PreloadNextBackgroundImage("http://www.gutenberg.org/files/8789/8789-h/images/29-269.jpg");

    //    TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/28_3");
    //    TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/28_3");
    //    sourceTextGUI.text = sourceTextFileContents.text;
    //    descriptionTextGUI.text = descriptionTextFileContents.text;
    //    promptTextGUI.text = "prompt";

    //    numberOfOptions = 3;

    //    //option1
    //    option1GoodOutcomeText = "good1";
    //    option1NeutralOutcomeText = "neutral1";
    //    option1BadOutcomeText = "bad1";
    //    virtueGained1 = "Hope";
    //    virtueLost1 = "Faith";

    //    //option2
    //    option2GoodOutcomeText = "good2";
    //    option2NeutralOutcomeText = "neutral2";
    //    option2BadOutcomeText = "bad2";
    //    virtueGained2 = "Courage";
    //    virtueLost2 = "Temperance";

    //    //option3
    //    option3GoodOutcomeText = "good3";
    //    option3NeutralOutcomeText = "neutral3";
    //    option3BadOutcomeText = "bad3";
    //    virtueGained3 = "Temperance";
    //    virtueLost3 = "Justice";
    //}


    //private void _29_1()
    //{
    //    PreloadNextBackgroundImage("http://www.gutenberg.org/files/8789/8789-h/images/29-273.jpg");

    //    TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/29_1");
    //    TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/29_1");
    //    sourceTextGUI.text = sourceTextFileContents.text;
    //    descriptionTextGUI.text = descriptionTextFileContents.text;
    //    promptTextGUI.text = "prompt";

    //    numberOfOptions = 3;

    //    //option1
    //    option1GoodOutcomeText = "good1";
    //    option1NeutralOutcomeText = "neutral1";
    //    option1BadOutcomeText = "bad1";
    //    virtueGained1 = "Hope";
    //    virtueLost1 = "Faith";

    //    //option2
    //    option2GoodOutcomeText = "good2";
    //    option2NeutralOutcomeText = "neutral2";
    //    option2BadOutcomeText = "bad2";
    //    virtueGained2 = "Courage";
    //    virtueLost2 = "Temperance";

    //    //option3
    //    option3GoodOutcomeText = "good3";
    //    option3NeutralOutcomeText = "neutral3";
    //    option3BadOutcomeText = "bad3";
    //    virtueGained3 = "Temperance";
    //    virtueLost3 = "Justice";
    //}


    //private void _29_2()
    //{
    //    PreloadNextBackgroundImage("http://www.gutenberg.org/files/8789/8789-h/images/29-275.jpg");

    //    TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/29_2");
    //    TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/29_2");
    //    sourceTextGUI.text = sourceTextFileContents.text;
    //    descriptionTextGUI.text = descriptionTextFileContents.text;
    //    promptTextGUI.text = "prompt";

    //    numberOfOptions = 3;

    //    //option1
    //    option1GoodOutcomeText = "good1";
    //    option1NeutralOutcomeText = "neutral1";
    //    option1BadOutcomeText = "bad1";
    //    virtueGained1 = "Hope";
    //    virtueLost1 = "Faith";

    //    //option2
    //    option2GoodOutcomeText = "good2";
    //    option2NeutralOutcomeText = "neutral2";
    //    option2BadOutcomeText = "bad2";
    //    virtueGained2 = "Courage";
    //    virtueLost2 = "Temperance";

    //    //option3
    //    option3GoodOutcomeText = "good3";
    //    option3NeutralOutcomeText = "neutral3";
    //    option3BadOutcomeText = "bad3";
    //    virtueGained3 = "Temperance";
    //    virtueLost3 = "Justice";
    //}


    //private void _29_3()
    //{
    //    PreloadNextBackgroundImage("http://www.gutenberg.org/files/8789/8789-h/images/30-281.jpg");

    //    TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/29_3");
    //    TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/29_3");
    //    sourceTextGUI.text = sourceTextFileContents.text;
    //    descriptionTextGUI.text = descriptionTextFileContents.text;
    //    promptTextGUI.text = "prompt";

    //    numberOfOptions = 3;

    //    //option1
    //    option1GoodOutcomeText = "good1";
    //    option1NeutralOutcomeText = "neutral1";
    //    option1BadOutcomeText = "bad1";
    //    virtueGained1 = "Hope";
    //    virtueLost1 = "Faith";

    //    //option2
    //    option2GoodOutcomeText = "good2";
    //    option2NeutralOutcomeText = "neutral2";
    //    option2BadOutcomeText = "bad2";
    //    virtueGained2 = "Courage";
    //    virtueLost2 = "Temperance";

    //    //option3
    //    option3GoodOutcomeText = "good3";
    //    option3NeutralOutcomeText = "neutral3";
    //    option3BadOutcomeText = "bad3";
    //    virtueGained3 = "Temperance";
    //    virtueLost3 = "Justice";
    //}


    //private void _30_1()
    //{
    //    PreloadNextBackgroundImage("http://www.gutenberg.org/files/8789/8789-h/images/30-283.jpg");

    //    TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/30_1");
    //    TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/30_1");
    //    sourceTextGUI.text = sourceTextFileContents.text;
    //    descriptionTextGUI.text = descriptionTextFileContents.text;
    //    promptTextGUI.text = "prompt";

    //    numberOfOptions = 3;

    //    //option1
    //    option1GoodOutcomeText = "good1";
    //    option1NeutralOutcomeText = "neutral1";
    //    option1BadOutcomeText = "bad1";
    //    virtueGained1 = "Hope";
    //    virtueLost1 = "Faith";

    //    //option2
    //    option2GoodOutcomeText = "good2";
    //    option2NeutralOutcomeText = "neutral2";
    //    option2BadOutcomeText = "bad2";
    //    virtueGained2 = "Courage";
    //    virtueLost2 = "Temperance";

    //    //option3
    //    option3GoodOutcomeText = "good3";
    //    option3NeutralOutcomeText = "neutral3";
    //    option3BadOutcomeText = "bad3";
    //    virtueGained3 = "Temperance";
    //    virtueLost3 = "Justice";
    //}


    //private void _30_2()
    //{
    //    PreloadNextBackgroundImage("http://www.gutenberg.org/files/8789/8789-h/images/31-291.jpg");

    //    TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/30_2");
    //    TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/30_2");
    //    sourceTextGUI.text = sourceTextFileContents.text;
    //    descriptionTextGUI.text = descriptionTextFileContents.text;
    //    promptTextGUI.text = "prompt";

    //    numberOfOptions = 3;

    //    //option1
    //    option1GoodOutcomeText = "good1";
    //    option1NeutralOutcomeText = "neutral1";
    //    option1BadOutcomeText = "bad1";
    //    virtueGained1 = "Hope";
    //    virtueLost1 = "Faith";

    //    //option2
    //    option2GoodOutcomeText = "good2";
    //    option2NeutralOutcomeText = "neutral2";
    //    option2BadOutcomeText = "bad2";
    //    virtueGained2 = "Courage";
    //    virtueLost2 = "Temperance";

    //    //option3
    //    option3GoodOutcomeText = "good3";
    //    option3NeutralOutcomeText = "neutral3";
    //    option3BadOutcomeText = "bad3";
    //    virtueGained3 = "Temperance";
    //    virtueLost3 = "Justice";
    //}


    //private void _31_1()
    //{
    //    PreloadNextBackgroundImage("http://www.gutenberg.org/files/8789/8789-h/images/31-293.jpg");

    //    TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/31_1");
    //    TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/31_1");
    //    sourceTextGUI.text = sourceTextFileContents.text;
    //    descriptionTextGUI.text = descriptionTextFileContents.text;
    //    promptTextGUI.text = "prompt";

    //    numberOfOptions = 3;

    //    //option1
    //    option1GoodOutcomeText = "good1";
    //    option1NeutralOutcomeText = "neutral1";
    //    option1BadOutcomeText = "bad1";
    //    virtueGained1 = "Hope";
    //    virtueLost1 = "Faith";

    //    //option2
    //    option2GoodOutcomeText = "good2";
    //    option2NeutralOutcomeText = "neutral2";
    //    option2BadOutcomeText = "bad2";
    //    virtueGained2 = "Courage";
    //    virtueLost2 = "Temperance";

    //    //option3
    //    option3GoodOutcomeText = "good3";
    //    option3NeutralOutcomeText = "neutral3";
    //    option3BadOutcomeText = "bad3";
    //    virtueGained3 = "Temperance";
    //    virtueLost3 = "Justice";
    //}


    //private void _31_2()
    //{
    //    PreloadNextBackgroundImage("http://www.gutenberg.org/files/8789/8789-h/images/31-297.jpg");

    //    TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/31_2");
    //    TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/31_2");
    //    sourceTextGUI.text = sourceTextFileContents.text;
    //    descriptionTextGUI.text = descriptionTextFileContents.text;
    //    promptTextGUI.text = "prompt";

    //    numberOfOptions = 3;

    //    //option1
    //    option1GoodOutcomeText = "good1";
    //    option1NeutralOutcomeText = "neutral1";
    //    option1BadOutcomeText = "bad1";
    //    virtueGained1 = "Hope";
    //    virtueLost1 = "Faith";

    //    //option2
    //    option2GoodOutcomeText = "good2";
    //    option2NeutralOutcomeText = "neutral2";
    //    option2BadOutcomeText = "bad2";
    //    virtueGained2 = "Courage";
    //    virtueLost2 = "Temperance";

    //    //option3
    //    option3GoodOutcomeText = "good3";
    //    option3NeutralOutcomeText = "neutral3";
    //    option3BadOutcomeText = "bad3";
    //    virtueGained3 = "Temperance";
    //    virtueLost3 = "Justice";
    //}


    //private void _31_3()
    //{
    //    PreloadNextBackgroundImage("http://www.gutenberg.org/files/8789/8789-h/images/32-301.jpg");

    //    TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/31_3");
    //    TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/31_3");
    //    sourceTextGUI.text = sourceTextFileContents.text;
    //    descriptionTextGUI.text = descriptionTextFileContents.text;
    //    promptTextGUI.text = "prompt";

    //    numberOfOptions = 3;

    //    //option1
    //    option1GoodOutcomeText = "good1";
    //    option1NeutralOutcomeText = "neutral1";
    //    option1BadOutcomeText = "bad1";
    //    virtueGained1 = "Hope";
    //    virtueLost1 = "Faith";

    //    //option2
    //    option2GoodOutcomeText = "good2";
    //    option2NeutralOutcomeText = "neutral2";
    //    option2BadOutcomeText = "bad2";
    //    virtueGained2 = "Courage";
    //    virtueLost2 = "Temperance";

    //    //option3
    //    option3GoodOutcomeText = "good3";
    //    option3NeutralOutcomeText = "neutral3";
    //    option3BadOutcomeText = "bad3";
    //    virtueGained3 = "Temperance";
    //    virtueLost3 = "Justice";
    //}


    //private void _32_1()
    //{
    //    PreloadNextBackgroundImage("http://www.gutenberg.org/files/8789/8789-h/images/32-305.jpg");

    //    TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/32_1");
    //    TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/32_1");
    //    sourceTextGUI.text = sourceTextFileContents.text;
    //    descriptionTextGUI.text = descriptionTextFileContents.text;
    //    promptTextGUI.text = "prompt";

    //    numberOfOptions = 3;

    //    //option1
    //    option1GoodOutcomeText = "good1";
    //    option1NeutralOutcomeText = "neutral1";
    //    option1BadOutcomeText = "bad1";
    //    virtueGained1 = "Hope";
    //    virtueLost1 = "Faith";

    //    //option2
    //    option2GoodOutcomeText = "good2";
    //    option2NeutralOutcomeText = "neutral2";
    //    option2BadOutcomeText = "bad2";
    //    virtueGained2 = "Courage";
    //    virtueLost2 = "Temperance";

    //    //option3
    //    option3GoodOutcomeText = "good3";
    //    option3NeutralOutcomeText = "neutral3";
    //    option3BadOutcomeText = "bad3";
    //    virtueGained3 = "Temperance";
    //    virtueLost3 = "Justice";
    //}


    //private void _32_2()
    //{
    //    PreloadNextBackgroundImage("http://www.gutenberg.org/files/8789/8789-h/images/32-309.jpg");

    //    TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/32_2");
    //    TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/32_2");
    //    sourceTextGUI.text = sourceTextFileContents.text;
    //    descriptionTextGUI.text = descriptionTextFileContents.text;
    //    promptTextGUI.text = "prompt";

    //    numberOfOptions = 3;

    //    //option1
    //    option1GoodOutcomeText = "good1";
    //    option1NeutralOutcomeText = "neutral1";
    //    option1BadOutcomeText = "bad1";
    //    virtueGained1 = "Hope";
    //    virtueLost1 = "Faith";

    //    //option2
    //    option2GoodOutcomeText = "good2";
    //    option2NeutralOutcomeText = "neutral2";
    //    option2BadOutcomeText = "bad2";
    //    virtueGained2 = "Courage";
    //    virtueLost2 = "Temperance";

    //    //option3
    //    option3GoodOutcomeText = "good3";
    //    option3NeutralOutcomeText = "neutral3";
    //    option3BadOutcomeText = "bad3";
    //    virtueGained3 = "Temperance";
    //    virtueLost3 = "Justice";
    //}


    //private void _32_3()
    //{
    //    PreloadNextBackgroundImage("http://www.gutenberg.org/files/8789/8789-h/images/33-313.jpg");

    //    TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/32_3");
    //    TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/32_3");
    //    sourceTextGUI.text = sourceTextFileContents.text;
    //    descriptionTextGUI.text = descriptionTextFileContents.text;
    //    promptTextGUI.text = "prompt";

    //    numberOfOptions = 3;

    //    //option1
    //    option1GoodOutcomeText = "good1";
    //    option1NeutralOutcomeText = "neutral1";
    //    option1BadOutcomeText = "bad1";
    //    virtueGained1 = "Hope";
    //    virtueLost1 = "Faith";

    //    //option2
    //    option2GoodOutcomeText = "good2";
    //    option2NeutralOutcomeText = "neutral2";
    //    option2BadOutcomeText = "bad2";
    //    virtueGained2 = "Courage";
    //    virtueLost2 = "Temperance";

    //    //option3
    //    option3GoodOutcomeText = "good3";
    //    option3NeutralOutcomeText = "neutral3";
    //    option3BadOutcomeText = "bad3";
    //    virtueGained3 = "Temperance";
    //    virtueLost3 = "Justice";
    //}


    //private void _33_1()
    //{
    //    PreloadNextBackgroundImage("http://www.gutenberg.org/files/8789/8789-h/images/33-315.jpg");

    //    TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/33_1");
    //    TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/33_1");
    //    sourceTextGUI.text = sourceTextFileContents.text;
    //    descriptionTextGUI.text = descriptionTextFileContents.text;
    //    promptTextGUI.text = "prompt";

    //    numberOfOptions = 3;

    //    //option1
    //    option1GoodOutcomeText = "good1";
    //    option1NeutralOutcomeText = "neutral1";
    //    option1BadOutcomeText = "bad1";
    //    virtueGained1 = "Hope";
    //    virtueLost1 = "Faith";

    //    //option2
    //    option2GoodOutcomeText = "good2";
    //    option2NeutralOutcomeText = "neutral2";
    //    option2BadOutcomeText = "bad2";
    //    virtueGained2 = "Courage";
    //    virtueLost2 = "Temperance";

    //    //option3
    //    option3GoodOutcomeText = "good3";
    //    option3NeutralOutcomeText = "neutral3";
    //    option3BadOutcomeText = "bad3";
    //    virtueGained3 = "Temperance";
    //    virtueLost3 = "Justice";
    //}


    //private void _33_2()
    //{
    //    PreloadNextBackgroundImage("http://www.gutenberg.org/files/8789/8789-h/images/33-317.jpg");

    //    TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/33_2");
    //    TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/33_2");
    //    sourceTextGUI.text = sourceTextFileContents.text;
    //    descriptionTextGUI.text = descriptionTextFileContents.text;
    //    promptTextGUI.text = "prompt";

    //    numberOfOptions = 3;

    //    //option1
    //    option1GoodOutcomeText = "good1";
    //    option1NeutralOutcomeText = "neutral1";
    //    option1BadOutcomeText = "bad1";
    //    virtueGained1 = "Hope";
    //    virtueLost1 = "Faith";

    //    //option2
    //    option2GoodOutcomeText = "good2";
    //    option2NeutralOutcomeText = "neutral2";
    //    option2BadOutcomeText = "bad2";
    //    virtueGained2 = "Courage";
    //    virtueLost2 = "Temperance";

    //    //option3
    //    option3GoodOutcomeText = "good3";
    //    option3NeutralOutcomeText = "neutral3";
    //    option3BadOutcomeText = "bad3";
    //    virtueGained3 = "Temperance";
    //    virtueLost3 = "Justice";
    //}


    //private void _33_3()
    //{
    //    PreloadNextBackgroundImage("http://www.gutenberg.org/files/8789/8789-h/images/34-323.jpg");

    //    TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/33_3");
    //    TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/33_3");
    //    sourceTextGUI.text = sourceTextFileContents.text;
    //    descriptionTextGUI.text = descriptionTextFileContents.text;
    //    promptTextGUI.text = "prompt";

    //    numberOfOptions = 3;

    //    //option1
    //    option1GoodOutcomeText = "good1";
    //    option1NeutralOutcomeText = "neutral1";
    //    option1BadOutcomeText = "bad1";
    //    virtueGained1 = "Hope";
    //    virtueLost1 = "Faith";

    //    //option2
    //    option2GoodOutcomeText = "good2";
    //    option2NeutralOutcomeText = "neutral2";
    //    option2BadOutcomeText = "bad2";
    //    virtueGained2 = "Courage";
    //    virtueLost2 = "Temperance";

    //    //option3
    //    option3GoodOutcomeText = "good3";
    //    option3NeutralOutcomeText = "neutral3";
    //    option3BadOutcomeText = "bad3";
    //    virtueGained3 = "Temperance";
    //    virtueLost3 = "Justice";
    //}


    //private void _34_1()
    //{
    //    PreloadNextBackgroundImage("http://www.gutenberg.org/files/8789/8789-h/images/34-329.jpg");

    //    TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/34_1");
    //    TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/34_1");
    //    sourceTextGUI.text = sourceTextFileContents.text;
    //    descriptionTextGUI.text = descriptionTextFileContents.text;
    //    promptTextGUI.text = "prompt";

    //    numberOfOptions = 3;

    //    //option1
    //    option1GoodOutcomeText = "good1";
    //    option1NeutralOutcomeText = "neutral1";
    //    option1BadOutcomeText = "bad1";
    //    virtueGained1 = "Hope";
    //    virtueLost1 = "Faith";

    //    //option2
    //    option2GoodOutcomeText = "good2";
    //    option2NeutralOutcomeText = "neutral2";
    //    option2BadOutcomeText = "bad2";
    //    virtueGained2 = "Courage";
    //    virtueLost2 = "Temperance";

    //    //option3
    //    option3GoodOutcomeText = "good3";
    //    option3NeutralOutcomeText = "neutral3";
    //    option3BadOutcomeText = "bad3";
    //    virtueGained3 = "Temperance";
    //    virtueLost3 = "Justice";
    //}


    //private void _34_2()
    //{
    //    PreloadNextBackgroundImage("http://www.gutenberg.org/files/8789/8789-h/images/34-331.jpg");

    //    TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/34_2");
    //    TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/34_2");
    //    sourceTextGUI.text = sourceTextFileContents.text;
    //    descriptionTextGUI.text = descriptionTextFileContents.text;
    //    promptTextGUI.text = "prompt";

    //    numberOfOptions = 3;

    //    //option1
    //    option1GoodOutcomeText = "good1";
    //    option1NeutralOutcomeText = "neutral1";
    //    option1BadOutcomeText = "bad1";
    //    virtueGained1 = "Hope";
    //    virtueLost1 = "Faith";

    //    //option2
    //    option2GoodOutcomeText = "good2";
    //    option2NeutralOutcomeText = "neutral2";
    //    option2BadOutcomeText = "bad2";
    //    virtueGained2 = "Courage";
    //    virtueLost2 = "Temperance";

    //    //option3
    //    option3GoodOutcomeText = "good3";
    //    option3NeutralOutcomeText = "neutral3";
    //    option3BadOutcomeText = "bad3";
    //    virtueGained3 = "Temperance";
    //    virtueLost3 = "Justice";
    //}


    //private void _34_3()
    //{
    //    //PreloadNextBackgroundImage("");

    //    TextAsset sourceTextFileContents = Resources.Load<TextAsset>("SourceMaterial/SourceText/34_3");
    //    TextAsset descriptionTextFileContents = Resources.Load<TextAsset>("SourceMaterial/DescriptionText/34_3");
    //    sourceTextGUI.text = sourceTextFileContents.text;
    //    descriptionTextGUI.text = descriptionTextFileContents.text;
    //    promptTextGUI.text = "prompt";

    //    numberOfOptions = 3;

    //    //option1
    //    option1GoodOutcomeText = "good1";
    //    option1NeutralOutcomeText = "neutral1";
    //    option1BadOutcomeText = "bad1";
    //    virtueGained1 = "Hope";
    //    virtueLost1 = "Faith";

    //    //option2
    //    option2GoodOutcomeText = "good2";
    //    option2NeutralOutcomeText = "neutral2";
    //    option2BadOutcomeText = "bad2";
    //    virtueGained2 = "Courage";
    //    virtueLost2 = "Temperance";

    //    //option3
    //    option3GoodOutcomeText = "good3";
    //    option3NeutralOutcomeText = "neutral3";
    //    option3BadOutcomeText = "bad3";
    //    virtueGained3 = "Temperance";
    //    virtueLost3 = "Justice";
    //}

    //private void End()
    //{
    //    descriptionTextGUI.text = "You have survived the journey through Hell.";

    //    endPanel.SetActive(true);
    //    endScoreTextGUI.text = (Prudence + Temperance + Courage + Justice + Faith + Hope + Charity).ToString(); ;

    //}

    //#endregion

}