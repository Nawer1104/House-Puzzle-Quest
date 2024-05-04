using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Object : MonoBehaviour
{
    private bool isClicked = false;

    public float scale;

    public Vector3 dir;

    public GameObject vfxCompleted;

    private void OnMouseDown()
    {
        if (isClicked) return;

        isClicked = true;

        transform.DOMove(dir, 1f).OnComplete(() => {
            transform.DOScale(scale, 1f);

            GameObject vfx = Instantiate(vfxCompleted, transform.position, Quaternion.identity) as GameObject;
            Destroy(vfx, 1f);

            GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].gameObjects.Remove(gameObject);
            GameManager.Instance.CheckLevelUp();
        });
    }
}
