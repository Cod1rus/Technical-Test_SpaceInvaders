using Input;
using UnityEngine;

namespace Entities
{
    public class Player : EntityBase
    {
        [SerializeField] private InputReader _inputReader;
        public InputReader InputReader => _inputReader;
    }
}