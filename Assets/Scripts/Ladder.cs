using UnityEngine;
using UnityEngine.UI;

public class Ladder : MonoBehaviour
{
    private bool _isInRange;
    private PlayerMovement _playerMovement;
    public BoxCollider2D topCollider;
    private Text _interactUI;
    
    private void Awake()
    {
        _playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        _interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }

    private void Update()
    {
        if (_isInRange && _playerMovement.isClimbing && Input.GetKeyDown(KeyCode.E))
        {
            _playerMovement.isClimbing = false;
            topCollider.isTrigger = false;
            return;
        }
        
        if (_isInRange && Input.GetKeyDown(KeyCode.E))
        {
            _playerMovement.isClimbing = true;
            topCollider.isTrigger = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _interactUI.enabled = true;
            _isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _isInRange = false;
            _playerMovement.isClimbing = false;
            topCollider.isTrigger = false;
            _interactUI.enabled = false;
        }
    }
}
