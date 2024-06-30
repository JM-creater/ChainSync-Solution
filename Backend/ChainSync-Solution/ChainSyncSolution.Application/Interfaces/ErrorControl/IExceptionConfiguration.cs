using ChainSyncSolution.Application.Features.AuthenticationFeatures.Commands.Register.CustomerRegister;
using ChainSyncSolution.Application.Features.AuthenticationFeatures.Commands.Register.SupplierRegister;
using ChainSyncSolution.Application.Features.AuthenticationFeatures.Queries.Login;
using ChainSyncSolution.Application.Features.UsersFeatures.Commands.UpdateCustomerProfile;

namespace ChainSyncSolution.Application.Interfaces.ErrorControl;

public interface IExceptionConfiguration
{
    Task CustomerRegisterValidator(RegisterCommand command);
    Task CustomSupplierRegister(SupplierRegisterCommand command);
    Task CustomLoginValidator(LoginQueries queries);
    Task CustomUpdateCustomerProfile(UpdateCustomerProfileCommand command);
}
