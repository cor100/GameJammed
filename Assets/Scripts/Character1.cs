using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character1 : MonoBehaviour
{
    public float playerSpeed = 1;
    public float jumpSpeed = 1;
    public Sprite[] spritesAttack;
    public Sprite[] spritesFall;
    public Sprite[] spritesDeath;
    public Sprite[] spritesIdle;
    public Sprite[] spritesJump;
    public Sprite[] spritesRun;
    public Sprite[] spritesTakeHit;
    public float animationFPS;
    public HPBar healthbar;
    public LayerMask hitboxLayer;

    protected Rigidbody2D _myRb2D;
    protected int _currentFrameIndex = 0;
    protected float _animationTimer;
    protected SpriteRenderer _playerSpriteRenderer;
    protected Vector2 velChange = Vector2.zero;
    protected Vector2 centreLeft;
    protected Vector2 centreRight;


    void OnDrawGizmosSelected(){
        centreLeft = transform.position;
        centreLeft.x += 3;
        centreRight = transform.position;
        centreRight.x -= 3;
        Gizmos.DrawWireCube(centreLeft, new Vector2(1.5f, 2f));
        Gizmos.DrawWireCube(centreRight,new Vector2(1.5f, 2f));
    }

    // Start is called before the first frame update
    void Start()
    {
        _myRb2D = GetComponent<Rigidbody2D>();
        _playerSpriteRenderer = GetComponent<SpriteRenderer>();
        _animationTimer = 1f/animationFPS;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateVelChange();
        _myRb2D.velocity = velChange;
        ResetVelChange();

        Attack();
        
    }

    // update velocity and also animate sprite
    protected virtual void UpdateVelChange()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            velChange.y = jumpSpeed;
            Animate("jump");
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            velChange.x = -playerSpeed;
            _playerSpriteRenderer.flipX = true;
            Animate("run");
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            velChange.x = playerSpeed;
            _playerSpriteRenderer.flipX = false;
            Animate("run");
        }

    }

    protected void ResetVelChange()
    {
        velChange = Vector2.zero;
    }

    protected virtual void Attack()
    {
        if(Input.GetKeyDown(KeyCode.RightShift))
        {
            StartCoroutine(AnimateAttack());
            // float distance = 66;
            // RaycastHit2D attackEnemyRight = Physics2D.Raycast(transform.position, Vector2.right, distance);
            // RaycastHit2D attackEnemyLeft = Physics2D.Raycast(transform.position, Vector2.left, distance);
            // if(attackEnemyRight.collider.GetComponent<Character2>() != null){
            //     attackEnemyRight.collider.GetComponent<Character2>().getHit();
            // }
            // if(attackEnemyLeft.collider.GetComponent<Character2>() != null){
            //     attackEnemyLeft.collider.GetComponent<Character2>().getHit();
            // }
            Collider2D attackedLeft = Physics2D.OverlapBox(centreLeft, new Vector2(1.5f, 2), 0, hitboxLayer);  
            Collider2D attackedRight = Physics2D.OverlapBox(centreRight, new Vector2(1.5f, 2), 0, hitboxLayer);

            if (attackedLeft != null && attackedLeft.gameObject.GetComponent<Hitbox2>() != null){
                Debug.Log("2left");
                attackedLeft.gameObject.GetComponent<Hitbox2>().hit();
            }
            if (attackedRight != null && attackedRight.gameObject.GetComponent<Hitbox2>() != null){
                Debug.Log("2right");
                attackedRight.gameObject.GetComponent<Hitbox2>().hit();
            }
        }
    }

    public void getHit()
    {
        Animate("takehit");
        healthbar.TakeDamage(10);
    }

    
    // eventually make this a "go to menu screen or dead screen or something"
    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    protected void Animate(string action){
        if(action == "run"){
            move(spritesRun);
        }else if(action == "idle"){
            move(spritesIdle);
        }else if(action == "jump"){
            move(spritesJump);
        }else if(action == "fall"){
            move(spritesFall);
        }else if(action == "death"){
            move(spritesDeath);
        }
    }

    protected void move(Sprite[] sprites){
        _animationTimer -= Time.deltaTime;
        if(_animationTimer <= 0){
            _animationTimer = 1f/animationFPS;
            _currentFrameIndex++;
            if(_currentFrameIndex >= sprites.Length){
                _currentFrameIndex = 0;
            }
            _playerSpriteRenderer.sprite = sprites[_currentFrameIndex];
        }
    }

    protected IEnumerator AnimateAttack(){
        
        for(int i = 0; i < spritesAttack.Length; i ++){
            _playerSpriteRenderer.sprite = spritesAttack[i];
            yield return new WaitForSeconds(_animationTimer * 1.8f);
        }
        _playerSpriteRenderer.sprite = spritesIdle[0];
        
    }
    
    
    
}
