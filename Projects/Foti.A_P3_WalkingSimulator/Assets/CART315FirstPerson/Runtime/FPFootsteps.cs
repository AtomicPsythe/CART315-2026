using System;
using UnityEngine;

namespace Cart315.FirstPerson
{
    [RequireComponent(typeof(FPController), typeof(AudioSource))]
    public class FPFootsteps : MonoBehaviour
    {
        [Tooltip("Leave empty for silent movement. Drag your own audio clips here.")]
        [SerializeField] private AudioClip[] _sounds = Array.Empty<AudioClip>();
        [Tooltip("Horizontal metres travelled between steps; sprinting produces faster steps.")]
        [SerializeField, Min(0.1f)] private float _stepDistance = 1.8f;
        [SerializeField, Range(0, 1)] private float _volume = 0.35f;

        // Decal variables
        [SerializeField] private GameObject _footprintDecalPrefab;
        [SerializeField] private int _maxFootprints = 10;
        [SerializeField] private LayerMask _groundLayer;

        public event Action FootstepPlayed;
        private FPController _player;
        private AudioSource _audioSource;
        private float _distance;
        private int _lastClip = -1;

        // footprint variables
        private GameObject[] _decalPool;
        private int _currentPoolIndex = 0;

        private void Awake()
        {
            _player = GetComponent<FPController>();
            _audioSource = GetComponent<AudioSource>();
            _audioSource.playOnAwake = false;
            _audioSource.loop = false;

            // generates the footprints before loading them
            if (_footprintDecalPrefab != null)
            {
                _decalPool = new GameObject[_maxFootprints];
                for (int i = 0; i < _maxFootprints; i++)
                {
                    _decalPool[i] = Instantiate(_footprintDecalPrefab);
                    _decalPool[i].SetActive(false);
                }
            }
        }

        private void LateUpdate()
        {
            if (!_player.isActiveAndEnabled || !_player.IsGrounded || !_player.IsInputMoving)
            {
                _distance = 0;

                if (_audioSource.isPlaying)
                {
                    _audioSource.Stop();
                }
                
                return;
            }
            _distance += _player.GroundDistanceThisFrame;
            if (_distance < Mathf.Max(0.1f, _stepDistance)) return;
            _distance %= Mathf.Max(0.1f, _stepDistance);
            if (_sounds == null || _sounds.Length == 0) return;

            // Skip empty slots, and avoid repeating the last clip when possible.
            int first = UnityEngine.Random.Range(0, _sounds.Length);
            int selected = -1;
            for (int i = 0; i < _sounds.Length; i++)
            {
                int index = (first + i) % _sounds.Length;
                if (_sounds[index] == null) continue;
                selected = index;
                if (index != _lastClip) break;
            }
            if (selected < 0) return;
            _audioSource.PlayOneShot(_sounds[selected], _volume);
            _lastClip = selected;

            // make the prints spawn on and off in unison with the sound
            TrySpawnDecalFootprint();

            FootstepPlayed?.Invoke();
        }

        private void TrySpawnDecalFootprint()
        {
            if (_decalPool == null || _decalPool.Length == 0) return;

            // this makes it so that the footprints lay IN the snow terrain
            if (Physics.Raycast(transform.position + Vector3.up * 0.5f, Vector3.down, out RaycastHit hit, 2f, _groundLayer))
            {
                GameObject decal = _decalPool[_currentPoolIndex];
                decal.SetActive(true);
                
                // applies the decal straight onto the surface as the player makes the step
                decal.transform.position = hit.point;

                // adjusts the footprints' orientation based on the direction in which the player is moving
                decal.transform.rotation = Quaternion.Euler(90f, transform.eulerAngles.y, 0f);

                // when it reaches the maximum capacity (20) it deletes the older footprints one by one to spawn new ones
                _currentPoolIndex = (_currentPoolIndex + 1) % _maxFootprints;
            }
        }

        private void OnDisable() => _distance = 0;
    }
}
