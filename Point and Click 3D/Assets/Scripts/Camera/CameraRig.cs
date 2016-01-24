using UnityEngine;
using System.Collections;
using DG.Tweening;

public class CameraRig : MonoBehaviour {

    public Transform yAxis;
    public Transform xAxis;
    public float moveTime;

    public void AlignTo(Transform target) {
        // mode the camera
        Sequence seq = DOTween.Sequence();
        seq.Append(yAxis.DOMove(target.position, moveTime));
        seq.Join(yAxis.DORotate(new Vector3(0f, target.rotation.eulerAngles.y, 0f), moveTime));
        seq.Join(xAxis.DOLocalRotate(new Vector3(target.rotation.eulerAngles.x, 0f, 0f), moveTime));
    }
}
