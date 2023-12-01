using InvoiceApp.Domain;
using InvoiceApp.Persistence;

namespace InvoiceApp.Business;

public class InvoiceService : IInvoiceService
{
    private readonly IInvoiceRepository _invoiceRepository;
    private readonly IUnitOfWork _unitOfWork;

    public InvoiceService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _invoiceRepository = _unitOfWork.InvoiceRepository;
    }

    public Invoice CreateInvoice(Invoice invoice)
    {
        _invoiceRepository.Insert(invoice);
        _unitOfWork.Commit();
        return invoice;
    }
}