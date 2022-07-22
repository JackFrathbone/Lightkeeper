using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Animator _noteAnimator;

    [Header("Data")]
    private bool _showNote = false;

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void UnPause()
    {
        Time.timeScale = 1;
    }

    public void OpenNotes()
    {
        Pause();
        _showNote = true;
        _noteAnimator.SetTrigger("PopUp");
    }

    public void CloseNotes()
    {
        UnPause();
        _showNote = false;
        _noteAnimator.SetTrigger("PopDown");
    }

    public void LoadLevel(int i)
    {
        SceneManager.LoadScene(i);
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && !_showNote && Time.timeScale == 1)
        {
            OpenNotes();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
