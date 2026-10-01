using Dalamud.Game.Text.SeStringHandling;

namespace GlamourLog.Windows.GuideWindow;

internal sealed class LootWindowGuidePage : IGuidePage {
    public string Id => "tweaks.loot-window";
    public GuideCategory Category => GuideCategory.Tweaks;
    public int Order => 3;
    public string Title => Loc.Get("Guide.LootWindow.Title");

    public IReadOnlyList<IGuideBlock> BuildBlocks(GuidePageContext context)
        => [
            new GuideTextBlock(
                new Lumina.Text.ReadOnly.ReadOnlySeString(
                    new SeStringBuilder()
                        .Append(Loc.Get("Guide.LootWindow.Intro"))
                        .Encode())),
            new IconExampleBlock(
                IconExampleKind.Armoire,
                new Lumina.Text.ReadOnly.ReadOnlySeString(
                    new SeStringBuilder()
                        .Markup(Loc.Get("Guide.LootWindow.Armoire"))
                        .Encode())),
            new IconExampleBlock(
                IconExampleKind.Dresser,
                new Lumina.Text.ReadOnly.ReadOnlySeString(
                    new SeStringBuilder()
                        .Markup(Loc.Get("Guide.LootWindow.Dresser"))
                        .Encode())),
        ];
}
