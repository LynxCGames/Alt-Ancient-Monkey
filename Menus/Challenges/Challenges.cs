using BTD_Mod_Helper.Api.Enums;
using WeaponPacks;

namespace AncientMonkey.Menus;

public class Classic : ChallengeTemplate
{
    public override string ChallengeName => "Classic";
    public override int Order => 0;
    public override string Background => VanillaSprites.MainBgPanelJukebox;
    public override string Icon => VanillaSprites.WoodenRoundButton;
    public override string Description => "" +
        "- The classic Ancient Monkey experience";

    public override void Edit()
    {
        Reseter.ChallengeReset();
    }
}
public class SuperWeapons : ChallengeTemplate
{
    public override string ChallengeName => "Super Weapons";
    public override int Order => 1;
    public override string Background => VanillaSprites.MainBGPanelYellow;
    public override string Icon => VanillaSprites.AdoraPortraitLvl20SunGod;
    public override string Description => "" +
        "- Every Weapon and Ability is Legendary or better";

    public override void Edit()
    {
        Reseter.ChallengeReset();
        AncientMonkey.mod.superWeapons = true;
    }
}
public class BlingedOut : ChallengeTemplate
{
    public override string ChallengeName => "Blinged Out";
    public override int Order => 2;
    public override string Background => VanillaSprites.MainBGPanelYellow;
    public override string Icon => VanillaSprites.UpgradeContainerParagonUnlocked;
    public override string Description => "" +
        "- Every weapon is guranteed to be gilded if it can be";

    public override void Edit()
    {
        Reseter.ChallengeReset();
        AncientMonkey.mod.blingedOut = true;
    }
}
public class AbilityMayhem : ChallengeTemplate
{
    public override string ChallengeName => "Ability Mayhem";
    public override int Order => 3;
    public override string Background => VanillaSprites.MainBGPanelSilver;
    public override string Icon => VanillaSprites.PowersIcon2;
    public override string Description => "" +
        "- Weapons and Strength upgrades are disabled\n" +
        "- Only the starting weapon is allowed\n" +
        "- New Abilities are cheaper";

    public override void Edit()
    {
        Reseter.ChallengeReset();
        AncientMonkey.mod.abilityMayhem = true;
    }
}
public class OneSlot : ChallengeTemplate
{
    public override string ChallengeName => "One Slot";
    public override int Order => 4;
    public override string Background => VanillaSprites.MainBGPanelSilver;
    public override string Icon => VanillaSprites.CoopPlayer1Icon;
    public override string Description => "" +
        "- Only one slot is available for new Weapons, Abilities, and Strength upgrades\n" +
        "- Additional upgrade slots are disabled";

    public override void Edit()
    {
        Reseter.ChallengeReset();
        AncientMonkey.mod.oneSlot = true;
    }
}
public class FoolsGold : ChallengeTemplate
{
    public override string ChallengeName => "Fool's Gold";
    public override int Order => 5;
    public override string Background => VanillaSprites.MainBGPanelSilver;
    public override string Icon => VanillaSprites.RubbertoGoldUpgradeIcon;
    public override string Description => "" +
        "- Every round up to 5 weapons will be removed from the tower\n" +
        "- Gilded weapons are safe from this effect\n" +
        "- Starting weapon is guaranteed to be gilded\n" +
        "- Gilded chance is reduced and the cost to upgrade it is increased\n" +
        "- Ace and Heli weapons are disabled";

    public override void Edit()
    {
        Reseter.ChallengeReset();
        AncientMonkey.mod.foolsGold = true;

        foreach (var weapon in GetContent<WeaponTemplate>())
        {
            if (weapon.CreateTower == true)
            {
                weapon.enabled = false;
            }
        }
    }
}
public class ErrorCode : ChallengeTemplate
{
    public override string ChallengeName => "Error Code";
    public override int Order => 6;
    public override string Background => VanillaSprites.MainBGPanelSilver;
    public override string Icon => VanillaSprites.MonkeyBusinessUpgradeIcon;
    public override string Description => "" +
        "- Every round the price of all upgrades will either increase or decrease by up to 50%";

    public override void Edit()
    {
        Reseter.ChallengeReset();
        AncientMonkey.mod.errorCode = true;
    }
}
public class MoneyStarved : ChallengeTemplate
{
    public override string ChallengeName => "Money Starved";
    public override int Order => 7;
    public override string Background => VanillaSprites.MainBGPanelSilver;
    public override string Icon => VanillaSprites.HalfCashIcon;
    public override string Description => "" +
        "- The costs of new Weapons, Abilities, and Strength upgrades are tripled\n" +
        "- The costs of all extra menu upgrades are doubled";

    public override void Edit()
    {
        Reseter.ChallengeReset();
        AncientMonkey.mod.moneyStarved = true;
        AncientMonkey.mod.upgradeMultiplier = 3;
        AncientMonkey.mod.extrasMultiplier = 2;
    }
}
public class PowerCreep : ChallengeTemplate
{
    public override string ChallengeName => "Power Creep";
    public override int Order => 8;
    public override string Background => VanillaSprites.MainBGPanelSilver;
    public override string Icon => VanillaSprites.UltraboostUpgradeIcon;
    public override string Description => "" +
        "- Weapon, Ability, and Strength upgrades are locked to Epic rarity or less\n" +
        "- Gilded weapons are disabled";

    public override void Edit()
    {
        Reseter.ChallengeReset();
        AncientMonkey.mod.powerCreep = true;
    }
}
public class Mastery : ChallengeTemplate
{
    public override string ChallengeName => "Mastery";
    public override int Order => 9;
    public override string Background => VanillaSprites.MainBgPanelHematite;
    public override string Icon => VanillaSprites.ImpoppableIcon;
    public override string Description => "" +
        "- Lead and Camo popping indicators will not show up\n" +
        "- Extras Menu is disabled\n" +
        "   - No additional upgrade slots\n" +
        "   - No luck\n" +
        "   - No Cash Generator\n" +
        "   - No tower upgrade\n" +
        "- The costs of new Weapons, Abilities, and Strength upgrades are increased\n" +
        "- Gilded weapons are disabled\n" +
        "- All money making weapons and abilities are disabled";

    public override void Edit()
    {
        Reseter.ChallengeReset();
        AncientMonkey.mod.mastery = true;
        AncientMonkey.mod.upgradeMultiplier = 2.5f;

        foreach (var weapon in GetContent<WeaponTemplate>())
        {
            if (weapon.MoneyMaker == true)
            {
                weapon.enabled = false;
            }
        }

        foreach (var ability in GetContent<AbilityTemplate>())
        {
            if (ability.MoneyMaker == true)
            {
                ability.enabled = false;
            }
        }
    }
}