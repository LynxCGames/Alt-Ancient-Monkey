using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Components;
using static AncientMonkey.AncientMonkey;
using UnityEngine;
using BTD_Mod_Helper.Extensions;
using BTD_Mod_Helper.Api;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using WeaponPacks;

namespace AncientMonkey;

public class OmegaUpgrade : BloonsTD6Mod
{
    public static void UpgradeTower()
    {
        mod.level += 1;
        var sprite = MenuUi.panelSprites[mod.level].GetComponent<ModHelperPanel>().Background.sprite;
        var menu = MenuUi.upgradeMenu.GetComponent<ModHelperPanel>();
        var extrasMenu = MenuUi.extrasMenu.GetComponent<ModHelperPanel>();

        menu.Background.sprite = sprite;
        menu.GetComponentFromChildrenByName<ModHelperPanel>("newStrengthBox").GetComponentFromChildrenByName<ModHelperPanel>("newStrengthCostBox").Background.sprite = sprite;
        menu.GetComponentFromChildrenByName<ModHelperPanel>("newWeaponBox").GetComponentFromChildrenByName<ModHelperPanel>("newWeaponCostBox").Background.sprite = sprite;
        menu.GetComponentFromChildrenByName<ModHelperPanel>("newAbilitynBox").GetComponentFromChildrenByName<ModHelperPanel>("newAbilityCostBox").Background.sprite = sprite;

        extrasMenu.Background.sprite = sprite;
        extrasMenu.GetComponentFromChildrenByName<ModHelperPanel>("slotsPanel").Background.sprite = sprite;
        extrasMenu.GetComponentFromChildrenByName<ModHelperPanel>("luckPanel").Background.sprite = sprite;
        extrasMenu.GetComponentFromChildrenByName<ModHelperPanel>("lagPanel").Background.sprite = sprite;
        extrasMenu.GetComponentFromChildrenByName<ModHelperPanel>("upgradePanel").Background.sprite = sprite;

        var luckPanel = extrasMenu.GetComponentFromChildrenByName<ModHelperPanel>("luckPanel").GetComponentFromChildrenByName<ModHelperPanel>("luckScorePanel");
        var gildPanel = extrasMenu.GetComponentFromChildrenByName<ModHelperPanel>("luckPanel").GetComponentFromChildrenByName<ModHelperPanel>("gildScorePanel");

        luckPanel.Background.sprite = sprite;
        gildPanel.Background.sprite = sprite;
        extrasMenu.GetComponentFromChildrenByName<ModHelperPanel>("luckPanel").GetComponentFromChildrenByName<ModHelperPanel>("moneyScorePanel").Background.sprite = sprite;

        if (mod.weaponActive != false && SandboxMode == false)
        {
            MenuUi.weaponMenu.GetComponent<ModHelperPanel>().Background.sprite = MenuUi.panelSprites[mod.level].GetComponent<ModHelperPanel>().Background.sprite;
            MenuUi.weaponNotePanel.GetComponent<ModHelperPanel>().Background.sprite = MenuUi.panelSprites[mod.level].GetComponent<ModHelperPanel>().Background.sprite;
        }

        if (mod.abilityActive != false && SandboxMode == false)
        {
            MenuUi.abilityMenu.GetComponent<ModHelperPanel>().Background.sprite = MenuUi.panelSprites[mod.level].GetComponent<ModHelperPanel>().Background.sprite;
            MenuUi.abilityNotePanel.GetComponent<ModHelperPanel>().Background.sprite = MenuUi.panelSprites[mod.level].GetComponent<ModHelperPanel>().Background.sprite;
        }

        if (mod.strengthActive != false && SandboxMode == false)
        {
            MenuUi.strengthMenu.GetComponent<ModHelperPanel>().Background.sprite = MenuUi.panelSprites[mod.level].GetComponent<ModHelperPanel>().Background.sprite;
            MenuUi.strengthNotePanel.GetComponent<ModHelperPanel>().Background.sprite = MenuUi.panelSprites[mod.level].GetComponent<ModHelperPanel>().Background.sprite;
        }


        // Unlocks more upgrade slots
        if (mod.oneSlot == true) { MenuUi.weaponSlotText.GetComponent<ModHelperText>().Text.text = "Additional Weapon Slot: Disabled"; }
        else { MenuUi.weaponSlotText.GetComponent<ModHelperText>().Text.text = $"Additional Weapon Slot: ${mod.weaponSlotCost}"; }

        if (mod.oneSlot == true) { MenuUi.abilitySlotText.GetComponent<ModHelperText>().Text.text = "Additional Ability Slot: Disabled"; }
        else { MenuUi.abilitySlotText.GetComponent<ModHelperText>().Text.text = $"Additional Ability Slot: ${mod.abilitySlotCost}"; }

        if (mod.oneSlot == true) { MenuUi.strengthSlotText.GetComponent<ModHelperText>().Text.text = "Additional Strength Slot: Disabled"; }
        else { MenuUi.strengthSlotText.GetComponent<ModHelperText>().Text.text = $"Additional Strength Slot: ${mod.strengthSlotCost}"; }


        // Increases the maximum Gilded Chance upgrade
        if (mod.blingedOut == true) { MenuUi.gildedCostText.GetComponent<ModHelperText>().Text.text = "Upgrade: Maxed"; }
        else { MenuUi.gildedCostText.GetComponent<ModHelperText>().Text.text = $"Upgrade: ${mod.gildedCost}"; }

        if (mod.foolsGold == true) { mod.gildedMax += 5; }
        else if (mod.powerCreep == true | mod.mastery == true) { mod.gildedMax = 0; }
        else { mod.gildedMax += 20; }

        gildPanel.GetComponentFromChildrenByName<ModHelperPanel>("gildScoreBar").SetInfo(new Info("gildScoreBar", 300 * (mod.gildedChance / mod.gildedMax), 75, 600 * (mod.gildedChance / mod.gildedMax), 150, new Vector2()));


        // Resets the cost of all upgrades
        mod.weaponCost = 250;
        mod.weaponCostIncreaser = 100;

        if (mod.abilityMayhem == true)
        {
            mod.abilityCost = 250;
            mod.abilityCostIncreaser = 100;
        }
        else
        {
            mod.abilityCost = 1000;
            mod.abilityCostIncreaser = 250;
        }

        mod.strengthCost = 500;
        mod.strengthCostIncreaser = 200;

        if (mod.abilityMayhem == true) { MenuUi.weaponCostText.GetComponent<ModHelperText>().Text.text = "Disabled"; }
        else { MenuUi.weaponCostText.GetComponent<ModHelperText>().Text.text = "$" + TextManager.ConvertCostText((int)Mathf.Round(mod.weaponCost)); }

        MenuUi.abilityCostText.GetComponent<ModHelperText>().Text.text = "$" + TextManager.ConvertCostText((int)Mathf.Round(mod.abilityCost));

        if (mod.abilityMayhem == true) { MenuUi.strengthCostText.GetComponent<ModHelperText>().Text.text = "Disabled"; }
        else { MenuUi.strengthCostText.GetComponent<ModHelperText>().Text.text = "$" + TextManager.ConvertCostText((int)Mathf.Round(mod.strengthCost)); }

        if (mod.superWeapons == true)
        {
            SuperReset();
        }
        else
        {
            ClassicReset();
        }


        // Removes all non-gilded Rare weapons
        foreach (var tower in InGame.instance.GetTowers())
        {
            if (tower.towerModel.name.Contains("AncientMonkey-AncientMonkey"))
            {
                var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();

                foreach (var weapon in towerModel.GetAttackModels())
                {
                    if (weapon.name.Contains("Rare"))
                    {
                        towerModel.RemoveBehavior(weapon);
                    }
                }

                foreach (var weapon in towerModel.GetBehaviors<TowerCreateTowerModel>())
                {
                    if (weapon.name.Contains("Rare"))
                    {
                        towerModel.RemoveBehavior(weapon);
                    }
                }

                tower.UpdateRootModel(towerModel);
            }
        }
    }

    public static void ClassicReset()
    {
        foreach (var rarity in ModContent.GetContent<WeaponRarityTemplate>())
        {
            if (rarity.WeaponRarity == WeaponRarityTemplate.Rarity.Common | rarity.WeaponRarity == WeaponRarityTemplate.Rarity.Rare)
            {
                rarity.minValue = 0;
                rarity.maxValue = 0;
            }
            else if (rarity.WeaponRarity == WeaponRarityTemplate.Rarity.Epic)
            {
                rarity.minValue = 0;
                rarity.maxValue = 100;
            }
            else
            {
                rarity.minValue = 100;
                rarity.maxValue = 100;
            }
        }
        foreach (var rarity in ModContent.GetContent<AbilityRarityTemplate>())
        {
            if (rarity.AbilityRarity == AbilityRarityTemplate.Rarity.Common | rarity.AbilityRarity == AbilityRarityTemplate.Rarity.Rare)
            {
                rarity.minValue = 0;
                rarity.maxValue = 0;
            }
            else if (rarity.AbilityRarity == AbilityRarityTemplate.Rarity.Epic)
            {
                rarity.trueMinimum = 0;
                rarity.minValue = 0;
                rarity.maxValue = 100;
            }
            else
            {
                rarity.minValue = 100;
                rarity.maxValue = 100;
            }
        }
        foreach (var rarity in ModContent.GetContent<StrengthRarityTemplate>())
        {
            if (rarity.StrengthRarity == StrengthRarityTemplate.Rarity.Common | rarity.StrengthRarity == StrengthRarityTemplate.Rarity.Rare)
            {
                rarity.minValue = 0;
                rarity.maxValue = 0;
            }
            else if (rarity.StrengthRarity == StrengthRarityTemplate.Rarity.Epic)
            {
                rarity.minValue = 0;
                rarity.maxValue = 100;
            }
            else
            {
                rarity.minValue = 100;
                rarity.maxValue = 100;
            }
        }
    }

    public static void SuperReset()
    {
        foreach (var rarity in ModContent.GetContent<WeaponRarityTemplate>())
        {
            if (rarity.WeaponRarity == WeaponRarityTemplate.Rarity.Common | rarity.WeaponRarity == WeaponRarityTemplate.Rarity.Rare | rarity.WeaponRarity == WeaponRarityTemplate.Rarity.Epic)
            {
                rarity.trueMinimum = 0;
                rarity.minValue = 0;
                rarity.maxValue = 0;
            }
            else if (rarity.WeaponRarity == WeaponRarityTemplate.Rarity.Legendary)
            {
                rarity.trueMinimum = 0;
                rarity.minValue = 0;
                rarity.maxValue = 100;
            }
            else
            {
                rarity.minValue = 100;
                rarity.maxValue = 100;
            }
        }
        foreach (var rarity in ModContent.GetContent<AbilityRarityTemplate>())
        {
            if (rarity.AbilityRarity == AbilityRarityTemplate.Rarity.Common | rarity.AbilityRarity == AbilityRarityTemplate.Rarity.Rare | rarity.AbilityRarity == AbilityRarityTemplate.Rarity.Epic)
            {
                rarity.trueMinimum = 0;
                rarity.minValue = 0;
                rarity.maxValue = 0;
            }
            else if (rarity.AbilityRarity == AbilityRarityTemplate.Rarity.Legendary)
            {
                rarity.trueMinimum = 0;
                rarity.minValue = 0;
                rarity.maxValue = 100;
            }
            else
            {
                rarity.minValue = 100;
                rarity.maxValue = 100;
            }
        }
        foreach (var rarity in ModContent.GetContent<StrengthRarityTemplate>())
        {
            if (rarity.StrengthRarity == StrengthRarityTemplate.Rarity.Common | rarity.StrengthRarity == StrengthRarityTemplate.Rarity.Rare | rarity.StrengthRarity == StrengthRarityTemplate.Rarity.Epic)
            {
                rarity.trueMinimum = 0;
                rarity.minValue = 0;
                rarity.maxValue = 0;
            }
            else if (rarity.StrengthRarity == StrengthRarityTemplate.Rarity.Legendary)
            {
                rarity.trueMinimum = 0;
                rarity.minValue = 0;
                rarity.maxValue = 100;
            }
            else
            {
                rarity.minValue = 100;
                rarity.maxValue = 100;
            }
        }
    }
}