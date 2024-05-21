using UnityEngine;

public class CharacterStatHandler : MonoBehaviour
{
    public CharacterStat currentStat;
    public StatSO[] attackData;
    public Sprite[] characterSprites;

    private SpriteRenderer _characterSprite;

    private void Awake()
    {
        _characterSprite = GetComponentInChildren<SpriteRenderer>();
        InitializeCharacter();
    }

    private void InitializeCharacter()
    {
        // TODO: 적 기체 idx 설정
        int idx = 0;

        if (gameObject.CompareTag("Player"))
        {
            idx = DataManager.instance.characterNum;
        }

        _characterSprite.sprite = characterSprites[idx];
        StatSO statSO = attackData[idx];

        currentStat = new CharacterStat
        {
            health = statSO.health,
            speed = statSO.speed,

            attackDelay = statSO.attackDelay,
            attackPower = statSO.attackPower,
            attackSpeed = statSO.attackSpeed,
            target = statSO.target,

            nameTag = statSO.nameTag,
            size = statSO.size,
            duration = statSO.duration,
            spread = statSO.spread,
            numberOfProjectiles = statSO.numberOfProjectiles,
            projectilesAngle = statSO.projectilesAngle,
            projectileColor = statSO.projectileColor
        };
    }
}
