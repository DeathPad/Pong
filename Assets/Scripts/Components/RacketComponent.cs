using ProgrammingBatch.Pong.DesignPattern.Command;
using ProgrammingBatch.Pong.Logic;
using System.Collections;
using UnityEngine;

namespace ProgrammingBatch.Pong.Scene
{
    public sealed class RacketComponent : GameActorComponent
    {
        [SerializeField] private KeyCode topKeyCode = default;
        [SerializeField] private KeyCode botKeyCode = default;
        [SerializeField] private KeyCode boostKeyCode = default;
        private ICommand _topCommand;
        private ICommand _botCommand;

        private Vector2 _transformPosition;

        public override void OnInitialized(IHandler ihandler) 
        {
            _topCommand = new UpMovementCommand(this, movementPower);
            _botCommand = new DownMovementCommand(this, movementPower);

            _transformPosition = transform.position;
        }

        private void Update()
        {
            if(Input.GetKeyDown(topKeyCode))
            {
                _topCommand.Execute();
            }

            if(Input.GetKeyDown(botKeyCode))
            {
                _botCommand.Execute();
            }

            if(Input.GetKeyDown(boostKeyCode))
            { StartCoroutine(Boost()); }
            RestrictMovement();
        }

        private IEnumerator Boost()
        {
            yield return Lerp(1, 2);
            yield return new WaitForSeconds(2);
            yield return Lerp(2, 1);
        }

        private IEnumerator Lerp(float initialSize, float targetSize)
        {
            float _time = 0;
            float _percentage;

            while (_time < 1)
            {
                _time += Time.deltaTime;
                if(_time > 1)
                {
                    _time = 1;
                }

                _percentage = _time / 1;
                float _scaleY = Mathf.Lerp(initialSize, targetSize, _percentage);
                transform.localScale = new Vector3(1, _scaleY, 0);

                yield return null;
            }
        }

        private void RestrictMovement()
        {
            _transformPosition.y = Mathf.Clamp(transform.position.y, botClamp, topClamp);
            transform.position = _transformPosition;
        }
    }
}