namespace NivalisNights.BoatControlBindings;

internal static class BoatHintPlacement
{
    // Coordinates are in native HUD units, measured from its bottom edge.
    internal static float Bottom(bool securityVisible, float securityTop, float safeBottom) =>
        securityVisible && float.IsFinite(securityTop) && float.IsFinite(safeBottom)
            ? Math.Max(20, securityTop - safeBottom + 12) : 20;
}
