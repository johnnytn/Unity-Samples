using UnityEngine;
using DG.Tweening;
using System;

public class Character : MonoBehaviour {

    // Movement varibles
    public Transform yAxis;
    public Transform xAxis;
    public float moveTime;

    /** 
    * Move the Character to a target position
    */
    public void MoveTo(Transform target) {
        try {
            // Move the player
            Sequence seq = DOTween.Sequence();
            seq.Append(yAxis.DOMove(target.position, moveTime));
            seq.Join(yAxis.DORotate(new Vector3(0f, target.rotation.eulerAngles.y, 0f), moveTime));
            seq.Join(xAxis.DOLocalRotate(new Vector3(target.rotation.eulerAngles.x, 0f, 0f), moveTime));
        } catch (Exception e) {
            Debug.Log(e.Message);
        }
    }

}
