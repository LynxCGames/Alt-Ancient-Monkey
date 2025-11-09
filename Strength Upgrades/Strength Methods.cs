using BTD_Mod_Helper;
using BTD_Mod_Helper.Api;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using static AncientMonkey.AncientMonkey;
using UnityEngine;
using Il2CppAssets.Scripts.Simulation.Towers;
using BTD_Mod_Helper.Api.Components;
using System.Collections.Generic;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Weapons;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppSystem.Linq;
using WeaponPacks;

namespace AncientMonkey;

public class StrengthMethods : BloonsTD6Mod
{
    public static void RaritySetter()
    {
        List<StrengthRarityTemplate> rarityList = new List<StrengthRarityTemplate>();
        for (int i = 0; i < ModContent.GetContent<WeaponRarityTemplate>().Count; i++)
        {
            foreach (var rarity in ModContent.GetContent<StrengthRarityTemplate>())
            {
                if (rarity.Order == i)
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

    public static void StrengthSelected(float[] stats, Tower tower)
    {
        mod.panelOpen = false;
        InGame game = InGame.instance;
        RectTransform rect = game.uiRect;

        float Damage = stats[0];
        float Pierce = stats[1];
        float Range = stats[2];
        float AttackSpeed = stats[3];
        float Money = stats[4];
        float projSpeed = stats[5];
        float debuff = stats[6];
        float cooldown = stats[7];

        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();

        foreach (var weapon in towerModel.GetAttackModels())
        {
            weapon.range *= Range;

            weapon.GetDescendants<ProjectileModel>().ForEach(model => model.pierce += Pierce);
            weapon.GetDescendants<DamageModel>().ForEach(model => model.damage += Damage);

            weapon.range *= mod.rangeBonus;
            weapon.GetDescendants<TravelStraitModel>().ForEach(model => model.lifespan *= Range);
            weapon.GetDescendants<TravelStraitModel>().ForEach(model => model.speed *= projSpeed);

            weapon.GetDescendants<CashModel>().ForEach(model => model.minimum *= Money);
            weapon.GetDescendants<CashModel>().ForEach(model => model.maximum *= Money);

            weapon.GetDescendants<AddBehaviorToBloonModel>().ForEach(model => model.lifespan *= debuff);
            weapon.GetDescendants<SlowModel>().ForEach(model => model.lifespan *= debuff);
            weapon.GetDescendants<FreezeModel>().ForEach(model => model.lifespan *= debuff);

            foreach (var attack in weapon.weapons)
            {
                attack.rate /= AttackSpeed;

                if (attack.rate < 0.1f)
                {
                    attack.rate *= 10;
                    attack.GetDescendants<DamageModel>().ForEach(model => model.damage *= 10);
                }
            }

            if (!weapon.name.Contains("BaseAttackModel"))
            {
                if (weapon.weapons[0].projectile.HasBehavior<CreateTowerModel>())
                {
                    var sentry = weapon.weapons[0].projectile.GetDescendant<CreateTowerModel>().tower;
                    sentry.range *= Range;

                    foreach (var senWeapon in sentry.GetAttackModels())
                    {
                        senWeapon.GetDescendants<ProjectileModel>().ForEach(model => model.pierce += Pierce);
                        senWeapon.GetDescendants<DamageModel>().ForEach(model => model.damage += Damage);

                        senWeapon.range *= Range;
                        senWeapon.GetDescendants<TravelStraitModel>().ForEach(model => model.lifespan *= Range);
                        senWeapon.GetDescendants<TravelStraitModel>().ForEach(model => model.speed *= projSpeed);

                        foreach (var attack in weapon.weapons)
                        {
                            attack.rate /= AttackSpeed;

                            if (attack.rate < 0.1f)
                            {
                                attack.rate *= 10;
                                attack.GetDescendants<DamageModel>().ForEach(model => model.damage *= 10);
                            }
                        }
                    }
                }
            }
        }

        foreach (var weapon in towerModel.GetBehaviors<TowerCreateTowerModel>())
        {
            weapon.towerModel.GetDescendants<ProjectileModel>().ForEach(model => model.pierce += Pierce);
            weapon.towerModel.GetDescendants<DamageModel>().ForEach(model => model.damage += Damage);

            foreach (var attack in weapon.towerModel.GetDescendants<WeaponModel>().ToArray())
            {
                attack.rate /= AttackSpeed;

                if (attack.rate < 0.1f)
                {
                    attack.rate *= 10;
                    attack.GetDescendants<DamageModel>().ForEach(model => model.damage *= 10);
                }
            }
        }

        foreach (var weapon in towerModel.GetBehaviors<PerRoundCashBonusTowerModel>())
        {
            if (!weapon.name.Contains("ExtrasMoneyGenerate"))
            {
                weapon.cashPerRound *= Money;
            }
        }

        foreach (var ability in towerModel.GetAbilities())
        {
            ability.cooldown /= cooldown;
        }

        towerModel.range *= Range;
        tower.UpdateRootModel(towerModel);

        RaritySetter();

        if (mod.isSelected == true)
        {
            MenuUi.CreateUpgradeMenu(rect, tower);
        }
    }
}