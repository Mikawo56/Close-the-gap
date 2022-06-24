namespace Close_the_gap.Controllers
{
    public enum CTGCircularColumn
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

    static class CTGCircularColumnMethods
    {

        public static int GetInt(this CTGCircularColumn column)
        {
            return (int)column;
        }
    }
}
