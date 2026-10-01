using Dalamud.Plugin;
using Newtonsoft.Json;

namespace GlamourLog.Localization;

/// <summary>
/// Lightweight UI string table. Follows the Dalamud UI language and falls back to English
/// for missing keys/languages. Text is resolved when nodes are built, so a language change
/// applies the next time a window is opened.
/// </summary>
public static class Loc {
    public const string DefaultLanguage = "en";

    public static readonly IReadOnlyList<(string Code, string Name)> SupportedLanguages = [
        ("en", "English"),
        ("zh", "简体中文"),
    ];

    private static Dictionary<string, string> _fallback = [];
    private static Dictionary<string, string> _current = [];

    public static string CurrentLanguage { get; private set; } = DefaultLanguage;
    public static bool IsDefault => CurrentLanguage == DefaultLanguage;

    public static event System.Action? LanguageChanged;

    private static IDalamudPluginInterface? _pluginInterface;

    public static void Init(IDalamudPluginInterface pluginInterface) {
        _pluginInterface = pluginInterface;
        _fallback = Load(DefaultLanguage) ?? [];
        pluginInterface.LanguageChanged += OnDalamudLanguageChanged;
        Apply();
    }

    public static void Dispose() {
        if (_pluginInterface != null)
            _pluginInterface.LanguageChanged -= OnDalamudLanguageChanged;
        _pluginInterface = null;
        LanguageChanged = null;
    }

    private static void OnDalamudLanguageChanged(string langCode) => Apply();

    public static void Apply() {
        var code = ResolveLanguage();
        _current = code == DefaultLanguage ? _fallback : Load(code) ?? _fallback;
        CurrentLanguage = code;
        LanguageChanged?.Invoke();
    }

    public static string Get(string key) {
        if (_current.TryGetValue(key, out var text) || _fallback.TryGetValue(key, out text))
            return text;
        IPluginLog.Get().Verbose($"[Loc] Missing key: {key}");
        return key;
    }

    /// <summary>Returns the translation for <paramref name="key"/> or <paramref name="fallback"/> if none exists.</summary>
    public static string GetOr(string key, string fallback)
        => _current.TryGetValue(key, out var text) || _fallback.TryGetValue(key, out text) ? text : fallback;

    public static string Format(string key, params object?[] args) {
        try {
            return string.Format(Get(key), args);
        } catch (FormatException) {
            return _fallback.TryGetValue(key, out var text) ? string.Format(text, args) : key;
        }
    }

    /// <summary>Display name for an internal (English) category id.</summary>
    public static string Category(string categoryId) => GetOr($"Category.{categoryId}", categoryId);

    private static string ResolveLanguage() {
        // accept region-qualified codes ("zh-CN", "zh_CN") as their base language
        var code = (_pluginInterface?.UiLanguage ?? DefaultLanguage).Split('-', '_')[0].ToLowerInvariant();
        return SupportedLanguages.Any(l => l.Code == code) ? code : DefaultLanguage;
    }

    private static Dictionary<string, string>? Load(string code) {
        try {
            using var stream = typeof(Loc).Assembly.GetManifestResourceStream($"GlamourLog.Localization.{code}.json");
            if (stream == null)
                return null;
            using var reader = new System.IO.StreamReader(stream);
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(reader.ReadToEnd());
        } catch (Exception ex) {
            IPluginLog.Get().Error(ex, $"[Loc] Failed to load language {code}");
            return null;
        }
    }
}
