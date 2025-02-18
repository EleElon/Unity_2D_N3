using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class CrateOP : ObjectPools<GameObject> {

    internal static CrateOP Instance { get; private set; }

    [SerializeField] GameObject cratePrefab;

    void Start() {
        Instance = this;
        InitializePool(3);

        for (int i = 0; i < poolSize; i++) {
            GameObject obj = CreateNewObject();
            ReturnCrate(obj);
        }
    }

    internal GameObject GetCrate() {
        return GetObject();
    }

    internal void ReturnCrate(GameObject obj) {
        ReturnObject(obj);
    }

    protected override GameObject CreateNewObject() {
        return GameObject.Instantiate(cratePrefab, transform);
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
