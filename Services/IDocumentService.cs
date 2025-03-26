using CloudDoc.ViewModels;
using CloudDoc.Models;

namespace CloudDoc.Services
{
    public interface IDocumentService
    {
        Task<List<DocumentViewModel>> GetAll();
        Task<DocumentViewModel> GetById(int id);
        Task<Document> Add(DocumentViewModel documentViewModel);
        Task<DocumentViewModel> Update(DocumentViewModel documentViewModel);
        Task<DocumentViewModel> DeleteById(int id ,DocumentViewModel documentViewModel);
    }
}
