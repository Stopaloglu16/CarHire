namespace Domain.Entities.UserAuthAggregate
{
    public class ApiUserIdentity
    {
        public int UserId { get; set; }
        public int UserTypeId { get; set; }
        public int CompanyId { get; set; }

        public string AspId { get; set; }
        public string FullName { get; set; }

        public List<string> myRoles { get; set; }
    }
}
