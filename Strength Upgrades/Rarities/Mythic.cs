using Il2CppAssets.Scripts.Simulation.Towers;
using System;

namespace AncientMonkey.Strengths.Rarities;

public class MythicMulti : StrengthTemplate
{
    public override int Index => 5;
    public override Rarity StrengthRarity => Rarity.Mythic;
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
public class MythicDamage : StrengthTemplate
{
    public override int Index => 5;
    public override Rarity StrengthRarity => Rarity.Mythic;
    public override string StrengthName => "Damage Boost";
    public override string Description => $"Gives all current weapons:\n{damageBonus} damage";
    public override void EditTower(Tower tower)
    {
        float[] stats = [damageBonus, pierceBonus, rangeBonus, attackSpeedBonus, moneyBonus, projectileSpeed, debuffDuration, abilityCooldown];
        StrengthMethods.StrengthSelected(stats, tower);
    }
}
public class MythicSpeed : StrengthTemplate
{
    public override int Index => 5;
    public override Rarity StrengthRarity => Rarity.Mythic;
    public override string StrengthName => "Attack Speed Boost";
    public override string Description => $"Gives all current weapons:\n{Math.Round((attackSpeedBonus - 1) * 100)}% attack speed";
    public override void EditTower(Tower tower)
    {
        float[] stats = [damageBonus, pierceBonus, rangeBonus, attackSpeedBonus, moneyBonus, projectileSpeed, debuffDuration, abilityCooldown];
        StrengthMethods.StrengthSelected(stats, tower);
    }
}
public class MythicRange : StrengthTemplate
{
    public override int Index => 5;
    public override Rarity StrengthRarity => Rarity.Mythic;
    public override string StrengthName => "Range Boost";
    public override string Description => $"Gives all current weapons:\n{Math.Round((rangeBonus - 1) * 100)}% range\n{pierceBonus} pierce";
    public override void EditTower(Tower tower)
    {
        float[] stats = [damageBonus, pierceBonus, rangeBonus, attackSpeedBonus, moneyBonus, projectileSpeed, debuffDuration, abilityCooldown];
        StrengthMethods.StrengthSelected(stats, tower);
    }
}
public class MythicMoney : StrengthTemplate
{
    public override int Index => 5;
    public override Rarity StrengthRarity => Rarity.Mythic;
    public override string StrengthName => "Money Boost";
    public override string Description => $"Gives all current weapons:\n{Math.Round((moneyBonus - 1) * 100)}% money boost";
    public override void EditTower(Tower tower)
    {
        float[] stats = [damageBonus, pierceBonus, rangeBonus, attackSpeedBonus, moneyBonus, projectileSpeed, debuffDuration, abilityCooldown];
        StrengthMethods.StrengthSelected(stats, tower);
    }
}
public class MythicProjSpeed : StrengthTemplate
{
    public override int Index => 5;
    public override Rarity StrengthRarity => Rarity.Mythic;
    public override string StrengthName => "Projectile Speed";
    public override string Description => $"Gives all current weapons:\n{Math.Round((projectileSpeed - 1) * 100)}% projectile speed\n{Math.Round((attackSpeedBonus - 1) * 100)}% attack speed";
    public override void EditTower(Tower tower)
    {
        float[] stats = [damageBonus, pierceBonus, rangeBonus, attackSpeedBonus, moneyBonus, projectileSpeed, debuffDuration, abilityCooldown];
        StrengthMethods.StrengthSelected(stats, tower);
    }
}
public class MythicDebuff : StrengthTemplate
{
    public override int Index => 5;
    public override Rarity StrengthRarity => Rarity.Mythic;
    public override string StrengthName => "Debuff Duration";
    public override string Description => $"Gives all current weapons:\n{Math.Round((debuffDuration - 1) * 100)}% debuff duration";
    public override void EditTower(Tower tower)
    {
        float[] stats = [damageBonus, pierceBonus, rangeBonus, attackSpeedBonus, moneyBonus, projectileSpeed, debuffDuration, abilityCooldown];
        StrengthMethods.StrengthSelected(stats, tower);
    }
}
public class MythicAbility : StrengthTemplate
{
    public override int Index => 5;
    public override Rarity StrengthRarity => Rarity.Mythic;
    public override string StrengthName => "Ability Cooldown";
    public override string Description => $"Gives all current abilities:\n{Math.Round((abilityCooldown - 1) * 100)}% decreased cooldown";
    public override void EditTower(Tower tower)
    {
        float[] stats = [damageBonus, pierceBonus, rangeBonus, attackSpeedBonus, moneyBonus, projectileSpeed, debuffDuration, abilityCooldown];
        StrengthMethods.StrengthSelected(stats, tower);
    }
}