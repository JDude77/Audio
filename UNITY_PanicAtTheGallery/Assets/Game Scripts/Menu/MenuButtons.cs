using UnityEngine;

public class MenuButtons : MonoBehaviour
{
    #region Attributes
    [SerializeField]
    private GameObject MenuHUD;
    [SerializeField]
    private Animator PlayerAnimator;
    #endregion

    public void StartGame()
    {
        PlayerAnimator.Play("PlayerIntro");
        Cursor.visible = false;
        MenuHUD.SetActive(false);
    }//End StartGame

    public void QuitGame()
    {
        Application.Quit();
    }//End QuitGame
}
