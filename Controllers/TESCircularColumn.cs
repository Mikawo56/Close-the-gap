using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Close_the_gap.Controllers
{
    public enum TESCircularColumn
    {
        ReconditionnerBookNumber = 0,
        Manufacturer = 1,
        Model = 2,
        Processor = 3,
        ScreenSize = 5,
        Memory = 6,
        FDD = 7,
        HDD = 8,
        CDROM = 9,
        SerialNumber = 10,
        AssetTag = 11,
        StockType = 12,
        Weight = 13,
        ConditionCode = 14,
        StockComments = 15,
        DiskStatus = 16,
        ParentIdOfHDD = 17,
        ProcessingFee = 18,
    }
  
    static class TESCircularColumnMethods
    {

        public static int GetInt(this TESCircularColumn column)
        {
            return (int)column;
        }
    }
}
