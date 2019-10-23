using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Clima.Queries
{
    public class GetClimaByDiaQueryHandler : IRequestHandler<GetClimaByDiaQuery, ClimaDTO>
    {
        //private readonly ICustomerService customerService;
        //public GetCustomerByIdQueryHandler(ICustomerService customerService)
        //{
        //    this.customerService = customerService;
        //}

        public async Task<ClimaDTO> Handle(GetClimaByDiaQuery request, CancellationToken cancellationToken)
        {
            //var customer = await customerService.GetCustomerByNupAsync(request.Nup);
            //if (customer == null) throw new CustomerDomainException($"Cliente con el nup {request.Nup} no encontrado");

            //return CustomerDTO.FromDomain(customer);
            return null;
        }
    }

    public class ClimaDTO
    {
        public ClimaDTO(int dia, string clima)
        {
            this.Dia = dia;
            this.Clima = clima;
        }
        public int Dia { get; set; }
        public string Clima { get; set; }


        //public static CustomerDTO FromDomain(Customer customer)
        //{
        //    return new CustomerDTO(customer.Name, customer.Surname, customer.Nup);
        //}
    }
}
