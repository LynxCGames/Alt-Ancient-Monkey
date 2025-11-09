using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using static AncientMonkey.AncientMonkey;
using UnityEngine;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using System;

namespace AncientMonkey.Strengths.Rarities;

public class LegendaryMulti : StrengthTemplate
{
    public override int Index => 4;
    public override Rarity StrengthRarity => Rarity.Legendary;
    public override string StrengthName => "Multi Boost";
    public override string Description => $"Gives all current weapons:\n" +
        $"{pierceBonus} pierce\n" +
        $"{damageBonus} damage\n" +
        $"{Math.Round((attackSpeedBonus - 1) * 100)}% attack speed\n" +
        $"{Math.Round((rangeBonus - 1) * 100)}% range\n" +
        $"{Math.Round((moneyBonus - 1) * 100)}% money boost";
    public override void EditTower(Tower tower)
    {
        float[] stats = [damageBonus, pierceBonus, rangeBonus, attackSpeedBonus, moneyBonus, projectileSpeed, debuffDuration, abilityCooldown];
        StrengthMethods.StrengthSelected(stats, tower);
    }
}
public class LegendaryDamage : StrengthTemplate
{
    public override int Index => 4;
    public override Rarity StrengthRarity => Rarity.Legendary;
    public override string StrengthName => "Damage Boost";
    public override string Description => $"Gives all current weapons:\n{damageBonus} damage";
    public override void EditTower(Tower tower)
    {
        float[] stats = [damageBonus, pierceBonus, rangeBonus, attackSpeedBonus, moneyBonus, projectileSpeed, debuffDuration, abilityCooldown];
        StrengthMethods.StrengthSelected(stats, tower);
    }
}
public class LegendarySpeed : StrengthTemplate
{
    public override int Index => 4;
    public override Rarity StrengthRarity => Rarity.Legendary;
    public override string StrengthName => "Attack Speed Boost";
    public override string Description => $"Gives all current weapons:\n{Math.Round((attackSpeedBonus - 1) * 100)}% attack speed";
    public override void EditTower(Tower tower)
    {
        float[] stats = [damageBonus, pierceBonus, rangeBonus, attackSpeedBonus, moneyBonus, projectileSpeed, debuffDuration, abilityCooldown];
        StrengthMethods.StrengthSelected(stats, tower);
    }
}
public class LegendaryRange : StrengthTemplate
{
    public override int Index => 4;
    public override Rarity StrengthRarity => Rarity.Legendary;
    public override string StrengthName => "Range Boost";
    public override string Description => $"Gives all current weapons:\n{Math.Round((rangeBonus - 1) * 100)}% range\n{pierceBonus} pierce";
    public override void EditTower(Tower tower)
    {
        float[] stats = [damageBonus, pierceBonus, rangeBonus, attackSpeedBonus, moneyBonus, projectileSpeed, debuffDuration, abilityCooldown];
        StrengthMethods.StrengthSelected(stats, tower);
    }
}
public class LegendaryMoney : StrengthTemplate
{
    public override int Index => 4;
    public override Rarity StrengthRarity => Rarity.Legendary;
    public override string StrengthName => "Money Boost";
    public override string Description => $"Gives all current weapons:\n{Math.Round((moneyBonus - 1) * 100)}% money boost";
    public override void EditTower(Tower tower)
    {
        float[] stats = [damageBonus, pierceBonus, rangeBonus, attackSpeedBonus, moneyBonus, projectileSpeed, debuffDuration, abilityCooldown];
        StrengthMethods.StrengthSelected(stats, tower);
    }
}
public class LegendaryMIB : StrengthTemplate
{
    public override int Index => 4;
    public override Rarity StrengthRarity => Rarity.Legendary;
    public override string StrengthName => "M.I.B.";
    public override string Description => $"Gives all current weapons: MIB";
    public override void EditTower(Tower tower)
    {
        AncientMonkey.mod.panelOpen = false;
        InGame game = InGame.instance;
        RectTransform rect = game.uiRect;

        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();

        foreach (var weapon in towerModel.GetAttackModels())
        {
            weapon.GetDescendants<DamageModel>().ForEach(model => model.immuneBloonProperties = Il2Cpp.BloonProperties.None);
            weapon.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);

            if (!weapon.name.Contains("BaseAttackModel"))
            {
                if (weapon.weapons[0].projectile.HasBehavior<CreateTowerModel>())
                {
                    var sentry = weapon.weapons[0].projectile.GetDescendant<CreateTowerModel>().tower;

                    foreach (var senWeapon in sentry.GetAttackModels())
                    {
                        senWeapon.GetDescendants<DamageModel>().ForEach(model => model.immuneBloonProperties = Il2Cpp.BloonProperties.None);
                        senWeapon.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
                    }
                }
            }
        }

        foreach (var weapon in towerModel.GetBehaviors<TowerCreateTowerModel>())
        {
            weapon.towerModel.GetDescendants<DamageModel>().ForEach(model => model.immuneBloonProperties = Il2Cpp.BloonProperties.None);
            weapon.towerModel.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
        }

        tower.UpdateRootModel(towerModel);

        StrengthMethods.RaritySetter();

        if (AncientMonkey.mod.isSelected == true)
        {
            MenuUi.CreateUpgradeMenu(rect, tower);
        }
    }
}
public class LegendaryProjSpeed : StrengthTemplate
{
    public override int Index => 4;
    public override Rarity StrengthRarity => Rarity.Legendary;
    public override string StrengthName => "Projectile Speed";
    public override string Description => $"Gives all current weapons:\n{Math.Round((projectileSpeed - 1) * 100)}% projectile speed\n{Math.Round((attackSpeedBonus - 1) * 100)}% attack speed";
    public override void EditTower(Tower tower)
    {
        float[] stats = [damageBonus, pierceBonus, rangeBonus, attackSpeedBonus, moneyBonus, projectileSpeed, debuffDuration, abilityCooldown];
        StrengthMethods.StrengthSelected(stats, tower);
    }
}
public class LegendaryDebuff : StrengthTemplate
{
    public override int Index => 4;
    public override Rarity StrengthRarity => Rarity.Legendary;
    public override string StrengthName => "Debuff Duration";
    public override string Description => $"Gives all current weapons:\n{Math.Round((debuffDuration - 1) * 100)}% debuff duration";
    public override void EditTower(Tower tower)
    {
        float[] stats = [damageBonus, pierceBonus, rangeBonus, attackSpeedBonus, moneyBonus, projectileSpeed, debuffDuration, abilityCooldown];
        StrengthMethods.StrengthSelected(stats, tower);
    }
}
public class LegendaryAbility : StrengthTemplate
{
    public override int Index => 4;
    public override Rarity StrengthRarity => Rarity.Legendary;
    public override string StrengthName => "Ability Cooldown";
    public override string Description => $"Gives all current abilities:\n{Math.Round((abilityCooldown - 1) * 100)}% decreased cooldown";
    public override void EditTower(Tower tower)
    {
        float[] stats = [damageBonus, pierceBonus, rangeBonus, attackSpeedBonus, moneyBonus, projectileSpeed, debuffDuration, abilityCooldown];
        StrengthMethods.StrengthSelected(stats, tower);
    }
}