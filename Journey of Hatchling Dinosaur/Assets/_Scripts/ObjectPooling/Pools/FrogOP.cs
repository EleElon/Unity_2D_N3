using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class FrogOP : ObjectPools<GameObject> {

    internal static FrogOP Instance { get; private set; }

    [SerializeField] GameObject frogPrefab;

    void Start() {
        Instance = this;
        InitializePool(3);

        for (int i = 0; i < poolSize; i++) {
            GameObject obj = CreateNewObject();
            ReturnFrog(obj);
        }
    }

    internal GameObject GetFrog() {
        return GetObject();
    }

    internal void ReturnFrog(GameObject obj) {
        ReturnObject(obj);
    }

    protected override GameObject CreateNewObject() {
        return GameObject.Instantiate(frogPrefab, transform);
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
