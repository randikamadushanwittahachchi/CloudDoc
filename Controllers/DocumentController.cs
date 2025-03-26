using CloudDoc.Exceptions;
using CloudDoc.Services;
using CloudDoc.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CloudDoc.Controllers
{
    public class DocumentController : Controller
    {
        private readonly IDocumentService _documentService;
        public DocumentController(IDocumentService documentService)
        {
            _documentService = documentService;
        }
        [HttpGet("Document")]
        public async Task<IActionResult> Index()
        {
            try
            {
                var documents = await _documentService.GetAll();
                return View(documents);
            }
            catch (DocumentServiceException ex) 
            {
                ViewData["Error"] = ex.Message;
                return View(new List<DocumentViewModel>());
            }catch (Exception ex)
            {
                ViewData["Error"] = "An unexpected error occurred.";
                return View(new List<DocumentViewModel>());
            }
        }

        [HttpGet("Document/Create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost("Document/Create")]
        public async Task<IActionResult> Create(DocumentViewModel documentViewModel)
        {
            try
            {
                await _documentService.Add(documentViewModel);
                return RedirectToAction("Document", "Index");
            }
            catch (DocumentServiceException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(documentViewModel);
            }
            catch (Exception ex) 
            {
                ModelState.AddModelError(string.Empty, "An unexpected error occurred.");
                return View(documentViewModel);
            }
        }
        [HttpGet("Document/${id}")]
        public async Task<ActionResult> Edit(int id) 
        {
            try
            {
                var documentViewModel = await _documentService.GetById(id);
                return View(documentViewModel);
            }catch (DocumentServiceException ex)
            {
                ModelState.AddModelError(string.Empty,ex.Message);
                return View(new DocumentViewModel());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An unexpected error occurred.");
                return View(new DocumentViewModel());
            }

            
        }


    }
}
