using Dalamud.Game.Text.SeStringHandling;

namespace GlamourLog.Windows.GuideWindow;

internal sealed class IntegrationsGuidePage : IGuidePage {
    public string Id => "guide.integrations";
    public GuideCategory Category => GuideCategory.Guide;
    public int Order => 2;
    public string Title => Loc.Get("Guide.Integrations.Title");

    public IReadOnlyList<IGuideBlock> BuildBlocks(GuidePageContext context)
        => [
            new GuideTextBlock(
                new Lumina.Text.ReadOnly.ReadOnlySeString(
                    new SeStringBuilder()
                        .Append(Loc.Get("Guide.Integrations.Intro"))
                        .Encode())),
            new GuideTextBlock(
                new Lumina.Text.ReadOnly.ReadOnlySeString(
                    new SeStringBuilder()
                        .Markup(Loc.Get("Guide.Integrations.AllaganTools"))
                        .Encode())),
            new GuideTextBlock(
                new Lumina.Text.ReadOnly.ReadOnlySeString(
                    new SeStringBuilder()
                        .Markup(Loc.Get("Guide.Integrations.Vnavmesh"))
                        .Encode())),
            new GuideTextBlock(
                new Lumina.Text.ReadOnly.ReadOnlySeString(
                    new SeStringBuilder()
                        .Markup(Loc.Get("Guide.Integrations.AutoDuty"))
                        .Encode())),
        ];
}
