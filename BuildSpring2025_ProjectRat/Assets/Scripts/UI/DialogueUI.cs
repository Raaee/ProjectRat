using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.cyborgAssets.inspectorButtonPro;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private GameObject singleSpeaker;
    [SerializeField] private GameObject doubleSpeaker;

    private void Start()
    {
        DeactivateAllBoxes();
    }
    [ProButton]
    private void DeactivateAllBoxes()
    {
        singleSpeaker.SetActive(false);
        doubleSpeaker.SetActive(false);
    }

    [ProButton]
    private void SingleBox()
    {
        singleSpeaker.SetActive(true);
        doubleSpeaker.SetActive(false);
    }

    [ProButton]
    private void DoubleBox()
    {
        singleSpeaker.SetActive(false);
        doubleSpeaker.SetActive(true);
    }
}