using System.Collections;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private AudioManager audioManager;
    
    [SerializeField] private Animator anim;
    [SerializeField] private Animator quitAnim;
    
    [SerializeField] private GameObject chamarPic;

    private void Start()
    {
        chamarPic.SetActive(false);
    }

    public void Play()
    {
        anim.SetTrigger("Start");
        StartCoroutine(StartGame());
    }

    private IEnumerator StartGame()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        quitAnim.SetTrigger("Start");
        StartCoroutine(QuitGame());
    }

    private IEnumerator QuitGame()
    {
        yield return new WaitForSeconds(1.5f);
        Application.Quit();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            audioManager.PlaySFX(audioManager.ClickDown);
        }

        else if (Input.GetMouseButtonUp(0))
        {
            audioManager.PlaySFX(audioManager.ClickUp);
        }
    }

    public void Chamar()
    {
        StartCoroutine(ChamarPopUp());
    }
    private IEnumerator ChamarPopUp()
    {
        chamarPic.SetActive(true);
        audioManager.PlaySFX(audioManager.poppinChamar);
        yield return new WaitForSeconds(12f);
        chamarPic.SetActive(false);
    }
}
