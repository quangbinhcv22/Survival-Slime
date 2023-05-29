using System;
using System.Collections.Generic;
using System.Linq;
using Gameplay.Abilities;
using Plugins.QB_UI.Core;
using UnityEngine;
using Random = UnityEngine.Random;

public class Popup_SelectAbility : Panel
{
    private const int MaxSelect = 5;
    private const int SelectAmount = 3;
    private const int MaxStar = 3;

    [Space] public List<string> actives;
    public List<string> passives;

    [Space] public List<string> selectableActives;
    public List<string> selectablePassives;
    
    [Space] public List<string> selectedActives;
    public List<string> selectingPassives;


    [Space] public List<string> selections = new();


    private Dictionary<string, Gp_AbilityData> _abilities = new();


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Roll();
        }

        if (Input.GetKeyDown(KeyCode.A)) Select(0);
        if (Input.GetKeyDown(KeyCode.B)) Select(1);
        if (Input.GetKeyDown(KeyCode.C)) Select(2);
    }

    private void Start()
    {
        selectableActives = actives;
        selectablePassives = passives;
    }

    public void Roll()
    {
        RandomSelection();

        foreach (var selection in selections)
        {
            Debug.Log($"{selection}: {GetStar(selection)} -> {GetNextStar(selection)}");
        }
    }

    public void Select(int index)
    {
        var key = selections[index];
        if (!_abilities.ContainsKey(key))
        {
            _abilities.Add(key, new()
            {
                star = 1,
            });
        }
        else
        {
            _abilities[key].star++;

            if (_abilities[key].star >= MaxStar)
            {
                selectableActives.Remove(key);
                selectablePassives.Remove(key);
            }
        }

        Debug.Log($"Select {key} -> {GetStar(key)} stars");
    }

    private int GetStar(string key) => !_abilities.ContainsKey(key) ? 0 : _abilities[key].star;

    public int GetNextStar(string key) => GetStar(key) + 1;


    public void RandomSelection()
    {
        var amountCurrent = SelectAmount;

        var otherAmount = 0;
        amountCurrent -= otherAmount;

        var activeAmount = Random.Range(0, amountCurrent + 1);
        amountCurrent -= activeAmount;

        var passiveAmount = amountCurrent;


        var selectActives = selectableActives.OrderBy(x => Random.value).Take(activeAmount).ToList();
        var selectPassives = selectablePassives.OrderBy(x => Random.value).Take(passiveAmount).ToList();
        var selectOther = OtherSelects(otherAmount);

        selections.Clear();
        selections.AddRange(selectActives);
        selections.AddRange(selectPassives);
        selections = selections.OrderBy(x => Random.value).ToList();
        selections.AddRange(selectOther);
    }

    private List<string> OtherSelects(int amount)
    {
        var selections = new List<string>();

        if (amount == 1) selections.Add("recover_hp");
        if (amount == 2) selections.Add("get_gold");
        if (amount == 3) selections.Add("get_gold");

        return selections;
    }
}

[Serializable]
public class Gp_AbilityData
{
    public _Ability root;
    public int star;
}