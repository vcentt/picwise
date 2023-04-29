using Models;

namespace Services.Interface;
public interface IPhotoService {
    public Task<List<Photos>> GetAll();
    public Task<Photos> Add(Photos photo);
    public Task<string> Update(string id,string photo);
    public Task<string> Delete(string id);
}