using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.Networking;
using UnityEngine.Video;

public class AdsManager : MonoBehaviour
{
    public static AdsManager Instance { get; private set; }
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [SerializeField]
    GameObject _PeepHoleVideoScreen; //to enable 'screen' component where video shows on play
    [SerializeField]
    VideoPlayer _videoPlayer;
    [SerializeField]
    GameObject _sponsorText;

    const string RewardedPlacementId = "rewardedVideo";
    
    //Peep Hole video should be 720x720
    string _baseURL = "http://www.emergereality.com/escaperoomvideos/";
    string _pathToFile;
    bool videoDownloaded = false;

    Vector3 peepHolePosition;

    [SerializeField]
    GameObject _propHolder;

    private void Start()
    { 
        _sponsorText.SetActive(false);
        _PeepHoleVideoScreen.SetActive(false);
    }


    public void ShowVideoAndAd(int VideoNumber, Vector3 peepPosition)
    {
        peepHolePosition = peepPosition;
        videoDownloaded = false;
        StartCoroutine(DownloadVideoFromThisURL(VideoNumber));  //first download the video
        //while waiting for download to complete, show an ad (but first the sponsor test)
        StartCoroutine(ShowSponsorText());
    }

    private IEnumerator DownloadVideoFromThisURL(int id)
    {
        //build download URL (based on the video id #)
        string _videoName = id.ToString() + ".mp4";
        string _url = _baseURL + _videoName;
        UnityWebRequest _videoRequest = UnityWebRequest.Get(_url);

        yield return _videoRequest.SendWebRequest();

        //when video is finished downloading, save it to the phone
        if (_videoRequest.isDone == false || _videoRequest.error != null)
        { Debug.Log("Request = " + _videoRequest.error); }

        byte[] _videoBytes = _videoRequest.downloadHandler.data;

        _pathToFile = Path.Combine(Application.persistentDataPath, _videoName);
        File.WriteAllBytes(_pathToFile, _videoBytes);
        videoDownloaded = true;
    }

    IEnumerator ShowSponsorText()   //and queue up the ad
    {
        Vector2 _sponsorTextInitialPosition = _sponsorText.transform.localPosition;

        Vector2 screenPoint = Camera.main.WorldToScreenPoint(peepHolePosition);
        RectTransform rect = _sponsorText.GetComponent<RectTransform>();
        Vector2 canvasPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rect, screenPoint, null, out canvasPos);

        Vector3 initialScale = new Vector3(.1f, .1f, .1f);
        _sponsorText.transform.localScale = initialScale;
        _sponsorText.transform.localPosition = canvasPos;
        _sponsorText.SetActive(true);

        float currentTime = 0.0f;
        WaitForSeconds waitTime = new WaitForSeconds(.05f);
        float sponsorTextZoomInTime = 2f;

        while (currentTime <= sponsorTextZoomInTime)
        {
            _sponsorText.transform.localScale = Vector3.Lerp(initialScale, Vector3.one, currentTime / sponsorTextZoomInTime);

            _sponsorText.transform.localPosition = Vector3.Lerp(canvasPos, _sponsorTextInitialPosition, currentTime / sponsorTextZoomInTime);

            currentTime += Time.deltaTime;
            yield return waitTime;
        }

        yield return new WaitForSeconds(1f);
        _sponsorText.SetActive(false);

#if UNITY_ADS
        if (!Advertisement.IsReady(RewardedPlacementId))
        {
            Debug.Log(string.Format("Ads not ready for placement '{0}'", RewardedPlacementId));
        }
        else
        {
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show(RewardedPlacementId, options);
        }
#endif

    }


#if UNITY_ADS
    private void HandleShowResult(ShowResult result)    //ad completed callback
    {
        switch (result)
        {
            //when ad is complete then trigger already downloaded video to play
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");
                StartCoroutine(playThisURLInVideo(_pathToFile));
                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                break;
        }
    }
#endif


    
    IEnumerator playThisURLInVideo(string _url)
    {
        //TODO:: TEST TO ENSURE tracking before we play the video
        while (!_propHolder.activeSelf)
        { yield return null; }

        while (videoDownloaded == false)
        { yield return null; }

        _PeepHoleVideoScreen.SetActive(true);
        _videoPlayer.url = _url;
        _videoPlayer.Prepare();

        while (_videoPlayer.isPrepared == false)
        { yield return null; }

        _videoPlayer.Play();

        while (_videoPlayer.isPlaying)
        { yield return null; }

        _PeepHoleVideoScreen.SetActive(false);
        videoDownloaded = false;
    }
}

//TODO:: test videos for successful download, create backup plan, and delete when done
