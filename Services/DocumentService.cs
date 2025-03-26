using CloudDoc.Data;
using CloudDoc.Exceptions;
using CloudDoc.Models;
using CloudDoc.ViewModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CloudDoc.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly AppDbContext _context;
        public DocumentService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<DocumentViewModel>> GetAll()
        {
            try
            {
                var documents = await _context.Documents.Select(d => new DocumentViewModel
                {
                    Id = d.Id,
                    Title = d.Title,
                    Content = d.Content,
                    UserId = d.UserId

                }).ToListAsync();
                return documents;
            }
            catch (DbUpdateException ex)
            {
                throw new DocumentServiceException("Database error while retrieving documents.", ex);
            }
            catch (InvalidOperationException ex)
            {
                throw new DocumentServiceException("Invalid operation when querying documents.", ex);
            }
            catch (Exception ex) 
            {
                throw new DocumentServiceException("An unexpected error occurred while retrieving documents.",ex);
            }
        }
        public async Task<Document> Add(DocumentViewModel documentViewModel)
        {
            try
            {
                var document = new Document
                {
                    Title = documentViewModel.Title,
                    Content = documentViewModel.Content,
                    UserId = documentViewModel.UserId
                };
                await _context.Documents.AddAsync(document);
                await _context.SaveChangesAsync();
                return document;
            }
            catch (DbUpdateException ex)
            {
                throw new DocumentServiceException("An error occurred while saving the document to the database.", ex);
            }
            catch(InvalidOperationException ex)
            {
                throw new DocumentServiceException("Invalid operation when querying document.",ex);
            }
            catch (Exception ex) 
            {
                throw new DocumentServiceException("An unexpected error occurred while adding the document.",ex);
            }
        }
        public async Task<DocumentViewModel> GetById(int id)
        {
            try
            {
                var model = await _context.Documents.FindAsync(id);
                if (model == null)
                {
                    throw new DocumentServiceException($"Document with Id ${id} Not Found");
                }
                var documentViewModel = new DocumentViewModel
                {
                    Id = model.Id,
                    Title = model.Title,
                    Content = model.Content,
                    UserId = model.UserId
                };
                return documentViewModel;
            }
            catch (DbUpdateException ex) 
            {
                throw new DocumentServiceException("Database error occurred while retrieving the document.",ex);
            }
            catch(InvalidOperationException ex)
            {
                throw new DocumentServiceException("Invalid operation while retrieving the document.",ex);
            }
            catch(Exception ex)
            {
                throw new DocumentServiceException("An unexpected error occurred while retrieving the document.",ex);
            }
        }

        public Task<DocumentViewModel> DeleteById(int id, DocumentViewModel documentViewModel)
        {
            return default!;
        }



        public Task<DocumentViewModel> Update(DocumentViewModel documentViewModel)
        {
            return default!;
        }
    }
}
