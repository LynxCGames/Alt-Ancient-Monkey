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

// #### Rare ####

public class SpikeStorm : AbilityTemplate
{
    public override string WeaponPack => "SupportPack";
    public override int SandboxIndex => 2;
    public override Rarity AbilityRarity => Rarity.Rare;
    public override string AbilityName => "Spike Storm";
    public override string CodeName => "SpikeStorm";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.SpikeStormUpgradeIcon);
    public override int upgradeCost => 12000;
    public override string upgradeName => "CarpetOfSpike";
    public override void EditTower(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var ab = Game.instance.model.GetTowerFromId("SpikeFactory-040").GetAbility().Duplicate();
        ab.name = "Ability" + AbilityRarity + CodeName;
        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);
    }
    public override void Upgrade(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        towerModel.RemoveBehavior(towerModel.GetAbilities().First(model => model.name.Contains(CodeName)));

        var ab = Game.instance.model.GetTowerFromId("SpikeFactory-050").GetAbility().Duplicate();
        ab.name = "AbilityLegendaryCarpetOfSpike";
        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);
    }
}
public class Overclock : AbilityTemplate
{
    public override string WeaponPack => "SupportPack";
    public override int SandboxIndex => 2;
    public override Rarity AbilityRarity => Rarity.Rare;
    public override string AbilityName => "Overclock";
    public override string CodeName => "Overclock";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.OverclockUpgradeIcon);
    public override int upgradeCost => 40000;
    public override void EditTower(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var ab = Game.instance.model.GetTowerFromId("EngineerMonkey-040").GetAbility().Duplicate();
        ab.name = "Ability" + AbilityRarity + CodeName;
        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);
    }
    public override void Upgrade(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        towerModel.RemoveBehavior(towerModel.GetAbilities().First(model => model.name.Contains(CodeName)));

        var ab = Game.instance.model.GetTowerFromId("EngineerMonkey-050").GetAbility().Duplicate();
        ab.name = "AbilityUpgradedUltraboost";
        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);
    }
}

// #### Epic ####

public class TRex : AbilityTemplate
{
    public override string WeaponPack => "SupportPack";
    public override int SandboxIndex => 3;
    public override Rarity AbilityRarity => Rarity.Epic;
    public override string AbilityName => "Tyrannosaurus Rex";
    public override string CodeName => "TRex";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.TRexStompAA);
    public override void EditTower(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var ab = Game.instance.model.GetTowerFromId("BeastHandler-040").GetBehavior<BeastHandlerLeashModel>().towerModel.GetAbility().Duplicate();
        ab.name = "Ability" + AbilityRarity + CodeName;
        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);
    }
    public override void Upgrade(Tower tower) { }
}

// #### Legendary ####

public class CarpetOfSpike : AbilityTemplate
{
    public override string WeaponPack => "SupportPack";
    public override int SandboxIndex => 4;
    public override Rarity AbilityRarity => Rarity.Legendary;
    public override string AbilityName => "Carpet Of Spike";
    public override string CodeName => "CarpetOfSpike";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.CarpetOfSpikesUpgradeIcon);
    public override void EditTower(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var ab = Game.instance.model.GetTowerFromId("SpikeFactory-250").GetAbility().Duplicate();
        ab.name = "Ability" + AbilityRarity + CodeName;
        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);
    }
    public override void Upgrade(Tower tower) { }
}
public class MonkeyNomics : AbilityTemplate
{
    public override string WeaponPack => "SupportPack";
    public override int SandboxIndex => 4;
    public override Rarity AbilityRarity => Rarity.Legendary;
    public override string AbilityName => "Monkey-Nomics";
    public override string CodeName => "MonkeyNomics";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.MonkeyNomicsUpgradeIcon);
    public override bool MoneyMaker => true;
    public override void EditTower(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var ab = Game.instance.model.GetTowerFromId("BananaFarm-050").GetAbility().Duplicate();
        ab.name = "Ability" + AbilityRarity + CodeName;
        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);
    }
    public override void Upgrade(Tower tower) { }
}

// #### Upgraded ####

public class Ultraboost : UpgradedAbilityTemplate
{
    public override string WeaponPack => "SupportPack";
    public override string AbilityName => "Ultraboost";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.UltraboostUpgradeIcon);
    public override void EditTower(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var ab = Game.instance.model.GetTowerFromId("EngineerMonkey-050").GetAbility().Duplicate();
        ab.name = "AbilityUpgradedUltraboost";
        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);
    }
}