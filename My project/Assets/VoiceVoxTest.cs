using System.Collections;
using UnityEngine;

public class VoiceVoxTest : MonoBehaviour
{
    [SerializeField]
    private AudioSource _audioSource;

    void Start()
    {
        StartCoroutine(SpeakTest("AI彼氏"));
    }

    IEnumerator SpeakTest (string text)
    {
        // VOICEVOXのREST-APIクライアント
        VoiceVoxApiClient client = new VoiceVoxApiClient();

        // テキストからAudioClipを生成（話者は「52:春日部つむぎ」）
        yield return client.TextToAudioClip(52, text);

        if (client.AudioClip != null)
        {
            // AudioClipを取得し、AudioSourceにアタッチ
            _audioSource.clip = client.AudioClip;
            // AudioSourceで再生
            _audioSource.Play();
        }
    }
}
