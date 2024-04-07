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
        yield return new WaitForSeconds(1f); // 1�� ���

        eyetrackingManager.StartEyetrackingRecording(); // EyetrackingManager Ŭ������ StartEyetrackingRecording() �Լ� ����
    }
}
