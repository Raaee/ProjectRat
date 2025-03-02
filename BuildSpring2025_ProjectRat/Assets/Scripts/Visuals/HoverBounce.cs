using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverBounce : MonoBehaviour
{
    [SerializeField] private GameObject objToMove;
    [SerializeField] private float duration = 10f;
    [SerializeField] private float hoverStrength = 1f;
    [SerializeField] private Ease easeType = Ease.Linear;
    [SerializeField] private bool smoothSnap = true;

    private void Start() {
        StartHover();
    }
    public void StartHover() {
        objToMove.transform.DOMove(Vector3.up, duration, smoothSnap);
    }
}
