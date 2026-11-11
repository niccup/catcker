using UnityEngine;
using UnityEngine.Video;

public class VideoTrigger : MonoBehaviour
{
    [Header("References")]
    public PointsManager pointsManager;
    public VideoPlayer videoPlayer;
    public GameObject videoUIParent;  

    [Header("Settings")]
    public int targetPoints = 67;
    private bool videoHasPlayed = false;

    void Start()
    {
        if (videoUIParent != null)
        {
            videoUIParent.SetActive(false);
        }

        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached += OnVideoFinished;
        }
    }

    void OnDestroy()
    {
        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached -= OnVideoFinished;
        }
    }

    void Update()
    {
        if (pointsManager != null && !videoHasPlayed)
        {
            if (pointsManager.points == targetPoints)
            {
                Play67Video();
            }
        }
    }

    void Play67Video()
    {
        videoHasPlayed = true;
        if (videoUIParent != null)
        {
            videoUIParent.SetActive(true);
        }
        if (videoPlayer != null)
        {
            videoPlayer.Play();
        }
    }
    void OnVideoFinished(VideoPlayer vp)
    {
        if (videoUIParent != null)
        {
            videoUIParent.SetActive(false);
        }
    }
}