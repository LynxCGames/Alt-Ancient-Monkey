using BTD_Mod_Helper;
using BTD_Mod_Helper.Api;
using static AncientMonkey.AncientMonkey;
using WeaponPacks;
using AncientMonkey.Menus;

namespace AncientMonkey;

public class Reseter : BloonsTD6Mod
{
    public static void Reset()
    {
        // Costs
        mod.weaponCost = 250 * mod.upgradeMultiplier;
        mod.weaponCostIncreaser = 100 * mod.upgradeMultiplier;
        mod.weaponSlotCost = 50000 * mod.extrasMultiplier;

        if (mod.abilityMayhem == true)
        {
            mod.abilityCost = 250;
            mod.abilityCostIncreaser = 100;
        }
        else
        {
            mod.abilityCost = 1000 * mod.upgradeMultiplier;
            mod.abilityCostIncreaser = 250 * mod.upgradeMultiplier;
        }
        mod.abilitySlotCost = 75000 * mod.extrasMultiplier;

        mod.strengthCost = 500 * mod.upgradeMultiplier;
        mod.strengthCostIncreaser = 200 * mod.upgradeMultiplier;
        mod.strengthSlotCost = 60000 * mod.extrasMultiplier;

        mod.luckCost = 500 * mod.extrasMultiplier;
        mod.moneyCost = 1500 * mod.extrasMultiplier;
        mod.upgradeCost = 125000 * mod.extrasMultiplier;
        mod.gildEffectCost = 15000 * mod.extrasMultiplier;

        if (mod.foolsGold == true)
        {
            mod.gildedCost = 5000;
        }
        else
        {
            mod.gildedCost = 1000 * mod.extrasMultiplier;
        }

        // Strength Values
        mod.damageBonus = 0;
        mod.pierceBonus = 0;
        mod.rangeBonus = 1;
        mod.attackSpeedBonus = 1;
        mod.moneyBonus = 1;

        // Menus
        mod.upgradeActive = false;
        mod.weaponActive = false;
        mod.abilityActive = false;
        mod.abUpgradeActive = false;
        mod.strengthActive = false;
        mod.extrasActive = false;
        mod.isSelected = false;
        mod.panelOpen = false;
        mod.level = 1;
        mod.isGilded = false;

        if (mod.oneSlot == true)
        {
            mod.weaponSlots = 1;
            mod.abilitySlots = 1;
            mod.strengthSlots = 1;
        }
        else
        {
            mod.weaponSlots = 3;
            mod.abilitySlots = 2;
            mod.strengthSlots = 3;
        }

        // Settings
        if (mod.blingedOut == true)
        {
            mod.gildedChance = 100;
            mod.gildedMax = 100;
        }
        else if (mod.foolsGold == true)
        {
            mod.gildedChance = 1;
            mod.gildedMax = 5;
        }
        else if (mod.powerCreep == true | mod.mastery == true)
        {
            mod.gildedChance = 0;
            mod.gildedMax = 100;
        }
        else
        {
            mod.gildedChance = 5;
            mod.gildedMax = 25;
        }

        mod.luck = 0;
        mod.moneyLevel = 0;
        mod.moneyGenerate = 62.5f;
        mod.gildEffectRoll = 1;

        // Stack Resets
        if (mod.superWeapons == true)
        {
            SuperReset();
        }
        else if (mod.powerCreep == true)
        {
            PowerReset();
        }
        else
        {
            ClassicReset();
        }
    }

    public static void ChallengeReset()
    {
        // Settings
        mod.upgradeMultiplier = 1;
        mod.extrasMultiplier = 1;

        // Challenges
        mod.superWeapons = false;
        mod.blingedOut = false;
        mod.abilityMayhem = false;
        mod.oneSlot = false;
        mod.foolsGold = false;
        mod.errorCode = false;
        mod.moneyStarved = false;
        mod.powerCreep = false;
        mod.mastery = false;

        foreach (var pack in ModContent.GetContent<PackTemplate>())
        {
            if (pack.isSelected == true)
            {
                foreach (var weapon in ModContent.GetContent<WeaponTemplate>())
                {
                    if (weapon.WeaponPack == pack.PackName)
                    {
                        weapon.enabled = true;
                    }
                }
            }
        }

        foreach (var pack in ModContent.GetContent<PackTemplate>())
        {
            if (pack.isSelected == true)
            {
                foreach (var ability in ModContent.GetContent<AbilityTemplate>())
                {
                    if (ability.WeaponPack == pack.PackName)
                    {
                        ability.enabled = true;
                    }
                }
            }
        }
    }

    public static void ClassicReset()
    {
        foreach (var weapon in ModContent.GetContent<WeaponTemplate>())
        {
            weapon.stackIndex = 0;
        }
        foreach (var ability in ModContent.GetContent<AbilityTemplate>())
        {
            ability.stackIndex = 0;
        }

        foreach (var rarity in ModContent.GetContent<WeaponRarityTemplate>())
        {
            rarity.trueMinimum = rarity.TrueMinimumValue;
            rarity.maxValue = 100;

            if (rarity.WeaponRarity == WeaponRarityTemplate.Rarity.Common)
            {
                rarity.minValue = 0;
            }
            else
            {
                rarity.minValue = 100;
            }
        }
        foreach (var rarity in ModContent.GetContent<AbilityRarityTemplate>())
        {
            rarity.trueMinimum = rarity.TrueMinimumValue;
            rarity.maxValue = 100;

            if (rarity.AbilityRarity == AbilityRarityTemplate.Rarity.Common)
            {
                rarity.minValue = 0;
            }
            else
            {
                rarity.minValue = 100;
            }
        }
        foreach (var rarity in ModContent.GetContent<StrengthRarityTemplate>())
        {
            rarity.trueMinimum = rarity.TrueMinimumValue;
            rarity.maxValue = 100;

            if (rarity.StrengthRarity == StrengthRarityTemplate.Rarity.Common)
            {
                rarity.minValue = 0;
            }
            else
            {
                rarity.minValue = 100;
            }
        }
    }

    public static void SuperReset()
    {
        foreach (var weapon in ModContent.GetContent<WeaponTemplate>())
        {
            weapon.stackIndex = 0;
        }
        foreach (var ability in ModContent.GetContent<AbilityTemplate>())
        {
            ability.stackIndex = 0;
        }

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

    public static void PowerReset()
    {
        foreach (var weapon in ModContent.GetContent<WeaponTemplate>())
        {
            weapon.stackIndex = 0;
        }
        foreach (var ability in ModContent.GetContent<AbilityTemplate>())
        {
            ability.stackIndex = 0;
        }

        foreach (var rarity in ModContent.GetContent<WeaponRarityTemplate>())
        {
            rarity.maxValue = 100;

            if (rarity.WeaponRarity == WeaponRarityTemplate.Rarity.Common)
            {
                rarity.minValue = 0;
            }
            else if (rarity.WeaponRarity == WeaponRarityTemplate.Rarity.Rare | rarity.WeaponRarity == WeaponRarityTemplate.Rarity.Epic)
            {
                rarity.minValue = 100;
            }
            else
            {
                rarity.trueMinimum = 100;
                rarity.minValue = 100;
            }
        }
        foreach (var rarity in ModContent.GetContent<AbilityRarityTemplate>())
        {
            rarity.maxValue = 100;

            if (rarity.AbilityRarity == AbilityRarityTemplate.Rarity.Common)
            {
                rarity.minValue = 0;
            }
            else if (rarity.AbilityRarity == AbilityRarityTemplate.Rarity.Rare | rarity.AbilityRarity == AbilityRarityTemplate.Rarity.Epic)
            {
                rarity.minValue = 100;
            }
            else
            {
                rarity.trueMinimum = 100;
                rarity.minValue = 100;
            }
        }
        foreach (var rarity in ModContent.GetContent<StrengthRarityTemplate>())
        {
            rarity.maxValue = 100;

            if (rarity.StrengthRarity == StrengthRarityTemplate.Rarity.Common)
            {
                rarity.minValue = 0;
            }
            else if (rarity.StrengthRarity == StrengthRarityTemplate.Rarity.Rare | rarity.StrengthRarity == StrengthRarityTemplate.Rarity.Epic)
            {
                rarity.minValue = 100;
            }
            else
            {
                rarity.trueMinimum = 100;
                rarity.minValue = 100;
            }
        }
    }
}