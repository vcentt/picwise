namespace Repository.Interface;
public interface IGenericRepository<T> {
    public Task<List<T>> GetAll();
    public Task Add(T photo);
    public Task Update(string id,string photo);
    public Task Delete(string id);
}