using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using UnityEditor;
using System.IO;

public class BattleSystem : MonoBehaviour {

    Animator animator;

    public GameObject chara1HpText;
    public GameObject chara1MpText;
    public GameObject chara2HpText;
    public GameObject chara2MpText;
    public GameObject chara3HpText;
    public GameObject chara3MpText;

    public GameObject spellMenu;
    public GameObject inventoryMenu;

    public GameObject enemy1Button;
    public GameObject enemy2Button;
    public GameObject enemy3Button;
    public GameObject warriorButton;
    public GameObject ninjaButton;
    public GameObject mageButton;

    public GameObject indicator;
    public GameObject indicator2;
    public GameObject deathIcon;
    public GameObject greenGoblin;
    public GameObject rat;
    public GameObject thunderGhost;
    public GameObject bossEnemy;

    public GameObject cureSpell;
    public GameObject windSpell;
    public GameObject iceSpell;
    public GameObject thunderSpell;
    public GameObject swordSlash;

    private Vector3 enemyPos1;
    private Vector3 enemyPos2;
    private Vector3 enemyPos3;

    private Warrior mainCharacter1;
    private Ninja mainCharacter2;
    private Mage mainCharacter3;

    private Enemy enemy1;
    private Enemy enemy2;
    private Enemy enemy3;

    private Character[] characters;
    private Character[] turnBasedSystem;

    private bool newRoundOfTurns;

    private Character currentTurnCharacter;
    private int turnCharacterIndex;

    private Character attackTarget;
    private Character healTarget;

    private bool windAttack;
    private bool iceAttack;
    private bool thunderAttack;

    private int multiplier;

    private Vector3 turnCharacterIndicatorPos;
    private Vector3 attackTargetIndicatorPos;
    private Vector3 healTargetIndicatorPos;
    private Vector3 deathIconIndicatorPos;

    private int amountOfPartyCharacters;
    private int amountOfEnemies;
    private int enemiesDefeated;
    private int playerCharactersDefeated;

    private bool attackSelect;
    private bool spellSelect;
    private bool healSelect;
    private bool inventorySelect;
    private bool enemy1Select;
    private bool enemy2Select;
    private bool enemy3Select;
    private bool character1Select;
    private bool character2Select;
    private bool character3Select;

    private bool character1Defend;
    private bool character2Defend;
    private bool character3Defend;

    private bool character1Charge;
    private bool character2Charge;
    private bool character3Charge;

    private bool playerTurn;
    private bool enemyTurn;

    private float enemyTurnTimer;

    private bool initialTargetSelected;

    private float randomNumber;

    private int mainCharacter1Att;
    private int mainCharacter2Att;
    private int mainCharacter3Att;

    private int mainCharacter1MagAtt;
    private int mainCharacter2MagAtt;
    private int mainCharacter3MagAtt;

    private int mainCharacter1Def;
    private int mainCharacter2Def;
    private int mainCharacter3Def;

    private int mainCharacter1MagDef;
    private int mainCharacter2MagDef;
    private int mainCharacter3MagDef;

    private bool healthPotionSelect;
    private bool mpPotionSelect;

    private bool itemUsed;

    private GameObject indicator1Clone;
    private GameObject indicator2Clone;

    private GameObject greenGoblinClone;
    private GameObject ratClone;
    private GameObject thunderGhostClone;

    private float animationTimer;
    private bool animationOccuring;

    private bool boss;
    private GameObject bossClone;
    private bool bossSelect;
    private Vector3 bossPosition;
    private BossEnemy bossEnemy1;
    private string[] gAAttacks;
    private string attackSelected;
    private string[] previousAttacks;
    private int prevAttacksIndex;

    private string bossEncountered;

    public GameObject normalBattleMusic;
    public GameObject bossBattleMusic;


    // Use this for initialization
	void Start () {
        mainCharacter1 = new Warrior();
        mainCharacter2 = new Ninja();
        mainCharacter3 = new Mage();

        enemy1 = new GreenGoblin();
        enemy2 = new Rat();
        enemy3 = new ThunderGhost();

        characters = new Character[6];
        characters[0] = mainCharacter1;
        characters[1] = mainCharacter2;
        characters[2] = mainCharacter3;
        characters[3] = enemy1;
        characters[4] = enemy2;
        characters[5] = enemy3;

        turnBasedSystem = new Character[6];

        newRoundOfTurns = true;

        currentTurnCharacter = new Character();
        turnCharacterIndex = 0;

        attackTarget = new Character();
        healTarget = new Character();

        multiplier = 15;

        windAttack = false;
        iceAttack = false;
        thunderAttack = false;

        enemyPos1 = new Vector3(-4.31f, -0.31f, 0);
        enemyPos2 = new Vector3(-4.44f, -1.85f, 0);
        enemyPos3 = new Vector3(-7.75f, -1.13f, 0);

        enemy1.SetPosition(enemyPos1);
        enemy2.SetPosition(enemyPos2);
        enemy3.SetPosition(enemyPos3);

        greenGoblinClone = Instantiate(greenGoblin, enemyPos1, Quaternion.identity);
        ratClone = Instantiate(rat, enemyPos2, Quaternion.identity);
        thunderGhostClone = Instantiate(thunderGhost, enemyPos3, Quaternion.identity);

        turnCharacterIndicatorPos = new Vector3(0, 0, 0);
        attackTargetIndicatorPos = new Vector3(0, 0, 0);

        healTargetIndicatorPos = new Vector3(0, 0, 0);

        deathIconIndicatorPos = new Vector3(0, 0, 0);

        amountOfPartyCharacters = 3;
        amountOfEnemies = 3;
        enemiesDefeated = 0;
        playerCharactersDefeated = 0;

        attackSelect = false;
        spellSelect = false;
        healSelect = false;
        inventorySelect = false;
        enemy1Select = false;
        enemy2Select = false;
        enemy3Select = false;
        character1Select = false;
        character2Select = false;
        character3Select = false;

        character1Defend = false;
        character2Defend = false;
        character3Defend = false;

        character1Charge = false;
        character2Charge = false;
        character3Charge = false;

        playerTurn = false;
        enemyTurn = false;

        enemyTurnTimer = 0.0f;

        initialTargetSelected = false;

        randomNumber = 0.0f;

        mainCharacter1Att = mainCharacter1.GetAttack();
        mainCharacter2Att = mainCharacter2.GetAttack();
        mainCharacter3Att = mainCharacter3.GetAttack();

        mainCharacter1MagAtt = mainCharacter1.GetMagicAttack();
        mainCharacter2MagAtt = mainCharacter2.GetMagicAttack();
        mainCharacter3MagAtt = mainCharacter3.GetMagicAttack();

        mainCharacter1Def = mainCharacter1.GetDefense();
        mainCharacter2Def = mainCharacter2.GetDefense();
        mainCharacter3Def = mainCharacter3.GetDefense();

        mainCharacter1MagDef = mainCharacter1.GetMagicDefense();
        mainCharacter2MagDef = mainCharacter2.GetMagicDefense();
        mainCharacter3MagDef = mainCharacter3.GetMagicDefense();

        healthPotionSelect = false;
        mpPotionSelect = false;

        itemUsed = false;

        spellMenu.SetActive(false);
        inventoryMenu.SetActive(false);

        enemy1Button.SetActive(false);
        enemy2Button.SetActive(false);
        enemy3Button.SetActive(false);
        warriorButton.SetActive(false);
        ninjaButton.SetActive(false);
        mageButton.SetActive(false);

        indicator1Clone = Instantiate(indicator, new Vector3(0, 0, 0), Quaternion.identity);
        indicator2Clone = Instantiate(indicator2);

        animationTimer = 0.0f;
        animationOccuring = false;

        boss = false;
        bossSelect = false;
        bossEnemy1 = new BossEnemy();
        bossPosition = new Vector3(-7.3f, -0.57f, 0.0f);
        bossEnemy1.SetPosition(bossPosition);
        bossClone = Instantiate(bossEnemy);
        gAAttacks = new string[4];
        attackSelected = "";
        previousAttacks = new string[5];
        prevAttacksIndex = 0;

        bossEncountered = "";

        normalBattleMusic.SetActive(false);
        bossBattleMusic.SetActive(false);

        ReadStatsFile();

        ReadBossEnemyFile();
        if(bossEncountered == "true")
        {
            boss = true;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if ((GameOver() != true) && (Victory() != true))
        { 

            SetText();

            if(boss == true)
            {
                bossBattleMusic.SetActive(true);

                amountOfEnemies = 1;

                if(greenGoblinClone != null)
                {
                    Destroy(greenGoblinClone);
                }
                else if(ratClone != null)
                {
                    Destroy(ratClone);
                }
                else if(thunderGhostClone != null)
                {
                    Destroy(thunderGhostClone);
                }

                characters[3] = bossEnemy1;
                characters[4] = null;
                characters[5] = null;
            }
            else
            {
                normalBattleMusic.SetActive(true);

                if (bossClone != null)
                {
                    Destroy(bossClone);
                }
            }

            if (animationOccuring == true)
            {
                animationTimer += Time.deltaTime;

                if (animationTimer > 1)
                {
                    animationOccuring = false;
                    animationTimer = 0.0f;
                }
            }
            else
            {

                if (turnCharacterIndex == 6)
                {
                    newRoundOfTurns = true;
                }

                if (newRoundOfTurns == true)
                {
                    for (int l = 0; l < 6; l++)
                    {
                        turnBasedSystem[l] = new Character();
                    }

                    for (int turns = 0; turns < 6;)
                    {
                        Character turnCharacter = new Character();
                        int currentAmountOfCharacters = ((amountOfPartyCharacters - playerCharactersDefeated) + (amountOfEnemies - enemiesDefeated));
                        //Debug.Log(currentAmountOfCharacters);
                        for (int i = 0; i < currentAmountOfCharacters; i++)
                        {
                            //Debug.Log("i = " + i);
                            int bestSpeed = 0;
                            int amountOfCharacters = amountOfPartyCharacters + amountOfEnemies;
                            //Debug.Log(amountOfCharacters);
                            for (int j = 0; j < amountOfCharacters; j++)
                            {
                                //Debug.Log("j = " + j);
                                //Debug.Log(characters[j]);
                                //Debug.Log(characters[j].GetSpeed());
                                if (characters[j] != null)
                                {
                                    if ((characters[j].GetSpeed() > bestSpeed) && (characters[j].GetCurrentHp() > 0))
                                    {
                                        bool hasTurn = false;
                                        for (int k = 0; k < currentAmountOfCharacters; k++)
                                        {
                                            //Debug.Log("Current character = " + characters[j].GetType());
                                            //Debug.Log(turnBasedSystem[k]);
                                            if ((turnBasedSystem[k] != null) && (turnBasedSystem[k].GetType().Equals(characters[j].GetType())))
                                            {
                                                hasTurn = true;
                                            }
                                        }

                                        //Debug.Log(hasTurn);

                                        if (hasTurn == false)
                                        {
                                            turnCharacter = characters[j];
                                            bestSpeed = characters[j].GetSpeed();
                                        }
                                    }
                                }
                            }
                            //Debug.Log(turnCharacter);
                            //Debug.Log("turns = " + turns);
                            turnBasedSystem[turns] = turnCharacter;
                            turns++;
                        }
                        Debug.Log("Turn list = " + turnBasedSystem[0] + " " + turnBasedSystem[1] + " " + turnBasedSystem[2] + " " + turnBasedSystem[3] + " " + turnBasedSystem[4] + " " + turnBasedSystem[5]);

                        while (turns < 6)
                        {
                            //Debug.Log("extra turns needed");
                            int currentAmountTurns = turns;
                            int bestSpeed2 = 0;
                            for (int i = 0; ((i < currentAmountOfCharacters) && (turns < 6)); i++)
                            {
                                int amountOfCharacters = amountOfPartyCharacters + amountOfEnemies;
                                for (int j = 0; ((j < amountOfCharacters) && (turns < 6)); j++)
                                {
                                    if (characters[j] != null)
                                    {
                                        //Debug.Log(j);
                                        if ((characters[j].GetSpeed() > bestSpeed2) && (characters[j].GetCurrentHp() > 0))
                                        {
                                            bool hasTurn = false;
                                            for (int k = turns - i; k < currentAmountTurns + i + 1 || k < 6; k++)
                                            {
                                                if ((turnBasedSystem[k] != null) && (turnBasedSystem[k].GetType().Equals(characters[j].GetType())))
                                                {
                                                    hasTurn = true;
                                                }
                                            }

                                            if (hasTurn == false)
                                            {
                                                turnCharacter = characters[j];
                                                bestSpeed2 = characters[j].GetSpeed();
                                            }
                                        }
                                    }
                                }
                                turnBasedSystem[turns] = turnCharacter;
                                turns++;
                            }
                            //Debug.Log("Turn list = " + turnBasedSystem[0] + " " + turnBasedSystem[1] + " " + turnBasedSystem[2] + " " + turnBasedSystem[3] + " " + turnBasedSystem[4] + " " + turnBasedSystem[5]);
                        }
                    }
                    newRoundOfTurns = false;
                    turnCharacterIndex = 0;
                }
                // Finished doing turns

                while(turnBasedSystem[turnCharacterIndex].GetCurrentHp() <= 0)
                {
                    turnCharacterIndex++;
                }

                //Debug.Log("Turn list = " + turnBasedSystem[0] + " " + turnBasedSystem[1] + " " + turnBasedSystem[2] + " " + turnBasedSystem[3] + " " + turnBasedSystem[4] + " " + turnBasedSystem[5]);
                currentTurnCharacter = turnBasedSystem[turnCharacterIndex];
                // Debug.Log("currentTurnCharacter = " + currentTurnCharacter);
                turnCharacterIndicatorPos = new Vector3(currentTurnCharacter.GetPosition().x,
                    currentTurnCharacter.GetPosition().y + 1.3f, currentTurnCharacter.GetPosition().z);
                indicator1Clone.transform.position = turnCharacterIndicatorPos;

                playerTurn = false;
                enemyTurn = false;

                // Check wether it is player or enemy turn
                if ((currentTurnCharacter.GetType().Equals(typeof(Warrior))) || (currentTurnCharacter.GetType().Equals(typeof(Ninja))) || (currentTurnCharacter.GetType().Equals(typeof(Mage))))
                {
                    playerTurn = true;
                    //Debug.Log("Player's turn");
                }
                else
                {
                    enemyTurn = true;
                    //Debug.Log("Enemy's turn");
                }

                // Enemy or Player turn actions
                if (enemyTurn == true)
                {
                    attackSelect = false;
                    spellSelect = false;
                    healSelect = false;
                    windAttack = false;
                    iceAttack = false;
                    thunderAttack = false;
                    healthPotionSelect = false;
                    mpPotionSelect = false;


                    if (indicator2Clone != null)
                    {
                        Destroy(indicator2Clone);
                    }

                    enemyTurnTimer += Time.deltaTime;

                    if (enemyTurnTimer >= 3)
                    {
                        attackTarget = new Character();
                        while (attackTarget.GetCurrentHp() <= 0)
                        {
                            randomNumber = Random.Range(0.0f, 10.0f);
                            if (randomNumber <= 3.33)
                            {
                                attackTarget = mainCharacter1;
                            }
                            else if (randomNumber <= 6.66)
                            {
                                attackTarget = mainCharacter2;
                            }
                            else
                            {
                                attackTarget = mainCharacter3;
                            }
                        }

                        if (boss == true)
                        {
                            for(int attackIndex = 0; attackIndex < 4; attackIndex++)
                            {
                                gAAttacks[attackIndex] = null;
                            }
                            GASelectTarget();
                            RunBossGA();
                            BossAttack();
                        }
                        else
                        {
                            if (currentTurnCharacter.GetType().Equals(typeof(ThunderGhost)))
                            {
                                thunderAttack = true;
                                iceAttack = false;
                                windAttack = false;
                                MagicAttack();
                            }
                            else
                            {
                                Attack();
                            }
                        }
                    }
                }
                else if (playerTurn == true)
                {
                    if (initialTargetSelected == false)
                    {
                        SelectInitialTarget();
                    }

                    enemyTurnTimer = 0f;

                    if ((attackSelect == true) || (spellSelect == true) || (healSelect == true) || (inventorySelect == true))
                    {
                        if (indicator2Clone == null)
                        {
                            indicator2Clone = Instantiate(indicator2);
                        }

                        if ((attackSelect == true) || (spellSelect == true))
                        {
                            if (enemy1Select == true)
                            {
                                attackTargetIndicatorPos = new Vector3(enemy1.GetPosition().x,
                                    enemy1.GetPosition().y + 1.3f, enemy1.GetPosition().z);
                                indicator2Clone.transform.position = attackTargetIndicatorPos;
                            }
                            else if (enemy2Select == true)
                            {
                                attackTargetIndicatorPos = new Vector3(enemy2.GetPosition().x,
                                    enemy2.GetPosition().y + 1.3f, enemy2.GetPosition().z);
                                indicator2Clone.transform.position = attackTargetIndicatorPos;
                            }
                            else if (enemy3Select == true)
                            {
                                attackTargetIndicatorPos = new Vector3(enemy3.GetPosition().x,
                                    enemy3.GetPosition().y + 1.3f, enemy3.GetPosition().z);
                                indicator2Clone.transform.position = attackTargetIndicatorPos;
                            }
                            else if (bossSelect == true)
                            {
                                attackTargetIndicatorPos = new Vector3(bossEnemy1.GetPosition().x,
                                    bossEnemy1.GetPosition().y + 1.3f, bossEnemy1.GetPosition().z);
                                indicator2Clone.transform.position = attackTargetIndicatorPos;
                            }
                        }
                        else
                        {
                            if (character1Select == true)
                            {
                                healTargetIndicatorPos = new Vector3(mainCharacter1.GetPosition().x,
                                    mainCharacter1.GetPosition().y + 1.3f, mainCharacter1.GetPosition().z);
                                indicator2Clone.transform.position = healTargetIndicatorPos;
                            }
                            else if (character2Select == true)
                            {
                                healTargetIndicatorPos = new Vector3(mainCharacter2.GetPosition().x,
                                    mainCharacter2.GetPosition().y + 1.3f, mainCharacter2.GetPosition().z);
                                indicator2Clone.transform.position = healTargetIndicatorPos;
                            }
                            else if (character3Select == true)
                            {
                                healTargetIndicatorPos = new Vector3(mainCharacter3.GetPosition().x,
                                    mainCharacter3.GetPosition().y + 1.3f, mainCharacter3.GetPosition().z);
                                indicator2Clone.transform.position = healTargetIndicatorPos;
                            }
                        }
                    }
                }
            }
        }
        else if(Victory() == true)
        {
            if(mainCharacter1.GetCurrentHp() > 0)
            {
                mainCharacter1.SetExperiencePoints(mainCharacter1.GetExperiencePoints() +
                    enemy1.GetExperienceAwarded() + enemy2.GetExperienceAwarded() + enemy3.GetExperienceAwarded());
                if(mainCharacter1.GetExperienceNeeded() <= mainCharacter1.GetExperiencePoints())
                {
                    mainCharacter1.LevelUp();
                }
            }

            if (mainCharacter2.GetCurrentHp() > 0)
            {
                mainCharacter2.SetExperiencePoints(mainCharacter2.GetExperiencePoints() +
                    enemy1.GetExperienceAwarded() + enemy2.GetExperienceAwarded() + enemy3.GetExperienceAwarded());
                if (mainCharacter2.GetExperienceNeeded() <= mainCharacter2.GetExperiencePoints())
                {
                    mainCharacter2.LevelUp();
                }
            }

            if (mainCharacter3.GetCurrentHp() > 0)
            {
                mainCharacter3.SetExperiencePoints(mainCharacter3.GetExperiencePoints() +
                    enemy1.GetExperienceAwarded() + enemy2.GetExperienceAwarded() + enemy3.GetExperienceAwarded());
                if (mainCharacter3.GetExperienceNeeded() <= mainCharacter3.GetExperiencePoints())
                {
                    mainCharacter3.LevelUp();
                }
            }

            mainCharacter1.SetCurrentHp(mainCharacter1.GetMaxHp());
            mainCharacter2.SetCurrentHp(mainCharacter2.GetMaxHp());
            mainCharacter3.SetCurrentHp(mainCharacter3.GetMaxHp());
            mainCharacter3.SetCurrentMp(mainCharacter3.GetMaxMp());

            WriteToStatsFile();

            if(boss == true)
            {
                WriteToBossFile(true);
            }

            SceneManager.LoadScene("WorldMap");
        }
        else if(GameOver() == true)
        {
            if(boss == true)
            {
                WriteToBossFile(false);
            }

            SceneManager.LoadScene("GameOver");
        }
    }

    public bool GameOver()
    { 
        if(amountOfPartyCharacters == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Victory()
    {
        if (amountOfEnemies == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Attack()
    {
        Debug.Log("Attacking");

        int damage = ((currentTurnCharacter.GetAttack() * multiplier) - attackTarget.GetDefense());
        attackTarget.SetCurrentHp(attackTarget.GetCurrentHp() - damage);

        Debug.Log("attack target = " + attackTarget);
        Debug.Log("Physical damage done = " + damage);

        turnCharacterIndex++;
        if (attackTarget.GetCurrentHp() <= 0)
        {
            Defeated(attackTarget);
        }
        initialTargetSelected = false;
        ClearDefenses();
        ClearCharges();

        var swordSlashAnimation = Instantiate(swordSlash, attackTarget.GetPosition(), Quaternion.identity);
        animator = swordSlashAnimation.GetComponent<Animator>();
        animator.SetBool("slashActive", true);
        Destroy(swordSlashAnimation, 1.0f);

        warriorButton.SetActive(false);
        ninjaButton.SetActive(false);
        mageButton.SetActive(false);

        enemy1Button.SetActive(false);
        enemy2Button.SetActive(false);
        enemy3Button.SetActive(false);

        animationOccuring = true;
    }

    public void MagicAttack()
    {
        int damage = 0;
        int result = ((currentTurnCharacter.GetMagicAttack() * multiplier) - attackTarget.GetMagicDefense());
        if (windAttack == true)
        {
            damage = result - (result * (attackTarget.GetWindResistance() / 100));
            attackTarget.SetCurrentHp(damage);
            currentTurnCharacter.SetCurrentMp(currentTurnCharacter.GetCurrentMp() - 30);
            windAttack = false;
            var windAttackAnimation = Instantiate(windSpell, attackTarget.GetPosition(), Quaternion.identity);
            animator = windAttackAnimation.GetComponent<Animator>();
            animator.SetBool("windActive", true);
            Destroy(windAttackAnimation, 1.0f);
        }
        else if(iceAttack == true)
        {
            damage = result - (result * (attackTarget.GetIceResistance() / 100));
            attackTarget.SetCurrentHp(damage);
            currentTurnCharacter.SetCurrentMp(currentTurnCharacter.GetCurrentMp() - 30);
            iceAttack = false;
            var iceAttackAnimation = Instantiate(iceSpell, attackTarget.GetPosition(), Quaternion.identity);
            animator = iceAttackAnimation.GetComponent<Animator>();
            animator.SetBool("iceActive", true);
            Destroy(iceAttackAnimation, 1.0f);
        }
        else if(thunderAttack == true)
        {
            damage = result - (result * (attackTarget.GetThunderResistance() / 100));
            attackTarget.SetCurrentHp(damage);
            currentTurnCharacter.SetCurrentMp(currentTurnCharacter.GetCurrentMp() - 30);
            thunderAttack = false;
            var thunderAttackAnimation = Instantiate(thunderSpell, attackTarget.GetPosition(), Quaternion.identity);
            animator = thunderAttackAnimation.GetComponent<Animator>();
            animator.SetBool("thunderActive", true);
            Destroy(thunderAttackAnimation, 1.0f);
        }
        turnCharacterIndex++;
        if (attackTarget.GetCurrentHp() <= 0)
        {
            Defeated(attackTarget);
        }
        initialTargetSelected = false;
        ClearDefenses();
        ClearCharges();

        warriorButton.SetActive(false);
        ninjaButton.SetActive(false);
        mageButton.SetActive(false);

        enemy1Button.SetActive(false);
        enemy2Button.SetActive(false);
        enemy3Button.SetActive(false);

        animationOccuring = true;
    }

    public void Heal()
    {
        int amountHealed = 101 * currentTurnCharacter.GetLevel();
        healTarget.SetCurrentHp(healTarget.GetCurrentHp() + amountHealed);
        if(healTarget.GetCurrentHp() > healTarget.GetMaxHp())
        {
            healTarget.SetCurrentHp(healTarget.GetMaxHp());
        }
        currentTurnCharacter.SetCurrentMp(currentTurnCharacter.GetCurrentMp() - 30);
        turnCharacterIndex++;
        initialTargetSelected = false;
        ClearDefenses();
        ClearCharges();

        var cureSpellAnimation = Instantiate(cureSpell, healTarget.GetPosition(), Quaternion.identity);
        animator = cureSpellAnimation.GetComponent<Animator>();
        animator.SetBool("cureActive", true);
        Destroy(cureSpellAnimation, 1.0f);

        enemy1Button.SetActive(false);
        enemy2Button.SetActive(false);
        enemy3Button.SetActive(false);

        warriorButton.SetActive(false);
        ninjaButton.SetActive(false);
        mageButton.SetActive(false);

        animationOccuring = true;
    }

    public void Defend()
    {
        if (playerTurn == true)
        {
            if (currentTurnCharacter == mainCharacter1)
            {
                mainCharacter1.SetDefense(mainCharacter1.GetDefense() + 10);
                mainCharacter1.SetMagicDefense(mainCharacter1.GetMagicDefense() + 10);
                character1Defend = true;
            }
            else if (currentTurnCharacter == mainCharacter2)
            {
                mainCharacter2.SetDefense(mainCharacter2.GetDefense() + 10);
                mainCharacter2.SetMagicDefense(mainCharacter2.GetMagicDefense() + 10);
                character2Defend = true;
            }
            else if (currentTurnCharacter == mainCharacter3)
            {
                mainCharacter3.SetDefense(mainCharacter3.GetDefense() + 10);
                mainCharacter3.SetMagicDefense(mainCharacter3.GetMagicDefense() + 10);
                character3Defend = true;
            }
            turnCharacterIndex++;
            initialTargetSelected = false;
            ClearCharges();
            spellMenu.SetActive(false);
            inventoryMenu.SetActive(false);

            enemy1Button.SetActive(false);
            enemy2Button.SetActive(false);
            enemy3Button.SetActive(false);

            warriorButton.SetActive(false);
            ninjaButton.SetActive(false);
            mageButton.SetActive(false);
        }
    }

    public void HealthPotion()
    {
        healTarget.SetCurrentHp(healTarget.GetCurrentHp() + 500);
        if (healTarget.GetCurrentHp() > healTarget.GetMaxHp())
        {
            healTarget.SetCurrentHp(healTarget.GetMaxHp());
        }
        turnCharacterIndex++;
        initialTargetSelected = false;
        ClearDefenses();
        ClearCharges();

        enemy1Button.SetActive(false);
        enemy2Button.SetActive(false);
        enemy3Button.SetActive(false);

        warriorButton.SetActive(false);
        ninjaButton.SetActive(false);
        mageButton.SetActive(false);

        var cureSpellAnimation = Instantiate(cureSpell, healTarget.GetPosition(), Quaternion.identity);
        animator = cureSpellAnimation.GetComponent<Animator>();
        animator.SetBool("cureActive", true);
        Destroy(cureSpellAnimation, 1.0f);

        animationOccuring = true;
    }

    public void MpPotion()
    {
        healTarget.SetCurrentMp(healTarget.GetCurrentMp() + 90);
        if (healTarget.GetCurrentMp() > healTarget.GetMaxMp())
        {
            healTarget.SetCurrentMp(healTarget.GetMaxMp());
        }
        turnCharacterIndex++;
        initialTargetSelected = false;
        ClearDefenses();
        ClearCharges();

        enemy1Button.SetActive(false);
        enemy2Button.SetActive(false);
        enemy3Button.SetActive(false);

        warriorButton.SetActive(false);
        ninjaButton.SetActive(false);
        mageButton.SetActive(false);

        var cureSpellAnimation = Instantiate(cureSpell, healTarget.GetPosition(), Quaternion.identity);
        animator = cureSpellAnimation.GetComponent<Animator>();
        animator.SetBool("cureActive", true);
        Destroy(cureSpellAnimation, 1.0f);

        animationOccuring = true;
    }

    public void Charge()
    {
        if (playerTurn == true)
        {
            if (currentTurnCharacter == mainCharacter1)
            {
                mainCharacter1.SetAttack(mainCharacter1.GetAttack() + 10);
                mainCharacter1.SetMagicAttack(mainCharacter1.GetMagicAttack() + 10);
                character1Charge = true;
            }
            else if (currentTurnCharacter == mainCharacter2)
            {
                mainCharacter2.SetAttack(mainCharacter2.GetAttack() + 10);
                mainCharacter2.SetMagicAttack(mainCharacter2.GetMagicAttack() + 10);
                character2Charge = true;
            }
            else if (currentTurnCharacter == mainCharacter3)
            {
                mainCharacter3.SetAttack(mainCharacter3.GetAttack() + 10);
                mainCharacter3.SetMagicAttack(mainCharacter3.GetMagicAttack() + 10);
                character3Charge = true;
            }
            turnCharacterIndex++;
            initialTargetSelected = false;
            ClearDefenses();

            enemy1Button.SetActive(false);
            enemy2Button.SetActive(false);
            enemy3Button.SetActive(false);

            warriorButton.SetActive(false);
            ninjaButton.SetActive(false);
            mageButton.SetActive(false);
        }
    }

    public void Escape()
    {
        randomNumber = Random.Range(0.0f, 10.0f);
        if (randomNumber <= 3.33)
        {
            mainCharacter1.SetCurrentHp(mainCharacter1.GetMaxHp());
            mainCharacter2.SetCurrentHp(mainCharacter2.GetMaxHp());
            mainCharacter3.SetCurrentHp(mainCharacter3.GetMaxHp());
            mainCharacter3.SetCurrentMp(mainCharacter3.GetMaxMp());
            SceneManager.LoadScene("WorldMap");
        }
        else
        {
            turnCharacterIndex++;

            initialTargetSelected = false;

            ClearDefenses();
            ClearCharges();

            enemy1Button.SetActive(false);
            enemy2Button.SetActive(false);
            enemy3Button.SetActive(false);

            warriorButton.SetActive(false);
            ninjaButton.SetActive(false);
            mageButton.SetActive(false);
        }
    }

    public void Enemy1Attack()
    {
        if (attackSelect == true)
        {
            if (enemy1Select == true)
            {
                Debug.Log("Enemy1 going to get attacked");
                Attack();
            }
            else if (enemy1.GetCurrentHp() > 0)
            {
                attackTarget = enemy1;
                enemy1Select = true;
                enemy2Select = false;
                enemy3Select = false;
            }
        }
        else if(spellSelect == true)
        {
            if (currentTurnCharacter.GetCurrentMp() >= 30)
            {
                if (enemy1Select == true)
                {
                    MagicAttack();
                }
                else if (enemy1.GetCurrentHp() > 0)
                {
                    attackTarget = enemy1;
                    enemy1Select = true;
                    enemy2Select = false;
                    enemy3Select = false;
                }
            }
        }
    }

    public void Enemy2Attack()
    {
        if (attackSelect == true)
        {
            if (enemy2Select == true)
            {
                Attack();
            }
            else if (enemy2.GetCurrentHp() > 0)
            {
                attackTarget = enemy2;
                enemy2Select = true;
                enemy1Select = false;
                enemy3Select = false;
            }
        }
        else if (spellSelect == true)
        {
            if (currentTurnCharacter.GetCurrentMp() >= 30)
            {
                if (enemy2Select == true)
                {
                    MagicAttack();
                }
                else if (enemy2.GetCurrentHp() > 0)
                {
                    attackTarget = enemy2;
                    enemy2Select = true;
                    enemy1Select = false;
                    enemy3Select = false;
                }
            }
        }
    }

    public void Enemy3Attack()
    {
        if (attackSelect == true)
        {
            if (enemy3Select == true)
            {
                Attack();
            }
            else if (enemy3.GetCurrentHp() > 0)
            {
                attackTarget = enemy3;
                enemy3Select = true;
                enemy1Select = false;
                enemy2Select = false;
            }
        }
        else if (spellSelect == true)
        {
            if (currentTurnCharacter.GetCurrentMp() >= 30)
            {
                if (enemy3Select == true)
                {
                    MagicAttack();
                }
                else if (enemy3.GetCurrentHp() > 0)
                {
                    attackTarget = enemy3;
                    enemy3Select = true;
                    enemy1Select = false;
                    enemy3Select = false;
                }
            }
        }
    }

    public void BossSelect()
    {
        if (attackSelect == true)
        {
            if (bossSelect == true)
            {
                Attack();
            }
            else if (bossEnemy1.GetCurrentHp() > 0)
            {
                attackTarget = bossEnemy1;
                bossSelect = true;
            }
        }
        else if (spellSelect == true)
        {
            if (bossSelect == true)
            {
                MagicAttack();
            }
            else if (bossEnemy1.GetCurrentHp() > 0)
            {
                attackTarget = bossEnemy1;
                bossSelect = true;
            }
        }
    }

    public void Character1Heal()
    {
        if (healSelect == true)
        {
            if (character1Select == true)
            {
                Heal();
            }
            else if (mainCharacter1.GetCurrentHp() > 0)
            {
                healTarget = mainCharacter1;
                character1Select = true;
                character2Select = false;
                character3Select = false;
            }
        }
        else if (inventorySelect == true)
        {
            if (character1Select == true)
            {
                if (healthPotionSelect == true)
                {
                    if (itemUsed == false)
                    {
                        itemUsed = true;
                    }
                    else
                    {
                        turnCharacterIndex++;
                        itemUsed = false;
                    }
                    //helathPotion effects
                    HealthPotion();
                }
                else if (mpPotionSelect == true)
                {
                    if (itemUsed == false)
                    {
                        itemUsed = true;
                    }
                    else
                    {
                        turnCharacterIndex++;
                        itemUsed = false;
                    }
                    //mpPotion effects
                    MpPotion();
                }
            }
            else if (mainCharacter1.GetCurrentHp() > 0)
            {
                healTarget = mainCharacter1;
                character1Select = true;
                character2Select = false;
                character3Select = false;
            }
        }
    }

    public void Character2Heal()
    {
        if (healSelect == true)
        {
            if (character2Select == true)
            {
                Heal();
            }
            else if (mainCharacter2.GetCurrentHp() > 0)
            {
                healTarget = mainCharacter2;
                character2Charge = true;
                character1Select = false;
                character3Select = false;
            }
        }
        else if (inventorySelect == true)
        {
            if (character2Select == true)
            {
                if (healthPotionSelect == true)
                {
                    if (itemUsed == false)
                    {
                        itemUsed = true;
                    }
                    else
                    {
                        turnCharacterIndex++;
                        itemUsed = false;
                    }
                    //helathPotion effects
                    HealthPotion();
                }
                else if (mpPotionSelect == true)
                {
                    if (itemUsed == false)
                    {
                        itemUsed = true;
                    }
                    else
                    {
                        turnCharacterIndex++;
                        itemUsed = false;
                    }
                    //mpPotion effects
                    MpPotion();
                }
            }
            else if (mainCharacter2.GetCurrentHp() > 0)
            {
                healTarget = mainCharacter2;
                character2Charge = true;
                character1Select = false;
                character3Select = false;
            }
        }
    }

    public void Character3Heal()
    {
        if (healSelect == true)
        {
            if (character3Select == true)
            {
                Heal();
            }
            else if (mainCharacter3.GetCurrentHp() > 0)
            {
                healTarget = enemy3;
                character3Select = true;
                character1Select = false;
                character2Select = false;
            }
        }
        else if(inventorySelect == true)
        {
            if (character3Select == true)
            {
                if (healthPotionSelect == true)
                {
                    if (itemUsed == false)
                    {
                        itemUsed = true;
                    }
                    else
                    {
                        turnCharacterIndex++;
                        itemUsed = false;
                    }
                    //helathPotion effects
                    HealthPotion();
                }
                else if (mpPotionSelect == true)
                {
                    if (itemUsed == false)
                    {
                        itemUsed = true;
                    }
                    else
                    {
                        turnCharacterIndex++;
                        itemUsed = false;
                    }
                    //mpPotion effects
                    MpPotion();
                }
            }
            else if (mainCharacter3.GetCurrentHp() > 0)
            {
                healTarget = mainCharacter3;
                character3Select = true;
                character1Select = false;
                character2Select = false;
            }
        }
    }

    public void ClearDefenses()
    {
        if (currentTurnCharacter == mainCharacter1)
        {
            if(character1Defend == true)
            {
                mainCharacter1.SetDefense(mainCharacter1Def);
                mainCharacter1.SetMagicDefense(mainCharacter1MagDef);
                character1Defend = false;
            }
        }
        else if (currentTurnCharacter == mainCharacter2)
        {
            if (character2Defend == true)
            {
                mainCharacter2.SetDefense(mainCharacter2Def);
                mainCharacter2.SetMagicDefense(mainCharacter2MagDef);
                character2Defend = false;
            }
        }
        else if (currentTurnCharacter == mainCharacter3)
        {
            if (character3Defend == true)
            {
                mainCharacter3.SetDefense(mainCharacter3Def);
                mainCharacter3.SetMagicDefense(mainCharacter3MagDef);
                character3Defend = false;
            }
        }
    }

    public void ClearCharges()
    {
        if (currentTurnCharacter == mainCharacter1)
        {
            if (character1Charge == true)
            {
                mainCharacter1.SetAttack(mainCharacter1Att);
                mainCharacter1.SetMagicAttack(mainCharacter1MagAtt);
                character1Charge = false;
            }
        }
        else if (currentTurnCharacter == mainCharacter2)
        {
            if (character2Charge == true)
            {
                mainCharacter2.SetAttack(mainCharacter2Att);
                mainCharacter2.SetMagicAttack(mainCharacter2MagAtt);
                character2Charge = false;
            }
        }
        else if (currentTurnCharacter == mainCharacter3)
        {
            if (character3Charge == true)
            {
                mainCharacter3.SetAttack(mainCharacter3Att);
                mainCharacter3.SetMagicAttack(mainCharacter3MagAtt);
                character3Charge = false;
            }
        }
    } 

    public void Defeated(Character target)
    {
        if((target.GetType().Equals(typeof(Warrior))) || (target.GetType().Equals(typeof(Ninja))) || (target.GetType().Equals(typeof(Mage))))
        {
            amountOfPartyCharacters -= 1;
        }
        else
        {
            amountOfEnemies -= 1;
        }
        deathIconIndicatorPos = new Vector3(target.GetPosition().x,
                target.GetPosition().y + 1.3f, target.GetPosition().z);
        Instantiate(deathIcon, deathIconIndicatorPos, Quaternion.identity);
    }

    public void SelectInitialTarget()
    {
        if (boss == true)
        {
            attackTarget = bossEnemy1;
            bossSelect = true;
        }
        else
        {

            if (enemy1.GetCurrentHp() > 0)
            {
                attackTarget = enemy1;
                enemy1Select = true;
                enemy2Select = false;
                enemy3Select = false;
            }
            else if (enemy2.GetCurrentHp() > 0)
            {
                attackTarget = enemy2;
                enemy2Select = true;
                enemy1Select = false;
                enemy3Select = false;
            }
            else if (enemy3.GetCurrentHp() > 0)
            {
                attackTarget = enemy3;
                enemy3Select = true;
                enemy1Select = false;
                enemy2Select = false;
            }
        }

        if (mainCharacter1.GetCurrentHp() > 0)
        {
            healTarget = mainCharacter1;
            character1Select = true;
            character2Select = false;
            character3Select = false;
        }
        else if (mainCharacter2.GetCurrentHp() > 0)
        {
            healTarget = mainCharacter2;
            character2Select = true;
            character1Select = false;
            character3Select = false;
        }
        else if (mainCharacter3.GetCurrentHp() > 0)
        {
            healTarget = mainCharacter3;
            character3Select = true;
            character1Select = false;
            character2Select = false;
        }
        initialTargetSelected = true;
    }

    public void SetText()
    {
        string character1Hp = "";
        if (mainCharacter1.GetCurrentHp() >= 0)
        {
            character1Hp = character1Hp + mainCharacter1.GetCurrentHp() + "/" + mainCharacter1.GetMaxHp();
        }
        else
        {
            character1Hp = character1Hp + 0 + "/" + mainCharacter1.GetMaxHp();
        }
        string character1Mp = "" + mainCharacter1.GetCurrentMp() + "/" + mainCharacter1.GetMaxMp();
        chara1HpText.GetComponent<Text>().text = character1Hp;
        chara1MpText.GetComponent<Text>().text = character1Mp;

        string character2Hp = "";
        if (mainCharacter2.GetCurrentHp() >= 0)
        {
            character2Hp = character2Hp + mainCharacter2.GetCurrentHp() + "/" + mainCharacter2.GetMaxHp();
        }
        else
        {
            character2Hp = "" + 0 + "/" + mainCharacter2.GetMaxHp();
        }
        string character2Mp = "" + mainCharacter2.GetCurrentMp() + "/" + mainCharacter2.GetMaxMp();
        chara2HpText.GetComponent<Text>().text = character2Hp;
        chara2MpText.GetComponent<Text>().text = character2Mp;

        string character3Hp = "";
        if (mainCharacter3.GetCurrentHp() >= 0)
        {
            character3Hp = character3Hp + mainCharacter3.GetCurrentHp() + "/" + mainCharacter3.GetMaxHp();
        }
        else
        {
            character3Hp = "" + 0 + "/" + mainCharacter3.GetMaxHp();
        }
        string character3Mp = "" + mainCharacter3.GetCurrentMp() + "/" + mainCharacter3.GetMaxMp();
        chara3HpText.GetComponent<Text>().text = character3Hp;
        chara3MpText.GetComponent<Text>().text = character3Mp;
    }

    public Character GetTurnCharacter()
    {
        return currentTurnCharacter;
    }

    public void AttackSelect()
    {
        attackSelect = true;
        spellSelect = false;
        healSelect = false;
        inventorySelect = false;
        healthPotionSelect = false;
        spellMenu.SetActive(false);
        inventoryMenu.SetActive(false);

        enemy1Button.SetActive(true);
        enemy2Button.SetActive(true);
        enemy3Button.SetActive(true);

        warriorButton.SetActive(false);
        ninjaButton.SetActive(false);
        mageButton.SetActive(false);
    }

    public void SpellSelect()
    {
        spellSelect = true;
        attackSelect = false;
        healSelect = false;
        inventorySelect = false;
        mpPotionSelect = false;
        windAttack = false;
        iceAttack = false;
        thunderAttack = false;
        spellMenu.SetActive(true);
        inventoryMenu.SetActive(false);

        enemy1Button.SetActive(true);
        enemy2Button.SetActive(true);
        enemy3Button.SetActive(true);

        warriorButton.SetActive(false);
        ninjaButton.SetActive(false);
        mageButton.SetActive(false);
    }

    public void HealSelect()
    {
        if (currentTurnCharacter.GetCurrentMp() >= 30)
        {
            healSelect = true;
            spellSelect = false;

            enemy1Button.SetActive(false);
            enemy2Button.SetActive(false);
            enemy3Button.SetActive(false);

            warriorButton.SetActive(true);
            ninjaButton.SetActive(true);
            mageButton.SetActive(true);
        }
    }

    public void InventorySelect()
    {
        inventorySelect = true;
        attackSelect = false;
        spellSelect = false;
        inventorySelect = false;
        inventoryMenu.SetActive(true);
        spellMenu.SetActive(false);

        enemy1Button.SetActive(false);
        enemy2Button.SetActive(false);
        enemy3Button.SetActive(false);

        warriorButton.SetActive(true);
        ninjaButton.SetActive(true);
        mageButton.SetActive(true);
    }

    public void HealthPotionSelect()
    {
        healthPotionSelect = true;
        mpPotionSelect = false;
        inventoryMenu.SetActive(false);
    }

    public void MpPotionSelect()
    {
        mpPotionSelect = true;
        healthPotionSelect = false;
        inventoryMenu.SetActive(false);
    }

    public void WindAttackSelect()
    {
        if (currentTurnCharacter.GetCurrentMp() >= 30)
        {
            windAttack = true;
            iceAttack = false;
            thunderAttack = false;
            spellMenu.SetActive(false);
        }
    }

    public void IceAttackSelect()
    {
        if (currentTurnCharacter.GetCurrentMp() >= 30)
        {
            iceAttack = true;
            windAttack = false;
            thunderAttack = false;
            spellMenu.SetActive(false);
        }
    }

    public void ThunderAttackSelect()
    {
        if (currentTurnCharacter.GetCurrentMp() >= 30)
        {
            thunderAttack = true;
            windAttack = false;
            thunderAttack = false;
            spellMenu.SetActive(false);
        }
    }

    public void SetBossEnemy()
    {
        boss = true;
    }

    public void SelectBoss()
    {
        bossSelect = true;
    }

    public void RunBossGA()
    {
        FitnessFunction();
        RouletteWheel();
    }

    public void GASelectTarget()
    {
        while (attackTarget.GetCurrentHp() <= 0)
        {
            randomNumber = Random.Range(0.0f, 10.0f);
            if (randomNumber <= 3.33)
            {
                attackTarget = mainCharacter1;
            }
            else if (randomNumber <= 6.66)
            {
                attackTarget = mainCharacter2;
            }
            else
            {
                attackTarget = mainCharacter3;
            }
        }
    }

    public void FitnessFunction()
    {
        for(int ga = 0; ga < 4; ga++)
        {
            int highestFitness = -9999;
            bool alreadySelected = false;

            for(int index = 0; index < 4; index++)
            {
                if((gAAttacks[index] != null) && (gAAttacks[index] == "attack"))
                {
                    alreadySelected = true;
                }
            }
            int physicalAttackDamage = ((currentTurnCharacter.GetAttack() * multiplier) - attackTarget.GetDefense());
            if((physicalAttackDamage > highestFitness) && (alreadySelected == false))
            {
                highestFitness = physicalAttackDamage;
                gAAttacks[ga] = "attack";
            }
            // need to check if phsycial attack is in attack list at the moment

            int result2 = (((currentTurnCharacter.GetMagicAttack() * multiplier) - attackTarget.GetMagicDefense()));
            Debug.Log("magic attack vs target magic defense = " + result2);
            Debug.Log("magic attack = " + currentTurnCharacter.GetMagicAttack());
            Debug.Log("target magic defense = " + attackTarget.GetMagicDefense());

            alreadySelected = false;
            for (int index = 0; index < 4; index++)
            {
                if ((gAAttacks[index] != null) && (gAAttacks[index] == "wind attack"))
                {
                    alreadySelected = true;
                }
            }
            int windAttackDamage = result2 - (result2 * (attackTarget.GetWindResistance() / 100));
            Debug.Log("damage - resistance = " + (result2 * (attackTarget.GetWindResistance() / 100)));
            Debug.Log(windAttackDamage);
            Debug.Log(alreadySelected);
            Debug.Log(highestFitness);
            if ((windAttackDamage > highestFitness) && (alreadySelected == false))
            {
                highestFitness = windAttackDamage;
                gAAttacks[ga] = "wind attack";
            }

            alreadySelected = false;
            for (int index = 0; index < 4; index++)
            {
                if ((gAAttacks[index] != null) && (gAAttacks[index] == "ice attack"))
                {
                    alreadySelected = true;
                }
            }
            int iceAttackDamage = result2 - (result2 * (attackTarget.GetIceResistance() / 100));
            if ((iceAttackDamage > highestFitness) && (alreadySelected == false)) 
            {
                highestFitness = iceAttackDamage;
                gAAttacks[ga] = "ice attack";
            }

            alreadySelected = false;
            for (int index = 0; index < 4; index++)
            {
                if ((gAAttacks[index] != null) && (gAAttacks[index] == "thunder attack"))
                {
                    alreadySelected = true;
                }
            }
            int thunderAttackDamage = result2 - (result2 * (attackTarget.GetThunderResistance() / 100));
            if ((thunderAttackDamage > highestFitness) && (alreadySelected == false))
            {
                highestFitness = thunderAttackDamage;
                gAAttacks[ga] = "thunder attack";
                Debug.Log("thunder attack is highest");
            }
            Debug.Log(gAAttacks[ga]);
        }
        Debug.Log(gAAttacks[0]);
        Debug.Log(gAAttacks[1]);
        Debug.Log(gAAttacks[2]);
        Debug.Log(gAAttacks[3]);
    }

    public void RouletteWheel()
    {
        for (bool attackOk = false; attackOk == false;)
        {
            randomNumber = Random.Range(0.0f, 10.0f);
            if (randomNumber <= 4.00)
            {
                attackSelected = gAAttacks[0];
            }
            else if (randomNumber <= 7.00)
            {
                attackSelected = gAAttacks[1];
            }
            else if (randomNumber <= 9.00)
            {
                attackSelected = gAAttacks[2];
            }
            else
            {
                attackSelected = gAAttacks[3];
            }

            int attackCount = 0;
            for(int prevAttIndex = 0; prevAttIndex < 4; prevAttIndex++)
            {
                if(previousAttacks[prevAttIndex] != null && previousAttacks[prevAttIndex] == attackSelected)
                {
                    attackCount++;
                }
            }
            if(attackCount < 3)
            {
                attackOk = true;
            }
        }
    }

    public void BossAttack()
    {
        Debug.Log("attack selected = " + attackSelected);

        if(prevAttacksIndex >= 4)
        {
            prevAttacksIndex = 0;
        }
        previousAttacks[prevAttacksIndex] = attackSelected;
        prevAttacksIndex++;

        if(attackSelected == "attack")
        {
            Attack();
        }
        else if(attackSelected == "wind attack")
        {
            WindAttackSelect();
            MagicAttack();
        }
        else if(attackSelected == "ice attack")
        {
            IceAttackSelect();
            MagicAttack();
        }
        else
        {
            ThunderAttackSelect();
            MagicAttack();
        }
    }

    public void ReadStatsFile()
    {
        string fileName = "Character1Stats.txt";
        string fileName2 = "Character2Stats.txt";
        string fileName3 = "Character3Stats.txt";

        StreamReader reader = new StreamReader(fileName);
        StreamReader reader2 = new StreamReader(fileName2);
        StreamReader reader3 = new StreamReader(fileName3);

        try
        {
            mainCharacter1.SetLevel(int.Parse(reader.ReadLine()));
            mainCharacter2.SetLevel(int.Parse(reader2.ReadLine()));
            mainCharacter3.SetLevel(int.Parse(reader3.ReadLine()));

            mainCharacter1.SetExperiencePoints(int.Parse(reader.ReadLine()));
            mainCharacter2.SetExperiencePoints(int.Parse(reader2.ReadLine()));
            mainCharacter3.SetExperiencePoints(int.Parse(reader3.ReadLine()));

            mainCharacter1.SetExperienceNeeded(int.Parse(reader.ReadLine()));
            mainCharacter2.SetExperienceNeeded(int.Parse(reader2.ReadLine()));
            mainCharacter3.SetExperienceNeeded(int.Parse(reader3.ReadLine()));

            mainCharacter1.SetMaxHp(int.Parse(reader.ReadLine()));
            mainCharacter2.SetMaxHp(int.Parse(reader2.ReadLine()));
            mainCharacter3.SetMaxHp(int.Parse(reader3.ReadLine()));

            mainCharacter3.SetMaxMp(int.Parse(reader3.ReadLine()));

            mainCharacter1.SetAttack(int.Parse(reader.ReadLine()));
            mainCharacter2.SetAttack(int.Parse(reader2.ReadLine()));
            mainCharacter3.SetAttack(int.Parse(reader3.ReadLine()));

            mainCharacter1.SetDefense(int.Parse(reader.ReadLine()));
            mainCharacter2.SetDefense(int.Parse(reader2.ReadLine()));
            mainCharacter3.SetDefense(int.Parse(reader3.ReadLine()));

            mainCharacter1.SetMagicAttack(int.Parse(reader.ReadLine()));
            mainCharacter2.SetMagicAttack(int.Parse(reader2.ReadLine()));
            mainCharacter3.SetMagicAttack(int.Parse(reader3.ReadLine()));

            mainCharacter1.SetMagicDefense(int.Parse(reader.ReadLine()));
            mainCharacter2.SetMagicDefense(int.Parse(reader2.ReadLine()));
            mainCharacter3.SetMagicDefense(int.Parse(reader3.ReadLine()));

            mainCharacter1.SetWindResistance(int.Parse(reader.ReadLine()));
            mainCharacter2.SetWindResistance(int.Parse(reader2.ReadLine()));
            mainCharacter3.SetWindResistance(int.Parse(reader3.ReadLine()));

            mainCharacter1.SetThunderResistance(int.Parse(reader.ReadLine()));
            mainCharacter2.SetThunderResistance(int.Parse(reader2.ReadLine()));
            mainCharacter3.SetThunderResistance(int.Parse(reader3.ReadLine()));

            mainCharacter1.SetAccuracy(int.Parse(reader.ReadLine()));
            mainCharacter2.SetAccuracy(int.Parse(reader2.ReadLine()));
            mainCharacter3.SetAccuracy(int.Parse(reader3.ReadLine()));

            mainCharacter1.SetSpeed(int.Parse(reader.ReadLine()));
            mainCharacter2.SetSpeed(int.Parse(reader2.ReadLine()));
            mainCharacter3.SetSpeed(int.Parse(reader3.ReadLine()));

            mainCharacter1.SetEvade(int.Parse(reader.ReadLine()));
            mainCharacter2.SetEvade(int.Parse(reader2.ReadLine()));
            mainCharacter3.SetEvade(int.Parse(reader3.ReadLine()));
        }
        catch (System.Exception e)
        {
            Debug.Log("" + e.Message);
        }
        finally
        {
            reader.Close();
            reader2.Close();
            reader3.Close();
        }
    }

    public void WriteToStatsFile()
    {
        string fileName = "Character1Stats.txt";
        string fileName2 = "Character2Stats.txt";
        string fileName3 = "Character3Stats.txt";

        StreamWriter writer = new StreamWriter(Application.persistentDataPath + "/" + fileName, false);
        StreamWriter writer2 = new StreamWriter(Application.persistentDataPath + "/" + fileName2, false);
        StreamWriter writer3 = new StreamWriter(Application.persistentDataPath + "/" + fileName3, false);

        try
        {
            writer.WriteLine("" + mainCharacter1.GetLevel());
            writer2.WriteLine("" + mainCharacter2.GetLevel());
            writer3.WriteLine("" + mainCharacter3.GetLevel());

            writer.WriteLine("" + mainCharacter1.GetExperiencePoints());
            writer2.WriteLine("" + mainCharacter2.GetExperiencePoints());
            writer3.WriteLine("" + mainCharacter3.GetExperiencePoints());

            writer.WriteLine("" + mainCharacter1.GetExperienceNeeded());
            writer2.WriteLine("" + mainCharacter2.GetExperienceNeeded());
            writer2.WriteLine("" + mainCharacter3.GetExperienceNeeded());

            writer.WriteLine("" + mainCharacter1.GetMaxHp());
            writer2.WriteLine("" + mainCharacter2.GetMaxHp());
            writer3.WriteLine("" + mainCharacter3.GetMaxHp());

            writer3.WriteLine("" + mainCharacter3.GetMaxMp());

            writer.WriteLine("" + mainCharacter1.GetAttack());
            writer2.WriteLine("" + mainCharacter2.GetAttack());
            writer3.WriteLine("" + mainCharacter3.GetAttack());

            writer.WriteLine("" + mainCharacter1.GetDefense());
            writer2.WriteLine("" + mainCharacter2.GetDefense());
            writer3.WriteLine("" + mainCharacter3.GetDefense());

            writer.WriteLine("" + mainCharacter1.GetMagicAttack());
            writer2.WriteLine("" + mainCharacter2.GetMagicAttack());
            writer3.WriteLine("" + mainCharacter3.GetMagicAttack());

            writer.WriteLine("" + mainCharacter1.GetMagicDefense());
            writer2.WriteLine("" + mainCharacter2.GetMagicDefense());
            writer3.WriteLine("" + mainCharacter3.GetMagicDefense());

            writer.WriteLine("" + mainCharacter1.GetWindResistance());
            writer2.WriteLine("" + mainCharacter2.GetWindResistance());
            writer3.WriteLine("" + mainCharacter3.GetWindResistance());

            writer.WriteLine("" + mainCharacter1.GetIceResistance());
            writer2.WriteLine("" + mainCharacter2.GetIceResistance());
            writer3.WriteLine("" + mainCharacter3.GetIceResistance());

            writer.WriteLine("" + mainCharacter1.GetThunderResistance());
            writer2.WriteLine("" + mainCharacter2.GetThunderResistance());
            writer3.WriteLine("" + mainCharacter3.GetThunderResistance());

            writer.WriteLine("" + mainCharacter1.GetAccuracy());
            writer2.WriteLine("" + mainCharacter2.GetAccuracy());
            writer3.WriteLine("" + mainCharacter3.GetAccuracy());

            writer.WriteLine("" + mainCharacter1.GetSpeed());
            writer2.WriteLine("" + mainCharacter2.GetSpeed());
            writer3.WriteLine("" + mainCharacter3.GetSpeed());

            writer.WriteLine("" + mainCharacter1.GetEvade());
            writer2.WriteLine("" + mainCharacter2.GetEvade());
            writer3.WriteLine("" + mainCharacter3.GetEvade());
        }
        catch (System.Exception e)
        {
            Debug.Log("" + e.Message);
        }
        finally
        {
            writer.Close();
            writer2.Close();
            writer3.Close();
        }

        //AssetDatabase.Refresh();
    }

    public void ReadBossEnemyFile()
    {
        string fileName = "BossEnemy.txt";

        StreamReader reader = new StreamReader(Application.persistentDataPath + "/" + fileName);

        try
        {
            reader.ReadLine();
            bossEncountered = reader.ReadLine();
        }
        catch (System.Exception e)
        {
            Debug.Log("" + e.Message);
        }
        finally
        {
            reader.Close();
        }
    }

    public void WriteToBossFile(bool victory)
    {
        string fileName = "BossEnemy.txt";

        StreamWriter writer = new StreamWriter(Application.persistentDataPath + "/" + fileName, false);

        try
        {
            writer.WriteLine("" + victory);
            writer.WriteLine("false");
        }
        catch (System.Exception e)
        {
            Debug.Log("" + e.Message);
        }
        finally
        {
            writer.Close();
        }

        //AssetDatabase.Refresh();
    }
}
