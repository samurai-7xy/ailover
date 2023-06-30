using UnityEngine;
using UnityEngine.SceneManagement;
 
public class explainButton : MonoBehaviour {
 
    public void OnClickStartButton()
    {
        SceneManager.LoadScene("explain");
    }
 
}

