using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class DisableMeneger : MonoBehaviour
{
    [SerializeField] private PlayerControler _playerControler;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private TextMeshProUGUI _timeScaleText;

    private void Update()
    {
        _timeScaleText.text = Time.timeScale.ToString();
    }

    public void Enable()
    {
        _playerControler.enabled = true;
        _playerInput.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Disable()
    {
        _playerControler.enabled = false;
        _playerInput.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}