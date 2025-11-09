using Il2CppAssets.Scripts.Simulation.Towers;
using System;

namespace AncientMonkey.Strengths.Rarities;

public class CommonMulti : StrengthTemplate
{
    public override int Index => 1;
    public override Rarity StrengthRarity => Rarity.Common;
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
public class CommonDamage : StrengthTemplate
{
    public override int Index => 1;
    public override Rarity StrengthRarity => Rarity.Common;
    public override string StrengthName => "Damage Boost";
    public override string Description => $"Gives all current weapons:\n{damageBonus} damage";
    public override void EditTower(Tower tower)
    {
        float[] stats = [damageBonus, pierceBonus, rangeBonus, attackSpeedBonus, moneyBonus, projectileSpeed, debuffDuration, abilityCooldown];
        StrengthMethods.StrengthSelected(stats, tower);
    }
}
public class CommonSpeed : StrengthTemplate
{
    public override int Index => 1;
    public override Rarity StrengthRarity => Rarity.Common;
    public override string StrengthName => "Attack Speed Boost";
    public override string Description => $"Gives all current weapons:\n{Math.Round((attackSpeedBonus - 1) * 100)}% attack speed";
    public override void EditTower(Tower tower)
    {
        float[] stats = [damageBonus, pierceBonus, rangeBonus, attackSpeedBonus, moneyBonus, projectileSpeed, debuffDuration, abilityCooldown];
        StrengthMethods.StrengthSelected(stats, tower);
    }
}
public class CommonRange : StrengthTemplate
{
    public override int Index => 1;
    public override Rarity StrengthRarity => Rarity.Common;
    public override string StrengthName => "Range Boost";
    public override string Description => $"Gives all current weapons:\n{Math.Round((rangeBonus - 1) * 100)}% range\n{pierceBonus} pierce";
    public override void EditTower(Tower tower)
    {
        float[] stats = [damageBonus, pierceBonus, rangeBonus, attackSpeedBonus, moneyBonus, projectileSpeed, debuffDuration, abilityCooldown];
        StrengthMethods.StrengthSelected(stats, tower);
    }
}
public class CommonMoney : StrengthTemplate
{
    public override int Index => 1;
    public override Rarity StrengthRarity => Rarity.Common;
    public override string StrengthName => "Money Boost";
    public override string Description => $"Gives all current weapons:\n{Math.Round((moneyBonus - 1) * 100)}% money boost";
    public override void EditTower(Tower tower)
    {
        float[] stats = [damageBonus, pierceBonus, rangeBonus, attackSpeedBonus, moneyBonus, projectileSpeed, debuffDuration, abilityCooldown];
        StrengthMethods.StrengthSelected(stats, tower);
    }
}
public class CommonProjSpeed : StrengthTemplate
{
    public override int Index => 1;
    public override Rarity StrengthRarity => Rarity.Common;
    public override string StrengthName => "Projectile Speed";
    public override string Description => $"Gives all current weapons:\n{Math.Round((projectileSpeed - 1) * 100)}% projectile speed\n{Math.Round((attackSpeedBonus - 1) * 100)}% attack speed";
    public override void EditTower(Tower tower)
    {
        float[] stats = [damageBonus, pierceBonus, rangeBonus, attackSpeedBonus, moneyBonus, projectileSpeed, debuffDuration, abilityCooldown];
        StrengthMethods.StrengthSelected(stats, tower);
    }
}
public class CommonDebuff : StrengthTemplate
{
    public override int Index => 1;
    public override Rarity StrengthRarity => Rarity.Common;
    public override string StrengthName => "Debuff Duration";
    public override string Description => $"Gives all current weapons:\n{Math.Round((debuffDuration - 1) * 100)}% debuff duration";
    public override void EditTower(Tower tower)
    {
        float[] stats = [damageBonus, pierceBonus, rangeBonus, attackSpeedBonus, moneyBonus, projectileSpeed, debuffDuration, abilityCooldown];
        StrengthMethods.StrengthSelected(stats, tower);
    }
}