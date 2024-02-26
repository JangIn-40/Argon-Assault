using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CollsionHandler : MonoBehaviour
{
    // PlayerControl playerControl;
    [SerializeField] ParticleSystem ExplosinVFX;
    [SerializeField] ParticleSystem LeftLaser;
    [SerializeField] ParticleSystem RightLaser;
    [SerializeField] float waitLoadScene = 1f;

    Transform[] childTransforms;


    void Awake()
    {
        // playerControl = GetComponent<PlayerControl>();
        childTransforms = GetComponentsInChildren<Transform>(true);

    }


    void OnTriggerEnter(Collider other)
    {
        StartCrashSequence();
    }

    private void StartCrashSequence()
    {
        // StartCoroutine(WaitaSecond());
        // playerControl.isAlive = false;


        // 부모 오브젝트에는 MeshRenderer가 없으므로 제외하고 자식 오브젝트에 MeshRenderer가 있으면 비활성화
        DisableRendererInChild();
        GetComponent<PlayerControl>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        LeftLaser.Stop();
        RightLaser.Stop();
        ExplosinVFX.Play();
        Invoke("ReloadLevel", waitLoadScene);
        
    }

    void DisableRendererInChild()
    {
        // 원하는 조건에 따라 특정 자식 오브젝트의 MeshRenderer만 비활성화
        // 예를 들어, 첫 번째 자식 오브젝트의 MeshRenderer를 비활성화
        foreach (Transform childTransform in childTransforms)
        {
            // 자식 오브젝트의 MeshRenderer 비활성화
            MeshRenderer meshRenderer = childTransform.GetComponent<MeshRenderer>();

            if (meshRenderer != null)
            {
                meshRenderer.enabled = false;
            }
        }
    }

    private void ReloadLevel()
    {
        // int indexScene = 0;
        // SceneManager.LoadScene(indexScene);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    IEnumerator WaitaSecond()
    {
        yield return new WaitForSeconds(waitLoadScene);
    }
}
