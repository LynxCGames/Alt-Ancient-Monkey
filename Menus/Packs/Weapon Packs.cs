using BTD_Mod_Helper;
using BTD_Mod_Helper.Api;
using System.Linq;
using WeaponPacks;

namespace AncientMonkey.Menus;

public class WeaponPacks : BloonsTD6Mod
{
    public static void PackSelect(PackTemplate weaponPack)
    {
        foreach (var pack in ModContent.GetContent<WeaponTemplate>())
        {
            if (pack.WeaponPack == weaponPack.WeaponPack)
            {
                pack.enabled = !pack.enabled;
            }
        }

        foreach (var pack in ModContent.GetContent<AbilityTemplate>())
        {
            if (pack.WeaponPack == weaponPack.WeaponPack)
            {
                pack.enabled = !pack.enabled;
            }
        }

        foreach (var pack in ModContent.GetContent<UpgradedAbilityTemplate>())
        {
            if (pack.WeaponPack == weaponPack.WeaponPack)
            {
                pack.enabled = !pack.enabled;
            }
        }

        for (var i = 0; i < AncientMonkey.mod.packUpgrades.Count(); i++)
        {
            if (weaponPack.isSelected) { AncientMonkey.mod.packUpgrades[i] -= weaponPack.Upgrades[i]; }
            else { AncientMonkey.mod.packUpgrades[i] += weaponPack.Upgrades[i]; }
        }
    }
}

public class PrimaryPack : PackTemplate
{
    public override string PackName => "Primary Pack";
    public override string WeaponPack => "PrimaryPack";
    public override int Order => 0;
    public override int[] Upgrades => [1, 1, 1, 1, 1, 1, 1, 1, 0];
    public override void Edit()
    {
        WeaponPacks.PackSelect(this);
    }
}
public class MilitaryPack : PackTemplate
{
    public override string PackName => "Military Pack";
    public override string WeaponPack => "MilitaryPack";
    public override int Order => 1;
    public override int[] Upgrades => [1, 1, 1, 1, 1, 0, 1, 1, 1];
    public override void Edit()
    {
        WeaponPacks.PackSelect(this);
    }
}
public class MagicPack : PackTemplate
{
    public override string PackName => "Magic Pack";
    public override string WeaponPack => "MagicPack";
    public override int Order => 2;
    public override int[] Upgrades => [1, 1, 1, 1, 1, 1, 1, 1, 1];
    public override void Edit()
    {
        WeaponPacks.PackSelect(this);
    }
}
public class SupportPack : PackTemplate
{
    public override string PackName => "Support Pack";
    public override string WeaponPack => "SupportPack";
    public override int Order => 3;
    public override int[] Upgrades => [1, 1, 1, 1, 1, 0, 1, 1, 1];
    public override void Edit()
    {
        WeaponPacks.PackSelect(this);
    }
}
public class HeroPack : PackTemplate
{
    public override string PackName => "Hero Pack";
    public override string WeaponPack => "HeroPack";
    public override int Order => 4;
    public override int[] Upgrades => [1, 1, 1, 1, 1, 1, 1, 1, 1];
    public override void Edit()
    {
        WeaponPacks.PackSelect(this);
    }
}
public class MemePack : PackTemplate
{
    public override string PackName => "Meme Pack";
    public override string WeaponPack => "MemePack";
    public override int Order => 5;
    public override int[] Upgrades => [1, 1, 1, 1, 1, 0, 0, 0, 0];
    public override void Edit()
    {
        WeaponPacks.PackSelect(this);
    }
}

public class HuborTowerPack : PackTemplate
{
    public override string PackName => "Hubor Towers";
    public override string WeaponPack => "HuborPack";
    public override int Order => 5;
    public override int[] Upgrades => [1, 1, 1, 1, 1, 0, 1, 1, 0];
    public override void Edit()
    {
        WeaponPacks.PackSelect(this);
    }
}
public class DarksTowerPack : PackTemplate
{
    public override string PackName => "Dark's Towers";
    public override string WeaponPack => "DarksTowerPack";
    public override int Order => 5;
    public override int[] Upgrades => [0, 1, 1, 1, 1, 0, 0, 0, 0];
    public override void Edit()
    {
        WeaponPacks.PackSelect(this);
    }
}
public class SpookyPack : PackTemplate
{
    public override string PackName => "Spooky Pack";
    public override string WeaponPack => "SpookyPack";
    public override int Order => 5;
    public override int[] Upgrades => [1, 1, 1, 1, 1, 1, 1, 1, 1];
    public override void Edit()
    {
        WeaponPacks.PackSelect(this);
    }
}