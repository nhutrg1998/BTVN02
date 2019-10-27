using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Intro : MonoBehaviour
{
    VideoPlayer vp;
    bool played;
    // Start is called before the first frame update
    void Start()
    {
        vp = GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (vp.isPlaying) played = true;

        if (played && !vp.isPlaying)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
