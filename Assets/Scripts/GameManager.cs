using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Animator _noteAnimator;

    [Header("Data")]
    private bool _showNote;

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void UnPause()
    {
        Time.timeScale = 1;
    }

    public void ToggleNotes()
    {
        _showNote = !_showNote;

        if (_showNote)
        {
            _noteAnimator.SetTrigger("PopUp");
            Pause();
        }
        else
        {
            _noteAnimator.SetTrigger("PopDown");
            UnPause();
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && Time.timeScale == 1)
        {
            ToggleNotes();
        }
    }
}
