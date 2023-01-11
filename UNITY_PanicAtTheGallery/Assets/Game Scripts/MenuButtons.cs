using UnityEngine;

public class MenuButtons : MonoBehaviour
{
    [SerializeField]
    private GameObject MenuHUD;
    [SerializeField]
    private Animator PlayerAnimator;
    public void StartGame()
    {
        PlayerAnimator.Play("PlayerIntro");
        MenuHUD.SetActive(false);
    }//End StartGame

    public void QuitGame()
    {
        Application.Quit();
    }//End QuitGame
}
