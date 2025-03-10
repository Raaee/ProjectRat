using Cinemachine;
using com.cyborgAssets.inspectorButtonPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private CinemachineBrain cmBrain;
    [SerializeField] private GameObject playerCam;
    [SerializeField] private GameObject targetVirtualCam;
    [SerializeField] private float wobbleAmount = 10f; // amplitude gain
    [SerializeField] private float wobbleIntensity = 5f; // frequency gain
    [SerializeField] private float dieAmount = 0.2f;
    [SerializeField] private float dieSpeed = 0.1f;

    private void Start() {
        cmBrain = GetComponent<CinemachineBrain>();
        playerCam = FindObjectOfType<PlayerMovement>().gameObject.transform.GetChild(0).gameObject;
    }

    [ProButton]
    public void StartWobble() {
        SwitchToTargetCam();
        StartCoroutine(WobbleMovement());
    }
    private IEnumerator WobbleMovement() {
        var cmPerlinChannel = targetVirtualCam.GetComponentInChildren<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        float wobbleInt = wobbleIntensity;
        float wobbleAmt = wobbleAmount;

        while (wobbleInt > 0 || wobbleAmt > 0) {
            cmPerlinChannel.m_AmplitudeGain = wobbleInt;
            cmPerlinChannel.m_FrequencyGain = wobbleAmt;
            wobbleInt -= dieAmount;
            wobbleAmt -= dieAmount;
            yield return new WaitForSeconds(dieSpeed);
        }
    }
    public void AssignTargetCam(GameObject bossGO) {
        targetVirtualCam = bossGO.transform.GetChild(0).gameObject;
    }
    [ProButton]
    private void SwitchToPlayerCam() {
        targetVirtualCam.SetActive(false);
        playerCam.SetActive(true);
    }
    [ProButton]
    private void SwitchToTargetCam() {
        playerCam.SetActive(false);
        targetVirtualCam.SetActive(true);
    }
}
