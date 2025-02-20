using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.cyborgAssets.inspectorButtonPro;

public class Audio_tester : MonoBehaviour
{
    [SerializeField]private AudioSource  audioSourcel;
    [SerializeField] private float playSeconds = 2f;


    [ProButton]
    public void TestHit()
    {
        audioSourcel.Play();
        StartCoroutine(playForSeconds());
        Debug.Log("Hit");
    }

    [ProButton]
    public void TestRandomAudio()
    {
        Debug.Log("RandomAudio");
    }

    IEnumerator playForSeconds() {
        yield return new WaitForSeconds(playSeconds);
        audioSourcel.Stop();
    }

    [ProButton]
    private void StopAllAudio() {
        audioSourcel.Stop();
    }
}
