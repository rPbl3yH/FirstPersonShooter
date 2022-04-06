using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    //[SerializeField] private GameObject _particleShooting;

    [SerializeField] private GameObject _prefabHit;

    private float _fireRate = 15f;
    private float _nextTimeToFire = 0f;
    

    private float _range = 100f;
    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponentInChildren<Camera>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetMouseButton(0) && Time.time >= _nextTimeToFire)
        {
            _nextTimeToFire = Time.time + 1f / _fireRate;
            Shoot();

        }
        
    }

    public void Shoot()
    {
        //Debug.Log("SHOOT!");
        Gun currentGun = GetComponentInChildren<Gun>();

        currentGun.Particle.Play();

        Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Ray ray = _camera.ScreenPointToRay(screenCenter);
        RaycastHit hit;

        if(Physics.Raycast(ray,out hit, _range))
        {
            
            //Debug.Log("HIT " + hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();

            if (target)
            {
                target.TakeDamage(currentGun.Damage);
                
                if (hit.rigidbody)
                {
                    Debug.Log("Rigidbody have");
                    //hit.rigidbody.AddForce(-hit.normal * 200f);
                    hit.rigidbody.AddExplosionForce(2000f, hit.normal, 10f);
                }
            }

            if (hit.transform.gameObject.GetComponent<Enemy>())
            {
                Enemy enemy = hit.transform.gameObject.GetComponent<Enemy>();
                
                enemy.TakeDamage(currentGun.Damage);
            }

            GameObject particleHit = Instantiate(_prefabHit, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(particleHit, 2f);
        }
    }

    
}
