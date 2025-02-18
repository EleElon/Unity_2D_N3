using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class EagleOP : ObjectPools<GameObject> {

    internal static EagleOP Instance { get; private set; }

    [SerializeField] GameObject eaglePrefab;

    void Start() {
        Instance = this;
        InitializePool(3);

        for (int i = 0; i < poolSize; i++) {
            GameObject obj = CreateNewObject();
            ReturnEagle(obj);
        }
    }

    internal GameObject GetEagle() {
        return GetObject();
    }

    internal void ReturnEagle(GameObject obj) {
        ReturnObject(obj);
    }

    protected override GameObject CreateNewObject() {
        return GameObject.Instantiate(eaglePrefab, transform);
    }

    protected override void RestoreObject(GameObject obj) {
        obj.SetActive(false);
    }

    protected override void BorrowObject(GameObject obj) {
        obj.SetActive(true);
    }

    protected override void DestroyObject(GameObject obj) {
        GameObject.Destroy(obj);
    }
}
