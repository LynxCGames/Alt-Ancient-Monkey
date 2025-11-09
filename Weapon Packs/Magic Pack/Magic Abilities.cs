using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppNinjaKiwi.Common.ResourceUtils;
using System.Linq;

namespace WeaponPacks;

// #### Common ####

public class DarkShift : AbilityTemplate
{
    public override string WeaponPack => "MagicPack";
    public override int SandboxIndex => 1;
    public override Rarity AbilityRarity => Rarity.Common;
    public override string AbilityName => "Dark Shift";
    public override string CodeName => "DarkShift";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.DarkKnightUpgradeIconAA);
    public override int upgradeCost => 6000;
    public override void EditTower(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var ab = Game.instance.model.GetTowerFromId("SuperMonkey-003").GetAbility().Duplicate();
        ab.name = "Ability" + AbilityRarity + CodeName;
        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);
    }
    public override void Upgrade(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        towerModel.RemoveBehavior(towerModel.GetAbilities().First(model => model.name.Contains(CodeName)));

        var ab = Game.instance.model.GetTowerFromId("SuperMonkey-004").GetAbility().Duplicate();
        ab.name = "AbilityUpgradedTeleportation";
        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);
    }
}
public class JunglesBounty : AbilityTemplate
{
    public override string WeaponPack => "MagicPack";
    public override int SandboxIndex => 1;
    public override Rarity AbilityRarity => Rarity.Common;
    public override string AbilityName => "Jungle's Bounty";
    public override string CodeName => "JunglesBounty";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.JunglesBountyUpgradeIconAA);
    public override int upgradeCost => 35000;
    public override bool MoneyMaker => true;
    public override void EditTower(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var ab = Game.instance.model.GetTowerFromId("Druid-040").GetAbility().Duplicate();
        ab.name = "Ability" + AbilityRarity + CodeName;
        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);
    }
    public override void Upgrade(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        towerModel.RemoveBehavior(towerModel.GetAbilities().First(model => model.name.Contains(CodeName)));

        var vines = Game.instance.model.GetTowerFromId("Druid-150").GetBehavior<SpiritOfTheForestModel>().Duplicate();
        towerModel.AddBehavior(vines);

        var ab = Game.instance.model.GetTowerFromId("Druid-050").GetAbility().Duplicate();
        ab.name = "AbilityUpgradedSpiritOfTheForest";
        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);
    }
}

// #### Rare ####

public class BloonSabotage : AbilityTemplate
{
    public override string WeaponPack => "MagicPack";
    public override int SandboxIndex => 2;
    public override Rarity AbilityRarity => Rarity.Rare;
    public override string AbilityName => "Bloon Sabotage";
    public override string CodeName => "BloonSabotage";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.BloonSabotageUpgradeIcon);
    public override int upgradeCost => 24000;
    public override void EditTower(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var ab = Game.instance.model.GetTowerFromId("NinjaMonkey-040").GetAbility().Duplicate();
        ab.name = "Ability" + AbilityRarity + CodeName;
        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);
    }
    public override void Upgrade(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        towerModel.RemoveBehavior(towerModel.GetAbilities().First(model => model.name.Contains(CodeName)));

        var ab = Game.instance.model.GetTowerFromId("NinjaMonkey-050").GetAbility().Duplicate();
        ab.name = "AbilityUpgradedGrandSabotage";
        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);
    }
}

// #### Epic ####

public class SummoningPhoenix : AbilityTemplate
{
    public override string WeaponPack => "MagicPack";
    public override int SandboxIndex => 3;
    public override Rarity AbilityRarity => Rarity.Epic;
    public override string AbilityName => "Summon Phoenix";
    public override string CodeName => "SummoningPhoenix";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.SummonPhoenixUpgradeIcon);
    public override void EditTower(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var ab = Game.instance.model.GetTowerFromId("WizardMonkey-042").GetAbility().Duplicate();
        ab.name = "Ability" + AbilityRarity + CodeName;
        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);
    }
    public override void Upgrade(Tower tower) { }
}
public class TechTerror : AbilityTemplate
{
    public override string WeaponPack => "MagicPack";
    public override int SandboxIndex => 3;
    public override Rarity AbilityRarity => Rarity.Epic;
    public override string AbilityName => "Tech Terror";
    public override string CodeName => "TechTerror";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.TechTerrorUpgradeIconAA);
    public override void EditTower(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var ab = Game.instance.model.GetTowerFromId("SuperMonkey-040").GetAbility().Duplicate();
        ab.name = "Ability" + AbilityRarity + CodeName;
        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);
    }
    public override void Upgrade(Tower tower) { }
}

// #### Legendary ####

public class PermaPhoenix : AbilityTemplate
{
    public override string WeaponPack => "MagicPack";
    public override int SandboxIndex => 4;
    public override Rarity AbilityRarity => Rarity.Legendary;
    public override string AbilityName => "Perma Phoenix";
    public override string CodeName => "PermaPhoenix";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.WizardLordPhoenixUpgradeIcon);
    public override void EditTower(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var phoenix = Game.instance.model.GetTowerFromId("WizardMonkey-050").GetBehavior<TowerCreateTowerModel>().Duplicate();
        phoenix.name = "Ability" + AbilityRarity + CodeName;
        towerModel.AddBehavior(phoenix);
        tower.UpdateRootModel(towerModel);
    }
    public override void Upgrade(Tower tower) { }
}
public class PopseidonAA : AbilityTemplate
{
    public override string WeaponPack => "MagicPack";
    public override int SandboxIndex => 4;
    public override Rarity AbilityRarity => Rarity.Legendary;
    public override string AbilityName => "Popseidon";
    public override string CodeName => "PopseidonAA";
    public override SpriteReference Icon => CreateSpriteReference("897071237de03fe4b9bea8152498a8ae");
    public override void EditTower(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var ab = Game.instance.model.GetTowerFromId("Mermonkey-050").GetAbility().Duplicate();
        ab.name = "Ability" + AbilityRarity + CodeName;
        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);
    }
    public override void Upgrade(Tower tower) { }
}

// #### Upgraded ####

public class SpiritOfTheForest : UpgradedAbilityTemplate
{
    public override string WeaponPack => "MagicPack";
    public override string AbilityName => "Spirit of the Forest";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.SpiritoftheForestUpgradeIcon);
    public override void EditTower(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();

        var vines = Game.instance.model.GetTowerFromId("Druid-150").GetBehavior<SpiritOfTheForestModel>().Duplicate();
        towerModel.AddBehavior(vines);

        var ab = Game.instance.model.GetTowerFromId("Druid-050").GetAbility().Duplicate();
        ab.name = "AbilityUpgradedSpiritOfTheForest";
        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);
    }
}
public class Teleportation : UpgradedAbilityTemplate
{
    public override string WeaponPack => "MagicPack";
    public override string AbilityName => "Teleportation";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.DarkChampionUpgradeIconAA);
    public override void EditTower(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var ab = Game.instance.model.GetTowerFromId("SuperMonkey-004").GetAbility().Duplicate();
        ab.name = "AbilityUpgradedTeleportation";
        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);
    }
}
public class GrandSabotage : UpgradedAbilityTemplate
{
    public override string WeaponPack => "MagicPack";
    public override string AbilityName => "Grand Sabotage";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.GrandSaboteurUpgradeIcon);
    public override void EditTower(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var ab = Game.instance.model.GetTowerFromId("NinjaMonkey-050").GetAbility().Duplicate();
        ab.name = "AbilityUpgradedGrandSabotage";
        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);
    }
}