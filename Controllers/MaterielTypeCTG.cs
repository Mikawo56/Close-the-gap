namespace Close_the_gap.Controllers
{
    public enum MaterialTypeCTG
    {
        ReconditionnerLoadNumber = 0,
        ReconditionnerTrackingReference = 1,
        SerialNumber = 2,
        AssetTag = 3,
        Type = 5,
        Brand = 6,
        Model = 7,
        CustomSpecifications = 8,
        CustomDefects = 9,
        CustomGrade = 10
    }

    static class MaterialTypeCTGMethods
    {

        public static int GetInt(this MaterialType type)
        {
            return (int)type;
        }

        public static MaterialType? GetMaterialEnum(string type)
        {
            switch (type)
            {
                case "CD":
                    return MaterialType.CDDrive;
                case "CS":
                    return MaterialType.ColourScreen;
                case "DP":
                    return MaterialType.DotMatrixPrinter;
                case "DS":
                    return MaterialType.DockingStation;
                case "DT":
                    return MaterialType.DumbTerminal;
                case "DV":
                    return MaterialType.DVDDrive;
                case "FD ":
                    return MaterialType.FDD;
                case "FM":
                    return MaterialType.FlashMemory;
                case "FS":
                    return MaterialType.FlatScreen;
                case "HD":
                    return MaterialType.HardDisk;
                case "IP":
                    return MaterialType.InkjetPrinter;
                case "KB":
                    return MaterialType.Keyboard;
                case "LC":
                    return MaterialType.LaptopCase;
                case "LD":
                    return MaterialType.LCDDisplay;
                case "LP":
                    return MaterialType.LaserPrinter;
                case "LT":
                    return MaterialType.Laptop;
                case "MM":
                    return MaterialType.MouseMat;
                case "MO ":
                    return MaterialType.Mouse;
                case "MP ":
                    return MaterialType.MultifunctionalPrinter;
                case "MS":
                    return MaterialType.MonoScreen;
                case "NC":
                    return MaterialType.NetworkComponent;
                case "OT":
                    return MaterialType.OtherMachines;
                case "PC":
                    return MaterialType.PCSystem;
                case "PL":
                    return MaterialType.Plotter;
                case "RA":
                    return MaterialType.Rack;
                case "SA":
                    return MaterialType.StorageArray;
                case "SC ":
                    return MaterialType.Scanner;
                case "SO":
                    return MaterialType.Software;
                case "SP":
                    return MaterialType.SmartPhone;
                case "SV  ":
                    return MaterialType.Server;
                case "TC ":
                    return MaterialType.TabletPc;
                case "TE":
                    return MaterialType.Telephone;
                case "VG":
                    return MaterialType.VGACable;
                case "WS":
                    return MaterialType.GraphicalWorkstation;
                case "XH":
                    return MaterialType.ExplodedHardDrive;
                case "XX":
                    return MaterialType.Part;

                default: /* Optional */
                    return null;
            }
        }
    }
}
