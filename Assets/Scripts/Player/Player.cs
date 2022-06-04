using System.Collections;
using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField] private HeroData _heroData;
    [SerializeField] private Camera _camera;
    [SerializeField, Range(100f, 300f)] private float _camSpeed = 130f;

    [SerializeField] private bool _canTakeDamage;
    [SerializeField] private PlayerGuiManager _playerGuiManager;

    private PlayerMovement _movement = new PlayerMovement();
    private CameraMovement _cameraMovement = new CameraMovement();
    private Attack _attack = new Attack();

    private HeroInfo _heroInfo;
    private PlayerStat _player;

    private Animator _animator;

    private bool _isTakingDamage;
    
    private void Start()
    {
        _player = new PlayerStat(_heroData);
        _heroInfo = new HeroInfo(_heroData);

        GetComponent<SpriteRenderer>().sprite = _heroInfo.icon;
        _movement.rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

        _movement.speed = _player.speed;
        _movement.runSpeed = _player.runSpeed;

        _cameraMovement.camera = _camera;
        _cameraMovement.cameraSpeed = _camSpeed;

        _attack.damage = _player.damage;
        _attack.camera = _camera;
        _attack.objectTransform = transform;

        _playerGuiManager.SetMax(_player.maxHealth, _player.maxMana, _player.maxStamina);
    }
    
    private void FixedUpdate()
    {
        _movement.Move(_movement.MoveDirection);
        _player.stamina = _movement.stamina;
        _playerGuiManager.SetData(_player.health, _player.mana, _player.stamina);
        Regeneration();
    }

    private void Regeneration()
    {
        if (_player.health < _player.maxHealth)
            _player.health += _player.regenHealth * Time.deltaTime;
        if (_player.mana < _player.maxMana)
            _player.mana += _player.regenMana * Time.deltaTime;
    }


    private void Update()
    {
        _cameraMovement.MoveCamera();
        _attack.Attacking();
        SetAnimation();
    }

    public void TakeDamage(float damage)
    {
        
        if (_canTakeDamage)
        {
            StartCoroutine(DamageAnimation());
            _player.health -= damage / (0.55f * _player.armor);
            if (_player.health <= 0)
                Destroy(gameObject);
        }
    }

    private IEnumerator DamageAnimation()
    {
        _isTakingDamage = true;
        yield return new WaitForSeconds(.2f);
        _isTakingDamage = false;
    }


    private void SetAnimation()
    {
        var dir = _movement.MoveDirection;
        if (_attack.attackDir != Vector2.zero) dir = _attack.attackDir; 

        _animator.SetFloat("Horizontal", dir.x);
        _animator.SetFloat("Vertical", dir.y);
        _animator.SetFloat("Speed", dir.sqrMagnitude);
        _animator.SetBool("IsRun", _movement.isRuning);
        _animator.SetBool("IsAttack", _attack.isAttacking);
        _animator.SetBool("IsTakingDamage", _isTakingDamage);
    }
}


public class PlayerStat
{
    public float health;
    public float armor;
    public float speed;

    public float runSpeed;
    public float stamina;

    public float damage;

    public float mana;

    //regen
    public float regenMana;
    public float regenHealth;

    // max
    public float maxMana;
    public float maxHealth;
    public float maxStamina;


    public PlayerStat(HeroData data)
    {
        health = data.Health;
        armor = data.Armor;
        speed = data.Speed;
        runSpeed = data.RunSpeed;
        stamina = data.Stamina;
        damage = data.Damage;
        mana = data.Mana;

        regenHealth = data.RegenHealth;
        regenMana = data.RegenMana;

        maxHealth = data.MaxHealth;
        maxMana = data.MaxMana;
        maxStamina = data.MaxStamina;

    }
}

public class HeroInfo
{
    public string name;
    public string description;
    public Sprite icon;

    public HeroInfo(HeroData data)
    {
        name = data.Name;
        description = data.Description;
        icon = data.Icon;
    }
}

