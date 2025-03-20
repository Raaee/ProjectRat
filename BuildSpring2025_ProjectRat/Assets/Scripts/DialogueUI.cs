using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.cyborgAssets.inspectorButtonPro;
/*Make a script DialogueUI and have functions that toggle each of the boxes on/off
So a function to turn off dialogueBox, one to turn on the singleSpeaker and another to turn on doubleSpeaker
*/
public class Dialogue : MonoBehaviour
{
    [SerializeField] private GameObject singleSpeaker;
    [SerializeField] private GameObject doubleSpeaker;

    private void Start()
    {
        defaultBoxes();
    }
    [ProButton]
    private void defaultBoxes()
    {
        singleSpeaker.SetActive(false);
        doubleSpeaker.SetActive(false);
    }

    [ProButton]
    private void singleBox()
    {
        singleSpeaker.SetActive(true);
        doubleSpeaker.SetActive(false);
    }

    [ProButton]
    private void doubleBox()
    {
        singleSpeaker.SetActive(false);
        doubleSpeaker.SetActive(true);
    }
}