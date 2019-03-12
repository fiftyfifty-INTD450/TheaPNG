using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPanel : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public RawImage videoImage;
    public AudioSource audioSource;

    public void PlayStreamingClip(string path, bool looping = false)
    {
        videoPlayer.source = VideoSource.Url;
        videoPlayer.url = path;
        videoPlayer.isLooping = looping;

        StartCoroutine(PlayVideo());
    }

    private IEnumerator PlayVideo()
    {
        videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        videoPlayer.controlledAudioTrackCount = 1;
        videoPlayer.EnableAudioTrack(0, true);
        videoPlayer.SetTargetAudioSource(0, audioSource);

        videoPlayer.Prepare();
        while (!videoPlayer.isPrepared)
            yield return null;

        videoPlayer.Play();

        videoImage.texture = videoPlayer.texture;

        while (videoPlayer.isPlaying)
            yield return null;
    }
}
