using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGenarator : MonoBehaviour
{
    const int StageChipSize = 100; //生成したらチップを配置するにあたってのチップの大きさ
    int currentChipIndex; //現在どのチップまで作ったか
    Transform player; //プレイヤーのTransgorm情報の習得
    public GameObject[] floorChips; //生成すべきオブジェクトを配列に格納
    public GameObject[] goalFloorChips;
    public int floorChipIndex; //チップ番号の開始
    public int preInstantiate; //余分に作っておく数

    //現在生成したオブジェクトの管理用
    public List<GameObject> generatedFloorList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        //Playerを探し出してそのTransformを習得
        player = GameObject.FindGameObjectWithTag("Player").transform;

        currentChipIndex = floorChipIndex - 1; //スタート時点でのPlayerの現在地
        UpdateStage(preInstantiate); //自作したアップデートステージメソッドでpreInstantiate文だけ最初にステージを作る
    }

    // Update is called once per frame
    void Update()
    {

        if (player != null) //もしもPlayerがいれば（nullヌルじゃなければ）
        {
            //キャラクターの位置から現在のステージチップのインデックスを計算
            int charaPositionindex = (int)(player.position.z / StageChipSize);

            //次のステージチップに入ったらステージの更新処理を行う
            if (charaPositionindex + preInstantiate > currentChipIndex)
            {
                UpdateStage(charaPositionindex + preInstantiate);
            }
        }
    }
    //指定のIndex
    void UpdateStage(int toChipIndex)
    {

        for (int i = currentChipIndex + 1; i <= toChipIndex; i++)
        {
            GameObject stageObject = GenerateStage(i);

            generatedFloorList.Add(stageObject);
        }

        while (generatedFloorList.Count > preInstantiate + 2)
        {
            DestroyOldestStage();
        }

        currentChipIndex = toChipIndex;
    }
    GameObject GenerateStage(int chipIndex)
    {

        if (player.position.z >= 0)
        {
            GameObject stageObject = Instantiate(
                goalFloorChips[0],
                new Vector3(-2, 1, chipIndex * StageChipSize),
                Quaternion.identity
                );
            return stageObject;
        }
        else
        {
            int nextStageChip = Random.Range(0, floorChips.Length);
            GameObject stageObject = Instantiate(
                floorChips[nextStageChip],
                new Vector3(-2, 1, chipIndex * StageChipSize),
                Quaternion.identity
                );
            return stageObject;
        }
    }

    void DestroyOldestStage()
    {
        GameObject oldStage = generatedFloorList[0];
        generatedFloorList.RemoveAt(0);
        Destroy(oldStage);
    }
}
