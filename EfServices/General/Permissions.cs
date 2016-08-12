using Vstack.Services.General;

namespace Services.General
{
    public class Permissions : RestPermissions
    {
        private readonly bool isInternal;

        private readonly int? superUserId;

        private readonly int? employeeId;

        private readonly int? employerId;

        public Permissions(int? employeeId)
        {
            this.employeeId = employeeId;
        }

        private Permissions(bool isInternal)
        {
            this.isInternal = isInternal;
        }

        public static Permissions Empty { get; } = new Permissions(false);

        public static Permissions Internal { get; } = new Permissions(true);

        public override bool IsInternal()
        {
            return this.isInternal;
        }

        public int? GetSuperUserId()
        {
            return this.superUserId;
        }

        public bool IsSuperUser()
        {
            return this.IsInternal() || this.superUserId.HasValue;
        }

        public bool HasPermissionsForEmployee(int employeeId)
        {
            return this.IsSuperUser() || this.employeeId == employeeId;
        }

        public bool HasPermissionsForEmployer(int employerId)
        {
            return this.IsSuperUser() || this.employerId == employerId;
        }
    }
}
