namespace Close_the_gap.Controllers
{

    public enum MaterialType
    {
          CDDrive = 0, 
          ColourScreen = 1,
          DotMatrixPrinter = 2, 
          DockingStation = 3, 
          DumbTerminal = 4,
          DVDDrive = 5,
          FDD = 6,
          FlashMemory = 7,
          FlatScreen = 8,
          HardDisk = 9,
          InkjetPrinter = 10,
          Keyboard = 11,
          LaptopCase = 12,
          LCDDisplay = 13,
          LaserPrinter = 14,
          Laptop = 15,
          MouseMat = 16,
          Mouse =17,
          MultifunctionalPrinter =18,
          MonoScreen = 19,
          NetworkComponent = 20,
          OtherMachines = 21,
          PCSystem = 22,
          Plotter = 23,
          Rack = 24,
          StorageArray = 25,
          Scanner = 26,
          Software = 27,
          SmartPhone = 28,
          Server = 29,
          TabletPc = 30,
          Telephone = 31,
          VGACable = 32,
          GraphicalWorkstation = 33,
          ExplodedHardDrive = 34,
          Part = 35,     
    }

    static class MaterialTypeMethods
    {

        //public static int GetInt(this MaterialType type)
        //{
        //    return (int)type;
        //}

        public static MaterialType? GetMaterialEnum(string type)
        {
            switch (type)
            {
                case "CD":
                    return MaterialType.CDDrive ;
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
