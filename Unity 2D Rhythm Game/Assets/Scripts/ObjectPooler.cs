using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    //리스트 사용하기
    //Note 1: 10개 => 리스트 1
    //Note 2: 10개 => 리스트 2
    //Note 3: 10개 => 리스트 3
    //Note 4: 10개 => 리스트 4

    public List<GameObject> Notes;
    private List<List<GameObject>> poolsOFnotes;
    public int noteCount = 10;
    private bool more = true;

    void Start()
    {
        poolsOFnotes = new List<List<GameObject>>(); //비어있는 리스트들의 리스트를 생성(=poolsOfNotes)
        for(int i = 0; i < Notes.Count; i++) // 4번 반복 반복문 시작. Notes라는 리스트의 개수(=4)만큼 아래 작업 반복
        {
            poolsOFnotes.Add(new List<GameObject>());//poolsOfNotes에 빈 리스트를 원소로 추가
            for(int n = 0; n < noteCount; n ++)// 10번 반복 반복문 시작.noteCount(=10)만큼 아래 작업 반복
            {
                GameObject obj = Instantiate(Notes[i]);//Notes의i번째 원소(=각각의 note)를 생성,obj에 할당
                obj.SetActive(false);//obj비활성화
                poolsOFnotes[i].Add(obj);//poolsOfNotes의i번째 원소(빈 리스트)에 obj 추가
            } //poolsOfNotes의 첫번째 원소(빈리스트)에 obj가 10개
        }     //채워지면,poolsOfNotes의 두 번째 원소(빈리스트)를 생성해서
    }         //똑같이 obj를 10개 채워넣음.
              //최종적으로 poolsOfNotes에는 노트가 10개씩 들어있는 리스트 4개가 원소로 추가됨!
public GameObject geteObject(int noteTye)
    {
        foreach(GameObject obj in poolsOFnotes[noteTye -1])
        { 
        if(!obj.activeInHierarchy)
                {
                    return obj;
                }
        }
        if(more)
        {
            GameObject obj = Instantiate(Notes[noteTye - 1]);
            poolsOFnotes[noteTye - 1].Add(obj);
            return obj;
        }
        return null;
    }

    void Update()
    {
        
    }
}
