using Nivalis.Localization;

namespace NivalisNights.FlatNivalisTimes;

internal static class Texts
{
    internal readonly record struct Entry(string Title, string Immediate, string Error);
    internal static readonly Dictionary<Language, Entry> All = new()
    {
        [Language.English] = new("Improve newspaper readability", "Changes apply immediately.", "Could not change the setting."),
        [Language.German] = new("Zeitung besser lesbar machen", "Änderungen werden sofort wirksam.", "Die Einstellung konnte nicht geändert werden."),
        [Language.French] = new("Améliorer la lisibilité du journal", "Les changements sont immédiats.", "Impossible de modifier ce paramètre."),
        [Language.Korean] = new("신문 가독성 개선", "변경 사항이 즉시 적용됩니다.", "설정을 변경하지 못했습니다."),
        [Language.Japanese] = new("新聞を読みやすくする", "変更はすぐに反映されます。", "設定を変更できませんでした。"),
        [Language.SChinese] = new("提高报纸可读性", "更改立即生效。", "无法更改设置。"),
        [Language.TChinese] = new("提高報紙可讀性", "變更立即生效。", "無法變更設定。"),
        [Language.Spanish] = new("Mejorar la legibilidad del periódico", "Los cambios se aplican al instante.", "No se pudo cambiar el ajuste."),
        [Language.Portuguese] = new("Melhorar a legibilidade do jornal", "As alterações são aplicadas de imediato.", "Não foi possível alterar a configuração."),
        [Language.Russian] = new("Улучшить читаемость газеты", "Изменения применяются сразу.", "Не удалось изменить настройку."),
        [Language.Turkish] = new("Gazetenin okunabilirliğini artır", "Değişiklikler hemen uygulanır.", "Ayar değiştirilemedi."),
    };

    internal static Entry Current => All.TryGetValue(LocObjectsDB.CurrentLanguage, out var entry) ? entry : All[Language.English];
}
