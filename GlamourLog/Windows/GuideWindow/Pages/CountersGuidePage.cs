using Dalamud.Game.Text.SeStringHandling;

namespace GlamourLog.Windows.GuideWindow;

internal sealed class CountersGuidePage : IGuidePage {
    public string Id => "guide.counters";
    public GuideCategory Category => GuideCategory.Guide;
    public int Order => 1;
    public string Title => Loc.Get("Guide.Counters.Title");

    public IReadOnlyList<IGuideBlock> BuildBlocks(GuidePageContext context)
        => [
            new GuideTextBlock(new Lumina.Text.ReadOnly.ReadOnlySeString(
                new SeStringBuilder().Append(Loc.Get("Guide.Counters.Completed") + "\n")
                .Append(Loc.Get("Guide.Counters.Saved") + "\n\n")
                .Footnote(Loc.Get("Guide.Counters.FootnoteCombined") + "\n")
                .Footnote(Loc.Get("Guide.Counters.FootnoteMisc")).Encode())),
        ];
}
