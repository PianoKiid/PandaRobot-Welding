using System.Collections;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public EyetrackingManager eyetrackingManager;

    private void Start()
    {
        eyetrackingManager = GetComponent<EyetrackingManager>();
        StartCoroutine(StartRecordingCoroutine());
    }

    private IEnumerator StartRecordingCoroutine()
    {
        yield return new WaitForSeconds(1f); // 1초 대기

        eyetrackingManager.StartEyetrackingRecording(); // EyetrackingManager 클래스의 StartEyetrackingRecording() 함수 실행
    }
}
