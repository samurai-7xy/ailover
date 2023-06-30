using UnityEngine;
using UnityEngine.SceneManagement;
 
public class TitlebackButton : MonoBehaviour {
 
    public void OnClickStartButton()
    {
        SceneManager.LoadScene("Title");
    }
 
}

