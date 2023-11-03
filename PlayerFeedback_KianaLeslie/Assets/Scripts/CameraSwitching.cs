using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitching : MonoBehaviour
{
    public RenderTexture[] cameraFeeds;
    private Renderer screenRenderer;
    private int currentCamera = 0;
    private float timeToNextSwitch;
    public float minSwitchTime = 2.0f;
    public float maxSwitchTime = 5.0f;

    void Start()
    {
        screenRenderer = GetComponent<Renderer>();
        timeToNextSwitch = Random.Range(minSwitchTime, maxSwitchTime);
        screenRenderer.material.mainTexture = cameraFeeds[currentCamera];
        StartCoroutine(SwitchCamera());
    }

    IEnumerator SwitchCamera()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeToNextSwitch);

            int randomCamera = Random.Range(0, cameraFeeds.Length);

            screenRenderer.material.mainTexture = cameraFeeds[randomCamera];
            currentCamera = randomCamera;
            timeToNextSwitch = Random.Range(minSwitchTime, maxSwitchTime);
        }
    }
}