var plIanaTimeZoneId = "Europe/Warsaw";

var plTimeZone = TimeZoneInfo.FindSystemTimeZoneById(plIanaTimeZoneId);
Console.WriteLine(plTimeZone.DisplayName);
// (UTC+01:00) Sarajevo, Skopje, Warsaw, Zagreb

TimeZoneInfo.TryConvertIanaIdToWindowsId(plIanaTimeZoneId, out var plWindowsId);
Console.WriteLine(plWindowsId);
// Central European Standard Time

TimeZoneInfo.TryConvertWindowsIdToIanaId(plWindowsId, out plIanaTimeZoneId);
Console.WriteLine(plIanaTimeZoneId);
// Europe/Warsaw

