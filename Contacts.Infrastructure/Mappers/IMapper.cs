namespace Contacts.Infrastructure.Mappers
{
    public interface IMapper<T1, T2>
    {
        public T1 ToDomainEntity(T2 infrastructureEntity);
        public T2 ToInfrastructureEntity(T1 domainEntity);
    }
}
