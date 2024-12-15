using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using static UnityEditor.PlayerSettings;
#endif

public class Scripts_Player : MonoBehaviour
{
    public Rigidbody2D _rigidbody;
    [SerializeField] private Transform player;

    public static Scripts_Player Instance { get; set; }

    [SerializeField] public float _hitpoints = 4;
    [SerializeField] public int _keys = 0;
    [SerializeField] private float _speed = 8f;
    [SerializeField] private float _jumpForce = 15f;
    [SerializeField] private ContactFilter2D _collider;
    [SerializeField] public Image Healthbar;

    public TextMeshProUGUI KeysStartAmount;
    public TextMeshProUGUI KeysEarned;
    [SerializeField] public int _keyStart;
    private float _hitpointsMax;

    private bool _isOnCollider = false;

    private void Awake()
    {
        Instance = this; 
        _rigidbody = GetComponent<Rigidbody2D>();

        _hitpointsMax = _hitpoints;
        _keyStart = GameObject.FindGameObjectsWithTag("Key").Length;
        if (_keyStart > 0)
            KeysStartAmount.text = _keyStart.ToString();
    }

    private void FixedUpdate()
    {
        CheckGround();    
    }

    private void Update()
    {
        if (Input.GetButton("Horizontal"))
            Movement();
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
            Jump();
    }

    private void CheckGround()
    {
        Collider2D[] _coll = Physics2D.OverlapCircleAll(transform.position, 0.3f);
        _isOnCollider = _coll.Length > 1;
    }

    public void Jump()
    {
        if (_isOnCollider == true)
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    private void Movement()
    {
        Vector3 _direction = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + _direction, _speed * Time.deltaTime);
    }

    public void GetDamage()
    {
        _hitpoints -= 1;
        Debug.Log(_hitpoints);
        HealthBarManager();
        if (_hitpoints == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void GetHeal()
    {
        if (_hitpoints < _hitpointsMax)
        {
            _hitpoints += 1;
            Debug.Log(_hitpoints);
            HealthBarManager();
        }
    }

    public void KeyManager()
    {
        _keys += 1;
        Debug.Log(_keys);
        KeysEarned.text = _keys.ToString();
    }

    public void HealthBarManager()
    {
        Healthbar.fillAmount = _hitpoints / _hitpointsMax;
    }
}
