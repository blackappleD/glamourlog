using AllaganLib.GameSheets.Caches;

namespace GlamourLog;

internal readonly record struct SourceFilterOption(ItemInfoType? Type, string Label) {
    internal static SourceFilterOption All { get; } = new(null, Loc.Get("Filter.AllSources"));
}

internal readonly record struct SourceSubFilterOption(string Key, string Label);
