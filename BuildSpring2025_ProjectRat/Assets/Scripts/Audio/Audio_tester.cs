using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.cyborgAssets.inspectorButtonPro;

public class Audio_tester : MonoBehaviour
{
    [ProButton]
    public void TestHit()
    {
        Debug.Log("Hit");
    }

    [ProButton]
    public void TestRandomAudio()
    {
        Debug.Log("RandomAudio");
    }
}
