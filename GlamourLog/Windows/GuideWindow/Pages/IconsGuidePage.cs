using Dalamud.Game.Text.SeStringHandling;

namespace GlamourLog.Windows.GuideWindow;

internal sealed class IconsGuidePage : IGuidePage {
    public string Id => "guide.icons";
    public GuideCategory Category => GuideCategory.Guide;
    public int Order => 0;
    public string Title => Loc.Get("Guide.Icons.Title");

    public IReadOnlyList<IGuideBlock> BuildBlocks(GuidePageContext context)
        => [
            new IconExampleBlock(
                IconExampleKind.Checkmark,
                new Lumina.Text.ReadOnly.ReadOnlySeString(
                    new SeStringBuilder().Markup(Loc.Get("Guide.Icons.Checkmark")).Encode())),
            new IconExampleBlock(
                IconExampleKind.Unobtainable,
                new Lumina.Text.ReadOnly.ReadOnlySeString(
                    new SeStringBuilder().Markup(Loc.Get("Guide.Icons.Unobtainable")).Encode())),
            new IconExampleBlock(
                IconExampleKind.FadedDresser,
                new Lumina.Text.ReadOnly.ReadOnlySeString(
                    new SeStringBuilder().Markup(Loc.Get("Guide.Icons.FadedDresser")).Encode())),
            new IconExampleBlock(
                IconExampleKind.Dresser,
                new Lumina.Text.ReadOnly.ReadOnlySeString(
                    new SeStringBuilder().Markup(Loc.Get("Guide.Icons.Dresser")).Encode())),
            new IconExampleBlock(
                IconExampleKind.Armoire,
                new Lumina.Text.ReadOnly.ReadOnlySeString(
                    new SeStringBuilder().Markup(Loc.Get("Guide.Icons.Armoire")).Encode())),
            new IconExampleBlock(
                IconExampleKind.WarningDresser,
                new Lumina.Text.ReadOnly.ReadOnlySeString(
                    new SeStringBuilder().Markup(Loc.Get("Guide.Icons.WarningDresser")).Encode())),
        ];
}
