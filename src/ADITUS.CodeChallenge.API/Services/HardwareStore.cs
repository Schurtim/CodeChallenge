using ADITUS.CodeChallenge.API.Domain;

namespace ADITUS.CodeChallenge.API.Services
{
  public static class HardwareStore
  {
    public static readonly List<Hardware> Hardware = new List<Hardware>
    {
      new Hardware()
      {
        Type = HardwareType.Drehsperre,
        Name = "Drehsperre1",
        Description = "Drehsperre 1",
        },
      new Hardware()
      {
        Type = HardwareType.Drehsperre,
        Name = "Drehsperre2",
        Description = "Drehsperre 2",
        },
       new Hardware()
      {
        Type = HardwareType.Drehsperre,
        Name = "Drehsperre3",
        Description = "Drehsperre 3",
        },
       new Hardware()
      {
        Type = HardwareType.Funkhandscanner,
        Name = "Funkhandscanner1",
        Description = "Funkhandscanner 1",
        },
       new Hardware()
      {
        Type = HardwareType.Funkhandscanner,
        Name = "Funkhandscanner2",
        Description = "Funkhandscanner 2",
        },
       new Hardware()
      {
        Type = HardwareType.Funkhandscanner,
        Name = "Funkhandscanner3",
        Description = "Funkhandscanner 3",
        },
       new Hardware()
      {
        Type = HardwareType.MobilesScanTerminal,
        Name = "MobilesScanTerminal1",
        Description = "MobilesScanTerminal 1",
        },
       new Hardware()
      {
        Type = HardwareType.MobilesScanTerminal,
        Name = "MobilesScanTerminal2",
        Description = "MobilesScanTerminal 2",
        },
       new Hardware()
      {
        Type = HardwareType.MobilesScanTerminal,
        Name = "MobilesScanTerminal3",
        Description = "MobilesScanTerminal 3",
        },
    };
  }
}
