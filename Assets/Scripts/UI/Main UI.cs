using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUI : MonoBehaviour
{
    public void CasinoLoad()
    {
        print("casinooo");
        SceneManager.LoadScene("CasinoArea");
    }

    public void WorkLoad()
    {
        print("workkk");
        SceneManager.LoadScene("JobArea");
    }

    public void HomeLoad()
    {
        print("Homeee"); 
        SceneManager.LoadScene("HomeArea");
    }
}
