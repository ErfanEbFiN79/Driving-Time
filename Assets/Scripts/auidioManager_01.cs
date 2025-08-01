using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager_01 : MonoBehaviour
{
    [SerializeField] AudioSource auidionTrack01, audioTrack02;
    [SerializeField] AudioClip[] BGMusicArray;
    [SerializeField] bool isplaying1;
    public static AudioManager_01 currentInstaance;
    [SerializeField] float fadeBetweenTime = 5f;


    private void Awake()
    {
        if (currentInstaance == null)
        {
            currentInstaance = this;
        }else
        {
            if (currentInstaance != this)
            {
                Destroy(gameObject);
                return;
            }
        }
        auidionTrack01 = gameObject.AddComponent<AudioSource>();
        audioTrack02 = gameObject.AddComponent<AudioSource>();
        auidionTrack01.playOnAwake = false;
        audioTrack02.playOnAwake = false;
       


    }

    private void Start()
    {
        if (BGMusicArray.Length > 1)
        {
            auidionTrack01.clip = BGMusicArray[0];
            auidionTrack01.Play();
            isplaying1 = true;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Swap();
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            StopCoroutine(nameof(SwapWithFading));

            StartCoroutine(nameof(SwapWithFading));
        }
    }
    public void Swap()
    {
        if (isplaying1)
        {
            //int nextIndex = choseNextClip();
            audioTrack02.clip = BGMusicArray[choseNextClip()];
            audioTrack02.Play();
            auidionTrack01.Stop();
        }
        else
        {
            auidionTrack01.clip = BGMusicArray[choseNextClip()];
            audioTrack02.Stop();
            auidionTrack01.Play();
        }
        isplaying1 = !isplaying1;
    }

    public int choseNextClip()
    {
        return Random.Range(0, BGMusicArray.Length);
    }

    public IEnumerator SwapWithFading()
    {
        
        float timeElapsed = 0f;
        if (isplaying1)
        {
            audioTrack02.clip = BGMusicArray[choseNextClip()];
            audioTrack02.Play();
            while (timeElapsed <= fadeBetweenTime)
            {
                audioTrack02.volume = Mathf.Lerp(0, 1, timeElapsed/fadeBetweenTime);
                auidionTrack01.volume = Mathf.Lerp(1, 0, timeElapsed/fadeBetweenTime);
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            auidionTrack01.Stop();
        }
        else
        {
            auidionTrack01.clip = BGMusicArray[choseNextClip()];
            auidionTrack01.Play();
            while (timeElapsed <= fadeBetweenTime)
            {
                auidionTrack01.volume = Mathf.Lerp(0, 1, timeElapsed / fadeBetweenTime);
                audioTrack02.volume = Mathf.Lerp(1, 0, timeElapsed / fadeBetweenTime);
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            audioTrack02.Stop();
        }
        if (isplaying1)
        {
            yield return new WaitForSeconds(auidionTrack01.clip.length);
            StartCoroutine(nameof(SwapWithFading));
        }
        else
        {
            yield return new WaitForSeconds(audioTrack02.clip.length);

            StartCoroutine(nameof(SwapWithFading));

        }
        yield return null;
    }
}
