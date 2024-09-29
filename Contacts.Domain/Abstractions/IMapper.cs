namespace Contacts.Domain.Abstractions
{
    public interface IMapper<T1, T2>
    {
        public T2 Map(T1 obj);
        public T1 Map(T2 obj);
    }
}
