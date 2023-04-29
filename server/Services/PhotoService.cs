
using Models;
using Repository.Interface;
using Services.Interface;

public class PhotoService : IPhotoService {
    private readonly IGenericRepository<Photos>? _photoRepository;

    public PhotoService(IGenericRepository<Photos> photoRepository) {
        _photoRepository = photoRepository;
    }

    public async Task<List<Photos>> GetAll(){
        return await _photoRepository.GetAll();
    }

    public async Task<Photos> Add(Photos photo) {
        await _photoRepository.Add(photo);
        return photo;
    }

    public async Task<string> Update(string id,string photo) {
        await _photoRepository.Update(id, photo);
        return photo;
    }

    public async Task<string> Delete(string id) {
        await _photoRepository.Delete(id);
        return id;
    }
}