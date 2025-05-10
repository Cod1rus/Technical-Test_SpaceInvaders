using UnityEngine;

namespace Entities
{
    public class LevelBounds : MonoBehaviour
    {
        private Camera _playerCamera;

        private void Awake()
        {
            _playerCamera = Camera.main;
        }

        public bool IsInBounds(Vector3 position)
        {
            var viewportPoint = _playerCamera.WorldToViewportPoint(position);
            return viewportPoint is {x: >= 0 and <= 1, y: >= 0 and <= 1};
        }
    }
}