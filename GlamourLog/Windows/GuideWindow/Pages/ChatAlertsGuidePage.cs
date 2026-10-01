using Dalamud.Game.Text.SeStringHandling;

namespace GlamourLog.Windows.GuideWindow;

internal sealed class ChatAlertsGuidePage : IGuidePage {
    public string Id => "tweaks.chat-alerts";
    public GuideCategory Category => GuideCategory.Tweaks;
    public int Order => 2;
    public string Title => Loc.Get("Guide.ChatAlerts.Title");

    private const string LinkMarker = "\u0001";

    public IReadOnlyList<IGuideBlock> BuildBlocks(GuidePageContext context)
        => [
            new GuideTextBlock(
                new Lumina.Text.ReadOnly.ReadOnlySeString(
                    new SeStringBuilder()
                        .Append(Loc.Get("Guide.ChatAlerts.Intro")).Encode())),
            new GuideTextBlock(
                new Lumina.Text.ReadOnly.ReadOnlySeString(
                    AppendWithLink(ExampleLoot(32597), Loc.Format("ChatAlert.SetProgress", 3, 5, LinkMarker), 51550)
                        .Encode())),
            new GuideTextBlock(
                new Lumina.Text.ReadOnly.ReadOnlySeString(
                    AppendWithLink(ExampleLoot(32622), Loc.Format("ChatAlert.FinalPiece", LinkMarker), 51550)
                        .Encode())),
            new GuideTextBlock(
                new Lumina.Text.ReadOnly.ReadOnlySeString(
                    ExampleLoot(50933)
                        .Append(Loc.Get("ChatAlert.ArmoireItem"))
                        .Encode())),
            new GuideTextBlock(
                new Lumina.Text.ReadOnly.ReadOnlySeString(
                    new SeStringBuilder()
                        .Append(Loc.Get("Guide.ChatAlerts.AlreadyOwned"))
                        .Encode())),
        ];

    // mimics the game's loot notice, which is itself localized by the client
    private static SeStringBuilder ExampleLoot(uint itemId)
        => AppendWithLink(new SeStringBuilder(), Loc.Format("Guide.ChatAlerts.ExampleLoot", LinkMarker), itemId);

    private static SeStringBuilder AppendWithLink(SeStringBuilder builder, string text, uint itemId) {
        var parts = text.Split(LinkMarker, 2);
        builder.Append(parts[0]);
        if (parts.Length == 2)
            builder.Append(SeString.CreateItemLink(itemId)).Append(parts[1]);
        return builder;
    }
}
