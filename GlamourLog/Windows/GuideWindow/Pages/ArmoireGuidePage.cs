using Dalamud.Game.Text.SeStringHandling;
using GlamourLog.Nodes.GuideWindow;
using KamiToolKit.Enums;

namespace GlamourLog.Windows.GuideWindow;

internal sealed class ArmoireGuidePage : IGuidePage {
    public string Id => "tweaks.armoire";
    public GuideCategory Category => GuideCategory.Tweaks;
    public int Order => 0;
    public string Title => Loc.Get("Guide.Armoire.Title");

    public IReadOnlyList<IGuideBlock> BuildBlocks(GuidePageContext context)
        => [
            new GuideTextBlock(
                new Lumina.Text.ReadOnly.ReadOnlySeString(
                    new SeStringBuilder()
                        .Append(Loc.Get("Guide.Armoire.Intro"))
                        .Encode())),
            new CircleButtonExampleBlock(
                CircleButtonIcon.GearCog,
                new Lumina.Text.ReadOnly.ReadOnlySeString(
                    new SeStringBuilder()
                        .Markup(Loc.Get("Guide.Tweak.Filters"))
                        .Encode())),
            new GuideTextBlock(
                new Lumina.Text.ReadOnly.ReadOnlySeString(
                    new SeStringBuilder()
                        .Emphasis(Loc.Get("AddonFilter.HideDeposited"))
                        .Encode()),
                TextLeftInset: Constants.IconTextLeft),
            new GuideTextBlock(
                new Lumina.Text.ReadOnly.ReadOnlySeString(
                    new SeStringBuilder()
                        .Emphasis(Loc.Get("AddonFilter.Armoire.HideGearset"))
                        .Encode()),
                TextLeftInset: Constants.IconTextLeft),
            new CircleButtonExampleBlock(
                CircleButtonIcon.Chest,
                new Lumina.Text.ReadOnly.ReadOnlySeString(
                    new SeStringBuilder()
                        .Markup(Loc.Get("Guide.Armoire.StoreAll"))
                        .Encode())),
        ];
}
