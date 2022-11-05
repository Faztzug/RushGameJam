using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public class TurnEntity : MonoBehaviour
    {

        public string name;
        public int initiative;

        public IEnumerator turnCo()
        {

            Debug.log(name + " turn started ");
            yield return new WaitForSeconds(5);
            Debug.Log(name + " turn ended ");

        }

    }

    public class BattleSystem : MonoBehaivour
    {

        [SerializeField] private List<TurnEntity> turnList;
        [SerializeField] private int currentTurnIndex;
        [SerializeField] private TurnEntity currentEntity;

        public List<TurnEntity> TurnList { get => turnList; }
        public int CurrentTurnIndex { get { return currentTurnIndex; } }

    }

    private void FindTurnEntities ()
    {

        TurnEntity[] turnEntities = GameObject.FindObjectsOfType<TurnEntity>();
        if (turnList == null)
            turnList = new List<TurnEntity>();

        foreach (TurnEntity turnEntity in turnEntities)
            TurnList.Add(turnEntity);

    }

    private void AdjustTurnOrder ()
    {

        if (TurnList == null) return;
        if (TurnList.Count <= 0) return;

        TurnList.Sort((a, b) => a.initiative.Compareto(b.initiative));
        TurnList.Reverse()

    }

    private void Setup ()
    {

        FindTurnEntities ();
        AdjustTurnOrder ();

    }

    private void Start ()
    {

        Setup ();

    }

    [SerializeField] private bool inBattle;

    private void Setup ()
    {

       inBattle = true;
        currentTurnIndex = 0;

    }

    private void Start ()
    {

        StartBattle();

    }

    private void StartBsttle ()
    {

        StartCoroutine(TurnLoopCo());

    }

    private IEnumerator TurnLoop ()
    {

        while (inBattle)
        {

            currentEntity = turnList[CurrentTurnIndex];
            yield return currentEntity.Turn();
            currentTurnIndex = GetNextTurnIndex(CurrentTurnIndex);
            currentEntity = turnList[CurrentTurnIndex];

        }
}

    private in GetNextTurnIndex(int currentIndex)
    {

        currentIndex++;
        currentIndex %= turnList.Count;
        return currentIndex;

    }