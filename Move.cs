using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    private float vmove, hmove;
    private Vector3 movement;
    private ResourseManager RM;
    private float HP;
    public FixedJoystick joystick;
    public TMP_Text Lose;

    // Start is called before the first frame update
    public void Start()
    {
        RM = FindObjectOfType<ResourseManager>();
        HP = RM.PlayerHP;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public void Update()
    {
        movement = joystick.Horizontal * transform.right + joystick.Vertical * transform.forward;
        rb.velocity = new Vector3(movement.x * speed, rb.velocity.y, movement.z * speed);
    }

    public void LossHP(float damage)
    {
        HP -= damage;
        RM.UpdateHP(HP);
        if (HP <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        Lose.enabled = true;
        StartCoroutine(Restart());
    }

    public IEnumerator Restart()
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(3);
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Ammo")
        {
            RM.PlusAmmo();
            Destroy(other.gameObject);
        }
    }


}
