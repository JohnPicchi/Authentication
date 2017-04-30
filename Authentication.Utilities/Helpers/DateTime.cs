namespace Authentication.Utilities.Helpers
{
  public static partial class Helpers
  {
    public static partial class DateTime
    {
      public struct UtcOffset
      {
        public const double Pst = -8.00;
        public const double Cst = -6.00;
        public const double Est = -5.00;
      }

      public struct UtcOffsetDisplayNames
      {
        public const string Pst = @"PST (UTC-8)";
        public const string Cst = @"CST (UTC-6)";
        public const string Est = @"EST (UTC-5)";
        public const string Utc = @"UTC (UTC+0)";
      }

      public static System.DateTime EstNow => System.DateTime.UtcNow.AddHours(UtcOffset.Est);

      public static System.DateTime CstNow => System.DateTime.UtcNow.AddHours(UtcOffset.Cst);

      public static System.DateTime PstNow => System.DateTime.UtcNow.AddHours(UtcOffset.Pst);
    }
  }
}
