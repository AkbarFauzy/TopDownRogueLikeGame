using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine;
using Agate.MVC.Base;
using Roguelike.Message;


namespace Roguelike.Module.Input 
{
    public class InputController : BaseController<InputController>
    {
        private InputActionManager _inputActionsManager = new InputActionManager();
        private Vector2 _currentDirection;

        private bool isPaused;

        public override IEnumerator Initialize()
        {
            yield return base.Initialize();
            /* _inputActionsManager.UI.Enable();
             _inputActionsManager.UI.TapStart.performed += OnTapStart;*/
            _inputActionsManager.Player.Move.performed += OnMove;
            _inputActionsManager.Player.Move.canceled += OnMoveCanceled;
            _inputActionsManager.Player.Enable();
        }

        private void OnMove(InputAction.CallbackContext context)
        {
            if (isPaused) return;

            Vector2 direction = context.ReadValue<Vector2>();
            Publish<MovePlayerMessage>(new MovePlayerMessage(direction));
        }

        private void OnMoveCanceled(InputAction.CallbackContext context)
        {
            _currentDirection = Vector2.zero;
            Publish<MovePlayerMessage>(new MovePlayerMessage(_currentDirection));
        }

        public void OnGamePause(OnGamePauseMessage message)
        {
            isPaused = true;
        }

        public void OnGameResume(OnGameResumeMessage message)
        {
            isPaused = false;
        }

        public void OnGameOver(GameOverMessage message)
        {
            _inputActionsManager.Player.Disable();
        }
    }

}

