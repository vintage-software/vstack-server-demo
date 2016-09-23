using Vstack.Services.General;

namespace Services.General
{
    public class Permissions : RestPermissions
    {
        private readonly bool isInternal;

        private readonly int? accountId;

        public Permissions(int? accountId)
        {
            this.accountId = accountId;
        }

        private Permissions(bool isInternal)
        {
            this.isInternal = isInternal;
        }

        public static Permissions Empty { get; } = new Permissions(false);

        public static Permissions Internal { get; } = new Permissions(true);

        public int? GetAccountId()
        {
            return this.accountId;
        }

        public override bool IsInternal()
        {
            return this.isInternal;
        }

        public bool HasPermissionsForAccount(int accountId)
        {
            return this.IsInternal() || this.accountId == accountId;
        }
    }
}
