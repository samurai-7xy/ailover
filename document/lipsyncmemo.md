//パソコンにあるwavデータをAssetsにインポートし、それをAudioClipに設定

using UnityEngine;
using System.IO;

public class AudioImportScript : MonoBehaviour
{
    public string wavFilePath; // .wavファイルのパス（フルパスまたはAssets内の相対パス）

    void Start()
    {
        ImportAudioClip(wavFilePath);
    }

    void ImportAudioClip(string path)
    {
        if (File.Exists(path))
        {
            byte[] audioData = File.ReadAllBytes(path);
            AudioClip audioClip = WavUtility.ToAudioClip(audioData, 0, audioData.Length, 0, audioData.Length);

            // AudioClipをAssetsに保存
            string fileName = Path.GetFileNameWithoutExtension(path);
            string assetPath = "Assets/Audio/" + fileName + ".wav"; // 保存先のパスを設定

            if (AssetDatabase.LoadAssetAtPath<AudioClip>(assetPath) == null)
            {
                AssetDatabase.CreateAsset(audioClip, assetPath);
                AssetDatabase.Refresh();
            }
            else
            {
                Debug.LogWarning("AudioClip already exists at path: " + assetPath);
            }
        }
        else
        {
            Debug.LogError("File not found at path: " + path);
        }
    }
}

//再生したらAudioClipを空にするコード

using UnityEngine;

public class AudioPlaybackScript : MonoBehaviour
{
    public AudioClip audioClip; // 再生するAudioClipをInspectorから設定
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayAudio();
        }
    }

    void PlayAudio()
    {
        if (audioClip != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayAudio();
        }

        if (audioSource.isPlaying && Input.GetKeyDown(KeyCode.Escape))
        {
            // 再生中のAudioClipを停止
            audioSource.Stop();
            // AudioClipをnullに戻す
            audioSource.clip = null;
        }
    }
}

// unity再生中にaudioclipを差し替えても音声が再生されるコード

using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioClip initialAudioClip; // Inspectorで初期のAudioClipを設定

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource();
        audioSource.clip = initialAudioClip;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 再生中にAudioClipを差し替える
            ChangeAudioClipToNewOne();
        }
    }

    void ChangeAudioClipToNewOne()
    {
        AudioClip newAudioClip = // ここで新しいAudioClipを読み込む処理を実行

        if (newAudioClip != null)
        {
            audioSource.Stop(); // 再生中の音声を停止
            audioSource.clip = newAudioClip; // 新しいAudioClipを設定
            audioSource.Play(); // 新しいAudioClipを再生
        }
    }
}


// 再生されたwavをAssetsとパソコン内から抹消するコード
//UnityのAssetsから消す

using UnityEngine;
using System.IO;

public class FileDeletionScript : MonoBehaviour
{
    public string relativePath; // 削除対象のファイルのAssets内の相対パス

    void Start()
    {
        string filePath = Application.dataPath + "/" + relativePath;

        if (File.Exists(filePath))
        {
            File.Delete(filePath);
            UnityEditor.AssetDatabase.Refresh(); // Unityエディタ内でのリフレッシュ
        }
        else
        {
            Debug.LogWarning("File not found at path: " + filePath);
        }
    }
}

//パソコンのファイルから削除

using System.IO;

public class FileDeletionScript : MonoBehaviour
{
    public string filePath; // パソコン内の削除対象のファイルのフルパス

    void Start()
    {
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
            Debug.Log("File deleted: " + filePath);
        }
        else
        {
            Debug.LogWarning("File not found at path: " + filePath);
        }
    }
}

//リアルタイムで生成されたwavを自動でunityのAssetsに入れ、Audioclipに設定するC#のコード

using UnityEngine;
using System.IO;

public class AudioImportScript : MonoBehaviour
{
    public string savePath = "Assets/Audio/GeneratedAudio.wav"; // 保存先のファイルパス
    public AudioClip audioClip; // AudioClipを設定

    void Start()
    {
        // この部分で.wavファイルを生成し、指定のパスに保存
        GenerateAndSaveWav(savePath);

        // 保存した.wavファイルをAudioClipに読み込む
        LoadWavToAudioClip(savePath);
    }

    void GenerateAndSaveWav(string path)
    {
        // ここに.wavファイルの生成コードを記述
        // 例: byte[] audioData = ... (生成した音声データ)
        // 例: File.WriteAllBytes(path, audioData);
    }

    void LoadWavToAudioClip(string path)
    {
        byte[] audioData = File.ReadAllBytes(path);

        if (audioData != null && audioData.Length > 0)
        {
            audioClip = WavUtility.ToAudioClip(audioData, 0, audioData.Length, 0, audioData.Length);
            // AudioClipをAssetsに保存
            if (audioClip != null)
            {
                AssetDatabase.CreateAsset(audioClip, savePath);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
            }
            else
            {
                Debug.LogError("Failed to create AudioClip from generated .wav file.");
            }
        }
        else
        {
            Debug.LogError("Failed to load .wav file from path: " + path);
        }
    }
}
