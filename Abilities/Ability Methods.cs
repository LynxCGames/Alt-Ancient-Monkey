using BTD_Mod_Helper;
using BTD_Mod_Helper.Api;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using static AncientMonkey.AncientMonkey;
using UnityEngine;
using Il2CppAssets.Scripts.Simulation.Towers;
using System.Collections.Generic;
using WeaponPacks;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Extensions;

namespace AncientMonkey;

public class AbilityMethods : BloonsTD6Mod
{
    public static void RaritySetter()
    {
        List<AbilityRarityTemplate> rarityList = new List<AbilityRarityTemplate>();
        for (int i = 0; i < ModContent.GetContent<WeaponRarityTemplate>().Count; i++)
        {
            foreach (var rarity in ModContent.GetContent<AbilityRarityTemplate>())
            {
                if (mod.level >= rarity.Level && rarity.Order == i)
                {
                    rarityList.Add(rarity);
                }
            }
        }

        for (var i = 1; i < rarityList.Count; i++)
        {
            if (rarityList[i - 1].minValue < 80)
            {
                rarityList[i].minValue -= (rarityList[i].RarityIncreaser + (mod.luck * 0.1f * rarityList[i].RarityIncreaser)) * mod.level;
            }

            if (rarityList[i].minValue < rarityList[i].trueMinimum)
            {
                rarityList[i].minValue = rarityList[i].trueMinimum;
            }
        }
        for (var i = 1; i < rarityList.Count; i++)
        {
            rarityList[i - 1].maxValue = rarityList[i].minValue;
        }
    }

    public static void AbilitySelected(AbilityTemplate ability, Tower tower)
    {
        mod.panelOpen = false;
        InGame game = InGame.instance;
        RectTransform rect = game.uiRect;

        ability.stackIndex += 1;
        ability.EditTower(tower);
        RaritySetter();

        if (mod.abUpgradeActive)
        {
            if (ability.AbilityRarity == AbilityTemplate.Rarity.Common | ability.AbilityRarity == AbilityTemplate.Rarity.Rare)
            {
                MenuUi.abUpgradeMenu.GetComponentFromChildrenByName<ModHelperScrollPanel>("UpgradeScroll").
                    GetComponentFromChildrenByName<ModHelperPanel>("AbilityContent" + ability.AbilityName).
                    GetComponentFromChildrenByName<ModHelperText>("StackText").Text.text = $"{ability.stackIndex}";
            }
        }

        if (mod.isSelected == true)
        {
            MenuUi.CreateUpgradeMenu(rect, tower);
        }

    }
}