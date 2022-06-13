using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private bool isCoroutineExecuting = false;
    [SerializeField]
    private GameObject _explosionPrefab;
    private GameObject _temp;

    void Update()
    {
        StartCoroutine(ExplosionRoutine());
        Destroy(this.gameObject, 2.1f);
    }

    IEnumerator ExplosionRoutine()
    {
        if (isCoroutineExecuting)
            yield break;

        isCoroutineExecuting = true;

        yield return new WaitForSeconds(2f);

        Vector3 position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        _temp = Instantiate(_explosionPrefab, position, Quaternion.identity);
        Destroy(_temp, 1f);

        isCoroutineExecuting = false;
    }
}
