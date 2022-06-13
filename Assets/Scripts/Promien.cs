using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
public class Promien : MonoBehaviour
{
    private Camera _camera;
    public GameObject impactEffect;
    public float baseDamage = 4.0f;
    public float playerDamage;
    bool _canShoot = true;
    public bool inUpgradePanel=false;
    private RaycastHit hit;
    public float baseFireRate = 0.75f;
    public float fireRate;
    public ParticleSystem muzzle;
    [SerializeField] private UIController kontroler;
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject crosshair;
    [SerializeField] private PlayerRotate rotatePlayer;
    [SerializeField] private PlayerRotate rotateCamera;
    [SerializeField] private GameObject HUD;
    void Start()
    {
      _camera = GetComponent<Camera>();
      Cursor.lockState = CursorLockMode.Locked;
      Cursor.visible = false;
    }
    void Update()
    {
        playerDamage = baseDamage + (1*Managers.Player.DMG_UPGRADES);
        fireRate = baseFireRate - (0.05f * Managers.Player.ATTACK_SPEED_UPGRADES);
        if (Input.GetKeyDown("e"))
        {
            Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
            Ray ray = _camera.ScreenPointToRay(point);
            if (!panel.activeSelf)
            {
                
                if (Physics.Raycast(ray, out hit))
                {
                    GameObject hitObject = hit.transform.gameObject;
                    if (hitObject.tag == "Upgrade")
                    {
                        kontroler.OpenUpgradePanel();
                        Cursor.lockState = CursorLockMode.None;
                        Cursor.visible = true;
                        rotatePlayer.inUpgradePanel = true;
                        rotateCamera.inUpgradePanel = true;
                        HUD.SetActive(false);
                        crosshair.SetActive(false);
                    }
                }
            }
            else {
                kontroler.CloseUpgradePanel();
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                rotatePlayer.inUpgradePanel = false;
                rotateCamera.inUpgradePanel = false;
                crosshair.SetActive(true);
                HUD.SetActive(true);
            }
        }
        if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.
            pixelHeight / 2, 0);
            Ray ray = _camera.ScreenPointToRay(point);
            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                CelReaktywny target = hitObject.GetComponent<CelReaktywny>();
                if (_canShoot == true && target!=null)
                {
                    Shoot();
                    target.ReactToHit(playerDamage);
                }
                else if(_canShoot == true)
                {
                    Shoot();
                }
            }
        }
    }

    /*   private IEnumerator SphereIndicator(Vector3 pos)
       {
           GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
           sphere.transform.position = pos;
           yield return new WaitForSeconds(1);
           Destroy(sphere);
       }*/
    void Shoot() {
        _canShoot = false;
        StartCoroutine(shooting());
    }
    IEnumerator shooting() {
        muzzle.Play();
        GameObject impact = Instantiate(impactEffect, hit.point, Quaternion.identity);
        Destroy(impact, 3f);
        yield return new WaitForSeconds(fireRate);
        _canShoot = true;
    }

}