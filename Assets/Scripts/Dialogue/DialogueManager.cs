using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class DialogueManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Dialogue _startDialogue;
    [SerializeField] TextMeshProUGUI _dialogueDisplay;

    private Animator _animator;

    private GameManager _gameManager;

    [Header("Data")]
    private int _onSentence;
    private Dialogue _currentDialogue;

    private void Start()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        _animator = GetComponent<Animator>();
        RunDialogue(_startDialogue);
    }

    public void RunDialogue(Dialogue dialogue)
    {
        _gameManager.Pause();

        _currentDialogue = dialogue;
        _onSentence = 0;
        _dialogueDisplay.text = _currentDialogue.sentences[_onSentence].sentence;

        _animator.SetTrigger("PopUp");
        SetFace(_currentDialogue.sentences[_onSentence].faceNum);
    }

    public void NextDialogue()
    {
        if(_currentDialogue != null)
        {
            _onSentence++;

            if(_onSentence > _currentDialogue.sentences.Count-1)
            {
                EndDialogue();
            }
            else
            {
                _dialogueDisplay.text = _currentDialogue.sentences[_onSentence].sentence;
                SetFace(_currentDialogue.sentences[_onSentence].faceNum);
            }
        }
    }

    public void EndDialogue()
    {
        _gameManager.UnPause();

        _currentDialogue = null;
        _animator.SetTrigger("PopDown");
    }

    public void SetFace(int i)
    {
        _animator.SetInteger("CharacterFace", i);
    }
}
