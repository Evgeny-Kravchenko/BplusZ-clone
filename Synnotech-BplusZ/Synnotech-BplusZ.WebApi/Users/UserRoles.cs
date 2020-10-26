namespace Synnotech_BplusZ.WebApi.Users
{
    public static class UserRoles
    {
        public const string GF = "GF";
        public const string NLL = "NLL";
        public const string Teamleiter = "Teamleiter";
        public const string Mitarbeiter = "Mitarbeiter";
        public const string Administrator = "Administrator";
        public const string FP = "FP";

        public const string FpOrGfOrNll = FP + "," + GF + "," + NLL;
    }
}
