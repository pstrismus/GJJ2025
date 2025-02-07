using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonMenager : MonoBehaviour
{
    public void RetryButton()
    {
        SceneManager.LoadScene(1);
    }
    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
    }
  
}
