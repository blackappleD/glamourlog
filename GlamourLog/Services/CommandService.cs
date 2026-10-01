using FFXIVClientStructs.FFXIV.Component.GUI;
using GlamourLog.Tweaks.Cabinet;
using GlamourLog.Tweaks.PrismBox;

namespace GlamourLog.Services;

internal sealed class CommandService : IPluginCommands {
    public string[] Commands { get; } = ["/glamourlog", "/gl"];
    public string HelpMessage => Loc.Get("Command.Help");

    public CommandNode<object> Root => field ??= Build();

    private static CommandNode<object> Build()
        => CommandNode<object>.Root(Loc.Get("Command.Root"))
            .Default(WindowsService.Get().ToggleMainWindow)
            .Sub("stop", Loc.Get("Command.Stop"), Svc.Automation.Stop)
            .Sub("store", Loc.Get("Command.Store"), () => {
                if (AtkUnitBase.IsAddonReady("Cabinet"))
                    Svc.Automation.Start(new StoreAllArmoireTask());
                if (AtkUnitBase.IsAddonReady("MiragePrismPrismBoxCrystallize"))
                    Svc.Automation.Start(new StoreAllDresserTask());
            });
}
